using UnityEngine;

[CreateAssetMenu(fileName ="NewText", menuName ="Texts")]
public class Texts : ScriptableObject
{
    public string[] dialogueLines;
    public bool[] autoProgressLines;
    public float autoProgressDelay = 1.5f;
    public float typingSpeed = 0.5f;
}