using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Homework_2
{
    struct ComplexNumber
    {
        private double re;
        private double im;

        public ComplexNumber(double re, double im)
        {
            this.im = im;
            this.re = re;
        }
        
        //Сложение
        public ComplexNumber Sum(ComplexNumber num)
        {
            return new ComplexNumber(re + num.re, im + num.im);
        }

        public ComplexNumber Sum(params ComplexNumber[] nums)
        {
            double re_new = re, im_new = im;
            foreach(ComplexNumber num in nums)
            {
                re_new += num.re;
                im_new += num.im;
            }
            return new ComplexNumber(re_new, im_new);
        }

        public static ComplexNumber Sum_st(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.re + num2.re, num1.im + num2.im);
        }

        public static ComplexNumber Sum_st(params ComplexNumber[] nums)
        {
            double re_new = 0, im_new = 0;
            foreach (ComplexNumber num in nums)
            {
                re_new += num.re;
                im_new += num.im;
            }
            return new ComplexNumber(re_new, im_new);
        }

        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re + c2.re, c1.im + c2.im);
        }

        //Вычитание
        public ComplexNumber Dif(ComplexNumber num)
        {
            return new ComplexNumber(re - num.re, im - num.im);
        }

        public static ComplexNumber Dif_st(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.re - num2.re, num1.im - num2.im);
        }

        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(c1.re - c2.re, c1.im - c2.im);
        }


        //Умножение
        public ComplexNumber Mult(ComplexNumber num)
        {
            return new ComplexNumber(re * num.re - im * num.im, re * num.im + im * num.re);
        }

        public ComplexNumber Mult(params ComplexNumber[] nums)
        {
            double re_new = re, im_new = im, re_temp, im_temp;
            foreach (ComplexNumber num in nums)
            {
                re_temp = re_new;
                im_temp = im_new;
                re_new = re_temp * num.re - im_temp * num.im;
                im_new = re_temp * num.im + im_temp * num.re;
            }
            return new ComplexNumber(re_new, im_new);
        }

        public static ComplexNumber Mult_st(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.re * num2.re - num1.im * num2.im, num1.re * num2.im + num1.im * num2.re);
        }

        public static ComplexNumber Mult_st(params ComplexNumber[] nums)
        {
            double re_new = nums[0].re, im_new = nums[0].im, re_temp, im_temp;
            ComplexNumber num;
            for (int i = 1; i < nums.Length; i ++)
            {
                num = nums[i];
                re_temp = re_new;
                im_temp = im_new;
                re_new = re_temp * num.re - im_temp * num.im;
                im_new = re_temp * num.im + im_temp * num.re;
            }
            return new ComplexNumber(re_new, im_new);
        }

        public static ComplexNumber operator *(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber(num1.re * num2.re - num1.im * num2.im, num1.re * num2.im + num1.im * num2.re);
        }


        //Деление
        public ComplexNumber Div(ComplexNumber num)
        {
            return new ComplexNumber((re * num.re + im * num.im)/(im * im + num.im * num.im), (im * num.re - re * num.im)/(im * im + num.im * num.im));
        }

        public static ComplexNumber Div_st(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber((num1.re * num2.re + num1.im * num2.im) / (num1.im * num1.im + num2.im * num2.im), (num1.im * num2.re - num1.re * num2.im) / (num1.im * num1.im + num2.im * num2.im));
        }

        public static ComplexNumber operator /(ComplexNumber num1, ComplexNumber num2)
        {
            return new ComplexNumber((num1.re * num2.re + num1.im * num2.im) / (num1.im * num1.im + num2.im * num2.im), (num1.im * num2.re - num1.re * num2.im) / (num1.im * num1.im + num2.im * num2.im));
        }


        //Модуль
        public static double mod(ComplexNumber num)
        {
            return Math.Sqrt(num.re * num.re + num.im * num.im);
        }

        public static implicit operator double(ComplexNumber num)
        {
            return Math.Sqrt(num.re * num.re + num.im * num.im);
        }

        //Перегрузка унарных операторов
        public static ComplexNumber operator +(ComplexNumber num)
        {
            return new ComplexNumber(Math.Abs(num.re), Math.Abs(num.im));
        }

        public static ComplexNumber operator -(ComplexNumber num)
        {
            return new ComplexNumber(-1 * num.re, -1 * num.im);
        }

        //Перегруженный ToString
        public override string ToString()
        {
            return "re: " + re.ToString() + ", im: " + im.ToString();
        }

        //Перегруженные Equals и операторы "==" и "!="
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is ComplexNumber))
                return false;
            else
                return ((re == ((ComplexNumber)obj).re) && (im == ((ComplexNumber)obj).im));
        }

        public static bool operator ==(ComplexNumber num1, ComplexNumber num2)
        {
            bool eq = true;
            if ((num1.re != num2.re) || (num1.im != num2.im)) eq = false;
            return eq;
        }

        public static bool operator !=(ComplexNumber num1, ComplexNumber num2)
        {
            bool eq = true;
            if ((num1.re == num2.re) && (num1.im == num2.im)) eq = false;
            return eq;
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber num1 = new ComplexNumber(1, 2);
            ComplexNumber num2 = new ComplexNumber(2.55, 6);
            ComplexNumber num3 = new ComplexNumber(0.45, 3);
            Console.WriteLine(num1 + num2);
            Console.WriteLine(num1.Sum(num2));
            Console.WriteLine(ComplexNumber.Sum_st(num1, num2));
            Console.WriteLine(num1.Sum(num2, num3));
            Console.WriteLine(ComplexNumber.Sum_st(num1, num2, num3));
            Console.WriteLine(num2 - num1);
            Console.WriteLine(num2.Dif(num1));
            Console.WriteLine(ComplexNumber.Dif_st(num2, num1));
            Console.WriteLine(num1 * num2);
            Console.WriteLine(num1.Mult(num2));
            Console.WriteLine(ComplexNumber.Mult_st(num1, num2));
            Console.WriteLine(num1.Mult(num2, num3));
            Console.WriteLine(ComplexNumber.Mult_st(num1, num2, num3));
            Console.WriteLine(num2 / num1);
            Console.WriteLine(num2.Div(num1));
            Console.WriteLine(ComplexNumber.Div_st(num2, num1));
            Console.WriteLine(ComplexNumber.mod(num1));
            Console.WriteLine((double)num1);
            Console.WriteLine((+num1).ToString());
            Console.WriteLine((-num1).ToString());
            Console.ReadKey();
        }
    }
}
