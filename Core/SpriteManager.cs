using System.IO;
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
                var fileName = GetSpriteFileName(Pokemon.Species.Number, Back, mega, alolan, Gender, Pokemon.Shiny);

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
            if (mega && name.StartsWith(nameof(PokemonFactory.Charizard)))
            {
                var kind = name[name.Length - 1];

                return GetLink().Replace($"{Pokemon.Species.Number}M", $"{Pokemon.Species.Number}M{kind}");
            }

            switch (name)
            {
                // Gender variants
                case nameof(PokemonFactory.Alakazam):
                case nameof(PokemonFactory.Blaziken):
                case nameof(PokemonFactory.Venusaur):
                case nameof(PokemonFactory.Pikachu):
                case nameof(PokemonFactory.Gyarados):
                case nameof(PokemonFactory.Meganium):
                case nameof(PokemonFactory.Politoed):
                case nameof(PokemonFactory.Steelix):
                case nameof(PokemonFactory.Scizor):
                case nameof(PokemonFactory.Heracross):
                case nameof(PokemonFactory.Houndoom):
                case nameof(PokemonFactory.Toxicroak):
                    return GetLink(Pokemon.Gender);

                default:
                    return GetLink();
            }
        }
    }
}