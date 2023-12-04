using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    // use typingCoroutine to avoid multiple execution of TypeLine so the dialogue text will be displayed properly
    private Coroutine typingCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine); 
                }
                textComponent.text = lines[index]; 
            }
        }
    }

    public void StartDialogue()
    {
        index = 0;
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); 
        }
        typingCoroutine = StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty; 
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            if (typingCoroutine != null)
            {
                StopCoroutine(typingCoroutine);
            }
            typingCoroutine = StartCoroutine(TypeLine()); 
        }
        else
        {
            gameObject.SetActive(false); 
        }
    }

    public void ClearDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine); 
            typingCoroutine = null; 
        }
        textComponent.text = string.Empty; 
    }
}