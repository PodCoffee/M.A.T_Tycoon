using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Diagnostics;

public class VegetableCtrl : MonoBehaviour
{
    public float burnTimer = 15f;
    public Stopwatch sw = new Stopwatch();
    public GameObject Steak;
    private Vector3 mousePos;
    private Vector3 VegePos;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((sw.ElapsedMilliseconds * 0.001f).ToString() + "진행중");
        if (sw.ElapsedMilliseconds * 0.001f >= burnTimer)
        {
            GameObject steake= Instantiate(Steak, this.transform.position, Quaternion.identity);
            steake.GetComponent<Transform>().SetParent(this.gameObject.GetComponent<Transform>().parent);
            Debug.Log("고기다!" + Steak);
            Destroy(this.gameObject);
        }
    }

   void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.y = 5f;
        transform.position = point;
        VegePos = new Vector3(point.x, 9f, point.z+2);
        transform.position = Vector3.MoveTowards(transform.position, VegePos, 100.0f);
        Debug.Log("드래그드랙드랙듥듥듥");
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("탄다 타요");
        if (this.tag == "UnSteak" && other.gameObject.tag == "FryingPan")
        {
            Debug.Log("팬이다 팬");
            //StartCoroutine(TimerOn());
            sw.Start();
            Debug.Log((sw.ElapsedMilliseconds * 0.001f).ToString() + "시작");
        }
    }
    void OnCollisionExit(Collision other)
    {
        if (this.tag == "UnSteak" && other.gameObject.tag == "FryingPan")
        {
            Debug.Log("팬이다 팬");
            sw.Stop();
            Debug.Log((sw.ElapsedMilliseconds * 0.001f).ToString() + "멈춤");
        }
    }
}
