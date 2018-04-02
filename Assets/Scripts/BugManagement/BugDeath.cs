using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugDeath : MonoBehaviour {

    Rigidbody2D m_Rigidbody;
    public BugRotation m_BugRotation;
    GameManager m_GameManger;
    Collider2D m_Collider;
    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_GameManger = GameManager.Instance;
        m_Collider = GetComponent<Collider2D>();
    }
    public void OnDeath()
    {
        if (transform.localRotation.x == 0)
        {
            m_BugRotation = BugRotation.LEFT;
        }
        else if (transform.localRotation.x == 180f)
        {
            m_BugRotation = BugRotation.RIGHT;
        }

        float forceX = (transform.localRotation.y == 0) ? -5f : 5f;
        m_Rigidbody.velocity = new Vector2(0, -3f);
        m_Rigidbody.AddForce(new Vector2(forceX,-1f), ForceMode2D.Impulse);
        m_Rigidbody.gravityScale = 1;
        m_Collider.enabled = false;
        m_GameManger.IncreaseScore();
    }
}

public enum BugRotation
{
    LEFT,
    RIGHT
};
