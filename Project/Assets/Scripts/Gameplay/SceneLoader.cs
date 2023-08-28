using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Gameplay
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private bool loadMainMenu;
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
#if UNITY_EDITOR
            if(loadMainMenu)
#endif
                SceneManager.LoadScene("MenuScene", LoadSceneMode.Additive);
        }

        public void LoadGameplay()
        {
            SceneManager.UnloadSceneAsync("MenuScene");
            SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        }

    }
}