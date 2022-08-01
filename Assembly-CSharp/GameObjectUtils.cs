// Decompiled with JetBrains decompiler
// Type: GameObjectUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public static class GameObjectUtils
{
  public static void SetLayerRecursively(GameObject obj, int newLayer)
  {
    obj.layer = newLayer;
    foreach (Component component in obj.transform)
      GameObjectUtils.SetLayerRecursively(component.gameObject, newLayer);
  }

  public static void SetTagRecursively(GameObject obj, string newTag)
  {
    obj.tag = newTag;
    foreach (Component component in obj.transform)
      GameObjectUtils.SetTagRecursively(component.gameObject, newTag);
  }
}
