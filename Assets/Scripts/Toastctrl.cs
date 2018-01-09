using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Toastctrl : MonoBehaviour {
    public toast startto;
    // Use this for initialization
    void Start() {
        startto = new basictoast();

    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            for (int i = 0; i < startto.tolist.Count; i++)
            {
                Debug.Log(i.ToString()+"번쨰"+ startto.tolist[i]+"인덱"+ (Ingredient)(startto.tolist[i]));
            
            }
        }
    }
    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.tag.Equals("Doma"))
        {
            this.tag = "CreatedToast";
            this.transform.parent = null;
           
        }

       


    }
    public BoxCollider trigrBox;
    private void OnTriggerEnter(Collider coll)
    {
        if (this.tag.Equals("CreatedToast"))
        {
            if (coll.GetComponent<Transform>().tag.Equals("Customer") || coll.tag.Equals("CreatedToast"))
            {

            }
            else if (coll.GetComponentInParent<Transform>().parent.tag.Equals("Vegetables"))
            {
                Debug.Log("dd");
                coll.gameObject.transform.SetParent(this.transform);

                Destroy(coll.gameObject.GetComponent<Rigidbody>());

                BoxCollider colid = coll.GetComponent<BoxCollider>();

                trigrBox.center = colid.transform.localPosition;
                trigrBox.size.Set(trigrBox.size.x, trigrBox.size.y, trigrBox.size.z + colid.size.z);

                if (coll.tag.Equals(Ingredient.Bread.ToString()))
                {
                    new Bread(startto);
                }

                else if (coll.tag.Equals(Ingredient.Cheese.ToString()))
                {
                    new Cheese(startto);
                }

                else if (coll.tag.Equals(Ingredient.Egg.ToString()))
                {
                    new Egg(startto);
                }
                else if (coll.tag.Equals(Ingredient.Mushroom.ToString()))
                {
                    new Mushroom(startto);
                }
                else if (coll.tag.Equals(Ingredient.Salad.ToString()))
                {
                    new Salad(startto);
                }
                else if (coll.tag.Equals(Ingredient.Steak.ToString()))
                {
                    new Steak(startto);
                }
                else if (coll.tag.Equals(Ingredient.Tomato.ToString()))
                {
                    new Tomato(startto);
                }
                else if (coll.tag.Equals(Ingredient.UnSteak.ToString()))
                {
                    new UnSteak(startto);
                }



            }



        }
    }
}


public abstract class toast
{
    public List<int> tolist;
    public string name;
    public float cost;

}
public class basictoast : toast
{
    public basictoast()
    {
        tolist = new List<int>();
        tolist.Add((int)Ingredient.Bread);
        name = "Bread";
        cost = 100f;
    }

}
public class ingredi : toast
{
    public toast to;
    public ingredi(toast to)
    {
        this.to = to;
    }


}
public class Tomato : ingredi
{
    public Tomato(toast to) : base(to)
    {
        to.tolist.Add((int)Ingredient.Tomato);
        to.name += "Tomato";
        to.cost += 200;
        //Debug.Log(to.name);
    }

}

public class Salad:ingredi
{
    public Salad(toast to) : base(to)
    {
        to.tolist.Add((int)Ingredient.Salad);
        to.name += "Salad";
        to.cost += 200;
    }
}
public class Bread : ingredi
{
    public Bread(toast to) : base(to)
    {
        to.tolist.Add((int)Ingredient.Bread);
        to.name += "Bread";
        to.cost += 100;
    }
}
public class Mushroom : ingredi
{
    public Mushroom(toast to) : base(to)
    {
        to.tolist.Add((int)Ingredient.Mushroom);
        to.name += "Mushroom";
        to.cost += 100;
    }
}
public class Egg : ingredi
{
    public Egg(toast to) : base(to)
    {
        to.tolist.Add((int)Ingredient.Egg);
        to.name += "Egg";
        to.cost += 100;
    }
}

public class Steak : ingredi
{
    public Steak(toast to) : base(to)
    {
        to.tolist.Add((int)Ingredient.Steak);
        to.name += "Steak";
        to.cost += 100;
    }
}
public class UnSteak : ingredi
{
    public UnSteak(toast to) : base(to)
    {
        to.tolist.Add((int)Ingredient.UnSteak);
        to.name += "UnSteak";
        to.cost += 100;
    }
}


public class Cheese : ingredi
{
    public Cheese(toast to) : base(to)
    {
        to.tolist.Add((int)Ingredient.Cheese);
        to.name += "Cheese";
        to.cost += 100;
    }
}
/*        BoxCollider cc = gameObject.AddComponent<BoxCollider>();
        cc.center.Set(0, 0, 0);
        cc.isTrigger = true;
        cc.center = bc.transform.position;
        cc.size = bc.size;
        gameObject.GetComponent<BoxCollider>().enabled = false ;
        bc.enabled = false;
*/
