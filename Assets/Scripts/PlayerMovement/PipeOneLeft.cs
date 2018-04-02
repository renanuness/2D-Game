using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeOneLeft : IPlayerPosition {

    PlayerMovement m_PlayerMovement;
    int m_HolderRight = 1;

    public PipeOneLeft(PlayerMovement p)
    {
        m_PlayerMovement = p;
    }
    private void Start()
    {
    }

    public void JumpRight()
    {
        m_PlayerMovement.SetHolder(m_HolderRight);
        m_PlayerMovement.TurnRight();
        m_PlayerMovement.ChangePosition(new PipeOneRight(m_PlayerMovement));
    }

    public void JumpLeft()
    {
    }


}
