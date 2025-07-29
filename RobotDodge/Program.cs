using System;
using SplashKitSDK;

namespace RobotDodge
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Robot Dodge By Zavis", 700, 500);
            Player player = new Player(window);


            while (!window.CloseRequested) // user click x on window to close the screen
            {
                SplashKit.ProcessEvents(); //listen to user input event
                window.Clear(Color.White);

                player.Draw(window); //draw a player on window

                player.HandleInput(); //press Arrow Keys to move player to X, Y direction or Quit

                player.StayOnWindow(window); //stay inside window boundary

                window.Refresh(60);

                if (player.Quit) //when user press Escapse -> Quit == true
                {
                    window.Close();
                }
            }

        }

    }
}
