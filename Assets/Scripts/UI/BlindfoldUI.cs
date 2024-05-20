using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class BlindfoldUI : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] float durationSeconds;
    private void Awake()
    {
        img = GetComponent<Image>();
    }
    private void Start()
    {
        StartCoroutine(Open(durationSeconds));
        GameManager.Singleton.OnGameSuccess += OnGameSuccesHandler;
    }
    private IEnumerator Open(float duration)
    {
        img.CrossFadeAlpha(0, duration, true);
        yield return new WaitForSeconds(duration);
    }
    private IEnumerator Close(float duration)
    {
        img.CrossFadeAlpha(1, duration, true);
        yield return new WaitForSeconds(duration);
    }
    private void OnGameSuccesHandler()
    {
        StartCoroutine(Close(1));
    }
}
