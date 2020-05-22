using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LevelLoader : MonoBehaviour
    {
        private int currentSceneIndex;

        private void Start()
        {
            currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex == 0)
            {
                StartCoroutine(LoadNextSceneWithDelay());
            }
        }

        private IEnumerator LoadNextSceneWithDelay()
        {
            yield return new WaitForSeconds(3);
            LoadNextScene();
        }

        public void RestartScene()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(currentSceneIndex);
        }

        public void LoadMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("Start Screen");
        }

        public void LoadNextScene()
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }

        public void LoadYouLoseScene()
        {
            SceneManager.LoadScene("Lose Screen");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
