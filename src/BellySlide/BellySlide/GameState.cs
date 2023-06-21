using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellySlide
{
    public class GameState
    {
        public double DistanceToNearestRock { get; set; }
        public double SpeedOfNearestRock { get; set; }
        public double HeightOfNearestRock { get; set; }
        public double DistanceToNearestBar { get; set; }
        public double PositionOfNearestBar { get; set; } // 0 for low, 1 for high
        public double DistanceToNearestLavaPit { get; set; }
        public double LengthOfNearestLavaPit { get; set; } // 0 for short, 1 for long
        public double DistanceToNearestMeteor { get; set; }
        public double SpeedOfNearestMeteor { get; set; }
        public double CharacterPosition { get; set; }
        public double CharacterVelocity { get; set; }
        public int RemainingJumps { get; set; } // 0, 1, or 2
        public int RemainingDashes { get; set; } // 0, 1, or 2

        public GameState()
        {
            // Initialize the game state
            this.DistanceToNearestRock = 0;
            this.SpeedOfNearestRock = 0;
            this.HeightOfNearestRock = 0;
            this.DistanceToNearestBar = 0;
            this.PositionOfNearestBar = 0;
            this.DistanceToNearestLavaPit = 0;
            this.LengthOfNearestLavaPit = 0;
            this.DistanceToNearestMeteor = 0;
            this.SpeedOfNearestMeteor = 0;
            this.CharacterPosition = 0;
            this.CharacterVelocity = 0;
            this.RemainingJumps = 2;
            this.RemainingDashes = 2;
        }
    }


}
