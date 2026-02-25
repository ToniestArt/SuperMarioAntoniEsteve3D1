using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverLoader : MonoBehaviour
{
  
    public void ChangeScene(string gameOverLoader)
    {

        SceneManager.LoadScene(gameOverLoader);

    }

    public void pleaseGoToGameOver()
    {
        ChangeScene ("GameOver");
    }

}
