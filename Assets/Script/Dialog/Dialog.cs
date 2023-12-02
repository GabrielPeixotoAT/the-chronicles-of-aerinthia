using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    public string Title;
    [TextArea(2, 5)]
    public string Message;
    public bool IsQuestion;
}
