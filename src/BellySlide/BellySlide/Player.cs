using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellySlide
{
    public class Player
    {
        public Point Location { get; set; }
        public int RemainingLives { get; set; }
        public int Score { get; set; }
        public PlayerAction CurrentAction { get; set; }
        public int Jumps { get; set; }
        public int Dashes { get; set; }
    }

    public enum PlayerAction
    {
        None,
        Jumping,
        Dashing
    }


}
