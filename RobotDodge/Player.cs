using System.Dynamic;
using System.Runtime.ConstrainedExecution;
using SplashKitSDK;

public class Player
{
    private Bitmap _PlayerBitmap;


    public double X { get; private set; }  //variable declaration, getter, private setter
    public double Y { get; private set; } // auto-property with hidden backing field, getter, private setter

    public bool Quit { get; private set; } //default value == false

    public int Width
    {
        get { return _PlayerBitmap.Width; } //variable declaration + readonly
    }
    public int Height
    {
        get { return _PlayerBitmap.Height; }
    }


    public Player(Window gameWindow)  //constructor: create a new player, player X, Y position (center) 
    {
        _PlayerBitmap = new Bitmap("Player Bitmap", "Player.png");
        X = (gameWindow.Width - _PlayerBitmap.Width) / 2;
        Y = (gameWindow.Height - _PlayerBitmap.Height) / 2;
        Quit = false;
    }

    //-- METHOD --
    public void Draw(Window gameWindow)
    {
        gameWindow.DrawBitmap(_PlayerBitmap, X, Y);
    }


    public void HandleInput()
    {
        // unchange value
        const int SPEED = 5;

        //seperate if statement for moving directions at the same time, not one direction at a time
        if (SplashKit.KeyDown(KeyCode.UpKey))
        {
            Move(0, -SPEED); //move up
        }
        if (SplashKit.KeyDown(KeyCode.DownKey))
        {
            Move(0, SPEED); //move down
        }
        if (SplashKit.KeyDown(KeyCode.LeftKey))
        {
            Move(-SPEED, 0); //move left
        }
        if (SplashKit.KeyDown(KeyCode.RightKey))
        {
            Move(SPEED, 0); //move right
        }
        if (SplashKit.KeyDown(KeyCode.EscapeKey))
        {
            Quit = true; //close the window
        }

    }

    public void StayOnWindow(Window gameWindow)
    {
        const int GAP = 10;

        //seperate if statement for keep checking
        if (X < GAP) //too far left
        {
            X = GAP;
        }
        //(X + Width > window.Width - GAP)
        if ((gameWindow.Width - Width - X) < GAP) // too far right 
        {
            X = gameWindow.Width - Width - GAP;
        }
        if (Y < GAP) //too far up
        {
            Y = GAP;
        }
        if ((gameWindow.Height - Height - Y) < GAP) //too far down
        {
            Y = gameWindow.Height - Height - GAP;

        }
    }

    public void Move(double x, double y)
    {
        X += x; //update X with SPEED 
        Y += y; //update Y with SPEED 
    }

    public bool CollideWith(Robot robot) // check if Player and Robot collise
    {
        return _PlayerBitmap.CircleCollision(X, Y, robot.CollisionCircle);
    }

}