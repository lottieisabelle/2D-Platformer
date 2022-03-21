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

        if(GameManager.passwords.Contains(user_input)){
            // get index of password in list
            index = GameManager.passwords.IndexOf(user_input);
        
            // indexes are in order and the same as the level IDs list

            // get scene ID of level
            sceneID = GameManager.levelSceneIDs[index];

            // load scene
            SceneManager.LoadScene(sceneID);

            
        } else {
            // if invalid show text on screen
            invalidMessage.text = "Code invalid. Please try again.";
        }
    }
    
}
