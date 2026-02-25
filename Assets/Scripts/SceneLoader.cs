using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
  
    public void ChangeScene(string sceneName)
    {

        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1;
    }

    void test()
    {
        ChangeScene ("SampleScene");
    }

}
