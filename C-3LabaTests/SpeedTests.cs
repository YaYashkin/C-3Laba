using Microsoft.VisualStudio.TestTools.UnitTesting;
using C_3Laba;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3Laba.Tests
{
    [TestClass()]
    public class SpeedTests
    {
        [TestMethod()]
        public void VerboseTest()
        {
            //Тест вывода чисел с их типом
            var speed = new Speed(10, MeasureType.mc);
            Assert.AreEqual("10 м/с", speed.Verbose());

            speed = new Speed(10, MeasureType.km);
            Assert.AreEqual("10 км/ч", speed.Verbose());

            speed = new Speed(10, MeasureType.yz);
            Assert.AreEqual("10 узел", speed.Verbose());

            speed = new Speed(10, MeasureType.max);
            Assert.AreEqual("10 мах", speed.Verbose());
        }

        [TestMethod()]
        public void AddNumberTest()
        {
            //тест сложения двух чисел
            var speed = new Speed(10, MeasureType.mc);
            speed = speed + 4.5;
            Assert.AreEqual("14,5 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void AddNumberTest1()
        {
            //тест умножения двух чисел
            var speed = new Speed(9, MeasureType.mc);
            speed = speed * 4;
            Assert.AreEqual("36 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void AddNumberTest2()
        {
            //тест вычитания двух чисел
            var speed = new Speed(100, MeasureType.mc);
            speed = speed - 96;
            Assert.AreEqual("4 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void AddNumberTest3()
        {
            //тест деления двух чисел
            var speed = new Speed(36, MeasureType.mc);
            speed = speed / 9;
            Assert.AreEqual("4 м/с", speed.Verbose());
        }

        [TestMethod()]
        public void MeterToAnyTest()
        {
            //тесты перевода числа в одном типе в другой тип
            Speed speed;

            speed = new Speed(1000, MeasureType.mc);
            Assert.AreEqual("3600 км/ч", speed.To(MeasureType.km).Verbose());

            speed = new Speed(10, MeasureType.mc);
            Assert.AreEqual("19,4 узел", speed.To(MeasureType.yz).Verbose());

            speed = new Speed(560, MeasureType.mc);
            Assert.AreEqual("1,9 мах", speed.To(MeasureType.max).Verbose());
        }

        [TestMethod()]
        public void MeterToAnyTest2()
        {
            //тесты перевода числа в одном типе в другой тип
            Speed speed;

            speed = new Speed(1, MeasureType.km);
            Assert.AreEqual("0,3 м/с", speed.To(MeasureType.mc).Verbose());

            speed = new Speed(10, MeasureType.yz);
            Assert.AreEqual("5,1 м/с", speed.To(MeasureType.mc).Verbose());

            speed = new Speed(560, MeasureType.max);
            Assert.AreEqual("165226 м/с", speed.To(MeasureType.mc).Verbose());
        }

        [TestMethod()]
        public void MeterToAnyTest3()
        {
            //тест перевода числа в одном типе в другой тип
            Speed speed;

            speed = new Speed(3, MeasureType.km);
            Assert.AreEqual("1,6 узел", speed.To(MeasureType.yz).Verbose());
        }

        [TestMethod()]
        public void AddSubKmMetersTest()
        {
            //тесты сложения и вычитания значений в РАЗНЫХ мерах
            var m = new Speed(100, MeasureType.mc);
            var km = new Speed(360, MeasureType.km);
            var yz = new Speed(50, MeasureType.yz);
            var max = new Speed(30, MeasureType.max);

            Assert.AreEqual("200 м/с", (m + km).Verbose());
            Assert.AreEqual("720 км/ч", (km + m).Verbose());

            Assert.AreEqual("0 км/ч", (km - m).Verbose());
            Assert.AreEqual("0 м/с", (m - km).Verbose());

            Assert.AreEqual("17255,7 узел", (yz + max).Verbose());
            Assert.AreEqual("30,1 мах", (max + yz).Verbose());
        }
        [TestMethod()]
        public void AddSubKmMetersTes2()
        {
            //тесты умножения и деления значений в РАЗНЫХ мерах
            var m = new Speed(100, MeasureType.mc);
            var km = new Speed(360, MeasureType.km);

            Assert.AreEqual("10000 м/с", (m * km).Verbose());
            Assert.AreEqual("129600 км/ч", (km * m).Verbose());

            Assert.AreEqual("1 км/ч", (km / m).Verbose());
            Assert.AreEqual("1 м/с", (m / km).Verbose());
        }

    }
}