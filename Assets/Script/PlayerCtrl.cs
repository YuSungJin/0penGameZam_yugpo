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
    public float hungry;
    public int amount;

    private int plrhungry;
    private int kill = 0;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetAbility(float h, int a)
    {
        hungry = h;
        plrhungry = (int)h;
        amount = a;
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
        kill++;
        AmountBar.fillAmount += 1f / amount;
        AmountText.text = kill.ToString() + "/" + amount.ToString();
    }

}
