using Godot;

public partial class Ball : RigidBody2D
{
    private Vector2 velocity = new(-200, 200);
    private Vector2 _initialPosition;

    [Export] AudioStreamPlayer2D bounceSound;

    public override void _Ready()
    {
        var audioStream = (AudioStream)GD.Load("res://Resources/plink.mp3");
        bounceSound.Stream = audioStream;
        _initialPosition = Position;
    }

    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(velocity * (float)delta);
        if (collision != null)
        {
            velocity = velocity.Bounce(collision.GetNormal());
            bounceSound.Play();
        }
    }

    public void Reset()
    {
        Transform = new Transform2D(0.0f, _initialPosition);
        velocity = new Vector2(-200, 200);
    }
}
