// Decompiled with JetBrains decompiler
// Type: OpinionsLearnedScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DF03FFAE-974C-4193-BB83-3E6945841C76
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using UnityEngine;

public class OpinionsLearnedScript : MonoBehaviour
{
  [SerializeField]
  public OpinionsLearnedScript.Students[] StudentOpinions;

  [Serializable]
  public struct Students
  {
    public List<bool> Opinions;
  }
}
