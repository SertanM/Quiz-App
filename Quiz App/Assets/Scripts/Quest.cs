using System.Collections;
using System.Collections.Generic;
using Unity.Properties;
using UnityEngine;

[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Quest : ScriptableObject
{
    public string quest;
    public string[] answers;
    public int correctAnswerIndex;
}
