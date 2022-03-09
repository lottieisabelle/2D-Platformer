using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingController : MonoBehaviour
{
    public bool setting;
    [SerializeField] public string settingID;

    // off button
    [SerializeField] public GameObject off;
    // on button 
    [SerializeField] public GameObject on;

    // Start is called before the first frame update
    void Start()
    {
        if(settingID == "ButtonLabels"){
            setting = GameManager.buttonLabels;
        }

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

    void Update()
    {
        if(settingID == "ButtonLabels"){
            GameManager.buttonLabels = setting;
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
        } else {
            // change to on
            off.GetComponent<Image>().enabled = false;
            on.GetComponent<Image>().enabled = true;
            setting = true;
        }
    }
}
