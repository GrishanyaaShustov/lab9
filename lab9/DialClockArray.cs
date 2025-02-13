namespace lab9
{
    public class DialClockArray
    {
        // Поле - массив объектов DialClock
        private DialClock[] _arr;
        private static int _collectionsCount = 0; // Счетчик коллекций

        // Конструктор без параметров
        public DialClockArray(int size = 10)
        {
            _arr = new DialClock[size];
            _collectionsCount++;
        }

        // Конструктор с параметрами (заполнение случайными значениями)
        public DialClockArray(int size, Random random)
        {
            _arr = new DialClock[size];
            for (int i = 0; i < size; i++)
            {
                int hours = random.Next(0, 24);
                int minutes = random.Next(0, 60);
                _arr[i] = new DialClock(hours, minutes);
            }
            _collectionsCount++;
        }

        // Конструктор копирования (глубокое копирование)
        public DialClockArray(DialClockArray other)
        {
            _arr = new DialClock[other._arr.Length];
            for (int i = 0; i < other._arr.Length; i++)
            {
                if (other._arr[i] != null)
                {
                    _arr[i] = new DialClock(other._arr[i]); // Используем конструктор копирования
                }
            }
            _collectionsCount++;
        }

        // Индексатор
        public DialClock this[int index]
        {
            get
            {
                if (index < 0 || index >= _arr.Length)
                    throw new IndexOutOfRangeException("Index out of array.");
                return _arr[index];
            }
            set
            {
                if (index < 0 || index >= _arr.Length)
                    throw new IndexOutOfRangeException("Index out of array.");
                _arr[index] = value;
            }
        }

        // Статический метод для получения количества коллекций
        public static int GetCollectionsCount()
        {
            return _collectionsCount;
        }

        // Метод для нахождения объекта с максимальным углом между стрелками
        public DialClock FindMaxAngleClock()
        {
            DialClock maxAngleClock = null;
            double maxAngle = 0;

            foreach (var clock in _arr)
            {
                if (clock != null)
                {
                    double angle = clock.GetAngleBetweenHands();
                    if (angle > maxAngle)
                    {
                        maxAngle = angle;
                        maxAngleClock = clock;
                    }
                }
            }
            return maxAngleClock;
        }
        
        public int GetLength()
        {
            return _arr.Length;
        }
    }
}