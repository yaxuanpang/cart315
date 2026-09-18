using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class court : MonoBehaviour
{
    public EventTrigger.TriggerEvent courtTrigger;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D other)
    {
        BaseEventData eventData = new BaseEventData(EventSystem.current);
        courtTrigger.Invoke(eventData);
    }

    
}
