// Decompiled with JetBrains decompiler
// Type: InvDatabase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 142BD599-F469-4844-AAF7-649036ADC83B
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Examples/Item Database")]
public class InvDatabase : MonoBehaviour
{
  private static InvDatabase[] mList;
  private static bool mIsDirty = true;
  public int databaseID;
  public List<InvBaseItem> items = new List<InvBaseItem>();
  public Object iconAtlas;

  public static InvDatabase[] list
  {
    get
    {
      if (InvDatabase.mIsDirty)
      {
        InvDatabase.mIsDirty = false;
        InvDatabase.mList = NGUITools.FindActive<InvDatabase>();
      }
      return InvDatabase.mList;
    }
  }

  private void OnEnable() => InvDatabase.mIsDirty = true;

  private void OnDisable() => InvDatabase.mIsDirty = true;

  private InvBaseItem GetItem(int id16)
  {
    int index = 0;
    for (int count = this.items.Count; index < count; ++index)
    {
      InvBaseItem invBaseItem = this.items[index];
      if (invBaseItem.id16 == id16)
        return invBaseItem;
    }
    return (InvBaseItem) null;
  }

  private static InvDatabase GetDatabase(int dbID)
  {
    int index = 0;
    for (int length = InvDatabase.list.Length; index < length; ++index)
    {
      InvDatabase database = InvDatabase.list[index];
      if (database.databaseID == dbID)
        return database;
    }
    return (InvDatabase) null;
  }

  public static InvBaseItem FindByID(int id32)
  {
    InvDatabase database = InvDatabase.GetDatabase(id32 >> 16);
    return !((Object) database != (Object) null) ? (InvBaseItem) null : database.GetItem(id32 & (int) ushort.MaxValue);
  }

  public static InvBaseItem FindByName(string exact)
  {
    int index1 = 0;
    for (int length = InvDatabase.list.Length; index1 < length; ++index1)
    {
      InvDatabase invDatabase = InvDatabase.list[index1];
      int index2 = 0;
      for (int count = invDatabase.items.Count; index2 < count; ++index2)
      {
        InvBaseItem byName = invDatabase.items[index2];
        if (byName.name == exact)
          return byName;
      }
    }
    return (InvBaseItem) null;
  }

  public static int FindItemID(InvBaseItem item)
  {
    int index = 0;
    for (int length = InvDatabase.list.Length; index < length; ++index)
    {
      InvDatabase invDatabase = InvDatabase.list[index];
      if (invDatabase.items.Contains(item))
        return invDatabase.databaseID << 16 | item.id16;
    }
    return -1;
  }
}
