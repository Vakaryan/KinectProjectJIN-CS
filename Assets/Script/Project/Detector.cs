using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector : MonoBehaviour {

    int framecount;
    public int framesWated;
    
    public Skeleton frame;

    Skeleton memory;

    SwipeRight move;

    private void Start()
    {
        frame = new Skeleton();
        frame.body = GetComponent<KinectPointController>().Spine.transform;
        frame.leftElbow = GetComponent<KinectPointController>().Elbow_Left.transform;
        frame.leftHand = GetComponent<KinectPointController>().Hand_Left.transform;
        frame.leftShoulder = GetComponent<KinectPointController>().Shoulder_Left.transform;
        frame.leftWrist = GetComponent<KinectPointController>().Wrist_Left.transform;
        frame.neck = GetComponent<KinectPointController>().Shoulder_Center.transform;
        frame.rightElbow = GetComponent<KinectPointController>().Elbow_Right.transform;
        frame.rightHand = GetComponent<KinectPointController>().Hand_Right.transform;
        frame.rightShoulder = GetComponent<KinectPointController>().Shoulder_Right.transform;
        frame.rightWrist = GetComponent<KinectPointController>().Wrist_Right.transform;

        memory = new Skeleton();
        memory.body = new GameObject().transform;
        memory.leftElbow = new GameObject().transform;
        memory.leftHand = new GameObject().transform;
        memory.leftShoulder = new GameObject().transform;
        memory.leftWrist = new GameObject().transform;
        memory.neck = new GameObject().transform;
        memory.rightElbow = new GameObject().transform;
        memory.rightHand = new GameObject().transform;
        memory.rightShoulder = new GameObject().transform;
        memory.rightWrist = new GameObject().transform;

        move = new SwipeRight();
        Debug.Log("coucou");
    }



    // Update is called once per frame
    void Update ()
    {
        memory.body.position += frame.body.position;
        memory.leftElbow.position += frame.leftElbow.position;
        memory.leftHand.position += frame.leftHand.position;
        memory.leftShoulder.position += frame.leftShoulder.position;
        memory.leftWrist.position += frame.leftWrist.position;
        memory.neck.position += frame.neck.position;
        memory.rightElbow.position += frame.rightElbow.position;
        memory.rightHand.position += frame.rightHand.position;
        memory.rightShoulder.position += frame.rightShoulder.position;
        memory.rightWrist.position += frame.rightWrist.position;

        if (framecount < framesWated)
        {
            framecount++;
        }
        else
        {
            memory.body.position /= framesWated;
            memory.leftElbow.position /= framesWated;
            memory.leftHand.position /= framesWated;
            memory.leftShoulder.position /= framesWated;
            memory.leftWrist.position /= framesWated;
            memory.neck.position /= framesWated;
            memory.rightElbow.position /= framesWated;
            memory.rightHand.position /= framesWated;
            memory.rightShoulder.position /= framesWated;
            memory.rightWrist.position /= framesWated;
            framecount = 0;
            if(move.verify(memory))
            {
                Debug.Log("Detected magle !");
            }
        }
	}
}
