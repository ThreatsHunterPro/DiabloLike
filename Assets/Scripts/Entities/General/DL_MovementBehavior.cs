// ReSharper disable all
using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class DL_MovementBehavior : MonoBehaviour
{
    #region Fields

    [SerializeField, Header("Movement values")]
    private bool canMove = true;
    
    [SerializeField, Range(0.0f, 10.0f)]
    private float acceptableRange = 0.1f;

    [SerializeField]
    protected NavMeshAgent agent = null;

    [SerializeField]
    protected Animator animator = null;
    
    protected Vector3 targetPosition = Vector3.zero;

    #endregion

    #region Properties

    public bool IsAtLocation => Vector3.Distance(transform.position, targetPosition) < acceptableRange;
    private Vector3 Position
    {
        get => transform.position; 
        set => transform.position = value;
    }
    private Quaternion Rotation
    {
        get => transform.rotation; 
        set => transform.rotation = value;
    }
    
    #endregion

    #region Methods

    // Engine methods
    private void Start()
    {
        targetPosition = transform.position;
    }
    protected virtual void Update()
    {
        MoveToTarget();
    }

    // Custom methods
    protected virtual void MoveToTarget()
    {
        if (!canMove || !agent) return;
        agent.SetDestination(targetPosition);
    }

    #endregion
}