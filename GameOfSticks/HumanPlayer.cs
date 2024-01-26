using System;

namespace ConsoleApplication1

/*
 * Interfaces with the console to allow humans to play the stick game
 * To make a pair of players on a game, initialize a game, then a player with the game, then a complement to that player
 */

{
    public class HumanPlayer
    {
        public readonly bool turn;
        private readonly StickGame game;
        public readonly string name;

        public HumanPlayer(StickGame game, string name)
        {
            this.turn = true;
            this.game = game;
            this.name = name;
        }

        public HumanPlayer(bool turn, StickGame game, string name)
        {
            this.turn = turn;
            this.game = game;
            this.name = name;
        }

        public HumanPlayer makeHumanComplement(string name)
        {
            return new HumanPlayer(!this.turn, this.game, name);
        }

        public bool play(int sticksPulled)
        {
            return game.playTurn(sticksPulled);
        }

        public bool playInput()
        {
            if (game.getPlayer() != this.turn)
            {
                throw new AccessViolationException("Wrong turn.");
            }

            int sticksPulled = -1;
            
            while (true)
            {
                try
                {
                    Console.Write(name + "'s turn. " + game.getSticks() + " Sticks remain. Pull 1-" + game.maxPull + " Sticks. Number of sticks to pull: ");
                    sticksPulled = int.Parse(Console.ReadLine());
                    if (sticksPulled > game.maxPull || sticksPulled < 1)
                    {
                        throw new Exception();
                    }
                    break;
                }
                catch
                {
                    Console.WriteLine("Input must be an integer between 1 and " + game.maxPull);
                }
            }

            return play(sticksPulled);
        }

        public bool didIWin()
        {
            return game.getPlayer() == turn;
        }
    }
}