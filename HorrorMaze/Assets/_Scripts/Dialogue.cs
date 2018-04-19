using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    // Singleton Implementation
    private static Dialogue instance;
    public static Dialogue getInstance() { return instance; }

    private Text dialogueText;
    private Image dialogueBackdrop;
    private bool isPrinting = false;

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

	// Use this for initialization
	void Start ()
    {
        dialogueText = GetComponentInChildren<Text>();
        if (dialogueText == null)
            Debug.Log("Dialogue::Start() - Could not find Dialogue Text");
        dialogueBackdrop = GetComponentInChildren<Image>();
        if (dialogueBackdrop == null)
            Debug.Log("Dialogue::Start() - Could not find Dialogue Backdrop");
        dialogueText.enabled = false;
        dialogueBackdrop.enabled = false;

    }

    // Update is called once per frame
    void Update ()
    {
        if (!isPrinting && dialogueText.enabled)
            if (Input.GetKeyDown(KeyCode.Return))
                ToggleDialogueDisplay();
	}

    public void Display(string message)
    {
        StartCoroutine(PrintDisplay(message));
    }

    IEnumerator PrintDisplay(string message)
    {
        isPrinting = true;
        dialogueText.text = "";
        ToggleDialogueDisplay();
        char[] msg = message.ToCharArray();
        foreach (char c in msg)
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(2.0f/msg.Length);
        }
        dialogueText.text += "\n\nPress 'Enter' to Close this Window";
        isPrinting = false;
    }

    private void ToggleDialogueDisplay()
    {
        dialogueText.enabled = !dialogueText.enabled;
        dialogueBackdrop.enabled = !dialogueBackdrop.enabled;
    }
}
