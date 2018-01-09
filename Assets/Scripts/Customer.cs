using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Ingredient
{
    Bread =0,Egg,Salad,Steak,UnSteak,Tomato,Cheese, Mushroom,empty=-1,complete=-2
}

public class Customer : MonoBehaviour {
    public int ingredientnum;//재료 개수를 가지고 있는 변수
    public List<int> wishlist;//어떤 재료를 가지고 있을지 정할 변수
    public float satisfaction;
    public Ingredient inde ;
    public int mynum=0;
    // Use this for initialization
    private void OnEnable()
    {
        startcler();
    }
    void startcler()
    {
        satisfaction = 0;
        wishlist.Clear();
        ingredientnum = Random.Range(1, 8);
        
        wishlist.Add((int)Ingredient.Bread);

        for (int i = 0; i < ingredientnum; i++)
        {

            inde = (Ingredient)Random.Range(0, System.Enum.GetValues(typeof(Ingredient)).Length - 2);
            if (inde == (Ingredient.UnSteak)||inde == (Ingredient.Tomato) )
            {
                continue;
            }
            wishlist.Add((int)inde);

        }

        wishlist.Add((int)Ingredient.Bread);


    }
    void Start () {
       /*
        ingredientnum = Random.Range(1, 8);
        Debug.Log("빵제외 재료개수" + ingredientnum);
        wishlist.Add((int)Ingredient.Bread);

         for(int i = 0; i < ingredientnum; i++)
         {
            
           inde = (Ingredient)Random.Range(0, System.Enum.GetValues(typeof(Ingredient)).Length-2);
            if (inde == (Ingredient.UnSteak))
            {
                continue;
            }
             wishlist.Add((int)inde);

         }

        wishlist.Add((int)Ingredient.Bread);
        
        for(int i = 0; i < wishlist.Count; i++)
        {
            Debug.Log(i.ToString()+"번째"+((Ingredient)wishlist[i]).ToString()+" index:"+ wishlist[i]);
        }*/
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
    private void OnCollisionEnter(Collision coll)
{

        if (coll.collider.tag.Equals("CreatedToast"))
        {//완성된 토스트가 Boxcollider에 트리거되며 마우스 버튼이 안눌렸을때 발동: 원하는 재료의 위치와
         //만든위치가 같다면 (100/재료개수)+1 의 만족도를 주어줌->만족도(satisfaction)는 최종에 100을 안넘게 셋팅
            float satisrate = (100 / wishlist.Count)+1;
            Toastctrl created = coll.collider.GetComponent<Toastctrl>();
            for(int i = 0;i< wishlist.Count; i++)//첫번째로 모든위치가 맞는지 확인
            {
                if(i > created.startto.tolist.Count-1)
                {
                    break;
                }
              
                if (wishlist[i].Equals(created.startto.tolist[i]))
                {
                    satisfaction += satisrate;
                    wishlist[i] = (int)Ingredient.complete;
                    created.startto.tolist[i] = (int)Ingredient.empty;
                }
            }
            for(int i = 0; i < wishlist.Count; i++)//위치가 안맞는 재료의 만족도 점수 기본만족도비율 점수/2
            {
                for(int j = 0; j < created.startto.tolist.Count; j++)
                {
                    if (wishlist[i].Equals(created.startto.tolist[j]))
                    {
                        satisfaction += satisrate;
                        created.startto.tolist[j] = (int)Ingredient.empty;
                        wishlist[i] = (int)Ingredient.complete;
                        break;
                    }
                }
            }
            for(int i = 0; i < created.startto.tolist.Count; i++)//재료가 아예틀린건 만족도 점수 -시킴
            {
                if (!(created.startto.tolist[i].Equals((int)Ingredient.empty)))
                {
                    satisfaction -= satisrate;
                }
            }
            if(satisfaction > 100)
            {
                satisfaction = 100f;
            }
            GameMgr gam = GameObject.Find("GameManager").GetComponent<GameMgr>();
            Debug.Log("만족도" + satisfaction);
            gam.addScore(satisfaction);
            Destroy(coll.gameObject);
            gam.goHome(this.gameObject,mynum);
            

        }
    }
}
