using System;

namespace ConsoleApplication1
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            StickGame game = new StickGame(20, 3);
            //Cheater playerA = new Cheater(game);
            AI playerA = new AI(game, "SKYNET");
            HumanPlayer playerB = playerA.makeHumanComplement("Player");
            
            //playerA.print();

            // One Thousand Years in the Chamber
            
            Console.WriteLine("Training...");
            for (int games = 0; games < 100; games++)
            {
                game.reset(false);
                while (true)
                {
                    if (playerA.playTurn(true))
                    {
                        break;
                    }

                    if (playerA.playTurn(false))
                    {
                        break;
                    }
                }

                playerA.GameOver(game.getPlayer());
                if (games % 10000 == 0 && games > 0)
                {
                    Console.WriteLine(games);
                }
            }

            //playerA.print();
            

            // Run the Gauntlet
            while (true)
            {
                game.reset(false);
                Console.WriteLine("\n\nNext Game\n");
                while (true)
                {
                    if (playerA.playTurnLoud())
                    {
                        break;
                    }

                    if (playerB.playInput())
                    {
                        break;
                    }
                }
                // Display winner
                if (playerA.didIWin())
                {
                    Console.WriteLine(playerA.name + " Wins!");
                }
                else
                {
                    Console.WriteLine(playerB.name + " Wins!");
                }
                Console.Write("Training...");
                playerA.GameOver(game.getPlayer());
                Console.WriteLine(" Done!");
                Console.ReadLine();
            }
        }
    }
}