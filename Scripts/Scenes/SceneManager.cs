using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class SceneManager : MonoBehaviour
    {
        [SerializeField] private LoadAnimation _loadAnimation;

        private int currentscene_index ;


        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            RestarButtonPause._restartEvent += LoadRestart;
            _loadAnimation._loadEvent += LoadScene;
            _loadAnimation._loadFromShop += LoadScene;
            RestartButton.restartEvent += LoadRestart;
        }

        private void LoadScene()
        {

            UnityEngine.SceneManagement.SceneManager.LoadScene(currentscene_index += 1);

        }


        private void LoadRestart()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        private void OnDisable()
        {
            RestarButtonPause._restartEvent -= LoadRestart;
            _loadAnimation._loadEvent -= LoadScene;
            _loadAnimation._loadFromShop -= LoadScene;
            RestartButton.restartEvent -= LoadRestart;
        }
    }
}