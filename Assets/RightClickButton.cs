using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RightClickButton : MonoBehaviour, IPointerClickHandler,
    IPointerDownHandler, IPointerUpHandler,
    IPointerEnterHandler, IPointerExitHandler,
    ISelectHandler, IDeselectHandler
{
    // Colors used for a color tint-based transition.
    [FormerlySerializedAs("colors")]
    [SerializeField]
    private ColorBlock m_Colors = ColorBlock.defaultColorBlock;

    private Image image;
    public Action OnRightClick { get; set; }

    private void Start()
    {
        image = this.GetComponent<Image>();
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            OnRightClick?.Invoke();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
            image.color = m_Colors.pressedColor;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        image.color = m_Colors.normalColor;
    }

    public virtual void OnPointerEnter(PointerEventData eventData)
    {
        image.color = m_Colors.highlightedColor;
    }

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        image.color = m_Colors.normalColor;
    }

    public virtual void OnSelect(BaseEventData eventData)
    {
        image.color = m_Colors.selectedColor;
    }

    public virtual void OnDeselect(BaseEventData eventData)
    {
        image.color = m_Colors.normalColor;
    }
}
