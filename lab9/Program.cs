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
            Console.WriteLine($"Clock1 (конструктор без параметров): {clock1.hours}:{clock1.minutes}");

            DialClock clock2 = new DialClock(15, 30); // Конструктор с параметрами
            Console.WriteLine($"Clock2 (конструктор с параметрами): {clock2.hours}:{clock2.minutes}");

            DialClock clock3 = new DialClock(clock2); // Конструктор копирования
            Console.WriteLine($"Clock3 (конструктор копирования): {clock3.hours}:{clock3.minutes}");

            // 2. Вычисление угла между стрелками
            Console.WriteLine("\n2. Вычисление угла между стрелками:");
            double angle1 = clock2.CalculateAngle();
            Console.WriteLine($"Угол для Clock2: {angle1} градусов");

            double angleStatic = DialClock.CalculateAngleStatic(6, 0);
            Console.WriteLine($"Статический угол для 6:00: {angleStatic} градусов");

            // 3. Унарные операции ++ и --
            Console.WriteLine("\n3. Унарные операции ++ и --:");
            DialClock incrementedClock = ++clock2;
            Console.WriteLine($"Clock2 после ++: {incrementedClock.hours}:{incrementedClock.minutes}");

            DialClock decrementedClock = --clock2;
            Console.WriteLine($"Clock2 после --: {decrementedClock.hours}:{decrementedClock.minutes}");

            // 4. Операции приведения типа
            Console.WriteLine("\n4. Операции приведения типа:");
            bool isAngleDivisible = (bool)clock2; // Явное приведение к bool
            Console.WriteLine($"Явное приведение к bool (угол кратен 2.5): {isAngleDivisible}");

            int totalMinutes = clock2; // Неявное приведение к int
            Console.WriteLine($"Неявное приведение к int (общее количество минут): {totalMinutes}");

            // 5. Бинарные операции + и -
            Console.WriteLine("\n5. Бинарные операции + и -: ");
            DialClock addedClock = clock2 + 45; // Добавление минут
            Console.WriteLine($"Clock2 + 45 минут: {addedClock.hours}:{addedClock.minutes}");

            DialClock minusedClock = clock2 - 30; // Вычитание минут
            Console.WriteLine($"Clock2 - 30 минут: {minusedClock.hours}:{minusedClock.minutes}");

            // 6. Статический счетчик объектов
            Console.WriteLine("\n6. Статический счетчик объектов:");
            int objectCount = DialClock.GetObjectsCount();
            Console.WriteLine($"Количество созданных объектов: {objectCount}");

            // 8. Поиск объекта с максимальным углом
            Console.WriteLine("\n8. Поиск объекта с максимальным углом:");

            Random random = new Random();
            int size = 10;
            DialClockArray clocks = new DialClockArray(size, random);
            DialClock maxAngleClock = null;
            double maxAngle = 0;
            for(int i = 0; i < size; i ++)
            {
                double angle = clocks[i].CalculateAngle();
                if (angle > maxAngle)
                {
                    maxAngle = angle;
                    maxAngleClock = clocks[i];
                }
            }
            Console.WriteLine($"Объект с максимальным углом: {maxAngleClock.hours}:{maxAngleClock.minutes}, угол: {maxAngle}");
            
        }
    }
}