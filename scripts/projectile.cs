using UnityEngine;


public class projectile : MonoBehaviour
{

    void OnCollisionEnter(Collision collisioninfo)
    {

        if (collisioninfo.collider.tag == "Player")
        {
            Die();
            
        }

        if (collisioninfo.collider.tag == "Ground")
        {
            Die();
        }

    }

    void Die()
    {
        Destroy(gameObject);
        
    }

}
