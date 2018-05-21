using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour {

    private IState currRun;
    private IState prevState;

    public void ChangeState(IState newState)
    {
        if (this.currRun != null)
        {
            this.currRun.Exit();
        }

        this.prevState = this.currRun;
        this.currRun = newState;
        this.currRun.Enter(); // state do not change because the enter is missing, try implement .Execute here!
    }

    public void ExecuteStateUpdate()
    {
        var runState = currRun;
        if(runState !=null)
        {
            runState.Execute();
        }
    }

    public void SwitchToPrevS()
    {
        this.currRun.Exit();
        this.currRun = this.prevState;
        this.currRun.Execute();
    }

}
