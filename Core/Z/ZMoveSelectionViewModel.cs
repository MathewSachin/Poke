using System.Linq;

namespace Poke
{
    public class ZMoveSelectionViewModel : NotifyPropertyChanged
    {
        public ZMoveSelectionViewModel(Pokemon Pokemon)
        {
            var zCrystal = Pokemon.HeldItem as ZCrystal;
            
            Type = zCrystal.Type;

            Available = new[]
            {
                zCrystal.Supports(Pokemon, Pokemon.Moves[0]),
                zCrystal.Supports(Pokemon, Pokemon.Moves[1]),
                zCrystal.Supports(Pokemon, Pokemon.Moves[2]),
                zCrystal.Supports(Pokemon, Pokemon.Moves[3])
            };

            Contents = Available.Select(M => M ? zCrystal.MoveName : "").ToArray();
        }
        
        public Types Type { get; }

        public string[] Contents { get; }
        
        public bool[] Available { get; }
    }
}