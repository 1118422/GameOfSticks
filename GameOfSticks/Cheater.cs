using System;

namespace ConsoleApplication1
{
    public class Cheater
    {
        private StickGame game;
        private bool turn;
        
        public Cheater(StickGame game)
        {
            this.game = game;
            this.turn = true;
        }
        
        public HumanPlayer makeHumanComplement(string name)
        {
            return new HumanPlayer(!this.turn, this.game, name);
        }

        public AI makeAIComplement(string name)
        {
            return new AI(!this.turn, this.game, name);
        }

        public bool playTurn()
        {
            return playTurn(this.turn);
        }

        public bool playTurnLoud()
        {
            return playTurnLoud(this.turn);
        }

        public bool playTurnLoud(bool turn)
        {
            int sticksPulled = (game.getSticks() - 1) % (game.maxPull + 1);
            if (sticksPulled > game.maxPull || sticksPulled > game.getSticks())
            {
                sticksPulled = game.maxPull;
            }
            if (sticksPulled < 1)
            {
                sticksPulled = 1;
            }
            Console.WriteLine("Cheater takes " + sticksPulled);
            bool win = game.playTurn(sticksPulled);

            return win;
        }

        public bool playTurn(bool turn)
        {
            int sticksPulled = (game.getSticks() - 1) % (game.maxPull + 1);
            if (sticksPulled > game.maxPull || sticksPulled > game.getSticks())
            {
                sticksPulled = game.maxPull;
            }

            if (sticksPulled < 1)
            {
                sticksPulled = 1;
            }
            bool win = game.playTurn(sticksPulled);

            return win;
        }
        
        public bool didIWin()
        {
            return game.getPlayer() == turn;
        }
    }
}