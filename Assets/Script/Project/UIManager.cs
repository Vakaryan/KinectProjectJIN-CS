using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text[] UI_texts;
    public float displayTimeWhenDetected;
    private bool[] statesTab;
    public GameObject mainLoopObject;

    // text[0] -> swipe right
    // text[1] -> swipe left 
    // text[2] -> swipe up
    // text[3] -> punch
    // text[4] -> run

    private void Start()
    {
        statesTab = new bool[mainLoopObject.GetComponent<Detector>().gestureNumber];
    }

    private void LateUpdate()
    {
        statesTab = mainLoopObject.GetComponent<Detector>().states;
        for(int i = 0; i < statesTab.Length; i++)
        {
            switch (statesTab[i])
            {
                case false: //nothing detected
                    UI_texts[i].color = Color.red;
                    break;

                case true: //something has been detected 
                    UI_texts[i].color = Color.green;
                    StartCoroutine("waiter",i);
                    break;

            }
        }
    }


    IEnumerator waiter(int id)
    {
        yield return new WaitForSeconds(displayTimeWhenDetected);
        mainLoopObject.GetComponent<Detector>().states[id] = false;
    }

	

}
