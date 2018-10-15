using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class TraceData : MonoBehaviour
{
    StreamWriter writer;

    // Use this for initialization
    void Start()
    {
        string fileName = "Trace.txt";
        writer = new StreamWriter(fileName);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<KinectPointController>().isTracked)
        {
            writer.WriteLine("x :" + transform.position.x + "; y :" + transform.position.y + "; z :" + transform.position.z + "; time : " + Time.deltaTime);
        }
    }


    void OnDestroy()
    {
        writer.Close();
    }
}
