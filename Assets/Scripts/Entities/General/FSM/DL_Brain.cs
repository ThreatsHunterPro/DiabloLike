// ReSharper disable All
using UnityEngine;

public abstract class DL_Brain : MonoBehaviour
{
    #region Properties

    public bool IsValidFSM => FSM;
    public Animator FSM { get; } = null;

    #endregion
        
    #region Methods
    
    protected virtual void InitBrain<State, Brain>() where State : DL_State<Brain>, new() where Brain : DL_Brain
    {
        if (!IsValidFSM) return;
        DL_State<Brain>[] _states = FSM.GetBehaviours<State>();
        
        int _statesCount = _states.Length;
        for (int _stateIndex = 0; _stateIndex < _statesCount; _stateIndex++)
        {
            _states[_stateIndex].InitState(this);
        }
    }
    
    #endregion
}