using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty {

    static float secondsToMaxDiff = 90;

    public static float GetDifficultyPercent() {
        //return 1;
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDiff);
    }

}

	
