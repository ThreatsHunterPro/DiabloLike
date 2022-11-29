// ReSharper disable All

using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(DL_PlayerMovementBehavior))]
public class DL_PlayerBrain : DL_Brain
{
    #region Fields
    
    [SerializeField, Header("Player brain values")]
    private DL_PlayerMovementBehavior movement = null;

    [SerializeField]
    private DL_PlayerAttackBehavior attack = null;
    
    #endregion

    #region Properties

    private bool IsValidBehaviours => movement;
    public DL_PlayerAttackBehavior Attack => attack;

    #endregion

    #region Methods

    // Engine methods
    private void Start() => InitBrain<DL_PlayerMovementState, DL_PlayerBrain>();

    // Custom methods
    protected override void InitBrain<FSM_State, Brain>()
    {
        if (!IsValidBehaviours)
        {
            movement = GetComponent<DL_PlayerMovementBehavior>();
            attack = GetComponent<DL_PlayerAttackBehavior>();
        }
        
        base.InitBrain<FSM_State, Brain>();
    }

    #endregion
}