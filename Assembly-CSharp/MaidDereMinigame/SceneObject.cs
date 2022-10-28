// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.SceneObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: CC755693-C2BE-45B9-A389-81C492F832E2
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
