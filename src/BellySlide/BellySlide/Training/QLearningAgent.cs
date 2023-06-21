using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BellySlide.Training
{
    public class QLearningAgent
    {
        private double[,] qTable;
        private double learningRate;
        private double discountFactor;
        private double explorationRate;
        private Random random;

        public QLearningAgent(int stateSize, int actionSize, double learningRate, double discountFactor, double explorationRate)
        {
            this.qTable = new double[stateSize, actionSize];
            this.learningRate = learningRate;
            this.discountFactor = discountFactor;
            this.explorationRate = explorationRate;
            this.random = new Random();
        }

        public int ChooseAction(int state)
        {
            // Implement the exploration-exploitation trade-off
            if (random.NextDouble() < explorationRate)
            {
                // Exploration: choose a random action
                return random.Next(qTable.GetLength(1));
            }
            else
            {
                // Exploitation: choose the action with the highest Q-value
                int bestAction = 0;
                double bestQValue = double.MinValue;
                for (int action = 0; action < qTable.GetLength(1); action++)
                {
                    if (qTable[state, action] > bestQValue)
                    {
                        bestQValue = qTable[state, action];
                        bestAction = action;
                    }
                }
                return bestAction;
            }
        }

        public void UpdatePolicy(int state, int action, double reward, int nextState)
        {
            // Calculate the maximum Q-value for the next state
            double maxNextQValue = double.MinValue;
            for (int nextAction = 0; nextAction < qTable.GetLength(1); nextAction++)
            {
                if (qTable[nextState, nextAction] > maxNextQValue)
                {
                    maxNextQValue = qTable[nextState, nextAction];
                }
            }

            // Update the Q-value for the current state and action
            qTable[state, action] = (1 - learningRate) * qTable[state, action] + learningRate * (reward + discountFactor * maxNextQValue);
        }
    }

}
