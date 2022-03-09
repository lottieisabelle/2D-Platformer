using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    //[SerializeField] public GameObject GameManager;
    public bool setting;

    // off button
    [SerializeField] public GameObject off;
    // on button 
    [SerializeField] public GameObject on;

    // Start is called before the first frame update
    void Start()
    {
        setting = GameManager.buttonLabels;
        //GameManager.setting = setting;
        //setting = GameManager.GetComponent<GameManager>().buttonLabels;

        if(setting)
        {
            // set as on
            off.GetComponent<Image>().enabled = false;
            on.GetComponent<Image>().enabled = true;
        } else {
            // set as off
            off.GetComponent<Image>().enabled = true;
            on.GetComponent<Image>().enabled = false;
        }
    }

    public void changeSetting()
    {
        if(setting)
        {
            // change to off
            off.GetComponent<Image>().enabled = true;
            on.GetComponent<Image>().enabled = false;
            setting = false;
            GameManager.buttonLabels = false;
        } else {
            // change to on
            off.GetComponent<Image>().enabled = false;
            on.GetComponent<Image>().enabled = true;
            setting = true;
            GameManager.buttonLabels = true;
        }
    }
}
