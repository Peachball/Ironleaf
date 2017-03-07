using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class NPCController : Interaction {
    protected int line = 0;
    protected int pointer = 0;
    public string dialogue_src;
    private JSONNode d;

    private int mod(int a, int b){
        // This function is literally used once in Update() to make code look
        // slightly nicer...
        if(b == 0){
            return a;
        }
        return (a + b) % b;
    }

    protected new void Start(){
        base.Start();
        d = JSON.Parse(DialogueManager.loadDialogueFromFile(dialogue_src));
    }

    protected new void Update()
    {
        base.Update();
        if (in_interaction)
        {
            if (d[line]["options"].Count != 0)
            {
                bool update = false;
                int newline = line;
                if (Input.GetButtonDown("Down"))
                {
                    pointer += 1;
                    update = true;
                }
                if (Input.GetButtonDown("Up"))
                {
                    pointer -= 1;
                    update = true;
                }
                if (Input.GetButtonDown("Interact"))
                {
                    newline = d[line]["options"][pointer]["next"].AsInt;
                    update = true;
                }
                if (line < 0)
                {
                    stop_interaction();
                }
                else
                {
                    pointer = mod(pointer, d[line]["options"].Count);
                    if (update)
                    {
                        if(line != newline)
                        {
                            pointer = 0;
                        line = newline;
                        }
                        set_text(get_line());
                    }
                }
            }
            else
            {
                int nl = line;
                if (Input.GetButtonDown("Interact"))
                {
                    nl = d[line]["next"].AsInt;
                }
                if(nl < 0)
                {
                    stop_interaction();
                }
                else
                {
                    line = nl;
                }
            }
        }
    }

    protected override void stop_interaction()
    {
        pointer = 0;
        line = 0;
        base.stop_interaction();
    }

    protected string get_line(){
        string t = d[line]["name"] + ":" + d[line]["text"] + '\n';
        for(int i = 0; i < d[line]["options"].Count; i++)
        {
            if (i == pointer)
            {
                t += " >  " + d[line]["options"][i]["text"] + '\n';
            }
            else
            {
                t += "    " + d[line]["options"][i]["text"] + '\n';
            }
        }
        return t;
    }

    protected override string init_text()
    {
        return get_line();
    }
}
