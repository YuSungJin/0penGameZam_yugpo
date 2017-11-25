using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{



    public void OnClickButton()
    {


        FadeInOut pScriptTempObject = GetComponent<FadeInOut>();
        StartCoroutine(pScriptTempObject.FadeOut());


        //SceneManager.LoadScene("MainGame");
    }
}
