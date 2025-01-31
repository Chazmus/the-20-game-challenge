namespace pong.Scripts.SelectableLabels;

public partial class QuitLabel : SelectableLabel
{
    public override void PerformAction()
    {
        GetTree().Quit();
    }
}
