using sgSchedule;
using UnityEngine;
using UnityEngine.EventSystems;
public class UIEventSystem : MonoBehaviour, IPointerClickHandler {
    public void OnPointerClick (PointerEventData eventData) {
        Main.UIClickAction.Invoke ();
    }
}