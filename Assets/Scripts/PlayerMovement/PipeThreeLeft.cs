using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeThreeLeft : IPlayerPosition {

    PlayerMovement m_PlayerMovement;
    int m_HolderLeft = 3;
    int m_HolderRight = 5;


    public PipeThreeLeft(PlayerMovement p)
    {
        m_PlayerMovement = p;
    }

    public void JumpLeft()
    {
        m_PlayerMovement.SetHolder(m_HolderLeft);
        m_PlayerMovement.JumpLeft();
        m_PlayerMovement.ChangePosition(new PipeTwoRight(m_PlayerMovement));
    }

    public void JumpRight()
    {
        m_PlayerMovement.SetHolder(m_HolderRight);
        m_PlayerMovement.TurnRight();
        m_PlayerMovement.ChangePosition(new PipeThreeRight(m_PlayerMovement));
    }
    
}
