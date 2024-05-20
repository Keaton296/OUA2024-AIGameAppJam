using UnityEngine;
using TMPro;
using System.Collections;

public class LevelCompleteTextUI : MonoBehaviour
{
    TMP_Text text;
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
        text.CrossFadeAlpha(0f, 0f, true);
    }
    private void Start()
    {
        GameManager.Singleton.OnGameSuccess += OnGameSuccessHandler;
    }
    private void OnGameSuccessHandler()
    {
        StartCoroutine(Open(1f));
    }
    private IEnumerator Open(float duration)
    {
        text.CrossFadeAlpha(1f, duration, true);
        yield return new WaitForSeconds(duration);  
    }
}
