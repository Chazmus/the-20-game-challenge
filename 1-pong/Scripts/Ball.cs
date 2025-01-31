using Godot;

public partial class Ball : RigidBody2D
{
    private Vector2 velocity = new(-200, 200);
    private Vector2 _initialPosition = new(577, 304);

    [Export] AudioStreamPlayer2D bounceSound;
    private bool _shouldReset;

    public override void _Ready()
    {
        var audioStream = (AudioStream)GD.Load("res://Resources/plink.mp3");
        bounceSound.Stream = audioStream;
    }

    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(velocity * (float)delta);
        if (collision != null)
        {
            velocity = velocity.Bounce(collision.GetNormal());
            bounceSound.Play();
        }

        if (_shouldReset)
        {
            _shouldReset = false;
            GlobalPosition = _initialPosition;
            velocity = new Vector2(-200, 200);
        }
    }

    public void Reset()
    {
        _shouldReset = true;
    }
}
