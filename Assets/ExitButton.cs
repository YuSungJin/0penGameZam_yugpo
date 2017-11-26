using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{

    [SerializeField]
    private Canvas PopupCanvas;

    [SerializeField]
    private Image EnterImage;

    private void Awake()
    {
        if (PopupCanvas != null)
            PopupCanvas.gameObject.SetActive(false);
    }

    public void OnClickExitButton()
    {
        if (PopupCanvas != null)
            PopupCanvas.gameObject.SetActive(false);

        if (EnterImage != null)
            EnterImage.raycastTarget = true;
    }
}
