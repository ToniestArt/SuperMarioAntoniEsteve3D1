using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    public int attackDamage = 3;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.layer ==7)
        {
            Goomba enemyScript = collider.gameObject.GetComponent<Goomba>();
            enemyScript.takeDamage(attackDamage);
        }
    }
}
