﻿// Decompiled with JetBrains decompiler
// Type: ExampleDragDropItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 75854DFC-6606-4168-9C8E-2538EB1902DD
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/Drag and Drop Item (Example)")]
public class ExampleDragDropItem : UIDragDropItem
{
  public GameObject prefab;

  protected override void OnDragDropRelease(GameObject surface)
  {
    if ((Object) surface != (Object) null)
    {
      ExampleDragDropSurface component = surface.GetComponent<ExampleDragDropSurface>();
      if ((Object) component != (Object) null)
      {
        GameObject gameObject = component.gameObject.AddChild(this.prefab);
        gameObject.transform.localScale = component.transform.localScale;
        Transform transform = gameObject.transform;
        transform.position = UICamera.lastWorldPosition;
        if (component.rotatePlacedObject)
          transform.rotation = Quaternion.LookRotation(UICamera.lastHit.normal) * Quaternion.Euler(90f, 0.0f, 0.0f);
        NGUITools.Destroy((Object) this.gameObject);
        return;
      }
    }
    base.OnDragDropRelease(surface);
  }
}