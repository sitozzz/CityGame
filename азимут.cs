using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        public static void Checking(double mylon, double mylat, double kladlon, double kladlat)
        {
            string s = "";
            int rad = 6372795;

            //в радианах
            double lrad = mylat * Math.PI / 180.0;
            double latrad = kladlat * Math.PI / 180.0;
            double krad = mylon * Math.PI / 180.0;
            double lonrad = kladlon * Math.PI / 180.0;

            //косинусы и синусы широт и разницы долгот
            double cl1 = Math.Cos(lrad);
            double cl2 = Math.Cos(latrad);
            double sl1 = Math.Sin(lrad);
            double sl2 = Math.Sin(latrad);
            double delta = lonrad - krad;
            double cdelta = Math.Cos(delta);
            double sdelta = Math.Sin(delta);

            //вычисления длины большого круга
            double y = Math.Sqrt(Math.Pow(cl2 * sdelta, 2) + Math.Pow(cl1 * sl2 - sl1 * cl2 * cdelta, 2));
            double x = sl1 * sl2 + cl1 * cl2 * cdelta;
            double ad = Math.Atan2(y, x);
            double dist = ad * rad;

            //вычисление начального азимута
            double x0 = (cl1 * sl2) - (sl1 * cl2 * cdelta);
            double y0 = sdelta * cl2;
            double z = (Math.Atan(-y0 / x0)) * (180.0 / Math.PI);

            if (x0 < 0)
            {
                z += 180.0;
            }
            double z1 = (z + 180.0) % 360.0 - 180;
            double z2 = -(Math.PI / 180.0) * z1;
            double anglerad2 = z2 - ((2 * Math.PI) * Math.Floor((z2 / (2 * Math.PI))));
            double angledeg = (anglerad2 * 180.0) / Math.PI;
            s = dist.ToString() + " метры " + angledeg + " градусов.";
            System.Console.WriteLine(s);
            System.Console.ReadKey();
        }
        static void Main(string[] args)
        {
            //координаты двух точек mylat,mylon - ты, kladlat,kladlon - клад
            double mylat = 56.51111;
            double mylon = 60.32111;
            double kladlat = 56.51120;
            double kladlon = 60.32120;

            Program.Checking(mylon, mylat, kladlon, kladlat);
        }
    }
}