using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] public string levelName;
    [SerializeField] private int NextLevelSceneID;

    [SerializeField] public LayerMask boxTriggerLayer;
    [SerializeField] public LayerMask blockLayer;
    [SerializeField] public LayerMask groundLayer;
    [SerializeField] public LayerMask boxLayer;
    [SerializeField] public LayerMask boxHeldLayer;
    [SerializeField] public LayerMask wallLayer;

    public void nextLevel()
    {
        SceneManager.LoadScene(NextLevelSceneID);
    }

}
