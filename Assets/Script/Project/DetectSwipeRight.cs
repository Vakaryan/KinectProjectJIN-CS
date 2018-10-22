using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectSwipeRight : MonoBehaviour {

    public GameObject rightHand;
    public GameObject rightShoulder;
    public float moveRange;

    private bool[] states;
    private int idState;
    private bool isGesturePossible;
    private float prevPosX;
    private float curPosX;
    private float dist;
    private float originX;

    private bool gestureDone;




    // Use this for initialization
    void Start() {
        idState = -1;
        states = new bool[] { false, false, false, false };
        // [isMovingRight, hasReachedRange, isMovingLeft, hasReachedBackOrigin]
        prevPosX = rightShoulder.transform.position.x;
        dist = 0f;
        originX = rightShoulder.transform.position.x;
	}


    private void Update()
    {
        SwipeRight(rightHand.transform.position);        
    }


    void SwipeRight(Vector3 movePos)
    {

        states = new bool[] { (curPosX > prevPosX), (dist >= moveRange), (curPosX < prevPosX), (curPosX <= originX) };
        // [isMovingRight, hasReachedRange, isMovingLeft, hasReachedBackOrigin]
        curPosX = movePos.x;


        switch (idState)
        {

            //gesture hasn't started
            case -1: 
                if (curPosX > prevPosX)
                {
                    states[idState + 1] = true;
                    dist = curPosX - originX;
                    idState++;
                }
                else
                {
                    ResetValues();
                }
                break;



            //right hand moving to the right
            case 0: 
                if (states[idState])
                {
                    if (dist >= moveRange)
                    {
                        states[idState + 1] = true;
                        dist = curPosX - originX;
                        idState++;
                    }
                }
                else
                {
                    ResetValues();
                }
                break;


            //right hand moving back to the left
            case 1:
                if (states[idState] && curPosX < prevPosX)
                {
                    states[idState + 1] = true;
                    idState++;
                }
                else
                {
                    ResetValues();
                }
                break;


            //right hand back to origin
            case 2:
                if (states[idState])
                {
                    if(curPosX <= originX)
                    {
                        gestureDone = true;
                        Debug.Log("Swipe right");
                    }
                }
                else
                {
                    ResetValues();
                }
                break;
        }

        prevPosX = curPosX;
    }



    void ResetValues()
    {
        idState = -1;
        states = new bool[] { false, false, false, false };
        // [isMovingRight, hasReachedRange, isMovingLeft, hasReachedBackOrigin]
        dist = 0f;
        gestureDone = false;
        prevPosX = rightShoulder.transform.position.x;
        dist = 0f;
        originX = rightShoulder.transform.position.x;
    }


    /*
    IEnumerator ShowDetection()
    {

    }
    */

}
