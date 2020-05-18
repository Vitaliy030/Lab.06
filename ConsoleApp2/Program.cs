using System;
using System.IO;

namespace ConsoleApp2
{
    interface IPerson
    {
        int is_number(string input);
        void Add(string surname, string language, int numberOfBooks, string date, string place, int numberOfListeners);
        void Edit(string surname, string language, int numberOfBooks, string date, string place, int numberOfListeners, string[] s0, int n, int count);
        void Remove();
        void Output();
        void Calculate_and_Print(string[] surname, string[] data, int[] numberOfListeners);
    }

    public abstract class Writer : IPerson
    {
        public string Address = "D:\\ІТ\\Програмування\\Програми\\Lab.6\\ConsoleApp2\\Writers.txt";

        public int is_number(string input)
        {
            bool a = true;
            bool a0 = true;
            while (a0)
            {
                while (a)
                {
                    int d = input.Length;
                    foreach (char c in input)
                        if (char.IsNumber(c))
                        {
                            if ((input[0] == '0') && (d != 1))
                            {
                                Console.WriteLine("Ви ввели некоректне значення, введiть нове: ");
                                input = Console.ReadLine();
                                a = true;
                                break;
                            }
                            a = false;
                        }
                        else if ((input[0] == '-') && (d != 1) && (input[1] != '-'))
                            continue;
                        else
                        {
                            Console.WriteLine("Ви ввели некоректне значення, введiть нове: ");
                            input = Console.ReadLine();
                            a = true;
                            break;
                        }
                }

                if (Convert.ToInt32(input) >= 0)
                {
                    a0 = false;
                }
                else
                {
                    Console.WriteLine("Ви ввели некоректне значення, введiть нове: ");
                    input = Console.ReadLine();
                    a = true;
                }
            }
            return Convert.ToInt32(input);
        }

        private string Surname;
        private string Language;
        private int NumberOfBooks;

        public string surname
        {
            get
            {
                return Surname;
            }
            set
            {
                Surname = value;
            }
        }
        public string language
        {
            get
            {
                return Language;
            }
            set
            {
                Language = value;
            }
        }
        public int numberOfBooks
        {
            get
            {
                return NumberOfBooks;
            }
            set
            {
                NumberOfBooks = value;
            }
        }

        public void Add(string surname, string language, int numberOfBooks, string date, string place, int numberOfListeners)
        {
            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter(Address, true))
                        f.WriteLine("{0}\t{1}\t\t{2}\t\t\t{3}\t{4}\t{5}", surname, language, numberOfBooks, date, place, numberOfListeners);
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }

        public void Edit(string surname, string language, int numberOfBooks, string date, string place, int numberOfListeners, string[] s0, int n, int count)
        {
            string s = surname + "\t" + language + "\t\t" + numberOfBooks + "\t\t\t" + date + "\t" + place + "\t" + numberOfListeners;

            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни, то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    s0[n] = s;
                    using (StreamWriter f = new StreamWriter(Address))
                        for (int i = 0; i < count; i++)
                            f.WriteLine(s0[i]);
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }

