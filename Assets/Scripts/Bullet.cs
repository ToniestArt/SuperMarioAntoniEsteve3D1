using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rBody;
    
    public float bulletSpeed = 10;
    public int bulletDamage = 3;

    public float bulletImpactForce = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {

        //rBody.AddForce(Vector2.right) <-- Esto dispararía siempre a la derecha
        rBody.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
    }
    void Awake()
    {

      rBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Coins"))
        {
            return;
        }

        
    if (collision.gameObject.layer == 7)
    {
       // Destroy(collision.gameObject);
        
        Goomba _enemyScript = collision.gameObject.GetComponent<Goomba>();
       // _enemyScript.takeDamage(bulletDamage);
        _enemyScript.TakeDamage(bulletDamage, transform.right, bulletImpactForce)

    }

        Destroy(gameObject);
    }

    
}
