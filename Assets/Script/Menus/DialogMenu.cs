using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogMenu : MonoBehaviour
{
    [Header("Ellements")]
    public TMP_Text Title;
    public TMP_Text Message;
    public TMP_InputField Response;

    [Header("Buttons")]
    public GameObject ButtonsGrid;
    public Button OkButton;
    public Button ConfirmButton;
    public Button CancelButton;

    [Header("Content")]
    public List<Dialog> Dialogs;

    private GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag(GameInfo.PlayerTag);
        player.GetComponent<PlayerController>().enabled = false;
    }

    private void OnEnable()
    {
        NextMessage();
    }

    public void NextMessage()
    {
        var currentDialog = Dialogs.FirstOrDefault();

        if (currentDialog.IsQuestion)
            QuestionConfig();

        SetTitle(currentDialog.Title);

        StopAllCoroutines();
        StartCoroutine(WriteMessage(currentDialog.Message));

        Dialogs.Remove(currentDialog);
    }

    private void QuestionConfig()
    {
        OkButton.gameObject.SetActive(false);
        ConfirmButton.gameObject.SetActive(true);
        CancelButton.gameObject.SetActive(true);

        Response.gameObject.SetActive(true);
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

    public void EndDialog()
    {
        player.GetComponent<PlayerController>().enabled = true;
        gameObject.SetActive(false);
    }

    private void SetTitle(string text)
    {
        Title.text = text;
    }
}
