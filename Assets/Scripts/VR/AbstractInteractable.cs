using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GvrPointerGraphicRaycaster))]
[RequireComponent(typeof(EventTrigger))]
public abstract class AbstractInteractable : MonoBehaviour
{
    protected virtual void Start()
    {
        InitEventTrigger();
    }

    // Links the EventTrigger with the methods the methods that will be called
    private void InitEventTrigger()
    {
        EventTrigger trigger = GetComponent<EventTrigger>();
        EventTrigger.Entry entry = null;

        // Add click
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => { OnPointerClick(); });
        trigger.triggers.Add(entry);

        // Add pointer enter
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerEnter;
        entry.callback.AddListener((data) => { OnPointerEnter(); });
        trigger.triggers.Add(entry);

        // Add pointer exit
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener((data) => { OnPointerExit(); });
        trigger.triggers.Add(entry);
    }

    public abstract void OnPointerClick();
    public abstract void OnPointerEnter();
    public abstract void OnPointerExit();
}
