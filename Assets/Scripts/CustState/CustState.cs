using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using myStateMachine;

enum enBehaviorState
{
    Idle,
    Green,
    Yellow,
    Red,
}

public class CustState : MonoBehaviour
{
    public StateMachine _myBehaviorStateMachine;

    public Image cooldown;
    public float timer;
    public float mTimer;
    public float nowTime;
    public Text timerString;
    public Stopwatch sw = new Stopwatch();
    public bool coolingdown;
    public static float startTime = 0;

    private void OnEnable()
    {
        setTime();
        startTime = mTimer;
        cooldown.fillAmount = 1.0f;
        setProgressBar();

        //  StartBehaviorStateMachine();
        // _myBehaviorStateMachine._currentState.myGameobject = this.gameObject;

        //  _myBehaviorStateMachine._currentState.nowTime = nowTime;
    }
    private void OnDisable()
    {
        sw.Stop();
        sw.Reset();

    }

    // Use this for initialization
    void Start()
    {
    
        //     
        StartBehaviorStateMachine();
        
        //     setTime();
    }

    // Update is called once per frame


    void Update()
    {

        UpdateBehaviorStateMachine();

        setProgressBar();
    }

    void setProgressBar()
    {
        if (coolingdown == true)
        {
            cooldown.fillAmount -= 1.0f / timer * Time.deltaTime;
            nowTime = (mTimer - (sw.ElapsedMilliseconds * 0.001f));

            timerString.text = nowTime.ToString("F") + "s";
            if (nowTime <= 0.0f)
            {
                coolingdown = false;
            }
        }
    }

    void setTime()
    {
        coolingdown = true;
        timer = Random.Range(30f, 40f);
        mTimer = timer;
        timerString.text = timer.ToString();

        nowTime = mTimer - (sw.ElapsedMilliseconds * 0.001f);

        sw.Start();
    }

    private void StartBehaviorStateMachine()
    {

        _myBehaviorStateMachine = new StateMachine();

        //idle
        _myBehaviorStateMachine.AddState((int)enBehaviorState.Idle, new BehaviorState_Idle(gameObject, _myBehaviorStateMachine));

        // Green
        _myBehaviorStateMachine.AddState((int)enBehaviorState.Green, new BehaviorState_Green(gameObject, _myBehaviorStateMachine));
        // Yellow
        _myBehaviorStateMachine.AddState((int)enBehaviorState.Yellow, new BehaviorState_Yellow(gameObject, _myBehaviorStateMachine));
        // Red
        _myBehaviorStateMachine.AddState((int)enBehaviorState.Red, new BehaviorState_Red(gameObject, _myBehaviorStateMachine));


        //first state

        _myBehaviorStateMachine.GotoState((int)enBehaviorState.Idle);


    }

    private void UpdateBehaviorStateMachine()
    {
        _myBehaviorStateMachine._currentState.nowTime = nowTime;

        _myBehaviorStateMachine.OnTick();
    }
}
