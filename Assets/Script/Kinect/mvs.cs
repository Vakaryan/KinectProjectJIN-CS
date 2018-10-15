using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvs : MonoBehaviour {
    public GameObject right_hand;
    protected Vector3 real_pos;
    protected Vector3 virtual_pos;
    public int scale;

	// Use this for initialization
	void Start () {
        real_pos = right_hand.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        real_pos = right_hand.transform.position;
        virtual_pos = scale * real_pos;
	}
}
