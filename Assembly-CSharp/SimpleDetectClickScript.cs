﻿// Decompiled with JetBrains decompiler
// Type: SimpleDetectClickScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

public class SimpleDetectClickScript : MonoBehaviour
{
  public InventoryItemScript InventoryItem;
  public Collider MyCollider;
  public bool Clicked;

  private void Update()
  {
    RaycastHit hitInfo;
    if (!Input.GetMouseButtonDown(0) || !Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo, 100f) || !((Object) hitInfo.collider == (Object) this.MyCollider))
      return;
    this.Clicked = true;
  }
}
