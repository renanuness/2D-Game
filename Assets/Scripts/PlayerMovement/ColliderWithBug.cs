using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderWithBug : MonoBehaviour {

    Collider2D m_PlayerCollider;
    Rigidbody2D m_Rigidbody;
    private void Start()
    {
        m_PlayerCollider = GetComponent<Collider2D>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bug")
        {
            Collider2D bugCollider = collision.gameObject.GetComponent<Collider2D>();
            BugDeath bugDeath = collision.gameObject.GetComponent<BugDeath>();
           
            float playerY = m_PlayerCollider.bounds.min.y;
            float bugY = bugCollider.bounds.max.y;
            float diff = playerY - bugY;

            if ((m_Rigidbody.velocity.y < 0) &&  diff > -0.4f)
            {
                bugDeath.OnDeath();
            }
            else
            {
                Morre();   
            }
        }
    }

    void Morre()
    {
        float forceX = 5f;
        float angularVelocity = 6f;

        if (transform.localRotation.y == 0)
        {
            forceX *= 1;
            angularVelocity *= 1f;
        }
        else
        {
            forceX *= -1;
            angularVelocity *= -1f;
        }

        PlayerMovement playerMovement = GetComponent<PlayerMovement>();
        playerMovement.ToggleState();
        playerMovement.LifeChange();
        m_Rigidbody.AddForce(new Vector2(forceX,-2f),ForceMode2D.Impulse);
        m_Rigidbody.gravityScale = 3;
        m_Rigidbody.angularVelocity = angularVelocity;
    }
}
