using UnityEngine;

public class GroundSensor : MonoBehaviour
{

PlayerController _playerScript;
public bool isGrounded;


void Awake ()
{

    _playerScript = GetComponentInParent<PlayerController>();

}
void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.gameObject.layer == 6)
    {

        isGrounded = true;

    }

    if (collision.gameObject.layer == 7)
    {
       // Destroy(collision.gameObject);

        Goomba _enemyScript = collision.gameObject.GetComponent<Goomba>();
        _enemyScript.GoombaDeath();
        _playerScript.Bounce();

    }

}

void OnTriggerStay2D(Collider2D collision)
{
       if(collision.gameObject.layer == 6)
    {

        isGrounded = true;

    } 
}

void OnTriggerExit2D(Collider2D collision)
{

    if(collision.gameObject.layer == 6)
    {

        isGrounded = false;

    }

}



}

