using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Gameplay
{
    public class SceneLoader : MonoBehaviour
    {
        private static SceneLoader instance;
        public static SceneLoader Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<SceneLoader>();
                }
                return instance;
            }
        }

        private void Awake()
        {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
        }

        public void LoadGameplay()
        {
            SceneManager.UnloadSceneAsync("MenuScene");
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        }

    }
}