using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeCtrl : MonoBehaviour {

    [Header("Tree Info")]
    public Image Treeimg; //나무 이미지
    public string Treename; //나무 이름
    public int Treelv; //나무 레벨
    public int Treehp; //나무 체력


	void Start () {
        Treeimg = GetComponentInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {

        if(Treehp<=0)
        {
            Die();
        }

	}


    void Die()
    {
        Debug.Log("TreeDie");
    }

    public void SetTreeUI() //트리 UI 설정
    {

    }

    public void HitTree(int damage) //나무 클릭(데미지)
    {
        Treehp -= damage;
        HpBar.fillAmount -= (float)damage / Treehp;

    }
}
