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


	void Start () {

    }


    void Update () {

        if(TreeHp<=0)
        {
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
    }

    public void HitTree(int damage) //나무 클릭(데미지)
    {
        TreeHp -= damage;
        TreeUi.SetHpBar(damage);
        GameMgr.instance.PlayerSet();
    }
}
