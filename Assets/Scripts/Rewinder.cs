using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rewinder : MonoBehaviour
{
    public static Rewinder Singleton;
    List<IRewindable> rewindables;
    bool isRewinding = false;
    private void Awake()
    {
        rewindables = new List<IRewindable>();
    }
    private void Update()
    {
        isRewinding = Input.GetKey(KeyCode.K);
    }
    private void FixedUpdate()
    {
        if (isRewinding)
        {
            foreach (IRewindable item in rewindables)
            {
                item.Rewind();
            }
        }
        else
        {
            foreach(IRewindable item in rewindables)
            {
                item.Record();
            }
        }
    }
}
