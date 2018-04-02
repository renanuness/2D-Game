using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Transform m_InitialHolder;
    IPlayerPosition m_PlayerPosition;
    [SerializeField]
    EPlayerStates m_PlayerState;
    [SerializeField]
    ELifeStates m_LifeState;
    HolderPoints m_HolderPoints;
    Transform m_Holder;
    Rigidbody2D m_Rigidbody;
    PlayerCollider m_Collider;

    float m_YinJump;
    float speedY;
    float speedDown = 14f;
    float speedUp = 5f;

    public PlayerMovement()
    {
        m_PlayerPosition = new PipeOneLeft(this);
        m_PlayerState = EPlayerStates.ONBAMBU;

    }

    private void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(m_InitialHolder.position.x,0,0);
        m_HolderPoints = GetComponent<HolderPoints>();
        m_Collider = GetComponent<PlayerCollider>();
        m_LifeState = ELifeStates.LIVE;
    }
    //============================INPUT================================================//
    private void FixedUpdate()
    {
        if (m_LifeState == ELifeStates.LIVE)
        {
            //Movimento horizontal
            if (m_PlayerState == EPlayerStates.ONBAMBU)
            {
                if (Input.GetButtonDown("JumpLeft"))
                    Left();
                if (Input.GetButtonDown("JumpRight"))
                    Right();
            }

            //Movimento vertical.
            float moveY = Input.GetAxisRaw("Vertical");
            speedY = SetSpeedY(moveY);

            if (moveY < 0 && m_PlayerState == EPlayerStates.ONBAMBU)
            {
                m_Rigidbody.velocity = new Vector2(0, moveY * speedY);
            }
            else if (moveY > 0 && m_PlayerState == EPlayerStates.ONBAMBU)
            {
                //speedY = moveY * 4f;

                m_Rigidbody.velocity = new Vector2(0, moveY * speedY);
            }
            else if (m_PlayerState == EPlayerStates.ONBAMBU)
            {
                m_Rigidbody.velocity = new Vector2(0, 0);
            }
        }
        else
        {
            if(m_LifeState == ELifeStates.DEAD)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    float SetSpeedY(float moveY)
    {
        float speed = 0f;
        if (moveY > 0)
        {
            m_Collider.VerticalCollision(speedUp*moveY);
            if (m_Collider.m_CollisionInfo.above)
            {
                speed = 0;
            }
            else
            {
                speed = speedUp;
            }
        }
        else if (moveY < 0)
        {

            m_Collider.VerticalCollision(speedDown*moveY);
            if (m_Collider.m_CollisionInfo.below)
            {
                speed = 0;

            }
            else
            {
                speed = speedDown;
            }
        }

        return speed;
    }

    //============================PLAYER STATE================================================//
    public void ToggleState()
    {
        if (m_PlayerState == EPlayerStates.ONBAMBU)
        {
            m_PlayerState = EPlayerStates.ONAIR;
            m_Rigidbody.gravityScale = 1;

        }
        else
        {
            m_PlayerState = EPlayerStates.ONBAMBU;
            m_Rigidbody.gravityScale = 0;

        }
    }

    public void LifeChange()
    {
        if(m_LifeState == ELifeStates.LIVE)
        {
            m_LifeState = ELifeStates.DEAD;
        }
        else
        {
            m_LifeState = ELifeStates.LIVE;
        }
    }

    //============================HORIZONTAL MOVEMENT==============================================//
    void Left()
    {
        m_PlayerPosition.JumpLeft();
    }

    void Right()
    {
        m_PlayerPosition.JumpRight();
    }

    public void JumpLeft()
    {
        SetYinJump();
        ToggleState();
        transform.rotation = new Quaternion(0, 0, 0, 0);
        ResetSpeed();
        m_Rigidbody.AddForce(new Vector2(-9.8f, 3.0f), ForceMode2D.Impulse);
    }

    public void JumpRight()
    {
        SetYinJump();
        ToggleState();
        transform.rotation = new Quaternion(0, 180, 0, 0);
        ResetSpeed();
        m_Rigidbody.AddForce(new Vector2(9.8f, 3.0f), ForceMode2D.Impulse);

    }

    public void TurnLeft()
    {
        transform.rotation = new Quaternion(0,180,0,0);
        transform.position = new Vector2(m_Holder.position.x,transform.position.y);

    }

    public void TurnRight()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
        transform.position = new Vector2(m_Holder.position.x,transform.position.y);


    }
    void ResetSpeed()
    {
        m_Rigidbody.velocity = new Vector2(0, 0);
    }
    void SetYinJump()
    {
        m_YinJump = transform.position.y; //+ m_Rigidbody.velocity.y/Physics2D.gravity.magnitude;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_PlayerState == EPlayerStates.ONAIR && collision.gameObject == m_Holder.gameObject)
        {
            transform.position = new Vector3(collision.gameObject.transform.position.x,m_YinJump);
            m_Rigidbody.velocity = new Vector2(0, 0);
            ToggleState();
        }
    }
    public void ChangePosition(IPlayerPosition pos)
    {
        m_PlayerPosition = pos;
    }

    public void SetHolder(int h)
    {
        m_Holder = m_HolderPoints.GetHoldPoint(h);
    }
    //=======================================================================================//
}
