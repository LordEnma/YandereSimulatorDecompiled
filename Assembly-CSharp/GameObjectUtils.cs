// Decompiled with JetBrains decompiler
// Type: GameObjectUtils
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
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
