using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move {

    public float linearTolerance;

    protected class State
    {
        public ElementalMove move;
        public float minimalDistanceX = 0f;
        public float maximalDistanceX = 0f;
        public float minimalDistanceY = 0f;
        public float maximalDistanceY = 0f;
        public float minimalDistanceZ = 0f;
        public float maximalDistanceZ = 0f;
        public bool validated = false;
        public void validate() { validated = true; }
        public void unvalidate() { validated = false; }
    }

    protected List<State> states; 

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
        for (int i = 0; i < states.Count; i++)
        {
            states[i].unvalidate();
        }
        currentState = 0;
    }

}
