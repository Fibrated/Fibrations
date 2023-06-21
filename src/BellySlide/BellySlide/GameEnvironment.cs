using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellySlide
{
    public class GameEnvironment
    {
        private GameState currentState;
        public Player Player { get; set; }
        public List<GameObject> GameObjects { get; set; }

        public const int MaxJumps = 2;
        public const int MaxDashes = 2;


        public GameEnvironment()
        {
            // Initialize the game state and the player and game objects
            this.currentState = new GameState();
            this.Player = new Player();
            this.GameObjects = new List<GameObject>();
        }

        public GameState GetInitialState()
        {
            // Return the initial game state
            return this.currentState;
        }

        public GameState ExecuteAction(int action)
        {
            // Execute the action and update the game state
            // This will depend on the specifics of your game
            // For example, if action == 0, the character might do nothing
            // If action == 1, the character might jump

            // After executing the action, you should update the game state
            // For example, you might move the rocks closer to the character

            // Check if the player has hit the ground or a bar
            // Check if the player has hit the ground or a bar
            if (Player.Location.Y >= GroundLevel)
            {
                // Reset the jumps and dashes
                Player.Jumps = MaxJumps;
                Player.Dashes = MaxDashes;
            }
            else
            {
                foreach (GameObject gameObject in GameObjects)
                {
                    if (gameObject.Type == GameObjectType.Bar && IsColliding(Player, gameObject) && Player.Location.Y < gameObject.Location.Y)
                    {
                        // The player has landed on a bar
                        // Reset the jumps and dashes
                        Player.Jumps = MaxJumps;
                        Player.Dashes = MaxDashes;
                        break;
                    }
                }
            }


            // Then return the new game state
            return this.currentState;
        }

        public double GetReward(GameState state)
        {
            // Calculate the reward for the current game state
            // This will depend on the specifics of your game
            // For example, you might give a reward of +1 for each frame the character survives
            // And a reward of -1000 for colliding with a rock
            return 0; // Placeholder
        }

        private bool IsColliding(Player player, GameObject gameObject)
        {
            // Check for a collision between the player and the game object
            // This will depend on the specifics of your game
            // For example, you might check if the player's location is within a certain distance of the game object's location
            return false; // Placeholder
        }
    }

}
