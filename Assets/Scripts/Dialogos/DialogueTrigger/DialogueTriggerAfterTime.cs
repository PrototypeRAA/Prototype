using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerAfterTime : DialogueTrigger
{
    public float DelayTime;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Invoke("Trigger", DelayTime);
    }
}
