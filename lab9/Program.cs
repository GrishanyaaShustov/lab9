namespace lab9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрационная программа для класса DialClock");

            // 1. Создание объектов с помощью конструкторов
            Console.WriteLine("\n1. Создание объектов:");
            DialClock clock1 = new DialClock(); // Конструктор без параметров
            Printer.PrintDialClock(clock1, "Clock1 (конструктор без параметров): ");

            DialClock clock2 = new DialClock(11, 59); // Конструктор с параметрами
            Printer.PrintDialClock(clock2, "Clock2 (конструктор с параметрами): ");

            DialClock clock3 = new DialClock(clock2); // Конструктор копирования
            Printer.PrintDialClock(clock3, "Clock3 (конструктор копирования): ");

            // 2. Вычисление угла между стрелками
            Console.WriteLine("\n2. Вычисление угла между стрелками:");
            double angle1 = clock2.GetAngleBetweenHands();
            double staticAngle = DialClock.GetAngleBetweenHands(11, 54);
            Printer.PrintAngle(angle1, "Угол для Clock2: ");
            
            Printer.PrintAngle(staticAngle, "Статический -");

            // 3. Унарные операции ++ и --
            Console.WriteLine("\n3. Унарные операции ++ и --:");
            DialClock incrementedClock = ++clock2;
            Printer.PrintDialClock(incrementedClock, "Clock2 после ++: ");

            DialClock decrementedClock = --clock2;
            Printer.PrintDialClock(decrementedClock, "Clock2 после --: ");

            // 4. Операции приведения типа
            Console.WriteLine("\n4. Операции приведения типа:");
            bool isAngleDivisible = (bool)clock2; // Явное приведение к bool
            Console.WriteLine($"Явное приведение к bool (угол кратен 2.5): {isAngleDivisible}");

            int totalMinutes = clock2; // Неявное приведение к int
            Console.WriteLine($"Неявное приведение к int (общее количество минут): {totalMinutes}");

            // 5. Бинарные операции + и -
            Console.WriteLine("\n5. Бинарные операции + и -: ");
            DialClock addedClock = clock2 + 45; // Добавление минут
            Printer.PrintDialClock(addedClock, "Clock2 + 45 минут: ");
            
            DialClock addedClock2 = 45 + clock2; // Добавление минут
            Printer.PrintDialClock(addedClock2, "45 минут + clock2: ");

            DialClock minusedClock = clock2 - 30; // Вычитание минут
            Printer.PrintDialClock(minusedClock, "Clock2 - 30 минут: ");
            
            DialClock minusedClock2 = clock2 - 30; // Вычитание минут
            Printer.PrintDialClock(minusedClock2, "30 минут - clock2: ");

            // 7. Создание массива разными способами
            Console.WriteLine("\n7. Создание массива разными способами:");
            Random random = new Random();
            int size = 4;

            // Массив с случайными значениями
            DialClockArray randomClocks = new DialClockArray(size, random);
            Console.WriteLine("\nМассив с случайными значениями:");
            Printer.PrintDialClockArray(randomClocks);
            
            DialClockArray manualClocks = new DialClockArray(size);
            Console.WriteLine("\nВведите значения для массива (часы и минуты):");
            for (int i = 0; i < size; i++)
            {
                Console.Write($"Введите часы для элемента [{i}]: ");
                int hours = int.Parse(Console.ReadLine());
                Console.Write($"Введите минуты для элемента [{i}]: ");
                int minutes = int.Parse(Console.ReadLine());
                manualClocks[i] = new DialClock(hours, minutes);
            }
            Console.WriteLine("\nМассив с ручным вводом:");
            Printer.PrintDialClockArray(manualClocks);

            // 8. Глубокое копирование
            Console.WriteLine("\n8. Глубокое копирование:");
            DialClockArray copiedClocks = new DialClockArray(randomClocks);
            Console.WriteLine("Скопированный массив:");
            Printer.PrintDialClockArray(copiedClocks);

            // 9. Поиск объекта с максимальным углом
            Console.WriteLine("\n9. Поиск объекта с максимальным углом:");
            DialClock maxAngleClock = randomClocks.FindMaxAngleClock();
            Printer.PrintMaxAngleClock(maxAngleClock);
            
            // 6. Статический счетчик объектов
            Console.WriteLine("\n6. Статический счетчик объектов:");
            int objectCount = DialClock.GetObjectsCount();
            int collectionCount = DialClockArray.GetCollectionsCount();
            Printer.PrintStatistics(objectCount, collectionCount);
        }
    }
}