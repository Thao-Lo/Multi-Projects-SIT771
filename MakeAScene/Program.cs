using System;
using SplashKitSDK;

namespace MakeAScene
{
    public class Program
    {
        public static void Main()
        {
            // get font
            Font comicFont = new Font("Comic Font", "ComicNeue-Bold.ttf");

            // create comic window object              
            Window comicScene = new Window("Comic by Zavis", 400, 600);

            //-- Scene 1 --
            //image and sound objects
            Bitmap hungryFace = new Bitmap("Hungry", "hungry-face.png");
            SoundEffect hungrySound = new SoundEffect("Stomach Rumble", "stomach-rumble.mp3");
            //animation
            comicScene.Clear(Color.GhostWhite);
            comicScene.DrawBitmap(hungryFace, 0, 80);
            comicScene.DrawText("Im HUNGRY..", Color.DarkBlue, comicFont, 28, 200, 70);
            hungrySound.Play();
            comicScene.Refresh(60);
            SplashKit.Delay(4000);

            //-- Scene 2 --
            //image and sound objects
            Bitmap thinkingFace = new Bitmap("Thinking", "thinking-face.png");
            SoundEffect lickingSound = new SoundEffect("Licking Sound", "comic-lick.mp3");
            //animation
            comicScene.Clear(Color.GhostWhite);
            comicScene.DrawBitmap(thinkingFace, 50, 100);
            comicScene.DrawText("Maybe some ICE CREAM??", Color.DarkBlue, comicFont, 22, 80, 70);
            lickingSound.Play();
            comicScene.Refresh(60);
            SplashKit.Delay(3000);

            //-- Scene 3 --
            //image and sound objects
            Bitmap happyFace = new Bitmap("Happy Face", "happy-face.png");
            SoundEffect happySound = new SoundEffect("Yay Sound", "yay.mp3");
            //animation
            comicScene.Clear(Color.GhostWhite);
            comicScene.DrawBitmap(happyFace, 50, 120);
            comicScene.DrawText("no ice cream, BURGER!!!!", Color.DarkBlue, comicFont, 24, 80, 70);
            happySound.Play();
            comicScene.Refresh(60);
            SplashKit.Delay(4000);

        }
    }
}
