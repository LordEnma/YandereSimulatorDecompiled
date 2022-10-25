// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.SceneObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 03C576EE-B2A0-4A87-90DA-D90BE80DF8AE
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
