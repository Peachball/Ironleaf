using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : NPCController {
    protected new void Start(){
        dialogue_src = "MotherBedroom.txt";
        base.Start();
    }

    protected override void stop_interaction()
    {
        if(line == 4){
            Globals.ready = true;
            Debug.Log("??");
        }
        base.stop_interaction();
    }

    protected override IEnumerator start_interaction()
    {
        if(Globals.inventory.ContainsKey("Crown")){
            dialogue_src = "MotherCrownDialogue.txt";
            base.Start();
        }
        yield return base.start_interaction();
    }
}
