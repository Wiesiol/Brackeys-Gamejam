using Assets.Scripts.Gameplay;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneLoader.Instance.LoadGameplay();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
