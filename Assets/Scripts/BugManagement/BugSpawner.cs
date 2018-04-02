using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Confirmation Number: 602362519
public class BugSpawner : MonoBehaviour {


    public GameObject m_Prefab;
    public List<Transform> m_PipeList = new List<Transform>(6);
    
    Quaternion m_Rotation;
    Vector3 m_Position;
    float m_TimeRespawn = .7f;
    float m_Counter = 0;
	// Use this for initialization
	void Start () {
        PoolManager.Instance.CreatePool(m_Prefab, 15);	
	}
	
	// Update is called once per frame
	void Update () {
        m_Counter += Time.deltaTime;
        if (m_Counter > m_TimeRespawn)
        {
            int index = Random.Range(0, m_PipeList.Capacity);
            if(index % 2 == 0)
            {
                m_Rotation = Quaternion.Euler(180,0,0);
                m_Position = m_PipeList[index].position + new Vector3(.5f,0,0);
            }
            else
            {
                m_Rotation = Quaternion.Euler(180, 180, 0);
                m_Position = m_PipeList[index].position - new Vector3(.5f, 0, 0);

            }
            PoolManager.Instance.ReuseObject(m_Prefab,new Vector3(m_Position.x,transform.position.y,0),m_Rotation);
            m_Counter = Random.Range(-3, 0);
        }
	}
}
