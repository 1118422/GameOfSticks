using System;
using TestingSticks;

namespace ConsoleApplication1
{
    public class AI : ITestSticks
    {
        private Cup[] cups;
        private StickGame game;
        private bool turn;
        public readonly string name;
        private Random rng;

        public AI(StickGame game, string name) : this(true, game, name, new Random()) { }
        public AI(StickGame game, string name, Random rng) : this(true, game, name, rng) { }
        public AI(bool turn, StickGame game, string name) : this(turn, game, name, new Random()) { }

        public AI(bool turn, StickGame game, string name, Random rng)
        {
            this.game = game;
            this.cups = new Cup[game.totalSticks];
            this.rng = rng;
            for (int i = 0; i < cups.Length; i++)
            {
                this.cups[i] = new Cup(game.maxPull, this.rng);
            }
            this.turn = turn;
            this.name = name;
        }
        
        public HumanPlayer makeHumanComplement(string name)
        {
            return new HumanPlayer(!this.turn, this.game, name);
        }

        public bool playTurn()
        {
            return playTurn(this.turn);
        }

        public bool playTurn(bool turn)
        {
            Cup currentCup = cups[game.getSticks() - 1];
            int sticksPulled = currentCup.play(turn);
            if (sticksPulled > game.maxPull || sticksPulled > game.getSticks())
            {
                sticksPulled = game.maxPull;
            }
            bool win = game.playTurn(sticksPulled);

            return win;
        }
        
        public bool playTurnLoud()
        {
            Cup currentCup = cups[game.getSticks() - 1];
            int sticksPulled = currentCup.play(this.turn);
            if (sticksPulled > game.maxPull || sticksPulled > game.getSticks())
            {
                sticksPulled = game.maxPull;
            }
            Console.WriteLine(name + " takes " + sticksPulled);
            bool win = game.playTurn(sticksPulled);

            return win;
        }

        public void GameOver(bool winner)
        {
            for (int i = 0; i < this.cups.Length; i++)
            {
                this.cups[i].train(winner);
            }
        }

        public void print()
        {
            for (int i = 0; i < this.cups.Length; i++)
            {
                this.cups[i].print();
                Console.WriteLine();
            }
        }
        
        public bool didIWin()
        {
            return game.getPlayer() == turn;
        }

        public int GetSticks(int currentSticks)
        {
            Cup currentCup = cups[currentSticks - 1];
            int sticksPulled = currentCup.play(turn);
            if (sticksPulled > game.maxPull || sticksPulled > currentSticks)
            {
                sticksPulled = game.maxPull;
            }

            return sticksPulled;
        }

        public int[] CupContents(int sticksRemaining)
        {
            return cups[sticksRemaining].GetTokens();
        }
    }
}