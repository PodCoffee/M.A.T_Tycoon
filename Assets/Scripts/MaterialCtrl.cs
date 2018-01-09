using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialCtrl : MonoBehaviour {
    public GameObject Metarials;
    public GameObject Vegetables;
    public int Count = 5;

    private Vector3 VegePos;
    private GameObject noew;
    // Use this for initialization
    void Start () {
        //this.gameObject.SetActive(false);
        Vegetables = GameObject.FindGameObjectWithTag("Vegetables");
	}
	
	// Update is called once per frame
	void Update () {
    }
    void OnMouseDown()
    {
        noew =  Instantiate(Metarials,this.transform.position,Metarials.transform.rotation);
        Count -= 1;
        noew.transform.SetParent(Vegetables.transform);   
    }
    void OnMouseDrag()
    {
        Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        point.y = 5f;
        noew.transform.position = point;
        VegePos = new Vector3(point.x, 9f, point.z + 2);
        noew.transform.position = Vector3.MoveTowards(noew.transform.position, VegePos, 100.0f);
        Debug.Log("드래그드랙드랙듥듥듥");
    }
}
