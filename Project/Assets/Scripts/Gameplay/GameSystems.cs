using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public static class GameSystems
    {
        public static GameState gamestate;
    }

    public enum GameState
    {
        Gameplay,
        Shop
    }
}