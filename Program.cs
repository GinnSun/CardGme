using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections.Generic;

namespace Card_Game
{
    class Program
    {
        static void StartGame()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            // фразы персонажей если персонаж выиграл
            string[] phrasesWin = {"Ого!", "Я не на столько слаб!", "Ага! Выиграл!", "Легкая победа", "А Я ЖЕ ГОВОРИЛ!", "НЫА СЮДА!!!"};
            
            // фразы если персонаж проиграл
            string[] phrasesLose = {"Твою **** опять я проиграль! =(", "Я влип!", "Похоже сегодня не мой день...", "ДА КАК ТАК!", "Ты гребанный волшебник!"};
            
            string[] PhrasesTimeGame =  // фразы персонажей во время игры
            { 
                "За императора!!", "Не проиграю РАДИ ГИНТАМЫ!!", "Что? НЕЕТ!",
                "Тебе не совладать со мной! =)", "Я просто подвигами маюсь...",
                "Сейчас мы покажем, на что способны… БЕЖИМ!!!",
                "То ли жизнь хороша, то ли я мазохист", "Хочешь быть полезным? Тогда свари мне кофе", 
                "Это лишь ступеньки, ступеньки на пути становления монсторм..."
            };

            // имена персонажей
            string[] names_characters = {"Сайтама", "Гинтоки", "Бусан", "Император", "Мизуя", "Пустоголовый", "Чертов Гений", "Спайк", "Вэш Ураган", "Джек Блэк"};

            Random random = new Random(); // создаю объект класса Random

            int[] lives_character = // жизни персонажей которые потом станут противниками
            {
                random.Next(10, 100), random.Next(10, 100), random.Next(10, 100),
                random.Next(20, 100), random.Next(20, 100), random.Next(20, 100),
                random.Next(30, 100), random.Next(30, 100), random.Next(30, 100),
                random.Next(40, 100)
            };

            // в уже логике игры создать переменную с дамагом

            int UserLive = random.Next(10,100); // хп игрока

            int enemylive = lives_character[random.Next(0, lives_character.Length - 1)]; // хп противника

            string enemyname = names_characters[random.Next(0, names_characters.Length - 1)]; // имя противника

            LogicGame(phrasesWin, phrasesLose, PhrasesTimeGame, UserLive, enemylive, enemyname); // добавляем параметры функции

