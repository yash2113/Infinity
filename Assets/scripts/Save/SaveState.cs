using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class SaveState
{



    [NonSerialized] private const int HAT_COUNT = 3666;

    public int HighScore { get; set; }
    public int Fish { get; set; }
    public DateTime LastSaveTime { get; set; }
    public int CurrentHatIndex { get; set; }
    public byte[] UnlockedHatFlag { get; set; }

    
    public SaveState()
    {
        HighScore = 0;
        Fish = 0;
        LastSaveTime = DateTime.Now;
        CurrentHatIndex = 0;
        UnlockedHatFlag = new byte[64];//new byte[HAT_COUNT];
        UnlockedHatFlag[0] = 1;
    }

}
