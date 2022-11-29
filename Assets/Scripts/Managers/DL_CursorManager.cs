// ReSharper disable All
using UnityEngine;
using CustomLibraryRuntime.Managers.Singleton;
using System;

public class DL_CursorManager : Singleton<DL_CursorManager>
{
    #region Fields

    [SerializeField, Header("Cusror values"), Range(0.0f, 100.0f)]
    private float depth = 20.0f;
    
    [SerializeField]
    private Camera render = null;

    private Ray ray;
    
    #endregion
        
    #region Properties

    private Vector3 MousePosition => Input.mousePosition;
    
    #endregion
        
    #region Methods
    
    // Engine methods
    private void Start()
    {
        if (!render)
        {
            render = GetComponent<Camera>();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(ray.origin, ray.direction * depth);
        Gizmos.DrawCube(ray.direction * depth, Vector3.one);
    }

    // Custom methods
    public void Interact<T>(LayerMask _layer, Action<T> _callback)
    {
        if (!render) return;
        
        Ray _ray = render.ScreenPointToRay(MousePosition);
        ray = _ray;
        bool _hasHit = Physics.Raycast(_ray, out RaycastHit _result, depth, _layer);
        
        if (_hasHit)
        {
            T _data = _result.collider.gameObject.GetComponent<T>();
            _callback?.Invoke(_data);
        }
    }
    
    #endregion
}