using Godot;

namespace pong.Scripts.SelectableLabels;

public abstract partial class SelectableLabel : Label
{
    public abstract void PerformAction();
}
