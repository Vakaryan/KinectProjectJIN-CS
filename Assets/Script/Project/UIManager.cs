using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    public Text[] UI_texts;
    public int displayTimeWhenDetected;
    private int[] statesTab;
    public GameObject mainLoopObject;

    // text[0] -> swipe right
    // text[1] -> swipe left 
    // text[2] -> swipe up
    // text[3] -> punch
    // text[4] -> run

    private void Update()
    {
        //statesTab = mainLoopObject.getComponent<MainLoop>().states;
        for(int i = 0; i < UI_texts.Length; i++)
        {
            switch (statesTab[i])
            {
                case -1: //nothing detected
                    UI_texts[i].color = Color.red;
                    break;

                case 0: //something is being detected
                    UI_texts[i].color = Color.yellow;
                    break;

                case 1: //something has been detected 
                    UI_texts[i].color = Color.green;
                    StartCoroutine("waiter");
                    UI_texts[i].color = Color.red;
                    break;

            }
        }
    }


    IEnumerator waiter()
    {
        yield return new WaitForSeconds(displayTimeWhenDetected);
    }

	

}
