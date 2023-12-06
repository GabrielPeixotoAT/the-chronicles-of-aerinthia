using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public string Title;
    [TextArea(2, 6)]
    public string Message;
    public bool IsQuestion;
    public string Answer;
}
