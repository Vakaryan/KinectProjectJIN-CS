using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectSwipeRight : MonoBehaviour {
    public GameObject rightWrist;
    public GameObject rightShoulder;
    public Text swipeRight_text;
    public int timerTextDetection;
    private bool gestureDetectedSR;
    public float minSwipeRange;
    private bool rangeReached;

    private bool movingToRight;
    private float diffX;

    private float[] posX;
    private Vector2 origin;
    public int nbPosX;





    // Use this for initialization
    void Start () {
        movingToRight = false;
        posX = new float[nbPosX];
        diffX = 0;
        origin.x = rightShoulder.transform.position.x;
        origin.y = rightShoulder.transform.position.y;
        rangeReached = false;

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void SwipeRightDetection()
    {
        posX[0] = rightWrist.transform.position.x;
        for(int i = 0; i<nbPosX; i++)
        {

        }
    }

    IEnumerator ShowDetection()
    {
        swipeRight_text.color = Color.green;
        yield return new WaitForSeconds(timerTextDetection);
        swipeRight_text.color = Color.red;
        rangeReached = false;
        gestureDetectedSR = false;
        posX = new float[nbPosX];
    }
}
