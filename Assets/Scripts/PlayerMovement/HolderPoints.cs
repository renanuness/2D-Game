using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HolderPoints : MonoBehaviour {

    public List<Transform> m_HolderPoints = new List<Transform>();

    private void Start()
    {
        Debug.Log(m_HolderPoints[0]);

    }
    public Transform GetHoldPoint(int h)
    {
        return m_HolderPoints[h];
    }
}
