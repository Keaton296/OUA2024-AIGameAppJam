using UnityEngine;
using TMPro;
public class TimeTextUI : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    private void Update()
    {
        text.text = string.Format("{0:00}:{1:00}",((int)Time.time)/60,Time.time%60);
    }
}
