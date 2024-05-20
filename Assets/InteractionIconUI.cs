using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class InteractionIconUI : MonoBehaviour
{
    [SerializeField] MouseLookController playerMouseLookController;
    [SerializeField] Image iconImage;
    [SerializeField] TMP_Text txt;
    private void Update()
    {
        if(playerMouseLookController.SelectedInteractable != null)
        {
            txt.color = Color.white;
            iconImage.color = Color.white;
        }
        else
        {
            txt.color = Color.clear;
            iconImage.color = Color.clear;
        }
    }
}
