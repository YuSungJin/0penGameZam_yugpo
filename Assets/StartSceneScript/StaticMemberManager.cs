﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMemberManager : MonoBehaviour
{


    public int Money = 0;
    public int Days = 0;
    public int SizeOfHungryGauge = 0;
    public int EquipAxeIndex = 0;



    private void Awake()
    {
        DontDestroyOnLoad(this);
    }


}
