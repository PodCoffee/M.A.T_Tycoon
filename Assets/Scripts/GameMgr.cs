using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour
{

    public GameObject customers;
    public Texture[] cusMat;
    public Transform[] points;
    public static bool[] pointsBool;
    public int idx;
    public static int cIdx;
    public int maxcustomer = 5;
    public float createTime;
    public bool isGameOver = false;
    public static GameObject customer;
    public static int PlayTime;
    private UnityEngine.UI.Text playPanel;
    public float  playScore = 0;
    public List<GameObject> customerPool = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        points = GameObject.Find("CustomerPoint").GetComponentsInChildren<Transform>();
        pointsBool = new bool[6];
        for (int i = 0; i < 6; i++)
        {
            pointsBool[i] = false;
        }

        for (int i = 0; i < maxcustomer; i++)
        {
            idx = Random.Range(0, 7);

            if (idx == 7)
                idx = 6;
           
            customer = (GameObject)Instantiate(customers);
            customer.GetComponentInChildren<Renderer>().material.mainTexture = cusMat[idx];


            customer.name = "customer_" + i.ToString();
            customer.SetActive(false);
            customerPool.Add(customer);
        }

        if (points.Length > 0)
        {
            StartCoroutine(this.CreateCustomers());
        }
        PlayTime = 300;
        StartCoroutine(PlayTimer());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addScore(float score)
    {
        playScore += score;
    }
    IEnumerator CreateCustomers()
    {
        /*
         * 손님 컨트롤할때 제품 줬다고 돈받고 디스트로이 시키면 안됨, 커스터머 캐릭터 SetActive(false) 하고 해당 pointsBool[idx]값 false로 해주면
         * 알아서 주기적으로 생성됨/ 주기가 너무 길어..ㅠ
         * */
        while (!isGameOver)
        {
            //  createTime = Random.Range(10.0f, 31.0f);

            yield return new WaitForSeconds(1f);

            if (isGameOver) yield break;

            foreach (GameObject customer in customerPool)
            {
                if (!customer.activeSelf)
                {

                    idx = Random.Range(0, 7);

                    if (idx == 7)
                        idx = 6;
                    customer.GetComponentInChildren<Renderer>().material.mainTexture = cusMat[idx];


                    cIdx = Random.Range(1, points.Length);

                    if (pointsBool[cIdx] == true)
                    {
                       for(int i = 1; i < 6; i++)
                        {
                            if (pointsBool[cIdx] == false)
                            {
                                cIdx = i;
                                break;
                            }
                        }
                    }

                    if (pointsBool[cIdx] == false)
                    {

                        customer.GetComponent<Customer>().mynum = cIdx;
                        customer.transform.position = points[cIdx].transform.localPosition;
                        customer.SetActive(true);

                        pointsBool[cIdx] = true;
                    }
                    break;
                }
            }
        }
    }

    /////////////////오브젝트풀링 집으로 돌아가고 다른 손님 불러오게 만들기
    public void goHome(GameObject custom, int num)
    {
        Debug.Log("집갈께");
        pointsBool[num] = false;
        custom.SetActive(false);

    }
    IEnumerator PlayTimer()
    {
        while (true)
        {
            playPanel = GameObject.Find("PlayTime").GetComponent<UnityEngine.UI.Text>();
            PlayTime -= 1;
            playPanel.text = playScore.ToString() +"<color=#00ff00>" + PlayTime + "</color>";
            if (PlayTime <= 0)
            {
                SceneManager.LoadScene("Title");
            }
            yield return new WaitForSeconds(1);
        }
    }
}




