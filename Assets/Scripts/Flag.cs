using UnityEngine;

public class Flag : MonoBehaviour
{

    private AudioSource _audioSource;
    public AudioClip flagSound;
    public AudioClip victorySound;
    BGMManager _bGMManager;
    
    private BoxCollider2D _boxCollider;

    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _bGMManager = GameObject.Find("BGM Manager").GetComponent<BGMManager>();
        _boxCollider = GetComponent <BoxCollider2D>();
        gameManager = GameObject.Find("Game Manager") .GetComponent<GameManager>();

    }

    // Update is called once per frame

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            _audioSource.PlayOneShot(flagSound);
            _bGMManager.StopBGM();
           _audioSource.PlayOneShot(victorySound);
           gameManager.YouWin();

        }
        
    }

}