            // создаем внгутренюю функцию для удобства
            void LogicGame(string[] phrasesWin, string[] phrasesLose, string[] PhrasesTimeGame, int UserLive, int enemylive, string enemyname)
            {
                
                Console.WriteLine("И так сейчас я тебе расскажу как играть в эту игру");
                Thread.Sleep(1500);
                Console.WriteLine("Тебе нужно взять карты, карты берутся нажатием пробела");
                Thread.Sleep(1500);
                Console.WriteLine("Всего выдаютсяс две карты, взяв карту написав ее число ты можешь ее кинуть и нанести урон своему оппоненту, но знай он может сделать то же самое");
                Thread.Sleep(1500);
                Console.WriteLine("У тебя будет высвеченно твое здоровье и здоровье твоего противника, у кого быстрее кончится здоровье тот и прогирал, собственно у кого отсалось здоровье тот и выиграл");
                Thread.Sleep(1500);
                Console.WriteLine("Забыл сказать за раунд ты можешь взять только один раз карты");

                string[] card_name = {"Лучник","Мечник","Маг","Орг","Балиста","Лекарь","Копейщик","Гароу","Миамото","Луффи"}; // имена карточных персонажей

                int[] card_damage = new int[10]; // урон карт

                int round = 1; // раунды
                Console.WriteLine();
                Console.WriteLine(String.Concat(Enumerable.Repeat("-", 210))); // повторяем конкатенацию - 210 раз
                Console.WriteLine();


                for (int i = enemylive; i > 0;) // создаем цикл это и есть основная логика игры
                {
                    for (int k = 0; k < card_damage.Length; k++) // внутренний цикл для добавление рандомного урона картам
                    {
                        card_damage[k] = random.Next(0,15);
                    }
                    Console.WriteLine("Раунд: " + round);
                    Console.Write("Чтобы взять карты нажмите Space:\t");
                    ConsoleKey consoleKeyForGame = Console.ReadKey().Key; // считываем нажатие на клавишы клавиатуры
                    
                    switch (consoleKeyForGame) // используем свич с значением переменной которая считывает нажатие на клавишы
                    {
                        case ConsoleKey.Spacebar: // создаем условие если пользователь нажал на пробел
                            {
                                Console.Clear();
                                Console.WriteLine("Ваш ход");
                                Console.WriteLine("Ваш противник: " + enemyname + " " + i); // выводим данные противника
                                Console.WriteLine("Ваше здоровье: " + UserLive); // выводим данные пользователя
                                Console.WriteLine("\nВаши карты:");
                                string[] cardNameUser = new string[2]; // создаем массив имен карт пользователя

                                for (int name = 0; name < cardNameUser.Length; name++) // добавляем картам имена через цикл
                                {
                                    cardNameUser[name] = card_name[random.Next(0, card_name.Length - 1)];
                                }

                                int[] cardDamgeUser = new int[2]; // создаем массив для урона карт пользователя

                                for (int damage = 0; damage < cardDamgeUser.Length; damage++) // добавляем картам пользователя урон через цикл
                                {
                                    cardDamgeUser[damage] = card_damage[random.Next(0, card_damage.Length - 1)];
                                }

                                for (int infocard = 0; infocard < 2; infocard++) // выводим инофрмациию о полученных карт пользователя
                                {
                                    Console.WriteLine($"{infocard + 1}. {cardNameUser[infocard]} | Урон {cardDamgeUser[infocard]}"); // ставим нумерацию карт с +1 потому что нумерация в цикле происходит с нуля
                                }
                                Console.WriteLine();
                                string space = string.Concat(Enumerable.Repeat("-", 210)); // делаем интервал для прикольного интерфейса
                                Console.WriteLine(space);
                                Console.WriteLine(space);
                                Console.WriteLine();

                                Console.Write("Выберите карту по немеру чтобы кинуть ее на магический стол: ");
                                try // исользуем try catch для того чтобы программа не вылетела из-за ошибки неправильного ввода числа
                                {
                                    // ход пользователя
                                    int cardNumber = int.Parse(Console.ReadLine()); // просим пользователя ввести число для определения какой картой ходить
                                    if (cardNumber == 1) // проверяем если пользователя выбрал первую карту
                                    {
                                        Console.WriteLine($"{cardNameUser[cardNumber - 1]} | {cardDamgeUser[cardNumber - 1]} ");
                                        Thread.Sleep(1500);
                                        Console.ForegroundColor = ConsoleColor.Red; // меняем цвет текста на крассный
                                        Console.WriteLine("Удар _-/-[] ");
                                        Console.ForegroundColor = ConsoleColor.DarkCyan; // вновб меняем цвет текста на прежний
                                        i -= cardDamgeUser[cardNumber - 1]; // отнимаем от хп противника урон нашей первой карты
                                        Console.WriteLine($"Здоровье противника: " + i);
                                    }
                                    else if (cardNumber == 2) // проверяем если пользователь выбрал вторую карту
                                    {
                                        Console.WriteLine($"{cardNameUser[cardNumber - 1]} | {cardDamgeUser[cardNumber - 1]} ");
                                        Thread.Sleep(1500);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Удар _-/-[] ");
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        i -= cardDamgeUser[cardNumber - 1]; // отнимаем от хп противника урон нашей первой карты
                                        Console.WriteLine($"Здоровье противника: " + i);
                                    }
                                    else // если пользователь написал не то число то и ход его пропускается
                                    {
                                        Console.WriteLine("У вас нет карты под таким номером!!");
                                    }
                                    Thread.Sleep(2000); // ждем 2 секунды
                                    // ход противника
                                    Console.WriteLine();
                                    Console.WriteLine(space);
                                    Console.WriteLine(space);
                                    Console.WriteLine();
                                    Console.WriteLine("Ход противника:");
                                    Thread.Sleep(1500);
                                    Console.WriteLine($"{enemyname}: " + PhrasesTimeGame[random.Next(0, PhrasesTimeGame.Length - 1)]); // выводим имя противника и его игровую фразу
                                    Thread.Sleep(2000);
                                    Console.WriteLine("Противник кидает на магический стол карту");
                                    int enemydamage = card_damage[random.Next(0, card_damage.Length - 1)]; // объявляем переменную урон противник, при помощи урона карт
                                    string cardnameEnemy = card_name[random.Next(0, card_name.Length - 1)]; // имя карты противника припомощи имен карт
                                    Console.WriteLine("Карта противника: " + cardnameEnemy + "| Урон " + enemydamage);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Удар _-/-[] ");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    UserLive -= enemydamage; // собсвтвенно отнимаем от хп пользователя урон карты противника
                                    Console.WriteLine("Ваше здоровье: " + UserLive);
                                    Thread.Sleep(2000);

                                    // ход пользователя
                                    Console.WriteLine();
                                    Console.WriteLine(space);
                                    Console.WriteLine(space);
                                    Console.WriteLine();
                                    Console.WriteLine("Оставшиеся карты: ");
                                    if (cardNumber == 1) // так как мы выбрали одну карту мы выбираем следующую оставшиесю
                                    {
                                        Console.WriteLine($"{2}. {cardNameUser[1]} | Урон {cardDamgeUser[1]}");
                                    }
                                    else if (cardNumber == 2)
                                    {
                                        Console.WriteLine($"{1}. {cardNameUser[0]} | Урон {cardDamgeUser[0]}");
                                    }
                                    Console.WriteLine();
                                    Console.Write("Выберите карту по немеру чтобы кинуть ее на магический стол: ");

                                    cardNumber = int.Parse(Console.ReadLine()); // присим пользователя ввести номер последней оставшиеся карты

                                    if (cardNumber == 1) // проверяемесли пользователь до этого выбрал карту под номером 2 то выводи первую карту
                                    {
                                        Console.WriteLine($"{cardNameUser[cardNumber - 1]} | {cardDamgeUser[cardNumber - 1]} ");
                                        Thread.Sleep(1500);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Удар _-/-[] ");
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        i -= cardDamgeUser[cardNumber - 1]; // отнимаем от хп противника урон нашей второй карты
                                        Console.WriteLine($"Здоровье противника: " + i);
                                    }
                                    else if (cardNumber == 2) // если пользователь до этгго выбрал первую карту то выводим вторую карту
                                    {
                                        Console.WriteLine($"{cardNameUser[cardNumber - 1]} | {cardDamgeUser[cardNumber - 1]} ");
                                        Thread.Sleep(1500);
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Удар _-/-[] ");
                                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                                        i -= cardDamgeUser[cardNumber - 1]; // отнимаем от хп противника урон нашей второй карты
                                        Console.WriteLine($"Здоровье противника: " + i);
                                    }
                                    Thread.Sleep(2000);

                                    // ход противника
                                    Console.WriteLine();
                                    Console.WriteLine(space);
                                    Console.WriteLine(space);
                                    Console.WriteLine();
                                    Console.WriteLine("Ход противника:");
                                    Thread.Sleep(1500);
                                    Console.WriteLine($"{enemyname}: "+PhrasesTimeGame[random.Next(0, PhrasesTimeGame.Length - 1)]); // игровая фраза противника
                                    Thread.Sleep(2000);
                                    Console.WriteLine("Противник кидает на магический стол карту");
                                    enemydamage = card_damage[random.Next(0, card_damage.Length - 1)]; // меняем значение карты противника так как у него как и у нас должно быть две карты
                                    cardnameEnemy = card_name[random.Next(0, card_name.Length - 1)]; // тоеж самое проделываем и с именем карты
                                    // мы поменяли урон карты и имя потоу что у противника было две карты и он своим ходу выбросил одну карту следовательно у него осталась одна карта и он ее выкидывает
                                    Console.WriteLine("Карта противника: " + cardnameEnemy + "| Урон " + enemydamage);
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Thread.Sleep(1500);
                                    Console.WriteLine("Удар _-/-[] ");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    UserLive -= enemydamage; // отнимаем от нашего хмп урон последней краты противника
                                    Console.WriteLine("Ваше здоровье: " + UserLive);
                                    Thread.Sleep(8000);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Вы ввели не правильно номер карты!!!");
                                }

                                break;
                            }
                        default:
                            break;
                    }

                    if (UserLive <= 0) // проверяем условие если хп пользователя уже нету то тогда выводим что он проимграл и заканчиваем игру
                    {
                        Console.Clear();
                        Console.WriteLine("ВЫ ПРОИГРАЛИ!!!");
                        Thread.Sleep(1000);
                        Console.WriteLine($"{enemyname}: " +phrasesWin[random.Next(0, phrasesWin.Length - 1)]);
                        Thread.Sleep(1500);
                        Console.WriteLine("Игра была очень хорошей, но к сажелению вы проиграли =(");
                        break;
                        Thread.Sleep(1500);
                    }

                    Console.Clear();
                }
                
                if (UserLive > 0) // если уикл завершился и хп пользователя осталось больше нуля а у противника нет то тогда мы выводи что пользователь выиграл
                {
                    Console.Clear();
                    Console.WriteLine("Вы выиграли!!!");
                    Console.WriteLine($"{enemyname}: " + phrasesLose[random.Next(0,phrasesLose.Length - 1)]);
                    Console.WriteLine("Вы очень классно свергли своего врага!");
                    Console.WriteLine("Ждем вас в следующей игре!");
                }

                Thread.Sleep(10000);

            }
        }   
        static void Main(string[] args)
        {
            Console.WindowHeight = Console.LargestWindowHeight;
            Console.WindowWidth = Console.LargestWindowWidth;

            Console.ForegroundColor = ConsoleColor.Yellow;

            string tab = string.Concat(Enumerable.Repeat("\t", 12)); // создаю повторение табуляции в 12 повторений

            Console.WriteLine(tab + "\\\\\\\\|||||||||/////"); // конкатенирую табуляцию с символами
            Thread.Sleep(700);
            Console.WriteLine(tab + "////CARD GAME\\\\\\\\\\"); // конкатенирую табуляцию с символами и названием
            Thread.Sleep(700);
            Console.WriteLine(tab + "\\\\\\\\|||||||||/////"); //конкатенирую табуляцию с символами

            Thread.Sleep(1500);

            string enter = string.Concat(Enumerable.Repeat("\n", 2)); // создаю повторение табулации в низ в 2 повторения

            Console.WriteLine(enter + "Приветствую тебя мой друг!"); // конкатенирую табуляцию с приветсвием
            Thread.Sleep(700); // ставлю таймер отключения программы на некторое время
            Console.WriteLine("Это очень забавная консольная карточная игра!");
            Thread.Sleep(700);
            Console.Write("Нажми Enter если хочешь сыграть:\t");
            int count_try = 0; // переменная для попыток игры, или попыток ввода Enter
            while (true)
            {
                if (count_try == 1) // проверяем хочет ли пользователь дальше играть или нет
                {
                    Console.Clear();
                    Console.Write("Хотите ли вы сыграть снова?");
                    Console.Write("Введите <<да>> если хотите: ");
                    string choice = Console.ReadLine();
                    if (choice == "да" || choice == "YES" || choice == "yes" || choice == "ДА")
                    {
                        Thread.Sleep(1500);
                        Console.Clear();
                        Console.WriteLine("Нажми Enter если хочешь сыграть:\t");
                    }
                    else // если же не хочет то тогда заканчиваем игру
                    {
                        Thread.Sleep(1000);
                        break;
                    }
                }
                ConsoleKey consoleKey = Console.ReadKey().Key; // считываю на какую клавишу нажал пользователь

                switch (consoleKey) // создаю switch с значнеием считывания нажатой клавыиши на клавиатуре
                {
                    case ConsoleKey.Enter: // создаю case с условием что пользователей нгажмет на Enter
                        Console.Clear();
                        Thread.Sleep(150);
                        StartGame();
                        count_try++; // инкримент переменной country_try
                        break;
                    default: // дефолтное значение если пользователь не нажал на Enter
                        Console.Clear(); // отчистка консоли
                        Console.WriteLine("Похоже что вы не хотите, если я ошибаюсь нажмите Enter вновь!");
                        count_try++; // инкримент переменной country_try
                        break;
                }

                if (count_try == 4) // условия выхода из игры и в принципе из приложения
                {
                    break;
                }
            }
            Thread.Sleep(2000);
            Console.Clear();
            Thread.Sleep(1000);
            Console.WriteLine("Спасибо за игру!");
            Console.WriteLine("С тобой было приятно играть!");
        }
    }
}