// Decompiled with JetBrains decompiler
// Type: UISpriteData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: BA643F73-9C44-4160-857E-C8D73B77B12F
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;

[Serializable]
public class UISpriteData
{
  public string name = "Sprite";
  public int x;
  public int y;
  public int width;
  public int height;
  public int borderLeft;
  public int borderRight;
  public int borderTop;
  public int borderBottom;
  public int paddingLeft;
  public int paddingRight;
  public int paddingTop;
  public int paddingBottom;

  public bool hasBorder => (this.borderLeft | this.borderRight | this.borderTop | this.borderBottom) != 0;

  public bool hasPadding => (this.paddingLeft | this.paddingRight | this.paddingTop | this.paddingBottom) != 0;

  public void SetRect(int x, int y, int width, int height)
  {
    this.x = x;
    this.y = y;
    this.width = width;
    this.height = height;
  }

  public void SetPadding(int left, int bottom, int right, int top)
  {
    this.paddingLeft = left;
    this.paddingBottom = bottom;
    this.paddingRight = right;
    this.paddingTop = top;
  }

  public void SetBorder(int left, int bottom, int right, int top)
  {
    this.borderLeft = left;
    this.borderBottom = bottom;
    this.borderRight = right;
    this.borderTop = top;
  }

  public void CopyFrom(UISpriteData sd)
  {
    this.name = sd.name;
    this.x = sd.x;
    this.y = sd.y;
    this.width = sd.width;
    this.height = sd.height;
    this.borderLeft = sd.borderLeft;
    this.borderRight = sd.borderRight;
    this.borderTop = sd.borderTop;
    this.borderBottom = sd.borderBottom;
    this.paddingLeft = sd.paddingLeft;
    this.paddingRight = sd.paddingRight;
    this.paddingTop = sd.paddingTop;
    this.paddingBottom = sd.paddingBottom;
  }

  public void CopyBorderFrom(UISpriteData sd)
  {
    this.borderLeft = sd.borderLeft;
    this.borderRight = sd.borderRight;
    this.borderTop = sd.borderTop;
    this.borderBottom = sd.borderBottom;
  }
}
