using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeThreeRight : IPlayerPosition
{

    PlayerMovement m_PlayerMovement;
    int m_HolderLeft = 4;

    public PipeThreeRight(PlayerMovement p)
    {
        m_PlayerMovement = p;
    }
    public void JumpLeft()
    {
        m_PlayerMovement.SetHolder(m_HolderLeft);
        m_PlayerMovement.TurnLeft();
        m_PlayerMovement.ChangePosition(new PipeThreeLeft(m_PlayerMovement));
    }

    public void JumpRight()
    {
        Debug.Log("Não pode");
    }
}
