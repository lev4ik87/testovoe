using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IScoreChangeModel
{
    public event Action<int> OnScoreChangeModel; 
}
