using Godot;

public partial class Ball : RigidBody2D
{
    private Vector2 velocity = new(-200, 200);

    public override void _PhysicsProcess(double delta)
    {
        var collision = MoveAndCollide(velocity * (float)delta);
        if (collision != null)
        {
            velocity = velocity.Bounce(collision.GetNormal());
        }
    }
}
