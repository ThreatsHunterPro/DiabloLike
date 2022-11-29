// ReSharper disable all
using UnityEngine;

[System.Serializable]
public struct DL_CameraSettings
{
    #region Fields

    [SerializeField, Header("Settings values")]
    private bool canMove;
    
    [SerializeField]
    private bool canRotate;
    
    [SerializeField, Range(0.0f, 100.0f)]
    private float moveSpeed, rotateSpeed;
    
    [SerializeField]
    private Camera render;
    
    [SerializeField]
    private Transform target;
    
    [SerializeField, Header("Offsets")]
    private Vector3 offset;
    
    [SerializeField]
    private Vector3 lookAtOffset;

    #endregion

    #region Properties

    public bool IsValidCamera => render;
    public bool IsValidTarget => target;
    public bool CanMove => canMove;
    public bool CanRotate => canRotate;
    public float MoveSpeed => moveSpeed;
    public float RotateSpeed => rotateSpeed;
    public Vector3 Offset => offset;
    public Vector3 LookAtOffset => lookAtOffset;
    public Vector3 CurrentPosition => IsValidCamera ? render.transform.position : Vector3.zero;
    public Vector3 TargetPosition => IsValidCamera ? target.transform.position : Vector3.zero;
    public Quaternion CurrentRotation => IsValidCamera ? render.transform.rotation : Quaternion.identity;

    public Camera Camera => render;
    public Transform Target => target;
    
    #endregion

    #region Methods

    public void SetTarget(Transform _target) =>  target = _target;
    public void SetOffset(Vector3 _offset) => offset = _offset;

    #endregion
}