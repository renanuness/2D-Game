using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tips : MonoBehaviour {


    public GameObject m_TipsPanel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnMouseOver()
    {
        Debug.Log("Tres");
        m_TipsPanel.SetActive(true);
    }

    public void  OnMouseExit()
    {
        Debug.Log("dois");
            m_TipsPanel.SetActive(false);
    }
}
