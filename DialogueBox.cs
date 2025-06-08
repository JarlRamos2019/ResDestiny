using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueBox : MonoBehaviour
{
    public TextMeshProUGUI textCompWithoutIcon;
    public TextMeshProUGUI textCompWithIcon;
    public TextMeshProUGUI speakerName;
    public List<string> lines = new List<string>();
    public float dialogueSpeed;
    public int index;
    public Image speakerIcon;
    public Image theCurrentIcon;

    public static readonly int DIAG_X_WITH_ICON = 859;
    public static readonly int DIAG_X_NO_ICON = 818;
    public static readonly int DIAG_WIDTH_WITH_ICON = 1500;
    public static readonly int DIAG_WIDTH_NO_ICON = 1582;

    private void Awake()
    {
        
    }

    private void OnEnable()
    {
        index = 0;
        InitiateDialogue();
    }

    // Start is called before the first frame update
    void Start()
    {
        textCompWithoutIcon.text = string.Empty;
        textCompWithIcon.text = string.Empty;

        if (!this.gameObject.activeInHierarchy)
        {
            InitiateDialogue();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("k was pressed");

            if (theCurrentIcon == null)
            {
                if (textCompWithoutIcon.text == lines[index])
                {
                    Debug.Log("continue to next line");
                    ContinueToNextLine();
                }
                else
                {
                    Debug.Log("Alternate path");
                    StopAllCoroutines();
                    textCompWithoutIcon.text = lines[index];
                }
            }
            else
            {
                if (textCompWithIcon.text == lines[index])
                {
                    Debug.Log("foo");
                    ContinueToNextLine();
                }
                else
                {
                    Debug.Log("bar");
                    StopAllCoroutines();
                    textCompWithIcon.text = lines[index];
                }
            }
            // gameObject.SetActive(true);
        }       
    }
    void InitiateDialogue()
    {
        Debug.Log("Initiate dialogue");
        index = 0;
        if (theCurrentIcon == null)
        {
            textCompWithoutIcon.gameObject.SetActive(true);
            textCompWithIcon.gameObject.SetActive(false);
            Debug.Log("icon is null");
            //Vector3 initial = this.gameObject.transform.position;
            // Vector2 initialSize = this.gameObject.GetComponent<RectTransform>().sizeDelta;
            //this.gameObject.transform.Find("DiagText").GetComponent<RectTransform>().sizeDelta = new Vector2(DIAG_WIDTH_NO_ICON, initialSize.y);
            //this.gameObject.transform.Find("DiagText").transform.position = new Vector3(DIAG_X_NO_ICON, initial.y, initial.z);
        }
        else
        {
            textCompWithoutIcon.gameObject.SetActive(false);
            textCompWithIcon.gameObject.SetActive(true);
            Instantiate(theCurrentIcon, speakerIcon.transform);
            //Vector3 initial = this.gameObject.transform.position;
            //Vector2 initialSize = this.gameObject.GetComponent<RectTransform>().sizeDelta;
            //initialSize.x = DIAG_WIDTH_WITH_ICON;
            //this.gameObject.GetComponent<RectTransform>().sizeDelta = initialSize;
            //this.gameObject.transform.Find("DiagText").transform.position = new Vector3(DIAG_X_WITH_ICON, initial.y, initial.z);
        }
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        if (index == 0)
        {
            yield return new WaitForSeconds(0.001f);
        }
        if (theCurrentIcon == null)
        {
           
            foreach (char c in lines[index].ToCharArray())
            {
                textCompWithoutIcon.text += c;
                yield return new WaitForSeconds(dialogueSpeed);
            }
        }
        else
        {
            foreach (char c in lines[index].ToCharArray())
            {
                textCompWithIcon.text += c;
                yield return new WaitForSeconds(dialogueSpeed);

            }
        }
    }

    void ContinueToNextLine()
    {
        if (theCurrentIcon == null)
        {
            if (index < lines.Count - 1)
            {
                index++;
                Debug.Log("Index moved: " + index);
                textCompWithoutIcon.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                textCompWithoutIcon.text = string.Empty;
                gameObject.SetActive(false);
            }

        }
        else
        {
            if (index < lines.Count - 1)
            {
                index++;
                textCompWithIcon.text = string.Empty;
                StartCoroutine(TypeLine());
            }
            else
            {
                textCompWithIcon.text = string.Empty;
                gameObject.SetActive(false);
            }
        }
       
    }
}
