using System;
using SplashKitSDK;

namespace WorkingWithObjects
{
    public class Program
    {
        public static void Main()
        {
            Window house = new Window("A House by Zavis", 450, 250);
            house.MoveTo(0, 0);

            Window car = new Window("A Car by Zavis", 400, 300);

            // color entire windows
            house.Clear(Color.LightCyan);
            car.Clear(Color.White);

            //Drawing One: a house
            house.FillTriangle(Color.DarkOliveGreen, 100, 100, 200, 50, 300, 100);
            house.FillRectangle(Color.DarkCyan, 100, 100, 200, 100);
            house.FillRectangle(Color.White, 150, 150, 50, 50); //door
            house.FillCircle(Color.White, 250, 160, 15); //window


            //Drawing Two: a car
            //wheels
            car.FillCircle(Color.DarkBlue, 100, 200, 30);
            car.FillCircle(Color.DarkBlue, 300, 200, 30);

            // car's body
            car.FillRectangle(Color.Brown, 50, 200, 300, -50);
            car.FillRectangle(Color.Brown, 115, 150, 170, -50);

            car.FillTriangle(Color.Brown, 85, 150, 115, 100, 115, 150);
            car.FillTriangle(Color.Brown, 285, 150, 285, 100, 315, 150);

            //car's windows
            car.FillRectangle(Color.White, 130, 150, 60, -20);
            car.FillRectangle(Color.White, 210, 150, 60, -20);


            house.Refresh();
            car.Refresh();
            SplashKit.Delay(5000); // 5 secs
        }
    }
}
