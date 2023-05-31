using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour, IPointerClickHandler
{ 
    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinChecker>().bWon == false && GameObject.FindGameObjectWithTag("WinManager").GetComponent<WinChecker>().bDidExplode == false)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
                GetComponent<Unit>().LeftClick();
            else if (eventData.button == PointerEventData.InputButton.Middle)
                GetComponent<Unit>().MiddleClick();
            else if (eventData.button == PointerEventData.InputButton.Right)
                GetComponent<Unit>().RightClick();
        }
    }
}