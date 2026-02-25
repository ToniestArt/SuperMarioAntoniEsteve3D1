using UnityEngine;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{

    public int killedEnemies = 0;
    public int coinPoints = 0;
    public Text goombaKillCounter;
    public Text coinCounter;

    public bool _pause;
    public bool youwin;
    public GameObject pauseCanvas;
    public GameObject winCanvas;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKill()
    {
        killedEnemies++;
        goombaKillCounter.text = killedEnemies.ToString(); //Cambiamos de variable "INT" a "Texto" con el ".ToString".
    }

    public void AddCoin()
    {
        coinPoints++;
        coinCounter.text = coinPoints.ToString(); //Cambiamos de variable "INT" a "Texto" con el ".ToString".
    }

 public void YouWin ()
    {
        if (youwin == false)
        {
        Time.timeScale = 0;
        youwin = true;
        }
        winCanvas.SetActive(youwin);
    }
   public void Pause ()
    {
        if (_pause == false)
        {
        Time.timeScale = 0;
        
        _pause = true;
        }
        else
        {
            Time.timeScale = 1;
            _pause = false;
        }
        pauseCanvas.SetActive(_pause);
    }

}
