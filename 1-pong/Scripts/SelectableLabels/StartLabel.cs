using Godot;

namespace pong.Scripts.SelectableLabels;

public partial class StartLabel : SelectableLabel
{
    public override void PerformAction()
    {
        GetTree().ChangeSceneToFile("res://Scenes/main.tscn");
    }
}
