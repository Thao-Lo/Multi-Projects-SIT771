using System.Security.Cryptography.X509Certificates;
using SplashKitSDK;
public class RobotDodges
{
    private Player _Player;
    private Window _GameWindow;

    private List<Robot> _Robots; //Many robots
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
        _Robots = []; // new List

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

        foreach (Robot robot in _Robots)
        {
            robot.Draw(_GameWindow);
        }

        _Player.Draw(_GameWindow); //draw a player on window        

        _GameWindow.Refresh(60);
    }

    public void Update() //Update the game: moving the robot and checking for collisions
    {      
        CheckCollision();
        foreach (Robot robot in _Robots)
        {
            robot.Update(); //Robot moves toward to a Player      
        }
        if (SplashKit.Rnd() > 0.9) // randomly add robots if 0.9 < values < 1 
        {
            _Robots.Add(RandomRobot());
        }

    }
    private void CheckCollision()
    {
        // Create new list to store all Robots need to be removed
        List<Robot> removedRobots = new List<Robot>();

        foreach (Robot robot in _Robots)
        {
             // Check whether Robot collides with a player or off screen
            if (_Player.CollideWith(robot) || robot.isOffscreen(_GameWindow))
            {
                removedRobots.Add(robot);
            }
        }

        // Loop through RemovedRobot List
        foreach (Robot robot in removedRobots)
        {
            _Robots.Remove(robot); // Tell _Robots to remove the current removedRobot
        }
    }

    public Robot RandomRobot() // draw new robot on window
    {
        return new Robot(_GameWindow, _Player);
    }
    
}