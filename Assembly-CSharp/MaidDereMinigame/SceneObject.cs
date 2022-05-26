// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.SceneObject
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
