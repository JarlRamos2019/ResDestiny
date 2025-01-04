using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI textComp;
    public string[] lines;
    public float dialogueSpeed;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComp.text = string.Empty;
        InitiateDialogue();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("k was pressed");
            // gameObject.SetActive(true);
            if (textComp.text == lines[index])
            {
                ContinueToNextLine();
            }
            else
            {
                StopAllCoroutines();
                textComp.text = lines[index];
            }
        }
        
    }

    void InitiateDialogue()
    {
        Debug.Log("Initiate dialogue");
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComp.text += c;
            yield return new WaitForSeconds(dialogueSpeed);

        }
    }

    void ContinueToNextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComp.text = string.Empty;
            StartCoroutine(TypeLine());

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
