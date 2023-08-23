public static class InputManager
{
    static InputManager()
    {
        //Input.Gameplay.Enable();
        ChangeActionMap(ActionMaps.Gameplay);
    }

    private static PlayerInput input;
    public static PlayerInput Input
    {
        get
        {
            if (input == null)
            {
                input = new();
            }
            return input;
        }
    }

    public static void ChangeActionMap(ActionMaps actionMap)
    {
        Input.Disable();

        switch (actionMap)
        {
            case ActionMaps.Gameplay:
                input.Gameplay.Enable();
                break;
            case ActionMaps.Inventory:
                input.Inventory.Enable();
                break;
        }

        CursorStates.AdjustCursor(actionMap);
    }
}

public enum ActionMaps
{
    Gameplay,
    Inventory
}