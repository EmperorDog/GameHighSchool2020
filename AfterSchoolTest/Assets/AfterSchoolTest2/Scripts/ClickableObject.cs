using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickableObject : MonoBehaviour/*, IPointerDownHandler*/
{
    //private void OnMouseDown()
    //{
    //    Debug.Log("오브젝트를 눌렀습니다.");
    //}

    //Main Camera-> Physics Raycaster 컴포넌트 추가
    //GameObject -> UI -> EventSystem 게임오브젝트 추가

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("오브젝트를 눌렀습니다.");
    //    //throw new System.NotImplementedException();
    //}

    public void OnPointerDownEvent(BaseEventData eventData)
    {
        Debug.Log("오브젝트를 눌렀습니다.");
    }
}
