using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    [SerializeField] private int NextLevelSceneID;

    public void nextLevel()
    {
        SceneManager.LoadScene(NextLevelSceneID);
    }

}
