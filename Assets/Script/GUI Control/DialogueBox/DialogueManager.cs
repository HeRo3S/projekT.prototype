using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private static DialogueManager _instance;

    private Dialogue dialogue;
    private Queue<string> sentences;
    private TextMeshProUGUI nameHolder;
    private TextMeshProUGUI textHolder;
    private Image portrayImage;
    private Button continueButton;

    private void Awake()
    {
        //Singleton
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        InstanceManager.Instance.dialogueManager = _instance;
    }

    private void OnEnable()
    {
        if (dialogue == null)
        {
            Debug.Log("Can't find dialogue property!");
            return;
        }
        else
        {
            nameHolder = transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            textHolder = transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
            StartDialogue();

            portrayImage = transform.GetChild(0).GetChild(2).GetComponent<Image>();
            portrayImage.sprite = dialogue.portrayImage;

            continueButton = transform.GetChild(1).GetComponent<Button>();
            continueButton.onClick.AddListener(ContinueButtonOnClick);
        }
    }

    private void StartDialogue()
    {
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        nameHolder.text = dialogue.talkingPerson;
        DisplayNextSentence();
    }

    private bool DisplayNextSentence()
    {
        if (sentences.Count == 0) return false;
        else
        {
            textHolder.text = sentences.Dequeue();
            return true;
        }
    }

    private void ContinueButtonOnClick()
    {
        if (DisplayNextSentence() == false)
        {
            CanvasController.GetInstance().EnableOnlyCanvas("ShopCanvas");
            return;
        }
    }

    public static DialogueManager GetInstance()
    {
        return _instance;
    }
    public void SetDialogue(Dialogue diag)
    {
        dialogue = diag;
    }
}
