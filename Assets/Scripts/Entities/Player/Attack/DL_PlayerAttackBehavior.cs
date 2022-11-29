// ReSharper disable All

using System;
using UnityEngine;

public class DL_PlayerAttackBehavior : DL_AttackBehavior
{
    #region Fields
    
    [SerializeField, ]    
    
    #endregion
        
    #region Properties

    public bool IsAttacking => false;

    #endregion
 
    #region Methods

    // Engine methods
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
        }
    }

    // Custom methods


    #endregion
}