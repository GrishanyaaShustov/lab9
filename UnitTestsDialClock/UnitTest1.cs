using lab9;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace DialClockTests
{
    [TestFixture]
    public class DialClockTests
    {

        // 1. Тесты для конструкторов
        [Test]
        public void Constructor_Default_ShouldInitializeToZero()
        {
            var clock = new DialClock();
            
            clock.Hours.Should().Be(0);
            clock.Minutes.Should().Be(0);
        }

        [Test]
        public void Constructor_WithParameters_ShouldInitializeCorrectly()
        {
            var clock = new DialClock(15, 30);
            
            clock.Hours.Should().Be(15);
            clock.Minutes.Should().Be(30);
        }

        [Test]
        public void Constructor_Copy_ShouldCreateDeepCopy()
        {
            var original = new DialClock(15, 30);
            
            var copy = new DialClock(original);
            
            copy.Hours.Should().Be(15);
            copy.Minutes.Should().Be(30);
            copy.Should().NotBeSameAs(original); // Проверка, что это разные объекты
        }

        // 2. Тесты для свойств Hours и Minutes
        [Test]
        public void Hours_SetValidValue_ShouldUpdateHours()
        {
            var clock = new DialClock();
            
            clock.Hours = 10;
            
            clock.Hours.Should().Be(10);
        }

        [Test]
        public void Hours_SetInvalidValue_ShouldThrowException()
        {
            var clock = new DialClock();
            
            Assert.Throws<ArgumentException>(() => clock.Hours = -1);
            Assert.Throws<ArgumentException>(() => clock.Hours = 24);
        }

        [Test]
        public void Minutes_SetValidValue_ShouldUpdateMinutes()
        {
            var clock = new DialClock();
            
            clock.Minutes = 45;
            
            clock.Minutes.Should().Be(45);
        }

        [Test]
        public void Minutes_SetInvalidValue_ShouldThrowException()
        {
            var clock = new DialClock();
            
            Assert.Throws<ArgumentException>(() => clock.Minutes = -1);
            Assert.Throws<ArgumentException>(() => clock.Minutes = 60);
        }

        // 3. Тесты для метода GetAngleBetweenHands
        [Test]
        public void GetAngleBetweenHands_ForTime3_0_ShouldReturn90()
        {
            var clock = new DialClock(3, 0);
            
            double angle = clock.GetAngleBetweenHands();
            
            angle.Should().Be(90);
        }

        [Test]
        public void GetAngleBetweenHands_ForTime6_0_ShouldReturn180()
        {
            var clock = new DialClock(6, 0);
            
            double angle = clock.GetAngleBetweenHands();
            
            angle.Should().Be(180);
        }

        [Test]
        public void GetAngleBetweenHands_StaticMethod_ShouldCalculateCorrectAngle()
        {
            double angle = DialClock.GetAngleBetweenHands(6, 0);
            
            angle.Should().Be(180);
        }

        // 4. Тесты для операторов ++ и --
        [Test]
        public void OperatorIncrement_ShouldIncrementMinutes()
        {
            var clock = new DialClock(11, 59);
            clock++;
            
            clock.Hours.Should().Be(12); // Часы увеличились на 1
            clock.Minutes.Should().Be(0); // Минуты обнулились
        }

        [Test]
        public void OperatorDecrement_ShouldDecrementMinutes()
        {
            var clock = new DialClock(0, 0);
            
            clock--;
            
            clock.Hours.Should().Be(23);
            clock.Minutes.Should().Be(59);
        }

        // 5. Тесты для приведения типов
        [Test]
        public void ExplicitConversionToBool_ShouldReturnTrueIfAngleDivisibleBy2_5()
        {
            var clock = new DialClock(3, 0); // Угол = 90 градусов
            
            bool result = (bool)clock;
            
            result.Should().BeTrue();
        }

        [Test]
        public void ImplicitConversionToInt_ShouldReturnTotalMinutesIn12HourFormat()
        {
            var clock = new DialClock(13, 30); // 13:30 -> 1:30 -> 90 минут
            
            int totalMinutes = clock;
            
            totalMinutes.Should().Be(90);
        }

        // 6. Тесты для бинарных операций + и -
        [Test]
        public void OperatorAdd_LeftSide_ShouldAddMinutesAndHandleOverflow()
        {
            var clock = new DialClock(11, 50);
            
            var result = clock + 20;
            
            result.Hours.Should().Be(0);
            result.Minutes.Should().Be(10);
        }

        [Test]
        public void OperatorAdd_RightSide_ShouldAddMinutesAndHandleOverflow()
        {
            var clock = new DialClock(11, 50);
            
            var result = 20 + clock;
            
            result.Hours.Should().Be(0);
            result.Minutes.Should().Be(10);
        }

        [Test]
        public void OperatorSubtract_LeftSide_ShouldSubtractMinutesAndHandleUnderflow()
        {
            var clock = new DialClock(0, 10);
            
            var result = clock - 20;
            
            result.Hours.Should().Be(11);
            result.Minutes.Should().Be(50);
        }

        [Test]
        public void OperatorSubtract_RightSide_ShouldSubtractMinutesAndHandleUnderflow()
        {
            var clock = new DialClock(0, 10);
            
            var result = 20 - clock;
            
            result.Hours.Should().Be(11);
            result.Minutes.Should().Be(50);
        }
        
        // 1. Тесты для конструкторов
        [Test]
        public void Constructor_Default_ShouldInitializeEmptyArray()
        {
            var array = new DialClockArray(5);
            
            array.GetLength().Should().Be(5);
        }

        [Test]
        public void Constructor_WithRandomValues_ShouldInitializeArrayWithRandomClocks()
        {
            var random = new Random();
            var array = new DialClockArray(5, random);
            
            for (int i = 0; i < array.GetLength(); i++)
            {
                array[i].Should().NotBeNull();
                array[i].Hours.Should().BeInRange(0, 23);
                array[i].Minutes.Should().BeInRange(0, 59);
            }
        }

        [Test]
        public void Constructor_Copy_ShouldCreateDeepCopy2()
        {
            var original = new DialClockArray(5);
            original[0] = new DialClock(15, 30);
            
            var copy = new DialClockArray(original);
            
            copy[0].Should().NotBeSameAs(original[0]); // Проверка глубокого копирования
            copy[0].Hours.Should().Be(15);
            copy[0].Minutes.Should().Be(30);
        }

        // 2. Тесты для индексатора
        [Test]
        public void Indexer_GetAndSet_ShouldWorkCorrectly()
        {
            var array = new DialClockArray(5);
            var clock = new DialClock(10, 20);
            
            array[0] = clock;
            
            array[0].Should().Be(clock);
        }

        [Test]
        public void Indexer_OutOfRange_ShouldThrowException()
        {
            var array = new DialClockArray(5);
            
            Assert.Throws<IndexOutOfRangeException>(() => { var _ = array[10]; });
            
        }

        // 3. Тесты для метода FindMaxAngleClock
        [Test]
        public void FindMaxAngleClock_ShouldReturnClockWithMaximumAngle()
        {
            var array = new DialClockArray(3);
            array[0] = new DialClock(3, 0); // Угол = 90
            array[1] = new DialClock(6, 0); // Угол = 180
            array[2] = new DialClock(0, 0); // Угол = 0
            
            var maxAngleClock = array.FindMaxAngleClock();
            
            maxAngleClock.Should().Be(array[1]);
        }

        [Test]
        public void FindMaxAngleClock_EmptyArray_ShouldReturnNull()
        {
            var array = new DialClockArray(3);
            
            var maxAngleClock = array.FindMaxAngleClock();
            
            maxAngleClock.Should().BeNull();
        }
        
    }
}