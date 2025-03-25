using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IScoreChangeViev 
{
   public event Action<int> OnScoreChangeViev;
}
