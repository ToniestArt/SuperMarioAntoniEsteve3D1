using UnityEngine;

public class Coin : MonoBehaviour
{
   private BoxCollider2D _boxCollider;
    private AudioSource _audioSource;
    public AudioClip coinSound;
    private SpriteRenderer coinRenderer;
    
    
    void Start()
    {

        _boxCollider = GetComponent<BoxCollider2D>();
        _audioSource = GetComponent<AudioSource>();
        coinRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame

     void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.gameObject.CompareTag("Player"))
        {
        
         _audioSource.PlayOneShot(coinSound);

        _boxCollider.enabled = false;

        coinRenderer.enabled = false;

          Destroy(gameObject, 2);
        }

    }

}
