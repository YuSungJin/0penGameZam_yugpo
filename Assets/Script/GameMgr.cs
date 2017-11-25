using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {
    public static GameMgr instance = null; //싱글턴
    public GameObject[] TreeObj; //나무 오브젝트
    public GameObject TreeArea; //나무 생성 위치

    void Awake()
    {
        if(instance==null)
        {
            instance = this;
        }
    }



	public void CreateTree() //나무 생성
    {
        int rand = Random.Range(0, 7);
        Instantiate(TreeObj[rand]);
        TreeObj[rand].transform.SetParent(TreeArea.transform);
        TreeObj[rand].SetActive(true);
    }

    
}
