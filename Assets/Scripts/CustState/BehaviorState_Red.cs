using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using myStateMachine;

public class BehaviorState_Red : myState {

    public BehaviorState_Red(GameObject _myOwner, StateMachine _myStateMachine)
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
        
        if (nowTime <= 0)
        {
            
            _myStateMachine.GotoState((int)enBehaviorState.Idle);
            GameMgr.pointsBool[_myOwner.GetComponent<Customer>().mynum] = false;
            _myOwner.SetActive(false);
            // Debug.Log(myGameobject);
            
           // GameObject.Find("GameManager").GetComponent<GameMgr>().goHome(myGameobject, myGameobject.GetComponent<Customer>().mynum);

            return true;
        }
        return false;
    }
    private void redState()
    {
        // 조금 화난 말풍선 펑펑펑퍼퍼ㅓ퍼러러렁ㅇ
    }
}
