using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMonitor : MonoBehaviour, IInteractable
{
    [SerializeField] int slideIndex = 0;
    [SerializeField] GameObject[] slides;
    public void Interact()
    {
        SlideToNext();
    }
    private void SlideToNext()
    {
        slides[slideIndex].SetActive(false);
        slideIndex++;
        slideIndex = slideIndex % slides.Length; 
        slides[slideIndex].SetActive(true);
    }
}
