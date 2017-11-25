using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class FadeInOut : MonoBehaviour
{

    private Color m_FadeInOutColor;

    public Image m_Image;
    public float fFadeTime;
    public float fWaitTime;

    public bool bLoadScene;
    public string strLoadSceneName = null;

    void Start()
    {
        m_Image.gameObject.SetActive(false);
        m_FadeInOutColor = new Color(0f, 0f, 0f, 1f);
        m_Image.color = m_FadeInOutColor;
    }

    public IEnumerator FadeIn()
    {
        m_Image.gameObject.SetActive(true);

        float elapsedTime = 0f;

        while (elapsedTime < fFadeTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            m_FadeInOutColor.a = 1.0f - Mathf.Clamp01(elapsedTime / fFadeTime);
            m_Image.color = m_FadeInOutColor;
        }
    }

    public IEnumerator FadeOut()
    {
        m_Image.gameObject.SetActive(true);

        float elapsedTime = 0f;

        yield return new WaitForSeconds(fWaitTime);

        while (elapsedTime < fFadeTime)
        {
            yield return new WaitForEndOfFrame();
            elapsedTime += Time.deltaTime;
            m_FadeInOutColor.a = Mathf.Clamp01(elapsedTime / fFadeTime);
            m_Image.color = m_FadeInOutColor;
        }

        if (bLoadScene)
        {
            if (strLoadSceneName != null)
                Application.LoadLevel(strLoadSceneName);
        }
    }
}