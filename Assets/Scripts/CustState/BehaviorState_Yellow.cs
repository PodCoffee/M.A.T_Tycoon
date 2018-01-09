
using myStateMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorState_Yellow : myState {

    public BehaviorState_Yellow(GameObject _myOwner, StateMachine _myStateMachine)
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
        if (nowTime < (CustState.startTime * 0.2))
        {
           
            _myStateMachine.GotoState((int)enBehaviorState.Red);
            return true;
        }
        return false;
    }
    private void yellowState()
    {
        // 조금 화난 말풍선 펑펑펑퍼퍼ㅓ퍼러러렁ㅇ
    }
}
