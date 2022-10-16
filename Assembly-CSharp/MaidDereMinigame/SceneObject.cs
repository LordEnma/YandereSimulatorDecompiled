// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.SceneObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using UnityEngine;

namespace MaidDereMinigame
{
  [CreateAssetMenu(fileName = "New Scene Object", menuName = "Scenes/New Scene Object")]
  [Serializable]
  public class SceneObject : ScriptableObject
  {
    public int sceneBuildNumber = -1;
  }
}
