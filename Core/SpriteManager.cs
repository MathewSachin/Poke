﻿using System.IO;
using System.Net;
using CsQuery;

namespace Poke
{
    public static class SpriteManager
    {
        static SpriteManager()
        {
            LocalPrefix = Path.Combine(Path.GetTempPath(), "pkimg");

            if (!Directory.Exists(LocalPrefix))
                Directory.CreateDirectory(LocalPrefix);
        }
        
        static string GetSpriteFileName(int Number, bool Back, bool Mega, bool Alolan, Gender Gender, bool Shiny)
        {
            var b = Back ? "b_" : "";

            var m = Mega ? "M" : "";

            var a = Alolan ? "A" : "";

            var gender = "";

            if (!Mega && !Alolan)
            {
                switch (Gender)
                {
                    case Gender.Male:
                        gender += "_m";
                        break;

                    case Gender.Female:
                        gender += "_f";
                        break;
                }
            }

            var s = Shiny ? "_s" : "";

            return $"Spr_{b}7s_{Number:D3}{m}{a}{gender}{s}.png";
        }

        const string BulbapediaPrefix = "https://bulbapedia.bulbagarden.net/wiki/File:";
        static readonly string LocalPrefix;

        public static string GetSpriteLink(Pokemon Pokemon, bool Back = false)
        {
            var name = Pokemon.Species.Name;
            var num = Pokemon.Species.Number;

            var mega = false;
            var alolan = false;

            if (name.StartsWith("Mega "))
            {
                mega = true;
                name = name.Substring(5);
            }
            else if (name.StartsWith("Alolan "))
            {
                alolan = true;
                name = name.Substring(7);
            }

            string GetLink(Gender Gender = Gender.Genderless)
            {
                var fileName = GetSpriteFileName(num, Back, mega, alolan, Gender, Pokemon.Shiny);

                var localPath = Path.Combine(LocalPrefix, fileName);

                if (File.Exists(localPath))
                    return localPath;
                
                using (var w = new WebClient())
                {
                    var content = w.DownloadString(BulbapediaPrefix + fileName);

                    var imgLink = "https:" + CQ.Create(content)[".fullImageLink a"].Attr("href");

                    w.DownloadFile(imgLink, localPath);
                }

                return localPath;
            }

            // Mega Charizard
            if (mega && num == PokemonSpecies.Charizard.Number)
            {
                var kind = name[name.Length - 1];

                return GetLink().Replace($"{num}M", $"{num}M{kind}");
            }

            // Midnight Lycanroc
            if (Pokemon.Species == PokemonSpecies.LycanrocMidnight)
            {
                return GetLink().Replace(num.ToString(), $"{num}Mn");
            }

            switch (name)
            {
                // Gender variants
                case nameof(PokemonFactory.Alakazam):
                case nameof(PokemonFactory.Blaziken):
                case nameof(PokemonFactory.Gyarados):
                case nameof(PokemonFactory.Heracross):
                case nameof(PokemonFactory.Houndoom):
                case nameof(PokemonFactory.Meganium):
                case nameof(PokemonFactory.Milotic):
                case nameof(PokemonFactory.Pikachu):
                case nameof(PokemonFactory.Politoed):
                case nameof(PokemonFactory.Scizor):
                case nameof(PokemonFactory.Steelix):
                case nameof(PokemonFactory.Toxicroak):
                case nameof(PokemonFactory.Venusaur):
                    return GetLink(Pokemon.Gender);

                default:
                    return GetLink();
            }
        }
    }
}