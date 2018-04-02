using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeOneRight :IPlayerPosition
{

    PlayerMovement m_PlayerMovement;
    int m_HolderLeft = 0;
    int m_HolderRight = 2;

    public PipeOneRight(PlayerMovement p)
    {
        m_PlayerMovement = p;
    }

    public void JumpRight()
    {
        m_PlayerMovement.SetHolder(m_HolderRight);
        m_PlayerMovement.JumpRight();
        m_PlayerMovement.ChangePosition(new PipeTwoLeft(m_PlayerMovement));

    }

    public void JumpLeft()
    {
        m_PlayerMovement.SetHolder(m_HolderLeft);
        m_PlayerMovement.TurnLeft();
        m_PlayerMovement.ChangePosition(new PipeOneLeft(m_PlayerMovement));

    }


}
