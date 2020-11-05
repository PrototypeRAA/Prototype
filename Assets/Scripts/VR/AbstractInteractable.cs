using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(GvrPointerGraphicRaycaster))]
[RequireComponent(typeof(EventTrigger))]
public abstract class AbstractInteractable : MonoBehaviour
{
    // Tiempo en segundos que tiene que pasar para llamar a HaSidoMirado()
    protected float LookDuration = 3f;

    // Tiempo que ha pasado desde que el objeto se ha empezado a mirar 
    protected float TiempoMirado
    {
        get { if (IsLooked) return Time.time - LookStart; else return 0f; }
        private set { return; }
    }

    // Se está mirando el objeto?
    protected bool IsLooked { get; private set; } = false;



    private float LookStart = 0; // Time in seconds when the last look by player started
    private Coroutine Coroutine; // Coroutine that waits for TiempoMirado to reach LookDuration before calling HaSidoMirado()

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
        entry.callback.AddListener(
            (data) => {
                this.IsLooked = true;
                LookStart = Time.time;
                Coroutine = StartCoroutine(WaitCoroutine());
                OnPointerEnter();
            }
        );
        trigger.triggers.Add(entry);

        // Add pointer exit
        entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerExit;
        entry.callback.AddListener(
            (data) => {
                this.IsLooked = false;
                StopCoroutine(Coroutine);
                OnPointerExit();
            }
        );
        trigger.triggers.Add(entry);
    }

    // Espera el tiempo necesario antes de llamar a HaSidoMirado
    // Si el jugador deja de mirar, la coroutine se detiene con StopCoroutine
    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(LookDuration); 
        HaSidoMirado(); 
    }

    // Llamado cuando el jugador hace click
    public virtual void OnPointerClick() { }

    // Llamado cuando el jugador empieza a mirar el objeto
    public virtual void OnPointerEnter() { }

    // Llamado cuando el jugador deja de mirar el objeto
    public virtual void OnPointerExit() { }

    // Llamado cuando el objeto ha sido mirado durante LookDuration segundos
    public virtual void HaSidoMirado() { }
}
