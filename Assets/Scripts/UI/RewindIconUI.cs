using UnityEngine;
using UnityEngine.UI;
public class RewindIconUI : MonoBehaviour
{
    [SerializeField] Image img;
    [SerializeField] Sprite rewindSprite;
    private void Awake()
    {
        img = GetComponent<Image>();
    }
    private void Start()
    {
        Rewinder.Singleton.OnRewindStart += OnRewindStart;
        Rewinder.Singleton.OnRewindEnd += OnRewindEnd;
    }
    private void OnRewindStart()
    {
        img.color = new Color(1,1,1,.16f);
        img.sprite = rewindSprite;
    }
    private void OnRewindEnd()
    {
        img.color = new Color(1, 1, 1, 0);
    }
}
