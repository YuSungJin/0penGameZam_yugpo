using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {
    public static GameMgr instance = null; //싱글턴
    public GameObject[] TreeObj; //나무 오브젝트
    public Transform TreeArea; //나무 생성 위치
    public Transform TreeDatas; //안쓰는 나무 모임
    public GameObject PlayerUI; //플레이어 UI


    private int treenum = -1;

    void Awake()
    {
        if(instance==null)
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
        StartGame();
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
        
        treenum = Random.Range(0, 7);
        TreeObj[treenum].transform.SetParent(TreeArea);
        TreeObj[treenum].GetComponent<TreeCtrl>().SetTree();
        TreeObj[treenum].SetActive(true);
    }

    public void ResetTree() //나무 재생성
    {
        TreeObj[treenum].gameObject.SetActive(false);
        TreeObj[treenum].transform.SetParent(TreeDatas);

        //StartCoroutine(LoadTree());
        Debug.Log("End Load");
        //CreateTree();
    }

    IEnumerator LoadTree()
    {
        Debug.Log("Reset Tree...");
        yield return new WaitForSeconds(3.0f);
        yield break;
    }
    
}
