using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basketball_Pause : MonoBehaviour
{
    public Sprite play;
    public Sprite pause;
    public Button images;
    public bool resumeCtrl = false;
    public void stopCtrl()
    {
        if (resumeCtrl == false)
        {
            Time.timeScale = 0f;
            resumeCtrl = true;
            images.GetComponent<Image>().sprite = play;
        }
        else
        {
            Time.timeScale = 1f;
            resumeCtrl = false;
            images.GetComponent<Image>().sprite = pause;
        }
    }
}