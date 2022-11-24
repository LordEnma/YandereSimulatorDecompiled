// Decompiled with JetBrains decompiler
// Type: SimpleDetectClickScript
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: F38A0724-AA2E-44D4-AF10-35004D386EF8
// Assembly location: D:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

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
