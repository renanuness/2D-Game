using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockBehaviour : MonoBehaviour {


    GameManager m_GameManager;
    Rigidbody2D m_Rigidbody;

    // Use this for initialization
	void Start () {
        m_GameManager = GameManager.Instance;
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.velocity = new Vector2(0, -4f);
    }

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag);
        if(collision.gameObject.tag == "Player")
        {
            m_GameManager.AddTime();
            Destroy(this.gameObject,0.1f);

        }
        else if(collision.gameObject.tag == "Collector")
        {
            Destroy(this.gameObject);
        }
    }
}
