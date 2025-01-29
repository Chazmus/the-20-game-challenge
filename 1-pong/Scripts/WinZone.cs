using System;
using Godot;

namespace pong.Scripts;

public partial class WinZone : Area2D
{

    public event Action BallEntered;

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body)
    {
        if(body is Ball)
        {
            BallEntered?.Invoke();
        }
    }

}
