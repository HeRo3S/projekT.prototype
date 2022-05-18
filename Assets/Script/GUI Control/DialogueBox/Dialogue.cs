using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dialogue : MonoBehaviour
{
    public string talkingPerson;

    [TextArea(3, 10)]
    public string[] sentences;

    public Sprite portrayImage;
}
