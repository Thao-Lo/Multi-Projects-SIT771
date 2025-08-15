using System.Reflection.Metadata.Ecma335;
using SplashKitSDK;

public class Robot
{
    private double X { get; set; } //private auto properties
    private double Y { get; set; }
    private Color MainColor { get; set; }

    //Robot size: 50 x 50
    public int Width //read only, return 50
    {
        get { return 50; }
    }
    public int Height
    {
        get { return 50; }
    }
    public Circle CollisionCircle 
    {
        get
        {
            return SplashKit.CircleAt(X + Width/2, Y + Height/2, 20); // center of the circle and radius
        }
    }

    public Robot(Window gameWindow)
    {
        X = SplashKit.Rnd(gameWindow.Width - Width);
        Y = SplashKit.Rnd(gameWindow.Height - Height);
        MainColor = Color.RandomRGB(200);

    }
    public void Draw(Window gameWindow)
    {
        // Draw new Robot
        double leftX = X + 12;
        double rightX = X + 27;
        double eyeY = Y + 10;
        double mouthY = Y + 30;

        gameWindow.FillRectangle(Color.Gray, X, Y, 50, 50);
        gameWindow.FillRectangle(MainColor, leftX, eyeY, 10, 10);
        gameWindow.FillRectangle(MainColor, rightX, eyeY, 10, 10);
        gameWindow.FillRectangle(MainColor, leftX, mouthY, 25, 10);
        gameWindow.FillRectangle(MainColor, leftX + 2, mouthY + 2, 21, 6);

    }

}
