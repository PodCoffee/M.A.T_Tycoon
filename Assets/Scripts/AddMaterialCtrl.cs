using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;
using System.Diagnostics;
using System.Linq;

public class AddMaterialCtrl : MonoBehaviour {
    public GameObject Materials;
    public Stopwatch sw = new Stopwatch();
    public int addTime = 5;
    public MaterialCtrl[] Counts;
    // Use this for initialization
    void Start () {
        sw.Start();
        Counts = Materials.GetComponentsInChildren<MaterialCtrl>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (sw.ElapsedMilliseconds * 0.001f >= addTime)
        {
            for (var i = 0; i < Counts.Length; i++)
            {
                Counts[i].Count += 1;
            }
            sw.Reset();
            sw.Start();
            Debug.Log("재료생성");
        }
        //Debug.Log("타이머" + sw.ElapsedMilliseconds * 0.001f);

    }
}
