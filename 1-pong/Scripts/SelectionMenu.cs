using System.Collections.Generic;
using System.Linq;
using Godot;
using pong.Scripts.SelectableLabels;

namespace pong.Scripts;

public partial class SelectionMenu : VBoxContainer
{
    List<SelectableLabel> menuOptions;
    int currentIndex;

    public override void _Ready()
    {
        menuOptions = GetChildren()
            .OfType<SelectableLabel>().ToList();
        menuOptions.First().AddThemeColorOverride("font_color", new Color(1, 0, 0));
        menuOptions[currentIndex].GrabFocus();
    }

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventKey keyEvent)
        {
            if (keyEvent.Pressed && keyEvent.GetKeyLabel() == Key.Down)
            {
                MoveSelection(1);
            }
            else if (keyEvent.Pressed && keyEvent.GetKeyLabel() == Key.Up)
            {
                MoveSelection(-1);
            }

            if (keyEvent.Pressed && keyEvent.GetKeyLabel() == Key.Enter)
            {
                menuOptions[currentIndex].PerformAction();
            }
        }
    }

    private void MoveSelection(int direction)
    {
        menuOptions[currentIndex].GrabFocus();
        menuOptions[currentIndex].AddThemeColorOverride("font_color", new Color(1, 1, 1));
        var nextIndex = (currentIndex + direction) % menuOptions.Count;
        if (nextIndex < 0)
        {
            nextIndex = menuOptions.Count - 1;
        }

        menuOptions[nextIndex].GrabFocus();
        menuOptions[nextIndex].AddThemeColorOverride("font_color", new Color(1, 0, 0));
        currentIndex = nextIndex;
    }
}
