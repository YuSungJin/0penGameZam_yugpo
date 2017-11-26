using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour {

    public Text Days;
    public Text Money;
    public Text UpdateAxeName;
    public Text UpdateAxeCost;

    public Sprite Axe1ImgSource;
    public Sprite Axe2ImgSource;
    public Sprite Axe3ImgSource;

    public Sprite Wow;

    public Sprite BuyButtonSource;
    public Sprite ActiveButtonSource;

    public Image EqAxeImg;
    public Image UpdateAxeImg;

    public Image BufferOneImg;
    public Image BufferTwoImg;
    public Image BufferThrImg;
    public Image BufferFourImg;

    private StaticMemberManager m_StaticMember = null;


    private void InitDays()
    {
        if (m_StaticMember != null)
        {
            if (Days != null )
                Days.text = m_StaticMember.Days.ToString() + " 일차";
            
        }
    } 

    private void UpdateMoney()
    {
        if (Money != null)
            Money.text = m_StaticMember.Money.ToString();
    }


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

    private void InitUpdateAxeZone()
    {
        if (m_StaticMember != null)
        {
            if (Axe1ImgSource != null && Axe2ImgSource != null && Axe3ImgSource != null 
                && Wow != null)
            {
                if (m_StaticMember.EquipAxeIndex == 0)
                {
                    UpdateAxeImg.sprite = Axe2ImgSource;
                    UpdateAxeName.text = "은도끼";
                    UpdateAxeCost.text = "4000";
                }
                else if (m_StaticMember.EquipAxeIndex == 1)
                {
                    UpdateAxeImg.sprite = Axe3ImgSource;
                    UpdateAxeName.text = "금도끼";
                    UpdateAxeCost.text = "15000";
                }
                else
                {
                    UpdateAxeImg.sprite = Wow;
                    UpdateAxeName.text = "채찍";
                    UpdateAxeCost.text = "40000";
                }
            }
        }
    }

    private void UpdateAxeZone()
    {
        if (m_StaticMember != null)
        {
            if (Axe1ImgSource != null && Axe2ImgSource != null && Axe3ImgSource != null
                && Wow != null)
            {
                if (m_StaticMember.EquipAxeIndex == 0)
                {
                    if (m_StaticMember.Money < 4000)
                        return;

                    UpdateAxeImg.sprite = Axe3ImgSource;
                    UpdateAxeName.text = "금도끼";
                    UpdateAxeCost.text = "15000";


                    m_StaticMember.Money -= 4000;

                    m_StaticMember.EquipAxeIndex++;
                    UpdateMoney();
                    InitEqAxe();
                    
                }
                else if (m_StaticMember.EquipAxeIndex == 1)
                {

                    if (m_StaticMember.Money < 15000)
                        return;

                    UpdateAxeImg.sprite = Wow;
                    UpdateAxeName.text = "채찍";
                    UpdateAxeCost.text = "40000";

                    m_StaticMember.Money -= 15000;

                    m_StaticMember.EquipAxeIndex++;
                    UpdateMoney();
                    InitEqAxe();
                    
                }
                else if (m_StaticMember.EquipAxeIndex == 2)
                {
                    if (m_StaticMember.Money < 40000)
                        return;

                    UpdateAxeImg.sprite = Wow;
                    UpdateAxeName.text = "채찍";
                    UpdateAxeCost.text = "40000";


                    m_StaticMember.Money -= 40000;

                    m_StaticMember.EquipAxeIndex++;
                    UpdateMoney();
                    InitEqAxe();
                    
                }
            }
        }
    }

    private void Awake()
    {
        m_StaticMember = (StaticMemberManager)GameObject.Find("StaticMemberManager").
                            gameObject.GetComponent< StaticMemberManager>();
    }

    // Use this for initialization
    void Start ()
    {
		if(m_StaticMember != null)
        {

            UpdateMoney();

            InitUpdateAxeZone();

            InitEqAxe();

            InitDays();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void BufferOneActive()
    {

        

        if (m_StaticMember != null)
        {
            if (m_StaticMember.Money < 4000 )
                return;

            if ((m_StaticMember.Buffer & Convert.ToByte("1000", 2)) == Convert.ToByte("1000", 2))
                return;

            if (BufferOneImg != null && ActiveButtonSource != null)
                BufferOneImg.sprite = ActiveButtonSource;

            m_StaticMember.Buffer = (byte)(m_StaticMember.Buffer | Convert.ToByte("1000", 2));
            m_StaticMember.Money -= 4000;

            UpdateMoney();

        }
    }


    public void BufferTwoActive()
    {
        if (m_StaticMember != null)
        {
            if (m_StaticMember.Money < 2500)
                return;

            if ((m_StaticMember.Buffer & Convert.ToByte("0100", 2)) == Convert.ToByte("0100", 2))
                return;

            if (BufferTwoImg != null && ActiveButtonSource != null)
                BufferTwoImg.sprite = ActiveButtonSource;

            m_StaticMember.Buffer = (byte)(m_StaticMember.Buffer | Convert.ToByte("0100", 2));
            m_StaticMember.Money -= 2500;

            UpdateMoney();
        }
    }


    public void BufferThrActive()
    {
        if (m_StaticMember != null)
        {
            if (m_StaticMember.Money < 5000)
                return;

            if ((m_StaticMember.Buffer & Convert.ToByte("0010", 2)) == Convert.ToByte("0010", 2))
                return;

            if (BufferThrImg != null && ActiveButtonSource != null)
                BufferThrImg.sprite = ActiveButtonSource;

            m_StaticMember.Buffer = (byte)(m_StaticMember.Buffer | Convert.ToByte("0010", 2));
            m_StaticMember.Money -= 5000;

            UpdateMoney();
        }
    }

    public void BufferFourActive()
    {
        if (m_StaticMember != null)
        {
            if (m_StaticMember.Money < 1000)
                return;

            if ((m_StaticMember.Buffer & Convert.ToByte("0001", 2)) == Convert.ToByte("0001", 2))
                return;

            if (BufferFourImg != null && ActiveButtonSource != null)
                BufferFourImg.sprite = ActiveButtonSource;

            m_StaticMember.Buffer = (byte)(m_StaticMember.Buffer | Convert.ToByte("0001", 2));
            m_StaticMember.Money -= 1000;

            UpdateMoney();
        }
    }


    public void UpdateAXe()
    {
        if (m_StaticMember != null)
        {

            if (m_StaticMember.EquipAxeIndex >= 3)
                return;

            

            UpdateAxeZone();

            
        }
    }





}
