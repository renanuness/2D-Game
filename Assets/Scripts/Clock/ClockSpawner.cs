using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockSpawner : MonoBehaviour {

    public Transform m_SpawnerLeft;
    public Transform m_SpawnerRight;

    public GameObject m_Clock;

    float m_Interval = 10;
    float m_Counter = 0;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		if(m_Counter < m_Interval)
        {
            m_Counter += Time.deltaTime;
        }else
        {
            int randomPos = Random.Range(0, 1);
            if(randomPos == 1)
                Instantiate(m_Clock, m_SpawnerRight.transform.position,Quaternion.identity);
            else
                Instantiate(m_Clock, m_SpawnerLeft.transform.position, Quaternion.identity);

            m_Counter = 0;
        }
	}
}
