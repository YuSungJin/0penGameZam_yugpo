using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    FadeInOut pScriptTempObject;
    Animation pThisButtonAni;


    private StaticMemberManager m_StaticMember = null;

    private void StartGame()
    {
        pThisButtonAni.Stop();
        StartCoroutine(pScriptTempObject.FadeOut());
    }



    private void Awake()
    {
        pScriptTempObject = GetComponent<FadeInOut>();
        pThisButtonAni = this.GetComponent<Animation>();

        m_StaticMember = (StaticMemberManager)GameObject.Find("StaticMemberManager").
                            gameObject.GetComponent<StaticMemberManager>();
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.G))
        {
            if (m_StaticMember != null)
            {
                m_StaticMember.Days = 9;
                m_StaticMember.Money = 1000000;
            }
        }

        if (Input.anyKeyDown)
            StartGame();
        
    }

    public void OnClickButton()
    {
        StartGame();
    }
}
