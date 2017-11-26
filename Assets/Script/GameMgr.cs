
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {

    public Text Money;
    public static GameMgr instance = null; //싱글턴
    public GameObject[] TreeObj; //나무 오브젝트
    public Transform TreeArea; //나무 생성 위치
    public Transform TreeDatas; //안쓰는 나무 모임
    public GameObject PlayerUI; //플레이어 UI

    public Image EqAxeImg;

    public Image EnddImg;

    public Sprite Axe1ImgSource;
    public Sprite Axe2ImgSource;
    public Sprite Axe3ImgSource;

    public Sprite Wow;

    private FadeInOut m_FadeInOut;
    private StaticMemberManager m_StaticMember = null;

    private int day = 1;
    private int randIndx = 0;

    private int treenum = -1;

    private int iCheckAll = 10;

    private void InitEqAxe()
    {
        if (m_StaticMember != null)
        {
            if (Axe1ImgSource != null && Axe2ImgSource != null && Axe3ImgSource != null)
            {
                if (m_StaticMember.EquipAxeIndex == 0)
                    EqAxeImg.sprite = Axe1ImgSource;
                else if (m_StaticMember.EquipAxeIndex == 1)
                    EqAxeImg.sprite = Axe2ImgSource;
                else if (m_StaticMember.EquipAxeIndex == 2)
                    EqAxeImg.sprite = Axe3ImgSource;
                else
                    EqAxeImg.sprite = Wow;
            }
        }
    }


    void Awake()
    {

        m_StaticMember = (StaticMemberManager)GameObject.Find("StaticMemberManager").
                            gameObject.GetComponent<StaticMemberManager>();

        if(m_StaticMember != null)
        {
            day = m_StaticMember.Days;

            if (day <= 8)
                randIndx = day;
            else
                randIndx = 8;
            if ((m_StaticMember.Buffer & System.Convert.ToByte("0001", 2)) == System.Convert.ToByte("0001", 2))
                iCheckAll = 5;
        }

        if (instance==null)
        {
            instance = this;
        }
        foreach (GameObject tr in TreeObj)
        {
            tr.GetComponent<TreeCtrl>().HpReset();
            tr.SetActive(false);
        }
    }

    void Start()
    {
        m_FadeInOut = this.gameObject.GetComponent<FadeInOut>();
        InitEqAxe();
        StartGame();
    }

    bool bEnd = false;

    private void Update()
    {
        if (m_StaticMember != null)
            Money.text = m_StaticMember.Money.ToString();

        if (!bEnd && PlayerCtrl.plrhungry == 0)
        {
            bEnd = true;
            m_StaticMember.SizeOfHungryGauge -= 10;

            if (m_StaticMember != null)
                m_StaticMember.cntHungryFail++;

            if(PlayerCtrl.kill < iCheckAll)
                if (m_StaticMember != null)
                    m_StaticMember.cntAmountFail++;



            
            MoveHome();
        }
    }

    void StartGame()
    {
        PlayerUI.GetComponent<PlayerCtrl>().SetAbility(100,10);
        CreateTree();
    }

    public void AddScore()
    {
        PlayerUI.GetComponent<PlayerCtrl>().AddAmount();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1.0f);
    }

    public void MoveHome()
    {
        if (m_StaticMember.Days == 10 && EnddImg != null)
        {
            if(m_StaticMember.cntAmountFail >= 4)
            {
                EnddImg.gameObject.SetActive(true);
                EnddImg.color = new Color(1f, 0f, 0f, 0.75f);

                StartCoroutine(Wait());
                Application.Quit();
            }
            else
            {
                EnddImg.gameObject.SetActive(true);
                EnddImg.color = new Color(0f, 0f, 0f, 0.75f);

                StartCoroutine(Wait());
                Application.Quit();
            }
        }

        if (PlayerCtrl.kill < iCheckAll)
        {
            if (m_StaticMember != null)
                m_StaticMember.cntAmountFail++;
        }
        else if (PlayerCtrl.kill == iCheckAll)
            if (m_StaticMember != null)
                m_StaticMember.SizeOfHungryGauge += 10;


        if (m_StaticMember != null)
        {
            m_StaticMember.Buffer = System.Convert.ToByte("0000", 2);
            m_StaticMember.Days++;
        }

        PlayerCtrl.plrhungry = m_StaticMember.SizeOfHungryGauge;
        PlayerCtrl.kill = 0;
        StartCoroutine(m_FadeInOut.FadeOut());
    }

    public void PlayerSet()
    {
        PlayerUI.GetComponent<PlayerCtrl>().DownHungry();
    }

    public void SkipTree()
    {
        TreeObj[treenum].GetComponent<TreeCtrl>().Die();
        PlayerUI.GetComponent<PlayerCtrl>().DownHungry();
    }

	public void CreateTree() //나무 만들어서 배치
    {
        if (treenum != -1)
            TreeObj[treenum].GetComponent<TreeCtrl>().HpReset();
        
        treenum = Random.Range(0, randIndx);
        if (treenum >= 8)
            treenum = 7;

        TreeObj[treenum].transform.SetParent(TreeArea);
        TreeObj[treenum].GetComponent<TreeCtrl>().SetTree();
        TreeObj[treenum].SetActive(true);

        MainBgImg.bStopLoop = false;
        MainBgImg.cntFram2 = 0;
        MainBgImg.cntFrame = 0;
    }

    public void ResetTree() //나무 재생성
    {
        TreeObj[treenum].gameObject.SetActive(false);
        TreeObj[treenum].transform.SetParent(TreeDatas);

        //StartCoroutine(LoadTree());
        Debug.Log("End Load");
        //CreateTree();

        MainBgImg.bStopLoop = false;
        MainBgImg.cntFram2 = 0;
        MainBgImg.cntFrame = 0;
    }

    IEnumerator LoadTree()
    {
        Debug.Log("Reset Tree...");
        yield return new WaitForSeconds(3.0f);
        yield break;
    }
    
}
