// Decompiled with JetBrains decompiler
// Type: UIEquipmentSlot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5F8D6662-C74B-4D30-A4EA-D74F7A9A95B9
// Assembly location: C:\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/UI Equipment Slot")]
public class UIEquipmentSlot : UIItemSlot
{
  public InvEquipment equipment;
  public InvBaseItem.Slot slot;

  protected override InvGameItem observedItem => !((Object) this.equipment != (Object) null) ? (InvGameItem) null : this.equipment.GetItem(this.slot);

  protected override InvGameItem Replace(InvGameItem item) => !((Object) this.equipment != (Object) null) ? item : this.equipment.Replace(this.slot, item);
}
