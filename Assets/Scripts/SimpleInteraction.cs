using UnityEngine;
using System.Collections;
using System;

public class SimpleInteraction : Interaction{

    public string message;

    protected override string init_text()
    {
        return message;
    }

    protected new void Update()
    {
        if (Input.GetButtonDown("Interact") && in_interaction)
        {
            stop_interaction();
        }
        else
        {
            base.Update();
        }
    }
}
