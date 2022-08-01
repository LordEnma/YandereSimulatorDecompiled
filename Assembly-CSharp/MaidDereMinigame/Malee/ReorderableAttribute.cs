// Decompiled with JetBrains decompiler
// Type: MaidDereMinigame.Malee.ReorderableAttribute
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: B122114D-AAD1-4BC3-90AB-645D18AE6C10
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using UnityEngine;

namespace MaidDereMinigame.Malee
{
  public class ReorderableAttribute : PropertyAttribute
  {
    public bool add;
    public bool remove;
    public bool draggable;
    public bool singleLine;
    public bool paginate;
    public bool sortable;
    public int pageSize;
    public string elementNameProperty;
    public string elementNameOverride;
    public string elementIconPath;

    public ReorderableAttribute()
      : this((string) null)
    {
    }

    public ReorderableAttribute(string elementNameProperty)
      : this(true, true, true, elementNameProperty, (string) null, (string) null)
    {
    }

    public ReorderableAttribute(string elementNameProperty, string elementIconPath)
      : this(true, true, true, elementNameProperty, (string) null, elementIconPath)
    {
    }

    public ReorderableAttribute(
      string elementNameProperty,
      string elementNameOverride,
      string elementIconPath)
      : this(true, true, true, elementNameProperty, elementNameOverride, elementIconPath)
    {
    }

    public ReorderableAttribute(
      bool add,
      bool remove,
      bool draggable,
      string elementNameProperty = null,
      string elementIconPath = null)
      : this(add, remove, draggable, elementNameProperty, (string) null, elementIconPath)
    {
    }

    public ReorderableAttribute(
      bool add,
      bool remove,
      bool draggable,
      string elementNameProperty = null,
      string elementNameOverride = null,
      string elementIconPath = null)
    {
      this.add = add;
      this.remove = remove;
      this.draggable = draggable;
      this.sortable = true;
      this.elementNameProperty = elementNameProperty;
      this.elementNameOverride = elementNameOverride;
      this.elementIconPath = elementIconPath;
    }
  }
}
