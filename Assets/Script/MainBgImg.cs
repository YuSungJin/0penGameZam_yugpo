using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainBgImg : MonoBehaviour
{


    [SerializeField]
    private Image BgImg;

    [SerializeField]
    private float loopSec = 1.5f;

    public Sprite map1;
    public Sprite map2;


    public static int cntFrame = 0;
    public static int cntFram2 = 0;
    private int indxMap = 0;
    private const int FPS = 60;

    public static bool bStopLoop = false;

    

	void Update ()
    {
        ///ㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠ
        ///
        GameObject Temp = GameObject.Find("Treeimg");
        RectTransform TreeImg = null; 

        if(Temp != null)
            TreeImg= Temp.gameObject.GetComponent<RectTransform>();

        if (TreeImg != null && TreeImg.sizeDelta.x >= 300)
            bStopLoop = true;
        //ㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠㅠ

        if (!bStopLoop)
        {


            if (TreeImg != null)
            {
                TreeImg.sizeDelta = new Vector2(30 + cntFram2, 40 + cntFram2);

                TreeImg.localPosition = new Vector3(0, 100 - cntFram2 / 1.5f, 0);
            }

            if ((float)cntFrame / (float)FPS >= loopSec)
            {
                cntFrame = 0;

                if (indxMap == 0)
                    indxMap = 1;
                else
                    indxMap = 0;
            }


            switch (indxMap)
            {
                case 0:
                    BgImg.sprite = map1;
                    break;
                case 1:
                    BgImg.sprite = map2;
                    break;
            }

            cntFrame++;

            cntFram2++;
        }

        

    }


    public void SetStopLoop(bool value)
    {

        bStopLoop = value;

    }
}
