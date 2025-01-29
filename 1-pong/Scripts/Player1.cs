using Godot;

public partial class Player1 : RigidBody2D
{
	private const int SPEED = 300;
	[Export] private Key upKey;
	[Export] private Key DownKey;

	public override void _Process(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		if (Input.IsKeyPressed(upKey))
		{
			velocity.Y -= SPEED;
		}

		if (Input.IsKeyPressed(DownKey))
		{
			velocity.Y += SPEED;
		}

		LinearVelocity = velocity;
	}
}
