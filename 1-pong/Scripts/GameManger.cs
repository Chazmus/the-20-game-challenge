using System;
using Godot;
using Godot.Collections;

namespace pong.Scripts;

public partial class GameManger : Node2D
{
    [Export] private WinZone _winZone1;
    [Export] private WinZone _winZone2;
    [Export] private Ball ball;
    [Export] Label _player1Score;
    [Export] Label _player2Score;

    Dictionary<Player, int> _score = new();

    public override void _Ready()
    {
        // Set the initial score
        _score[Player.Player1] = 0;
        _score[Player.Player2] = 0;

        // Connect the signals
        _winZone1.BallEntered += () => AwardPoint(Player.Player2);
        _winZone2.BallEntered += () => AwardPoint(Player.Player1);
    }

    private void AwardPoint(Player player)
    {
        _score[player]++;
        _player1Score.Text = _score[Player.Player1].ToString();
        _player2Score.Text = _score[Player.Player2].ToString();
        ResetGame();
    }

    private void ResetGame()
    {
        ball.Reset();
    }

    private enum Player
    {
        Player1,
        Player2
    }
}
