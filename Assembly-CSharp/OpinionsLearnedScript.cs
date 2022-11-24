// Decompiled with JetBrains decompiler
// Type: OpinionsLearnedScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
