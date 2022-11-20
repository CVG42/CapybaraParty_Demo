using System;
using System.Collections;
using UnityEngine;
using TMPro;
public class DialogoController : MonoBehaviour
{

    [SerializeField] private GameObject dialogueMark;
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField, TextArea(6, 4)]private string[] dialogueLines;
    
    private bool _isPlayerInRange;
    private bool _didDialogueStart;
    private int _lineIndex;
    private float _typingTime = 0.05f;
    void Update()
    {
        if (_isPlayerInRange && Input.GetKey("e"))
        {
            if (!_didDialogueStart)
            {
                StartDialogue();
            } else if (dialogueText.text == dialogueLines[_lineIndex])
            {
                NextDialogueLine();
            }
            else
            {
                StopAllCoroutines();
                dialogueText.text = dialogueLines[_lineIndex];
            }
        }
    }

    private void StartDialogue()
    {
        _didDialogueStart = true;
        dialoguePanel.SetActive(true);
        dialogueMark.SetActive(false);
        Time.timeScale = 0f;
        _lineIndex = 0;
        StartCoroutine(ShowLine());
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach (char ch in dialogueLines[_lineIndex])
        {
            dialogueText.text += ch;
            yield return new WaitForSecondsRealtime(_typingTime);
        }
    }

    private void NextDialogueLine()
    {
        _lineIndex++;
        if (_lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            _didDialogueStart = false;
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true);
            Time.timeScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerInRange = true;
            dialogueMark.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _isPlayerInRange = false;
            dialogueMark.SetActive(false);
        }
    }
}

