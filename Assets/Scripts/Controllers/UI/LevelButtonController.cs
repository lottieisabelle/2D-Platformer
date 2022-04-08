using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonController : MonoBehaviour
{
    [SerializeField] public Sprite _locked;

    void Start()
    {
        int numLevels = GameManager.levelSceneIDs.Count;
        int numLevelButtons = this.transform.childCount;

        // for all level buttons
        for(int i = 0; i < numLevelButtons; i++)
        {
            // to prevent level select screen from breaking when not all buttons lead to a level (yet) - bc there aren't that many levels
            if((i+1)>numLevels){
                this.transform.GetChild(i).GetComponent<ButtonClick>().sceneID = 0;    
            } else {
                this.transform.GetChild(i).GetComponent<ButtonClick>().sceneID = GameManager.levelSceneIDs[i];
            }
            
            // set sprite to locked if level is locked
            if((i+1) <=  GameManager.maxLevel || (i+1) == 1){
                this.transform.GetChild(i).GetComponent<Image>().sprite = this.transform.GetChild(i).GetComponent<ButtonClick>()._default;
                this.transform.GetChild(i).GetComponent<ButtonClick>().isLocked = false;
            } else {
                this.transform.GetChild(i).GetComponent<Image>().sprite = _locked;
                this.transform.GetChild(i).GetComponent<ButtonClick>().isLocked = true;
            }
        }

    }

}

