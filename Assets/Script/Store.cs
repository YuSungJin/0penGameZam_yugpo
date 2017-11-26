using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
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

    public void OnClickEnterGame()
    {
        if (PopupCanvas != null)
            PopupCanvas.gameObject.SetActive(true);

        if (EnterImage != null)
            EnterImage.raycastTarget = false;
    }
}
