using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_3Laba
{
    //используемые типы
    public enum MeasureType {mc, km, yz, max};

    public class Speed
    {
        private double value;
        private MeasureType type;

        public Speed(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }
        //Методы сложения, вычитания, умножение и деления значений
        public static Speed operator+(Speed instance1, Speed instance2)
        {
            return instance1 + instance2.To(instance1.type).value;
        }
        public static Speed operator -(Speed instance1, Speed instance2)
        {
            return instance1 - instance2.To(instance1.type).value;
        }

        public static Speed operator *(Speed instance1, Speed instance2)
        {
            return instance1 * instance2.To(instance1.type).value;
        }
        public static Speed operator /(Speed instance1, Speed instance2)
        {
            return instance1 / instance2.To(instance1.type).value;
        }

        //Конвертация одного типа в другой
        public Speed To(MeasureType newType)
        {
            var newValue = this.value;
            if(this.type == MeasureType.mc)
            {
                switch(newType)
                {
                    case MeasureType.mc:
                        {
                            newValue = this.value;
                            break;
                        }
                    case MeasureType.km:
                        {
                            newValue = this.value / 0.2777777777777778;
                            newValue = Math.Round(newValue, 1);
                            break;
                        }
                    case MeasureType.yz:
                        {
                            newValue = this.value / 0.5144444444403701;
                            newValue = Math.Round(newValue, 1);
                            break;
                        }
                    case MeasureType.max:
                        {
                            newValue = this.value / 295.0463999999687;
                            newValue = Math.Round(newValue, 1);
                            break;
                        }
                }
            }
            else if(newType == MeasureType.mc)
            {
                switch(this.type)
                {
                    case MeasureType.mc:
                        {
                            newValue = this.value;
                            break;
                        }
                    case MeasureType.km:
                        {
                            newValue = this.value * 0.2777777777777778;
                            newValue = Math.Round(newValue, 1);
                            break;
                        }
                    case MeasureType.yz:
                        {
                            newValue = this.value * 0.5144444444403701;
                            newValue = Math.Round(newValue, 1);
                            break;
                        }
                    case MeasureType.max:
                        {
                            newValue = this.value * 295.0463999999687;
                            newValue = Math.Round(newValue, 1);
                            break;
                        }
                }
            }
            else
            {
                newValue = this.To(MeasureType.mc).To(newType).value;
                newValue = Math.Round(newValue, 1);
            }
            return new Speed(newValue, newType);
        }




        public static Speed operator+(Speed instance, double number)
        {
            var newValue = instance.value + number;
            var speed = new Speed(newValue, instance.type);
            return speed;
        }

        public static Speed operator +(double number, Speed instance)
        {
            return instance + number;
        }

        public static Speed operator -(Speed instance, double number)
        {
            var newValue = instance.value - number;
            var speed = new Speed(newValue, instance.type);
            return speed;
        }

        public static Speed operator -(double number, Speed instance)
        {
            return instance - number;
        }

        public static Speed operator *(Speed instance, double number)
        {
            var newValue = instance.value * number;
            var speed = new Speed(newValue, instance.type);
            return speed;
        }

        public static Speed operator *(double number, Speed instance)
        {
            return instance * number;
        }

        public static Speed operator /(Speed instance, double number)
        {
            var newValue = instance.value / number;
            var speed = new Speed(newValue, instance.type);
            return speed;
        }

        public static Speed operator /(double number, Speed instance)
        {
            return instance / number;
        }

        public static implicit operator double(Speed v)
        {
            throw new NotImplementedException();
        }
        //Используемые типы
        public string Verbose()
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.mc:
                    typeVerbose = "м/с";
                    break;
                case MeasureType.km:
                    typeVerbose = "км/ч";
                    break;
                case MeasureType.yz:
                    typeVerbose = "узел";
                    break;
                case MeasureType.max:
                    typeVerbose = "мах";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }
    }
}
