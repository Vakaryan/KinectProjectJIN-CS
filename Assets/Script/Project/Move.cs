using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    protected struct State
    {
        public ElementalMove move;
        public float minimalDistanceX;
        public float maximalDistanceX;
        public float minimalDistanceY;
        public float maximalDistanceY;
        public float minimalDistanceZ;
        public float maximalDistanceZ;
        public bool validated;

    }

    protected State[] states;

    protected int currentState = 0;

    protected Skeleton lastPose;
    


    // Use this for initialization
    virtual protected void Start () {
		
	}
	
	virtual public bool verify(Skeleton currentPose)
    {
        return false;
    }

    protected void reinitialize()
    {
        for (int i = 0; i < states.Length; i++)
        {
            states[i].validated = false;
        }
        currentState = 0;
    }

}
