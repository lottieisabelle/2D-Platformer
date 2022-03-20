using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckLevelCode : MonoBehaviour
{
    [SerializeField] public TMP_InputField input;
    [SerializeField] public TextMeshProUGUI invalidMessage;

    private string user_input;
    private int index;
    private int sceneID;

    void Start()
    {
        invalidMessage.text = "";
    }

    public void verifyLevelCode()
    {
        user_input = input.text;

        if(GameManager.levelCodes.Contains(user_input)){
            Debug.Log("yes");
            // get index of password in list
            index = GameManager.levelCodes.IndexOf(user_input);
        
            // indexes are in order and the same as the level IDs list

            // get scene ID of level
            sceneID = GameManager.levelSceneIDs[index];

            // load scene
            SceneManager.LoadScene(sceneID);

            
        } else {
            // dialog box for invalid - or text on screen
            Debug.Log("no");
            invalidMessage.text = "Code invalid. Please try again.";
        }
    }
    
    /* 
    private string input;

    InputField iField;
    string myName;
    
    void MyFunction()
    {
        Debug.Log(iField.text);
        myName = iField.text;
        
        if (myName == "MattCarter")
        {
                Debug.Log("Welcome back Mr. Carter");
        }
        else
        {
            Debug.Log("I Don't Know You!");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void readInput(string s)
    {
        input = s;
    }
     */
}
