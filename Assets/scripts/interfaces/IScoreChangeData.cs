using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IScoreChangeData 
{
    public event Action<int> OnScoreChangeData; 
}
