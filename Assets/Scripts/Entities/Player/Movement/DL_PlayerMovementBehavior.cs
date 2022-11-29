// ReSharper disable All
using UnityEngine;

public class DL_PlayerMovementBehavior : DL_MovementBehavior
{
    #region Fields

    [SerializeField, Header("Player movement values")]
    private LayerMask groundLayer = 0;
    
    #endregion

    #region Methods
    
    // Engine methods
    override protected void Update()
    {
        base.Update();
        
        if (Input.GetMouseButton(0))
        {
            DL_CursorManager.Instance?.Interact<Transform>(groundLayer, SetTargetPosition);
        }
    }

    // Custom methods
    private void SetTargetPosition(Transform _targetTransform)
    {
        targetPosition = _targetTransform.position;
    }
    protected override void MoveToTarget()
    {
        base.MoveToTarget();
        
        if (animator)
        {
            animator.SetFloat(DL_AnimParams.PLAYER_MOVEMENT_SPEED, agent.velocity.magnitude);
        }
    }

    #endregion
}