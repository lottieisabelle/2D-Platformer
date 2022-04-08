using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _img;
    [SerializeField] public Sprite _default, _pressed; 
    public bool isLocked;
    public int sceneID;

   // locked buttons don't display correctly if game is loaded on level select scene due to order of game scripts running

    public void MoveToScene()
    {
        if(!isLocked){
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

