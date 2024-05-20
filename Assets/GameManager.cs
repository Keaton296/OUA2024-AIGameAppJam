using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Singleton;
    public Action OnGameSuccess;
    [SerializeField] NavMeshAgent robotBehaviour;
    [SerializeField] MovementController playerMovementController;
    private void Awake()
    {
        Singleton = this;

    }
    public void CompleteLevel()
    {
        OnGameSuccess?.Invoke();
        StartCoroutine(LevelCompleteDuration());
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
    IEnumerator LevelCompleteDuration()
    {
        yield return new WaitForSeconds(2);
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
