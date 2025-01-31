using System;
using Godot;

namespace pong.Scripts.SelectableLabels;

public partial class ResetLabel : SelectableLabel
{
    public event Action ResetGame;

    public override void PerformAction()
    {
        GetTree().Paused = false;
        ResetGame?.Invoke();
        GetOwner<Panel>().Visible = false;
    }
}
