using System.Collections;
using System.Collections.Generic;
using myStateMachine;
using UnityEngine;
using myStateMachine;
using System;


public class BehaviorState_Green : myState {

    public BehaviorState_Green(GameObject _myOwner, StateMachine _myStateMachine)
        :base (_myOwner, _myStateMachine)
    {

    }

    public override void OnBegin(myState previousState)
    {
        Debug.Log("녹");
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
        if (nowTime < (CustState.startTime * 0.5))
        {
            
            _myStateMachine.GotoState((int)enBehaviorState.Yellow);
            return true;
        }
        return false;
    }
    private void greenState()
    {
        // 노말 말풍선 펑펑펑퍼퍼ㅓ퍼러러렁ㅇ
    }
}
