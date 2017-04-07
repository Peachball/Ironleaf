using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{

    protected bool in_interaction = false;
    protected bool inzone = false;
    private DialogueManager dbox;
    private CharacterControl cc;

    protected void Start()
    {
        dbox = GameObject.Find("DialogueBackground").GetComponent<DialogueManager>();
        //cc = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControl>();
        cc = GameObject.Find("Main Character").GetComponent<CharacterControl>();
    }

    protected void Update()
    {
        if (inzone)
        {
            if (Input.GetButtonDown("Interact") && !in_interaction)
            {
                StartCoroutine(start_interaction());
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isMainCharacter(collision))
        {
            inzone = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (isMainCharacter(collision))
        {
            inzone = false;
            stop_interaction();
        }
    }

    protected virtual IEnumerator start_interaction()
    {
        yield return new WaitForEndOfFrame();
        in_interaction = true;
        dbox.setText(init_text());
        dbox.show();
        cc.disabled = true;
    }

    protected virtual void stop_interaction()
    {
        in_interaction = false;
        dbox.hide();
        dbox.setText("");
        cc.disabled = false;
    }

    protected bool isMainCharacter(Collider2D c)
    {
        return c.gameObject.tag == "Player";
    }

    protected void set_text(string s)
    {
        if (in_interaction)
        {
            dbox.setText(s);
        }
    }

    protected abstract string init_text();
}
