using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] public string levelName;
    [SerializeField] private int NextLevelSceneID;

    [SerializeField] public LayerMask blockLayer;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask boxLayer;
    [SerializeField] public LayerMask boxHeldLayer;
    [SerializeField] public LayerMask wallLayer;

    public List<int> boxOrder = new List<int>();
    public int numBoxes;

    void Start()
    {
        numBoxes = this.transform.GetChild(4).childCount;
    }

    public void nextLevel()
    {
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
