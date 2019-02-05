using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty {

    //static variable set to the seconds until max difficulty.
    static float secondsToMaxDiff = 60;

    //Calculates the difficulty and returns the value
    public static float GetDifficultyPercent() {
        //Performs a clamp calculation on the time since level load and seconds to max difficulty.
        return Mathf.Clamp01(Time.timeSinceLevelLoad / secondsToMaxDiff);
    }

}

	
