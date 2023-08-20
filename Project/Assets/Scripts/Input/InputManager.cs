public static class InputManager
{
    static InputManager()
    {
        Input.Gameplay.Enable();
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
}
