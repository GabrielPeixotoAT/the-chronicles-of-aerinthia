using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsMenu : MonoBehaviour
{
    public TMP_Text Message;

    [TextArea(2, 8)]
    public string MessageText;

    void Awake()
    {
        StopAllCoroutines();
        StartCoroutine(WriteMessage(MessageText));
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator WriteMessage(string text)
    {
        Message.text = string.Empty;

        foreach (char ch in text.ToCharArray())
        {
            Message.text += ch;
            yield return null;
        }
    }
}
