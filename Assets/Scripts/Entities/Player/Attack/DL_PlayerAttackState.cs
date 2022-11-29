// ReSharper disable All
using UnityEngine;

public class DL_PlayerAttackState : DL_State<DL_PlayerBrain>
{
    #region Methods
    
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateUpdate(animator, stateInfo, layerIndex);

        if (!brain.Attack.IsAttacking)
        {
            brain.FSM.SetBool(DL_FsmParams.IS_ATTACKING, false);
        }
    }
    
    #endregion
}