using System;
using SplashKitSDK;

namespace HelloWorld
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello World");

            Window drawing = new Window("My First Program", 200, 200);

            drawing.DrawText("Hello World", Color.DarkBlue, 50, 100);
            drawing.Refresh();
            SplashKit.Delay(10000);
        }          
    }
}
