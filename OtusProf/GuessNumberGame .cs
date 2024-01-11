using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtusProf
{
    class GuessNumberGame : IGame
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IGameSettings _gameSettings;

        public GuessNumberGame(IRandomNumberGenerator randomNumberGenerator, IGameSettings gameSettings)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _gameSettings = gameSettings;
        }

        public void Start()
        {
            int targetNumber = _randomNumberGenerator.Generate(_gameSettings.MinValue, _gameSettings.MaxValue);
            int attemptsLeft = _gameSettings.NumberOfAttempts;

            Console.WriteLine("Добро пожаловать в игру \"Угадай число\"!");

            while (attemptsLeft > 0)
            {
                Console.WriteLine($"У вас осталось {attemptsLeft} попыток.");

                Console.Write("Введите число: ");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out int guess))
                {
                    Console.WriteLine("Введите корректное число!");
                    continue;
                }

                if (guess == targetNumber)
                {
                    Console.WriteLine("Поздравляю, вы угадали число!");
                    return;
                }
                else if (guess < targetNumber)
                {
                    Console.WriteLine("Загаданное число больше.");
                }
                else
                {
                    Console.WriteLine("Загаданное число меньше.");
                }

                attemptsLeft--;
            }

            Console.WriteLine("У вас закончились попытки. Вы проиграли!");
            Console.WriteLine("Сгенерированное число = " + targetNumber);
        }
    }
}
