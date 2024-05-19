using System.Collections;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class BlindfoldUI : MonoBehaviour
{
    [SerializeField] Image img;
    private void Awake()
    {
        img = GetComponent<Image>();
    }
    private void Start()
    {
        StartCoroutine(Open());
    }
    private IEnumerator Open()
    {
        img.CrossFadeAlpha(0, 1f, true);
        yield return new WaitForSeconds(1);
    }
}
