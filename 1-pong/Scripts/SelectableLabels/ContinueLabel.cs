using Godot;

namespace pong.Scripts.SelectableLabels;

public partial class ContinueLabel : SelectableLabel
{
    public override void PerformAction()
    {
        GetOwner<Panel>().Visible = false;
        GetTree().Paused = false;
    }
}
