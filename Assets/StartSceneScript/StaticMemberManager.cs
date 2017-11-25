using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMemberManager : MonoBehaviour
{


    private long lMoney = 0;
    public long Money { get { return lMoney; } set { lMoney = value; } }

    private int iDays = 0;
    public int Days {  get { return iDays; } set { iDays = value; } }

    private int iSizeOfHungryGauge = 0;
    public int SizeOfHungryGauge {  get { return iSizeOfHungryGauge; } set { iSizeOfHungryGauge = value; } }



    private int iEquipAxeIndex = 0;
    public int EquipAxeIndex { get { return iEquipAxeIndex; } set { iEquipAxeIndex = value; } }


    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


}
