using Godot;

namespace Breakout.Scripts;

public partial class Player : RigidBody2D
{
	private const int SPEED = 300;
	[Export] private Key _leftKey;
	[Export] private Key _rightKey;

	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		if (Input.IsKeyPressed(_leftKey))
		{
			velocity.X -= SPEED;
		}

		if (Input.IsKeyPressed(_rightKey))
		{
			velocity.X += SPEED;
		}

		LinearVelocity = velocity;
	}
}
