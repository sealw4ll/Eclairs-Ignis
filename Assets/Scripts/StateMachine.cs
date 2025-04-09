using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State state;

    public void Set(State newState, bool forceReset = false) {
        if (state != newState || forceReset) {
            state?.Exit();
            state = newState;
            state?.Initalize();
            state?.Enter();
        }
    }

    public void clearMachine()
    {
        state?.Exit();
        state = null;
    }

    public List<State> GetActiveStateBranch(List<State> list = null)
    {
        if (list == null)
        {
            list = new List<State>();
        }

        if (state == null)
        {
            return list;
        } else
        {
            list.Add(state);
            return state.machine.GetActiveStateBranch(list);
        }
    }
}