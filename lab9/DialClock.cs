namespace lab9;

public class DialClock
{
    // Закрытые атрибуты
    private int hoursAtribute; // Часы (0-23)
    private int minutesAtribute; // Минуты (0-59)

    // Статическая переменная для подсчёта объектов
    private static int objectsCount = 0;

    // Свойства для доступа к часам и минутам
    public int hours
    {
        get { return hoursAtribute; }
        set
        {
            if (value >= 0 && value <= 23)
                hoursAtribute = value;
            else
                throw new ArgumentException("Hours should be in diapason from 0 to 23");
        }
    }

    public int minutes
    {
        get { return minutesAtribute; }
        set
        {
            if (value >= 0 && value <= 59)
                minutesAtribute = value;
            else
                throw new ArgumentException("Minutes should be in diapason from 0 to 59");
        }
    }

    // Конструктор без параметров
    public DialClock()
    {
        this.hoursAtribute = 0;
        this.minutesAtribute = 0;
        objectsCount++;
    }

    // Конструктор с параметрами
    public DialClock(int hours, int minutes)
    {
        this.hoursAtribute = hours;
        this.minutesAtribute = minutes;
        objectsCount++;
    }

    // Конструктор копирования
    public DialClock(DialClock other)
    {
        this.hoursAtribute = other.hours;
        this.minutesAtribute = other.minutes;
        objectsCount++;
    }

    // Метод для вычисления угла между стрелками (как метод класса)
    public double CalculateAngle()
    {
        double hourAngle = (hours % 12 + minutes / 60.0) * 30; // 30 градусов на час

        double minuteAngle = minutes * 6; // 6 градусов на минуту
        
        double angle = Math.Abs(hourAngle - minuteAngle);

        
        return Math.Min(angle, 360 - angle); // возврат угла от 0 до 180
    }

    // Статический метод для вычисления угла
    public static double CalculateAngleStatic(int hours, int minutes)
    {
        // Проверка корректности входных данных
        if (hours < 0 || hours > 23)
        {
            throw new ArgumentException("Hours should be in diapason from 0 to 23.");
        }
        if (minutes < 0 || minutes > 59)
        {
            throw new ArgumentException("Minutes should be in diapason from 0 to 59.");
        }

        // Вычисление угла между стрелками
        double hourAngle = (hours % 12 + minutes / 60.0) * 30; // Угол часовой стрелки
        double minuteAngle = minutes * 6; // Угол минутной стрелки

        // Разница между углами
        double angle = Math.Abs(hourAngle - minuteAngle);
        
        return Math.Min(angle, 360 - angle); // возврат угла от 0 до 180
    }
    
    // Статический метод для получения количества объектов
    public static int GetObjectsCount()
    {
        return objectsCount;
    }
    
    public static DialClock operator ++(DialClock dc)
    {
        DialClock dcIncremented = new DialClock(dc);
        dcIncremented.minutesAtribute++;
        if (dcIncremented.minutesAtribute == 60)
        {
            dcIncremented.minutesAtribute = 0;
            dcIncremented.hoursAtribute++;
            if (dcIncremented.hoursAtribute == 24)
                dcIncremented.hoursAtribute = 0;
        }
        return dcIncremented;
    }
    
    public static DialClock operator --(DialClock dc)
    {
        DialClock dcDecremented = new DialClock(dc);
        dcDecremented.minutesAtribute--;
        if (dcDecremented.minutesAtribute == -1)
        {
            dcDecremented.minutesAtribute = 59;
            dcDecremented.hoursAtribute--;
            if (dcDecremented.hoursAtribute == -1)
                dcDecremented.hoursAtribute = 23;
        }
        return dcDecremented;
    }
    
    public static explicit operator bool(DialClock dc)
    {
        double angle = dc.CalculateAngle();
        return angle % 2.5 == 0;
    }
    
    public static implicit operator int(DialClock dc)
    {
        int totalMinutes = dc.hours * 60 + dc.minutes;
        return totalMinutes;
    }
    
    // Бинарные операции
    public static DialClock operator +(DialClock dc, int minutesToAdd)
    {
        int totalMinutes = dc.hours * 60 + dc.minutes + minutesToAdd;
        totalMinutes = (totalMinutes % 1440 + 1440) % 1440; // Обработка переполнения
        return new DialClock(totalMinutes / 60, totalMinutes % 60);
    }

    public static DialClock operator -(DialClock dc, int minutesToMinus)
    {
        int totalMinutes = dc.hours * 60 + dc.minutes - minutesToMinus;
        totalMinutes = (totalMinutes % 1440 + 1440) % 1440; // Обработка переполнения
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