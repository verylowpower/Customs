using UnityEngine;
using UnityEngine.EventSystems;

public class ClickToHideUI : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Hiding: " + gameObject.name);
        gameObject.SetActive(false);
    }
}
