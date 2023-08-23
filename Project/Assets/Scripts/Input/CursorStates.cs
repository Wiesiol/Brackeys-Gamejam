using UnityEngine;

public static class CursorStates
{
    private static void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    private static void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public static void AdjustCursor(ActionMaps actionMap)
    {
        switch (actionMap)
        {
            case ActionMaps.Gameplay:
                HideCursor();
                break;
            case ActionMaps.Inventory:
                ShowCursor();
                break;
        }
    }
}
