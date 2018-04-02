using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{

    RaycasOrigins m_RaycastOrigins;
    Collider2D m_Collider;
    public LayerMask m_CollisionMask;
    public CollisionInfo m_CollisionInfo;
    // Use this for initialization
    void Start()
    {
        m_Collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateRaycastOrigins();
    }
    public void VerticalCollision(float velocity)
    {
        float directionY = Mathf.Sign(velocity);
        float rayLenght = 1f;
        Vector2 rayOrigin = (directionY == -1) ? m_RaycastOrigins.bottom : m_RaycastOrigins.top;
        RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.up * directionY, rayLenght, m_CollisionMask);
        Debug.DrawRay(rayOrigin, Vector2.up * directionY * rayLenght, Color.red);



        if (hit)
        {
               if (directionY > 0)
               {
                    m_CollisionInfo.above = true;
               }
               else if (directionY < 0)
               {
                   m_CollisionInfo.below = true;
               }
        }
        else
        {
            m_CollisionInfo.above = m_CollisionInfo.below = false;
        }
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = m_Collider.bounds;

        m_RaycastOrigins.top = new Vector2(bounds.center.x,bounds.max.y);
        m_RaycastOrigins.bottom = new Vector2(bounds.center.x, bounds.min.y);
        m_RaycastOrigins.left = new Vector2(bounds.min.x, bounds.center.y);
        m_RaycastOrigins.right = new Vector2(bounds.max.x, bounds.center.y);
            //Debug.Log(m_RaycastOrigins.top);
            //Debug.Log(m_RaycastOrigins.bottom);
            //Debug.Log(m_RaycastOrigins.left);
            //Debug.Log(m_RaycastOrigins.right);


    }

    public struct CollisionInfo
    {
        public bool above, below;
        public bool left, right;

        public void Reset()
        {
            above = below = false;
            left = right = false;
        }
    }
        
    struct RaycasOrigins
    {
        public Vector2 top, bottom;
        public Vector2 left, right;
    }


}
