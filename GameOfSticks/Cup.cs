using System;

namespace ConsoleApplication1
{
    public class Cup
    {
        private int maximumSticks;
        private int[] tokens;
        private bool played;
        private bool player;
        private int playedToken;
        private Random rng;

        public Cup(int maximumSticks, Random rng)
        {
            this.maximumSticks = maximumSticks;
            this.tokens = new int[this.maximumSticks];
            for (int i = 0; i < this.maximumSticks; i++)
            {
                tokens[i] = 1;
            }

            this.played = false;
            this.rng = rng;
        }

        public int play(bool currentPlayer)
        {
            this.played = true;
            this.player = currentPlayer;
            int sumPossibilities = 0;
            for (int i = 0; i < tokens.Length; i++)
            {
                sumPossibilities += tokens[i];
            }

            int choiceIndex = rng.Next(sumPossibilities);

            for (int i = 0; i < tokens.Length; i++)
            {
                choiceIndex -= tokens[i];
                if (choiceIndex < 0)
                {
                    this.playedToken = i + 1;
                    break;
                }
            }

            return this.playedToken;
        }
        
        // Run for every cup after each run
        public void train(bool winner)
        {
            if (!this.played)
            {
                return;
            }
            this.played = false;
            if (winner == this.player)
            {
                this.tokens[this.playedToken - 1]++;
            }
            else
            {
                if (this.tokens[this.playedToken - 1] > 1)
                {
                    this.tokens[this.playedToken - 1]--;
                }
            }
        }

        public void print()
        {
            for (int i = 0; i < tokens.Length; i++)
            {
                Console.Write(this.tokens[i]);
                Console.Write(", ");
            }
        }

        public int[] GetTokens()
        {
            return (int[])tokens.Clone();
        }
    }
}