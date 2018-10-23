using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {
    public Text[] UI_texts;
    public float displayTimeWhenDetected;
    private bool[] statesTab;
    public GameObject mainLoopObject;
    public Text playerDetectedTest;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }
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
                    StartCoroutine("waiter", i);
                    if (i == 5)
                    {
                        ReturnToMainMenu();
                    }
                    break;
            }
        }

        if(mainLoopObject.GetComponent<Detector>().isPlayerDetected == false)
        {
            playerDetectedTest.color = Color.red;
        }
        else
        {
            playerDetectedTest.color = Color.clear;
        }
    }


    IEnumerator waiter(int id)
    {
        yield return new WaitForSeconds(displayTimeWhenDetected);
        mainLoopObject.GetComponent<Detector>().states[id] = false;
    }

	public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

}
