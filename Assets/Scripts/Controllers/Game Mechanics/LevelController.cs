using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] public string levelName;
    [SerializeField] public int levelNumber;
    
    private int NextLevelSceneID;

    [SerializeField] public LayerMask blockLayer;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask boxLayer;
    [SerializeField] public LayerMask boxHeldLayer;
    [SerializeField] public LayerMask wallLayer;
    [SerializeField] public LayerMask buttonLayer;

    public List<int> boxOrder = new List<int>();
    public int numBoxes;

    void Start()
    {
        numBoxes = this.transform.GetChild(4).childCount;

        if(levelNumber > GameManager.maxLevel){
            GameManager.maxLevel = levelNumber;
        }
        
    }

    public void nextLevel()
    {
        int max = GameManager.levelSceneIDs.Count;
        if(!(levelNumber == max)){
            // level numbers start at 1, indexes of list start at 0, automatically gets the next one
            NextLevelSceneID = GameManager.levelSceneIDs[levelNumber];
        } else {
            // last level goes back to the menu for now
            NextLevelSceneID = 0;
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
