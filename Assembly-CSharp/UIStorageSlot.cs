// Decompiled with JetBrains decompiler
// Type: UIStorageSlot
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

[AddComponentMenu("NGUI/Examples/UI Storage Slot")]
public class UIStorageSlot : UIItemSlot
{
  public UIItemStorage storage;
  public int slot;

  protected override InvGameItem observedItem => !((Object) this.storage != (Object) null) ? (InvGameItem) null : this.storage.GetItem(this.slot);

  protected override InvGameItem Replace(InvGameItem item) => !((Object) this.storage != (Object) null) ? item : this.storage.Replace(this.slot, item);
}
