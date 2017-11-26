using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeCtrl : MonoBehaviour {

    [Header("TreeInfo")]
    public int Level; //나무의 레벨
    public int Hp; //나무의 채력(데이터 기록용)
    public string Name; //나무의 이름
    public Sprite Img; //나무의 이미지

    [Header("Demo Btn")]
    public GameObject Btn;

    [Header("Tree UI")]
    public TreeUICtrl TreeUi; //나무 UI(레벨,이름,채력바)

    [Header("Tree")]
    public Image TreeImg; //나무의 이미지 컴포넌트
    public int TreeHp; //나무의 채력(실제로 닳는)


    
    private int damage = 5;
    private StaticMemberManager m_StaticMember = null;


    RectTransform TreeImgRect = null; 


    private void Awake()
    {
        m_StaticMember = (StaticMemberManager)GameObject.Find("StaticMemberManager").
                            gameObject.GetComponent<StaticMemberManager>();
        TreeImgRect = TreeImg.gameObject.GetComponent<RectTransform>();

        if (m_StaticMember != null)
        {
            if (m_StaticMember.EquipAxeIndex == 0)
                damage = 5;
            else if (m_StaticMember.EquipAxeIndex == 1)
                damage = 15;
            else if (m_StaticMember.EquipAxeIndex == 2)
                damage = 30;
            else
                damage = 50;


            if ((m_StaticMember.Buffer & System.Convert.ToByte("1000", 2)) == System.Convert.ToByte("1000", 2))
                damage += (int)(damage * 0.1);

            
        }



    }

    void Start ()
    {

    }


    void Update () {

        if(TreeHp<=0)
        {
            if (m_StaticMember != null)
            {
                if (Level == 1)
                    m_StaticMember.Money += Random.Range(20, 40);
                else if (Level == 2)
                    m_StaticMember.Money += Random.Range(40, 60);
                else if (Level == 3)
                    m_StaticMember.Money += Random.Range(60, 80);
                else if (Level == 4)
                    m_StaticMember.Money += Random.Range(200, 300);
                else if (Level == 5)
                    m_StaticMember.Money += Random.Range(300, 400);
                else if (Level == 6)
                    m_StaticMember.Money += Random.Range(400, 500);
                else if (Level == 7)
                    m_StaticMember.Money += Random.Range(1000, 2000);
                else if (Level == 8)
                    m_StaticMember.Money += Random.Range(10000, 40000);
            }



            GameMgr.instance.AddScore();
            Die();
        }

	}


    public void Die() //사망
    {
        Btn.SetActive(true);
        Debug.Log("TreeDie");
        TreeUi.ResetUi();
        GameMgr.instance.ResetTree();
    }

    public void SetTree() //나무 로드
    {
        Btn.SetActive(false);
        TreeImg.sprite = Img;
        TreeUi.SetUI(Level, Name, Hp);
        TreeUi.gameObject.SetActive(true);
    }

    public void HpReset()
    {
        TreeHp = Hp;
        TreeImgRect.sizeDelta = new Vector2(10, 10);
    }

    public void HitTree( ) //나무 클릭(데미지)
    {
        TreeHp -= damage;
        TreeUi.SetHpBar(damage);
        GameMgr.instance.PlayerSet();
    }
}
