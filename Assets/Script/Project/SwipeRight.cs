using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeRight : Move {





	// Use this for initialization
	override protected void Start ()
    {
		
	}

    public override bool verify(Skeleton currentPose)
    {

        if (states[currentState].move.verify(lastPose.rightWrist, currentPose.rightWrist))
        {
            states[currentState].validated = true;
            if (currentState == states.Length -1)
            {
                reinitialize();
                return true;
            }

        }
        if(states[currentState].validated && states[currentState +1].move.verify(lastPose.rightWrist, currentPose.rightWrist))
        {
            currentState++;
        }





        return false;
    }

}
