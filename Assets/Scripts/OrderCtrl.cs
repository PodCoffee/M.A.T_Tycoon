using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCtrl : MonoBehaviour {
    public Transform visionPoint;
    public GameObject[] vetables;
    private Customer mycustom;
    public float ypoint = 0;

    // Use this for initialization
    void Start() {
        mycustom = GetComponent<Customer>();
        visionPoint = GameObject.FindGameObjectWithTag("VisionPoint").GetComponent<Transform>();
	}
    public Transform[] Child;
    private void OnMouseDown()
    {

        Child = visionPoint.GetComponentsInChildren<Transform>();
        if (visionPoint.childCount >= 2)
        {
            foreach(Transform ga in Child)
            {
                if (!ga.Equals(visionPoint))
                {
                    Destroy(ga.gameObject);
                    ypoint = 0;
                }
                
            }
        }
        for (int i = 0; i < mycustom.wishlist.Count; i++)
        {
            drawVegtable(mycustom.wishlist[i]);
       }

    }
    
    // Update is called once per frame
    void Update () {
		
	}
    void drawVegtable(int vegenum)
    {
        GameObject vege = Instantiate(vetables[vegenum],visionPoint.position+visionPoint.forward * -ypoint,vetables[vegenum].transform.rotation);
        vege.transform.localScale = Vector3.one*5f ;
        ypoint += 0.5f;
        vege.transform.SetParent(visionPoint.transform);

    }
  
}
