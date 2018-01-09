using myStateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorState_Idle : myState {

    public BehaviorState_Idle(GameObject _myOwner, StateMachine _myStateMachine)
        :base (_myOwner, _myStateMachine)
    {

    }

    public override void OnBegin(myState previousState)
    {

    }

    public override void OnEnd(myState nextState)
    {

    }

    public override bool OnTick()
    {
       
        if (OnTransition() == true)
            return false;
        return true;
    }

    protected override bool OnTransition()
    {
   
        if (nowTime <= (CustState.startTime * 0.9)) { 
            
        _myStateMachine.GotoState((int)enBehaviorState.Green);
        return true;
    }
            return false;
    }
   private void moveIdle()
    {
        //빈둥빈둥
    }
}
