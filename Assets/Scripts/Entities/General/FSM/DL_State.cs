// ReSharper disable All
using UnityEngine;

public abstract class DL_State<T> : StateMachineBehaviour where T : DL_Brain
{
    #region Fields

    protected T brain = null;
    
    #endregion
        
    #region Properties

    public bool IsValidBrain => brain;

    #endregion
        
    #region Methods
    
    public void InitState(DL_Brain _brain)
    {
        brain = (T)_brain;
    }
    
    #endregion
}