using Godot;

namespace Breakout.Scripts;

public partial class GameManager : Node2D
{
    [Export] private PackedScene _brickScene;

    public override void _Ready()
    {
        MakeBricks();
    }

    private void MakeBricks()
    {
        // Make an 8x8 grid of bricks
        var minX = 100;
        var minY = 50;
        var maxX = 1062;
        var maxY = 312;

        var spaceX = maxX - minX;
        var spaceY = maxY - minY;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                var brick = _brickScene.Instantiate<Brick>();
                brick.Position = new Vector2(minX + spaceX / 8 * i, minY + spaceY / 8 * j);
                AddChild(brick);
            }
        }
    }
}
