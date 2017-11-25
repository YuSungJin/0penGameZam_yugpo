using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    FadeInOut pScriptTempObject;
    Animation pThisButtonAni;


    private void StartGame()
    {
        pThisButtonAni.Stop();
        StartCoroutine(pScriptTempObject.FadeOut());
    }



    private void Awake()
    {
        pScriptTempObject = GetComponent<FadeInOut>();
        pThisButtonAni = this.GetComponent<Animation>();
    }


    private void Update()
    {
        if(Input.anyKeyDown)
            StartGame();
        


        
    }

    public void OnClickButton()
    {
        StartGame();
    }
}
