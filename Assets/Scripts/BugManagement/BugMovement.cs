using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : PoolObject {

    float m_InitialSpeed = 4f;

    Rigidbody2D m_Rigidbody;
	// Use this for initialization
	void Start () {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.velocity= new Vector2(0,m_InitialSpeed);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnObjectReuse()
    {
        //Initial State

    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Collector")
        {
            Destroy();
        }
    }


}
