using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour {
    [Header("UI Objects")]
    public Image HungryBar;
    public Text HungryText;
    public Image Weapon;
    public Image AmountBar; //할당량
    public Text AmountText; //할당량(텍스트)

    [Header("Player Ability")]
    private float hungry;
    public int amount;

    private GameObject TreeObj;


    public static int plrhungry = 100;
    public static int kill = 0;

    private int iCheckAll = 10;

    private StaticMemberManager m_StaticMember = null;


    private void Awake()
    {
        m_StaticMember = (StaticMemberManager)GameObject.Find("StaticMemberManager").
                            gameObject.GetComponent<StaticMemberManager>();

        if (m_StaticMember != null)
        {
            hungry = m_StaticMember.SizeOfHungryGauge;

            if ((m_StaticMember.Buffer & System.Convert.ToByte("0001", 2)) == System.Convert.ToByte("0001", 2))
                iCheckAll = 5;

            if ((m_StaticMember.Buffer & System.Convert.ToByte("0100", 2)) == System.Convert.ToByte("0100", 2))
            {
                hungry += 30;
                plrhungry = m_StaticMember.SizeOfHungryGauge + 30;
            }
        }
        amount = iCheckAll;
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAbility(float h, int a)
    {
        //plrhungry = (int)h;
        //amount = a;
        AmountBar.fillAmount = 0;
        AmountText.text = "0/" + amount.ToString();
        HungryText.text = plrhungry.ToString() + hungry.ToString();
    }

    public void DownHungry()
    {
        plrhungry --;
        HungryBar.fillAmount -= 1f / hungry;
        HungryText.text = plrhungry.ToString() + "/" + hungry.ToString();
    }

    public void AddAmount()
    {
        if (kill >= iCheckAll)
            return;





        kill++;
        AmountBar.fillAmount += 1f / amount;
        AmountText.text = kill.ToString() + "/" + amount.ToString();
    }

}
