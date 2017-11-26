using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterGame : MonoBehaviour
{

    private FadeInOut m_FadeInOut;

    private void Start()
    {
        m_FadeInOut = this.gameObject.GetComponent<FadeInOut>();
        
    }

    public void OnEnterGame()
    {
        StartCoroutine(m_FadeInOut.FadeOut());
    }

}
