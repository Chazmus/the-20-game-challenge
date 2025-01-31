using System.Collections.Generic;
using Godot;
using System.Linq;

public partial class SelectionMenu : VBoxContainer
{
    List<Label> menuOptions;
    int currentIndex = 0;

    public override void _Ready()
    {
        menuOptions = GetChildren()
            .OfType<Label>().ToList();
        menuOptions.First().AddThemeColorOverride("font_color", new Color(1, 0, 0));
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
                PerformSelection();
            }
        }
    }

    private void PerformSelection()
    {
        var selectedOption = menuOptions[currentIndex].Text;
        if (selectedOption == "Start")
        {
            GetTree().ChangeSceneToFile("res://Scenes/main.tscn");
        }
        else if (selectedOption == "Quit")
        {
            GetTree().Quit();
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
