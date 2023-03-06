using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Start_Behavor : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{

    [SerializeField] private Image image;
    [SerializeField] private Sprite _default, pressed;
    public void OnPointerDown(PointerEventData eventData)
    {
        image.sprite = pressed;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        image.sprite = _default;
    }
}
