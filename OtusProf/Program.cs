using System;

namespace OtusProf
{
    class Program
    {
        static void Main(string[] args)
        {
            IRandomNumberGenerator randomNumberGenerator = new RandomNumberGenerator();
            IGameSettings gameSettings = new GameSettings
            {
                NumberOfAttempts = 5,
                MinValue = 1,
                MaxValue = 100
            };

            IGame game = new GuessNumberGame(randomNumberGenerator, gameSettings);
            game.Start();

            Console.WriteLine("Нажмите любую клавишу, чтобы выйти...");
            Console.ReadKey();
        }
    }
    }
