// Decompiled with JetBrains decompiler
// Type: OpinionsLearnedScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
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
