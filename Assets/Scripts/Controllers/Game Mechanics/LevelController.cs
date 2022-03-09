using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] public string levelName;
    [SerializeField] private int NextLevelSceneID;

    public void nextLevel()
    {
        SceneManager.LoadScene(NextLevelSceneID);
    }

}
