using System.Linq;
using Godot;
using Godot.Collections;
using pong.Scripts.SelectableLabels;

namespace pong.Scripts;

public partial class GameManger : Node2D
{
    [Export] private WinZone _winZone1;
    [Export] private WinZone _winZone2;
    [Export] private Ball ball;
    [Export] private Label _player1Score;
    [Export] private Label _player2Score;
    [Export] private Panel _pauseMenu;

    private Dictionary<Player, int> _score = new();

    public override void _Ready()
    {
        // Set the initial score
        _score[Player.Player1] = 0;
        _score[Player.Player2] = 0;

        // Connect the signals
        _winZone1.BallEntered += () => AwardPoint(Player.Player2);
        _winZone2.BallEntered += () => AwardPoint(Player.Player1);

        _pauseMenu.GetChild(0).GetChildren().OfType<ResetLabel>().First().ResetGame += ResetGame;
    }

    public override void _Input(InputEvent @event)
    {
        base._Input(@event);
        if (@event is InputEventKey { Pressed: true } keyEvent && keyEvent.GetKeyLabel() == Key.Escape)
        {
            GetTree().Paused = true;
            _pauseMenu.Visible = true;
        }
    }

    private void AwardPoint(Player player)
    {
        _score[player]++;
        _player1Score.Text = _score[Player.Player1].ToString();
        _player2Score.Text = _score[Player.Player2].ToString();
        ResetBall();
    }

    private void ResetBall()
    {
        ball.Reset();
    }

    private void ResetGame()
    {
        ResetBall();
        _score[Player.Player1] = 0;
        _score[Player.Player2] = 0;
        _player1Score.Text = _score[Player.Player1].ToString();
        _player2Score.Text = _score[Player.Player2].ToString();
    }

    private enum Player
    {
        Player1,
        Player2
    }
}
