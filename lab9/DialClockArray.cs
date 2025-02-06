namespace lab9;

public class DialClockArray
{
    // Поле - массив объектов DialClock
    private DialClock[] arr;
    private static int collectionsCount = 0; // Счетчик коллекций
    
    // Конструктор без параметров
    public DialClockArray(int size = 10)
    {
        arr = new DialClock[size];
        collectionsCount++;
    }
    
    // Конструктор с параметрами (заполнение случайными значениями)
    public DialClockArray(int size, Random random)
    {
        arr = new DialClock[size];
        for (int i = 0; i < size; i++)
        {
            int hours = random.Next(0, 24);
            int minutes = random.Next(0, 60);
            arr[i] = new DialClock(hours, minutes);
        }
        collectionsCount++;
    }
    
    // Конструктор копирования (глубокое копирование)
    public DialClockArray(DialClockArray other)
    {
        arr = new DialClock[other.arr.Length];
        for (int i = 0; i < other.arr.Length; i++)
        {
            arr[i] = new DialClock(other.arr[i].hours, other.arr[i].minutes);
        }
        collectionsCount++;
    }
    
    // Метод для просмотра элементов массива
    public void Print()
    {
        Console.WriteLine("Элементы коллекции:");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.WriteLine($"[{i}]: {arr[i].hours}:{arr[i].minutes}");
        }
    }
    
    // Индексатор
    public DialClock this[int index]
    {
        get
        {
            if (index < 0 || index >= arr.Length)
                throw new IndexOutOfRangeException("Index out of array");
            return arr[index];
        }
        set
        {
            if (index < 0 || index >= arr.Length)
                throw new IndexOutOfRangeException("Index out of array");
            arr[index] = value;
        }
    }
    
    public static int GetCollectionsCount()
    {
        return collectionsCount;
    }
    
    // Метод для нахождения объекта с максимальным углом между стрелками
    public DialClock FindMaxAngleClock()
    {
        DialClock maxAngleClock = null;
        double maxAngle = 0;

        foreach (DialClock clock in arr)
        {
            if (clock != null)
            {
                double angle = clock.CalculateAngle();
                if (angle > maxAngle)
                {
                    maxAngle = angle;
                    maxAngleClock = clock;
                }
            }
        }
        return maxAngleClock;
    }
}