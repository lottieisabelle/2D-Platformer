using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelController : MonoBehaviour
{
    [SerializeField] public string levelName;
    [SerializeField] public int levelNumber;
    [SerializeField] public TextMeshProUGUI password;
    
    private int NextLevelSceneID;

    [SerializeField] public LayerMask blockLayer;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask boxLayer;
    [SerializeField] public LayerMask boxHeldLayer;
    [SerializeField] public LayerMask wallLayer;
    [SerializeField] public LayerMask buttonLayer;

    public List<int> boxOrder = new List<int>();
    public int numBoxes;

    public bool hasObstacles;

    void Start()
    {
        numBoxes = this.transform.GetChild(4).childCount;

        if(levelNumber > GameManager.maxLevel){
            GameManager.maxLevel = levelNumber;
        }
        // wait used to prevent errors when testing
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        // wait for 1 second
        yield return new WaitForSeconds(1);
        // tutorial levels have level number 0, and don't have/need level codes
        if(levelNumber > 0){
            // display level code
            password.text = "Level code: " + GameManager.passwords[levelNumber-1];
        }
    }

    public void nextLevel()
    {
        int lastLevel = GameManager.levelSceneIDs.Count;

        if(levelNumber == 0){
            // tutorials have level number 0
            if(levelName == "Tutorial1"){
                NextLevelSceneID = 6;
            } else if(levelName == "Tutorial2"){
                NextLevelSceneID = 7;
            } else if(levelName == "Tutorial3"){
                NextLevelSceneID = 48;
            } else {
                NextLevelSceneID = GameManager.levelSceneIDs[levelNumber];
            }
        } else if(levelNumber == lastLevel) {
            // last level goes to completion page
            NextLevelSceneID = 4;
        } else {
            // all other levels go to next level 
            NextLevelSceneID = GameManager.levelSceneIDs[levelNumber];
            // level numbers start at 1, indexes start at 0 so call automatically gets the next level
        }

        SceneManager.LoadScene(NextLevelSceneID);
    }

    public void getBoxIDs()
    {
        numBoxes = this.transform.GetChild(4).childCount;
        boxOrder.Clear();

        for(int i = 0; i < numBoxes; i++){
            boxOrder.Add(this.transform.GetChild(4).GetChild(i).GetComponent<BoxController>().boxID);
        }
    }
}
