using System.Security.Cryptography.X509Certificates;
using SplashKitSDK;
public class RobotDodges
{
    private Player _Player;
    private Window _GameWindow;

    private Robot _TestRobot;
    public bool Quit
    {
        get
        {
            return _Player.Quit;
        }
    }
    public RobotDodges(Window window)
    {
        _GameWindow = window;
        _Player = new Player(window);
        _TestRobot = RandomRobot();

    }
    public void HandleInput()
    {

        _Player.HandleInput(); //press Arrow Keys to move player to X, Y direction or Quit

        _Player.StayOnWindow(_GameWindow); //stay inside window boundary
        if (_Player.Quit) //when user press Escapse -> Quit == true
        {
            _GameWindow.Close();
        }

    }
    public void Draw() 
    {
        _GameWindow.Clear(Color.White);

        _TestRobot.Draw(_GameWindow);

        _Player.Draw(_GameWindow); //draw a player on window        

        _GameWindow.Refresh(60);
    }

    public void Update() //Update the game: moving the robot and checking for collisions
    {
        if (_Player.CollideWith(_TestRobot))
        {
            _TestRobot = RandomRobot();
        }
    }
    public Robot RandomRobot() // draw new robot on window
    {
        return new Robot(_GameWindow);
    }
}