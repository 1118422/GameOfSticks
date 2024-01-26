using System;

namespace ConsoleApplication1

/*
 * Stick game
 */

{
    public class StickGame
    {
        // False is player 1, true is player 2
        private int turn;
        public int totalSticks;
        private int sticks;
        // maximum sticks one can pull
        public int maxPull;

        public StickGame(int totalSticks, int maxPull)
        {
            this.totalSticks = totalSticks;
            this.sticks = this.totalSticks;
            this.turn = 0;
            this.maxPull = maxPull;
        }

        // Returns true if you lose
        public bool playTurn(int sticksPulled)
        {
            // Girlboss !!!!!
            turn = turn + 1;
            // Can't slay too hard
            if (sticksPulled > maxPull)
            {
                throw new IndexOutOfRangeException("Pulled more sticks than available");
            } 
            // NO CHEATY
            if (sticksPulled < 1)
            {
                throw new IndexOutOfRangeException("Must take at least one stick");
            }
            sticks -= sticksPulled;
            // :(

            // Funny modification, dont use
            //sticks = (int)(Math.Sqrt(sticks) + sticks / 2.0);
            
            if (sticks > 0)
            {
                return false;
            }

            return true;
        }

        public void reset(bool turn)
        {
            this.turn = turn ? 1 : 0;
            this.sticks = totalSticks;
        }

        // um returns sticks :)
        public int getSticks()
        {
            return sticks;
        }

        // returns the player whos turn it is
        public bool getPlayer()
        {
            return (turn % 2) == 0;
        }
    }
}