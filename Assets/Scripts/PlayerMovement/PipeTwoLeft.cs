using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTwoLeft :IPlayerPosition
{

    PlayerMovement m_PlayerMovement;
    int m_HolderLeft = 1;
    int m_HolderRight = 3;


    public PipeTwoLeft(PlayerMovement p)
    {
        m_PlayerMovement = p;
    }

    public void JumpLeft()
    {
        m_PlayerMovement.SetHolder(m_HolderLeft);
        m_PlayerMovement.JumpLeft();
        m_PlayerMovement.ChangePosition(new PipeOneRight(m_PlayerMovement));
    }

    public void JumpRight()
    {
        m_PlayerMovement.SetHolder(m_HolderRight);
        m_PlayerMovement.TurnRight();
        m_PlayerMovement.ChangePosition(new PipeTwoRight(m_PlayerMovement));
    }
}
