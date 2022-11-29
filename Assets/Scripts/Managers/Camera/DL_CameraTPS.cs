// ReSharper disable All

using System;
using UnityEngine;
using CustomLibraryRuntime.CustomMathLibrary;

public class DL_CameraTPS : MonoBehaviour
{
    #region Fields

    [SerializeField, Header("Camera values")]
    private DL_CameraSettings settings = new DL_CameraSettings();

    #endregion


    #region Methods

    // Engine methods
    private void LateUpdate()
    {
        if (settings.IsValidTarget)
        {
            MoveToTarget();
            RotateToTarget();
        }
    }
    
    // Custom methods
    private void MoveToTarget()
    {
        if (!settings.CanMove) return;
        transform.position = Vector3.MoveTowards(settings.CurrentPosition, settings.TargetPosition + settings.Offset, settings.MoveSpeed * Time.deltaTime);
    }
    private void RotateToTarget()
    {
        if (!settings.CanRotate) return;
        transform.rotation = GetRotation();
    }
    private Quaternion GetRotation()
    {
        Vector3 _lookPosition = settings.TargetPosition + settings.LookAtOffset - settings.CurrentPosition;
        if (_lookPosition == Vector3.zero) return Quaternion.identity;
        Quaternion _newRotation = Quaternion.LookRotation(_lookPosition);
        return Quaternion.RotateTowards(settings.CurrentRotation, _newRotation, settings.RotateSpeed * Time.deltaTime);
    }

    #endregion
}