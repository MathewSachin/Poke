using System.IO;
using System.Net;
using CsQuery;

namespace Poke
{
    public static class SpriteManager
    {
        public static Stream GetStream(string Link)
        {
            const int bytesToRead = 100;

            var request = WebRequest.Create(Link);
            request.Timeout = -1;
            
            var reader = new BinaryReader(request.GetResponse().GetResponseStream());
            var memoryStream = new MemoryStream();

            var bytebuffer = new byte[bytesToRead];
            var bytesRead = reader.Read(bytebuffer, 0, bytesToRead);

            while (bytesRead > 0)
            {
                memoryStream.Write(bytebuffer, 0, bytesRead);
                bytesRead = reader.Read(bytebuffer, 0, bytesToRead);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }

        static string MakeSpriteLink(int Number, bool Back, bool Mega, bool Alolan, Gender Gender, bool Shiny)
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

            return $"https://bulbapedia.bulbagarden.net/wiki/File:Spr_{b}7s_{Number:D3}{m}{a}{gender}{s}.png";
        }

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
                var link = MakeSpriteLink(Pokemon.Species.Number, Back, mega, alolan, Gender, Pokemon.Shiny);

                var request = WebRequest.Create(link);
                request.Timeout = -1;

                var stream = request.GetResponse().GetResponseStream();

                return "https:" + CQ.Create(stream)[".fullImageLink a"].Attr("href");
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