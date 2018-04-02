using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeTwoRight : IPlayerPosition
{

    PlayerMovement m_PlayerMovement;
    public int m_HolderLeft = 2;
    public int m_HolderRight = 4;


    public PipeTwoRight(PlayerMovement p )
    {
        m_PlayerMovement = p;
    }
    public void JumpLeft()
    {
        m_PlayerMovement.SetHolder(m_HolderLeft);
        m_PlayerMovement.TurnLeft();
        m_PlayerMovement.ChangePosition(new PipeTwoLeft(m_PlayerMovement));
    }

    public void JumpRight()
    {
        m_PlayerMovement.SetHolder(m_HolderRight);
        m_PlayerMovement.JumpRight();
        m_PlayerMovement.ChangePosition(new PipeThreeLeft(m_PlayerMovement));
    }
}
