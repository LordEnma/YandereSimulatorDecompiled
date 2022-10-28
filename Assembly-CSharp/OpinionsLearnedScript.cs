// Decompiled with JetBrains decompiler
// Type: OpinionsLearnedScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
