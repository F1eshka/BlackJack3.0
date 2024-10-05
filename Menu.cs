using System;

namespace PROJECT.BlackJack
{
    internal class Menu
    {
        private string[] menuOptions = { "Начать игру", "Правила игры", "О разработчике" };
        private int currentSelection = 0; 

        public void DisplayMenu()
        {
            Console.Clear(); 
            Console.Title = "Black Jack Game"; 
            DrawTitle();  
            ShowOptions();
        }

        // Отображение заголовка
        private void DrawTitle()
        {
            string title = "====BLACK JACK====";
            int screenWidth = Console.WindowWidth;
            int titlePosition = (screenWidth / 2) - (title.Length / 2);

            Console.SetCursorPosition(titlePosition, 2);
            Console.WriteLine(title);
        }

        // Отображение пунктов меню
        private void ShowOptions()
        {
            int screenWidth = Console.WindowWidth;

            for (int i = 0; i < menuOptions.Length; i++)
            {
                int optionPosition = (screenWidth / 2) - (menuOptions[i].Length / 2);
                Console.SetCursorPosition(optionPosition, 5 + i * 2);

              
                if (i == currentSelection)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;  
                    Console.ForegroundColor = ConsoleColor.Black; 
                }

                Console.WriteLine(menuOptions[i]);

                Console.ResetColor();
            }

            Console.SetCursorPosition((screenWidth / 2) - 12, 5 + menuOptions.Length * 2);
            Console.WriteLine("Используйте стрелки вверх/вниз и нажмите Enter");
        }

        // Запуск меню
        public void StartMenu()
        {
            while (true)
            {
                DisplayMenu(); 

                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        currentSelection--; 
                        if (currentSelection < 0)
                            currentSelection = menuOptions.Length - 1; 
                        break;
                    case ConsoleKey.DownArrow:
                        currentSelection++; 
                        if (currentSelection >= menuOptions.Length)
                            currentSelection = 0; 
                        break;
                    case ConsoleKey.Enter:
                        Console.Clear();
                        switch (currentSelection)
                        {
                            case 0:
                                Console.WriteLine(new string('=', 30)); 
                                Console.WriteLine("Добро пожаловать в игру BlackJack");
                                Console.WriteLine(new string('=', 30));
                                Game game = new Game();
                                game.Start();
                                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                                break;
                            case 1:
                                ShowRules();
                                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                                break;
                            case 2:
                                ShowAbout();
                                Console.WriteLine("\nНажмите любую клавишу, чтобы вернуться в меню");
                                Console.ReadKey();
                                break;
                        }
                        break;
                }

               
            }
        }

        // Правила игры
        private void ShowRules()
        {
            Console.Clear();
            Console.WriteLine("Правила игры:");
            Console.WriteLine("1. Цель игры — набрать 21 очко или как можно ближе к этой сумме");
            Console.WriteLine("2. Карты валет, дама и король 10 очков. Туз 11 очков. Остальные карты согласно их номиналу");
            Console.WriteLine("3. Игрок играет против дилера");
            Console.WriteLine("4. Если сумма очков превышает 21, игрок или дилер проигрывают");
        }

        //О разработчике
        private void ShowAbout()
        {
            Console.Clear();
            Console.WriteLine("О разработчике:");
            Console.WriteLine("Разработчик: Беноева Малика П26");
        }
    }
}
