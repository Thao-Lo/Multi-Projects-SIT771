using System;
using SplashKitSDK;

namespace RobotDodge
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Robot Dodge By Zavis", 700, 500);
            // Player player = new Player(window);

            RobotDodges robotDodge = new RobotDodges(window);


            while (!window.CloseRequested) // user click x on window to close the screen
            {
                SplashKit.ProcessEvents(); //listen to user input event

                robotDodge.HandleInput(); // Player input/ movements

                robotDodge.Update(); //Update robot position if colliding 
                
                robotDodge.Draw(); // Draw or update drawing
            }


        }

    }
}
