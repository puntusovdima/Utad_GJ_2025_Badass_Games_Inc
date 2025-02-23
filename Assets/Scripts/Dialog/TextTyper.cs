using System.Collections;
using UnityEngine;
using TMPro;
public class TextTyper : MonoBehaviour
{
    public TMP_Text tmpText;
    public string textToType = "This is a test string";
    public float typingDelay = 0.2f;
    public bool typeAll;
    public AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        tmpText = GetComponent<TMP_Text>();
        TypeText(textToType, tmpText);
    }
    
    public void TypeText(string text, TMP_Text textOut)
    {
        AudioManager.instance.PlayBlablaSound(0); //sets ONE pitch and audio for ONE character speaking?
        StartCoroutine(TypeTextWithDelay(text, textOut));
    }

    private IEnumerator TypeTextWithDelay(string text, TMP_Text textOut)
    {
        // string output;
        for (int i = 0; i < text.Length; i++)
        {
            if (Input.anyKeyDown)
                typeAll = true;
            if (typeAll)
            {
                textOut.text = text;
                yield break;
            }
            textOut.text += text[i];
            //AudioManager.instance.SetBlablaSound(0, audio); //sets a pitch and audio clip for EVERY key wrote down
            audio.PlayOneShot(audio.clip);
            yield return new WaitForSeconds(typingDelay);
        }
    }
}
