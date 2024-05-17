using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRewindable 
{
    void Rewind();
    void Record();
    void OnRewindStart();
    void OnRewindEnd();

}
