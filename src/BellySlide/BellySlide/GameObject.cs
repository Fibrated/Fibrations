using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellySlide
{
    public class GameObject
    {
        public GameObjectType Type { get; set; }
        public Point Location { get; set; }
    }

    public enum GameObjectType
    {
        Rock,
        Bar,
        LavaPit,
        Meteor
    }

}
