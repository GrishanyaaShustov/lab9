namespace lab9
{
    public static class Printer
    {
        // Метод для печати одного объекта DialClock
        public static void PrintDialClock(DialClock clock, string label = "")
        {
            Console.WriteLine($"{label} {clock.Hours}:{clock.Minutes}");
        }

        // Метод для печати массива объектов DialClock
        public static void PrintDialClockArray(DialClockArray clocks, string label = "")
        {
            Console.WriteLine($"{label} Элементы коллекции:");
            for (int i = 0; i < clocks.GetLength(); i++)
            {
                DialClock clock = clocks[i];
                Console.WriteLine($"[{i}]: {clock.Hours}:{clock.Minutes}");
            }
        }

        // Метод для печати угла между стрелками
        public static void PrintAngle(double angle, string label = "")
        {
            Console.WriteLine($"{label} Угол: {angle} градусов");
        }

        // Метод для печати статистики
        public static void PrintStatistics(int objectsCount, int collectionsCount)
        {
            Console.WriteLine($"Количество созданных объектов: {objectsCount}");
            Console.WriteLine($"Количество созданных коллекций: {collectionsCount}");
        }

        // Метод для печати часов с максимальным углом
        public static void PrintMaxAngleClock(DialClock maxAngleClock)
        {
            Console.WriteLine($"Часы с максимальным углом: {maxAngleClock.Hours}:{maxAngleClock.Minutes}, угол: {maxAngleClock.GetAngleBetweenHands()}");
        }
        
    }
}