using System.Reflection.Metadata.Ecma335;
using SplashKitSDK;

public class Robot
{
    private double X { get; set; } //private auto properties
    private double Y { get; set; }
    private Color MainColor { get; set; }
    private Vector2D Velocity { get; set; }

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
            return SplashKit.CircleAt(X + Width / 2, Y + Height / 2, 20); // center of the circle and radius
        }
    }

    public Robot(Window gameWindow, Player player)
    {
        // 1: Robot random positions
        // 0.0 <= SplashKit.Rnd() < 1
        if (SplashKit.Rnd() < 0.5)
        {
            // Start by picking a random position left to right X:(0 - windown.Width)
            X = SplashKit.Rnd(gameWindow.Width);

            if (SplashKit.Rnd() < 0.5)
                Y = -Height;  // Robot move down from above the windown top 
            else
                Y = gameWindow.Height;  // Robot move up from bottom of the windown 
        }
        else // > = 0.5
        {
            // Start by picking a random position top to bottom Y:(0 - windown.Height)
            Y = SplashKit.Rnd(gameWindow.Height);
            if (SplashKit.Rnd() < 0.5)
                X = -Width; // Robot move from outside left of the windown 
            else
                X = gameWindow.Width; // Robot move from edge right of the windown 
        }

        // 2: VELOCITY SET UP
        const int SPEED = 4;
        MainColor = Color.RandomRGB(200);

        // Get a Point for the Robot
        Point2D fromPt = new Point2D()
        {
            X = X,
            Y = Y
        };

        // Get a Point for the Player
        Point2D toPt = new Point2D()
        {
            X = player.X,
            Y = player.Y
        };

        // Calculate the direction to head
        // X = fromPt.X - toPt.X , Y = fromPt.Y - toPt.Y)
        // then calculate lenght =  square root of (X^2 + Y^2)
        // dir.X = X / length, Y = dir.Y / length
        Vector2D dir;
        dir = SplashKit.UnitVector(SplashKit.VectorPointToPoint(fromPt, toPt));

        // Set the speed and assign to the Velocity
        Velocity = SplashKit.VectorMultiply(dir, SPEED); //dir.X * SPEED, dir.Y * SPEED
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

    public void Update() // Moves toward a Player
    {
        X += Velocity.X;
        Y += Velocity.Y;
    }
    public bool isOffscreen(Window gameWindow)
    {
        if (X < -Width || X > gameWindow.Width || Y < -Height || Y > gameWindow.Height) return true;
        else return false;
    }


}