        public void Remove()
        {
            int count = File.ReadAllLines(Address).Length;
            Console.WriteLine("\nВведiть порядковий новер рядка, який ви хочете видалити: ");
            int n = is_number(Console.ReadLine());
            while (n > count - 1 || n < 1)
            {
                Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                n = is_number(Console.ReadLine());
            }

            string[] s0 = File.ReadAllLines(Address);
            for (int i = n; i < count - 1; i++)
                s0[i] = s0[i + 1];

            Console.WriteLine("\nЯкщо ви бажаєте зберегти змiни то натиснiть Enter, якщо нi, то будь-яку iншу клавiшу.");
            while (true)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    using (StreamWriter f = new StreamWriter(Address))
                        for (int i = 0; i < count - 1; i++)
                            f.WriteLine(s0[i]);
                    Console.WriteLine("Змiни збережено!\n\n");
                    break;
                }
                else
                {
                    Console.WriteLine("\nЗмiни не збережено!\n\n");
                    break;
                }
            }
        }

        public abstract void Output();

        public abstract void Calculate_and_Print(string[] surname, string[] data, int[] numberOfListeners);
    }

    class Speech : Writer
    {
        private string Date;
        private string Place;
        private int NumberOfListeners;

        public string date
        {
            get
            {
                return Date;
            }
            set
            {
                Date = value;
            }
        }
        public string place
        {
            get
            {
                return Place;
            }
            set
            {
                Place = value;
            }
        }
        public int numberOfListeners
        {
            get
            {
                return NumberOfListeners;
            }
            set
            {
                NumberOfListeners = value;
            }
        }

        public Speech() { }

        public override void Output()
        {
            string[] s0 = File.ReadAllLines(Address);
            int count = File.ReadAllLines(Address).Length;

            Console.WriteLine("\nЯкщо ви бажаєте вивести весь список, то натиснiть Enter, якщо тiльки один рядок, то будь-яку iншу клавiшу.\n");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                for (int i = 0; i < count; i++)
                    Console.WriteLine(s0[i]);
            }
            else
            {
                Console.WriteLine("\nВведiть порядковий новер товару, який ви хочете вивести: ");
                int n = is_number(Console.ReadLine());
                while (n > count - 1 || n < 1)
                {
                    Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                    n = is_number(Console.ReadLine());
                }
                string s = s0[n];
                Console.WriteLine("\nSurname:\tLanguage:\tNumber of books:\tDate:\t\tPlace:\t\t\tNumber of listeners:\n" + s);
            }
            Console.WriteLine("\n");
        }

        public override void Calculate_and_Print(string[] surname, string[] data, int[] numberOfListeners)
        {
            int count = File.ReadAllLines(Address).Length;
            int sum = 0;
            int min = numberOfListeners[0];
            int k = 0;

            for (int j = 0; j < count - 1; j++)
            {
                sum += numberOfListeners[j];
                if (numberOfListeners[j] < min)
                {
                    min = numberOfListeners[j];
                    k = j;
                }
            }

            Console.WriteLine("\nСумарна кiлькiсть слухачiв: " + sum);
            Console.WriteLine("День з найменшою кiлькiстю слухачiв: " + data[k] + "\n");
            for (int j = 0; j < count - 1; j++)
                Console.WriteLine("Довжина прiзвища " + surname[j] + " : " + surname[j].Length);
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Speech p = new Speech();

            while (true)
            {
                Console.WriteLine("Натиснiть на одну з вказаних клавiш, щоб вибрати режим роботи: ");
                Console.WriteLine("Додавання записiв - Enter");
                Console.WriteLine("Редагування записiв - E");
                Console.WriteLine("Знищення записiв - R");
                Console.WriteLine("Виведення iнформацiї з файла на екран - O");
                Console.WriteLine("Обчислення та виведення на екран результатiв - S");
                Console.WriteLine("Вихiд з програми - будь-яка iнша клавiша");

                ConsoleKeyInfo cki;
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Speech np = new Speech();
                    Console.WriteLine("\nВведiть прiзвище письменника: ");
                    np.surname = Console.ReadLine();
                    Console.WriteLine("Введiть мову творiв письменника: ");
                    np.language = Console.ReadLine();
                    Console.WriteLine("Введiть кiлькiсть книжок письменника: ");
                    np.numberOfBooks = p.is_number(Console.ReadLine());
                    Console.WriteLine("Введiть дату виступу: ");
                    np.date = Console.ReadLine();
                    Console.WriteLine("Введiть мiсце проведення виступу: ");
                    np.place = Console.ReadLine();
                    Console.WriteLine("Введiть кiлькiсть слухачiв на виступi: ");
                    np.numberOfListeners = p.is_number(Console.ReadLine());

                    p.Add(np.surname, np.language, np.numberOfBooks, np.date, np.place, np.numberOfListeners);
                }
                else if (cki.Key == ConsoleKey.E)
                {
                    Speech ep = new Speech();
                    int count = File.ReadAllLines(p.Address).Length;
                    Console.WriteLine("\nВведiть порядковий новер рядка, де ви хочете здiйснити редагування: ");
                    int n = p.is_number(Console.ReadLine());
                    while (n > count - 1 || n < 1)
                    {
                        Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                        n = p.is_number(Console.ReadLine());
                    }

                    string[] s0 = File.ReadAllLines(p.Address);
                    string s = s0[n];
                    int u = s.Length;

                    int k = 0;
                    foreach (char c in s)
                    {
                        if (Char.IsWhiteSpace(c))
                            break;
                        k++;
                    }
                    ep.surname = s.Substring(0, k);

                    int l = 1;
                    for (int i = k + 1; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            k++;
                        else
                            break;
                    }

                    k++;
                    for (int i = k + 1; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            break;
                        l++;
                    }
                    ep.language = s.Substring(k, l);

                    k += l;
                    l = 1;
                    for (int i = k; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            k++;
                        else
                            break;
                    }

                    for (int i = k; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            break;
                        l++;
                    }
                    ep.numberOfBooks = Convert.ToInt32(s.Substring(k, l));

                    k = k + l - 1;
                    l = 1;
                    for (int i = k; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            k++;
                        else
                            break;
                    }

                    for (int i = k; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            break;
                        l++;
                    }
                    ep.date = s.Substring(k, l - 1);

                    k = k + l - 1;
                    l = 1;
                    for (int i = k; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            k++;
                        else
                            break;
                    }

                    for (int i = k; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            break;
                        l++;
                    }
                    ep.place = s.Substring(k, l - 1);

                    k = k + l - 1;
                    l = 1;
                    for (int i = k; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            k++;
                        else
                            break;
                    }

                    for (int i = k; i < u; i++)
                    {
                        if (Char.IsWhiteSpace(s[i]))
                            break;
                        l++;
                    }
                    ep.numberOfListeners = Convert.ToInt32(s.Substring(k, l - 1));

                    Console.WriteLine("\n{0}\t{1}\t\t{2}\t\t\t{3}\t{4}\t{5}\n", ep.surname, ep.language, ep.numberOfBooks, ep.date, ep.place, ep.numberOfListeners);

                    Console.WriteLine("Введiть порядковий номер стовпчика, елемент якого хочете виправити: ");
                    int n0 = p.is_number(Console.ReadLine());
                    while (n0 > 6 || n0 < 1)
                    {
                        Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                        n0 = p.is_number(Console.ReadLine());
                    }

                    if (n0 == 1)
                    {
                        Console.WriteLine("Прiзвище письменника: ");
                        ep.surname = Console.ReadLine();
                    }
                    else if (n0 == 2)
                    {
                        Console.WriteLine("Мова творів письменника: ");
                        ep.language = Console.ReadLine();
                    }
                    else if (n0 == 3)
                    {
                        Console.WriteLine("Кiлькiсть творiв письменника: ");
                        ep.numberOfBooks = p.is_number(Console.ReadLine());
                    }
                    else if (n0 == 4)
                    {
                        Console.WriteLine("Дата проведення виступу: ");
                        ep.date = Console.ReadLine();
                    }
                    else if (n0 == 5)
                    {
                        Console.WriteLine("Мiсце проведення виступу: ");
                        ep.place = Console.ReadLine();
                    }
                    else if (n0 == 6)
                    {
                        Console.WriteLine("Кiлькiсть слухачiв на виступi: ");
                        ep.numberOfListeners = p.is_number(Console.ReadLine());
                    }

                    while (true)
                    {
                        Console.WriteLine("Якщо ви бажаєте продовжити редагування в даному рядку, то натиснiть на будь-яку клавiшу, якщо нi, то натиснiть Spacebar.");
                        if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                            break;
                        else
                        {
                            Console.WriteLine("\nВведiть порядковий номер стовпчика, елемент якого хочете виправити: ");
                            n0 = p.is_number(Console.ReadLine());
                            while (n0 > 6 || n0 < 1)
                            {
                                Console.WriteLine("Ви ввели некоректний порядковий номер, введiть ще раз: ");
                                n0 = p.is_number(Console.ReadLine());
                            }

                            if (n0 == 1)
                            {
                                Console.WriteLine("Прiзвище письменника: ");
                                ep.surname = Console.ReadLine();
                            }
                            else if (n0 == 2)
                            {
                                Console.WriteLine("Мова творів письменника: ");
                                ep.language = Console.ReadLine();
                            }
                            else if (n0 == 3)
                            {
                                Console.WriteLine("Кiлькiсть творiв письменника: ");
                                ep.numberOfBooks = p.is_number(Console.ReadLine());
                            }
                            else if (n0 == 4)
                            {
                                Console.WriteLine("Дата проведення виступу: ");
                                ep.date = Console.ReadLine();
                            }
                            else if (n0 == 5)
                            {
                                Console.WriteLine("Мiсце проведення виступу: ");
                                ep.place = Console.ReadLine();
                            }
                            else if (n0 == 6)
                            {
                                Console.WriteLine("Кiлькiсть слухачiв на виступi: ");
                                ep.numberOfListeners = p.is_number(Console.ReadLine());
                            }
                        }
                    }

                    p.Edit(ep.surname, ep.language, ep.numberOfBooks, ep.date, ep.place, ep.numberOfListeners, s0, n, count);
                }
                else if (cki.Key == ConsoleKey.R)
                    p.Remove();
                else if (cki.Key == ConsoleKey.O)
                    p.Output();
                else if (cki.Key == ConsoleKey.S)
                {
                    string[] s0 = File.ReadAllLines(p.Address);
                    int count = File.ReadAllLines(p.Address).Length;

                    string[] sr = new string[count - 1];
                    string[] dt = new string[count - 1];
                    int[] nm = new int[count - 1];

                    int u;
                    int k = 0;
                    int l = 1;
                    for (int j = 1; j < count; j++)
                    {
                        string s = s0[j];
                        u = s.Length;

                        foreach (char c in s)
                        {
                            if (Char.IsWhiteSpace(c))
                                break;
                            k++;
                        }
                        sr[j - 1] = s.Substring(0, k);

                        for (int i = k + 1; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                k++;
                            else
                                break;
                        }

                        k++;
                        for (int i = k + 1; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                break;
                            l++;
                        }

                        k += l;
                        l = 1;
                        for (int i = k; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                k++;
                            else
                                break;
                        }

                        for (int i = k; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                break;
                            l++;
                        }

                        k = k + l - 1;
                        l = 1;
                        for (int i = k; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                k++;
                            else
                                break;
                        }

                        for (int i = k; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                break;
                            l++;
                        }
                        dt[j - 1] = s.Substring(k, l - 1);

                        k = k + l - 1;
                        l = 1;
                        for (int i = k; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                k++;
                            else
                                break;
                        }

                        for (int i = k; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                break;
                            l++;
                        }

                        k = k + l - 1;
                        l = 1;
                        for (int i = k; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                k++;
                            else
                                break;
                        }

                        for (int i = k; i < u; i++)
                        {
                            if (Char.IsWhiteSpace(s[i]))
                                break;
                            l++;
                        }
                        nm[j - 1] = Convert.ToInt32(s.Substring(k, l - 1));

                        k = 0;
                        l = 1;
                    }

                    p.Calculate_and_Print(sr, dt, nm);
                }
                else
                    break;
            }
        }
    }
}
