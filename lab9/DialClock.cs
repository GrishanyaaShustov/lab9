namespace lab9
{
    public class DialClock
    {
        // Закрытые атрибуты
        private int _hours; // Часы (0-23)
        private int _minutes; // Минуты (0-59)

        // Статическая переменная для подсчёта объектов
        private static int _objectsCount = 0;

        // Свойства для доступа к часам и минутам
        public int Hours
        {
            get { return _hours; }
            set
            {
                if (value >= 0 && value <= 23)
                    _hours = value;
                else
                    throw new ArgumentException("Hours should be in range from 0 to 23.");
            }
        }

        public int Minutes
        {
            get { return _minutes; }
            set
            {
                if (value >= 0 && value <= 59)
                    _minutes = value;
                else
                    throw new ArgumentException("Minutes should be in range from 0 to 59.");
            }
        }

        // Конструктор без параметров
        public DialClock()
        {
            Hours = 0;
            Minutes = 0;
            _objectsCount++;
        }

        // Конструктор с параметрами
        public DialClock(int hours, int minutes)
        {
            Hours = hours;
            Minutes = minutes;
            _objectsCount++;
        }

        // Конструктор копирования
        public DialClock(DialClock other)
        {
            Hours = other.Hours;
            Minutes = other.Minutes;
            _objectsCount++;
        }

        // Метод для вычисления угла между стрелками
        public double GetAngleBetweenHands()
        {
            double hourAngle = ((_hours % 12) + (_minutes / 60.0)) * 30; // Угол часовой стрелки
            double minuteAngle = _minutes * 6; // Угол минутной стрелки
            double angle = Math.Abs(hourAngle - minuteAngle);
            return Math.Min(angle, 360 - angle); // Возврат угла от 0 до 180
        }

        // Статический метод для вычисления угла
        public static double GetAngleBetweenHands(int hours, int minutes)
        {
            if (hours < 0 || hours > 23)
                throw new ArgumentException("Hours should be in range from 0 to 23.");
            if (minutes < 0 || minutes > 59)
                throw new ArgumentException("Minutes should be in range from 0 to 59.");

            double hourAngle = ((hours % 12) + (minutes / 60.0)) * 30;
            double minuteAngle = minutes * 6;
            double angle = Math.Abs(hourAngle - minuteAngle);
            return Math.Min(angle, 360 - angle);
        }

        // Статический метод для получения количества объектов
        public static int GetObjectsCount()
        {
            return _objectsCount;
        }

        // Оператор ++
        public static DialClock operator ++(DialClock dc)
        {
            // Создаем копию объекта
            DialClock incremented = new DialClock(dc);

            // Увеличиваем минуты
            if (incremented.Minutes == 59) // Если минуты равны 59, переходим к следующему часу
            {
                incremented.Minutes = 0; // Обнуляем минуты
                if (incremented.Hours == 23) // Если часы равны 23, переходим к полночи (0 часов)
                {
                    incremented.Hours = 0;
                }
                else
                {
                    incremented.Hours++; // Увеличиваем часы на 1
                }
            }
            else
            {
                incremented.Minutes++; // Просто увеличиваем минуты
            }

            return incremented;
        }

        // Оператор --
        public static DialClock operator --(DialClock dc)
        {
            // Создаем копию объекта
            DialClock decremented = new DialClock(dc);

            // Уменьшаем минуты
            if (decremented.Minutes == 0) // Если минуты равны 0, нужно перейти к предыдущему часу
            {
                decremented.Minutes = 59; // Устанавливаем минуты в 59
                if (decremented.Hours == 0) // Если часы равны 0, переходим к последнему часу (23)
                {
                    decremented.Hours = 23;
                }
                else
                {
                    decremented.Hours--; // Уменьшаем часы на 1
                }
            }
            else
            {
                decremented.Minutes--; // Просто уменьшаем минуты
            }
            return decremented;
        }

        // Явное приведение к bool
        public static explicit operator bool(DialClock dc)
        {
            double angle = dc.GetAngleBetweenHands();
            return angle % 2.5 == 0;
        }

        // Неявное приведение к int
        public static implicit operator int(DialClock dc)
        {
            return (dc.Hours % 12) * 60 + dc.Minutes;
        }

        // Бинарные операции
        public static DialClock operator +(DialClock dc, int minutesToAdd)
        {
            int totalMinutes = (dc.Hours % 12) * 60 + dc.Minutes + minutesToAdd;
            totalMinutes = (totalMinutes + 720) % 720; // Обработка переполнения
            return new DialClock(totalMinutes / 60, totalMinutes % 60);
        }

        public static DialClock operator -(DialClock dc, int minutesToMinus)
        {
            int totalMinutes = (dc.Hours % 12) * 60 + dc.Minutes - minutesToMinus;
            totalMinutes = (totalMinutes + 720) % 720; // Обработка переполнения
            return new DialClock(totalMinutes / 60, totalMinutes % 60);
        }

        public static DialClock operator +(int minutesToAdd, DialClock dc)
        {
            return dc + minutesToAdd;
        }

        public static DialClock operator -(int minutesToMinus, DialClock dc)
        {
            return dc - minutesToMinus;
        }
    }
}