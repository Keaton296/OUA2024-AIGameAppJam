using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewinder : MonoBehaviour
{
    public static Rewinder Singleton;
    public List<IRewindable> rewindables;
    bool isRewinding = false;

    public Action OnRewindStart;
    public Action OnRewindEnd;
    private void Awake()
    {
        Singleton = this;
        rewindables = new List<IRewindable>();
    }
    private void Update()
    {
        bool GetRewindKey = Input.GetKey(KeyCode.Space);
        if((isRewinding != GetRewindKey) && isRewinding)
        {
            OnRewindEnd?.Invoke();
            foreach (IRewindable item in rewindables)
            {
                item.OnRewindEnd();
            }
        }
        else if ((isRewinding != GetRewindKey) && !isRewinding)
        {
            OnRewindStart?.Invoke();
            foreach (IRewindable item in rewindables)
            {
                item.OnRewindStart();
            } 
        }
        isRewinding = GetRewindKey;
        if (isRewinding)
        {
            foreach (IRewindable item in rewindables)
            {
                item.Rewind();
            }
        }
        else
        {
            foreach (IRewindable item in rewindables)
            {
                item.Record();
            }
        }
    }
}
