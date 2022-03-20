using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed, _locked;
    [SerializeField] public int buttonNumber;
    private bool isLocked;
    private int sceneID;

    void Start()
    {
        if((buttonNumber > GameManager.maxLevel) && (buttonNumber != 1)){
            isLocked = true;
            _img.sprite = _locked;
        } else {
            isLocked = false;
            _img.sprite = _default;
        }
    }


    public void MoveToScene()
    {
        if(!isLocked){
            sceneID = GameManager.levelSceneIDs[buttonNumber-1];
            SceneManager.LoadScene(sceneID);
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(!isLocked){
            _img.sprite = _pressed;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(!isLocked){
            _img.sprite = _default;
        }
    }
}

