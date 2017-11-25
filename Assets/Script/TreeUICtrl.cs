using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeUICtrl : MonoBehaviour {
    public Text LvText;
    public Text NameText;
    public Image HpBar;
    public Text HpText;
    private float Hp;
    private int HpAmount;

    void Start()
    {

    }

	public void SetUI(int lv, string name,int hp)
    {
        LvText.text = "Lv. " + lv.ToString();
        NameText.text = name;
        Hp = (float)hp;
        HpAmount = hp;
        HpText.text = HpAmount.ToString() + "/" + Hp.ToString();
    }

    public void SetHpBar(int damage)
    {
        HpAmount -= damage;
        Debug.Log("Damage!");
        HpBar.fillAmount -= (float)damage / Hp;
        HpText.text = HpAmount.ToString() + "/" + Hp.ToString();
    }

    public void ResetUi()
    {
        HpBar.fillAmount = 1;
        this.gameObject.SetActive(false);
    }
    
}
