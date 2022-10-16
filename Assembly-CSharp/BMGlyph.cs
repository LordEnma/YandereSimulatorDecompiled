// Decompiled with JetBrains decompiler
// Type: BMGlyph
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FF8D8C5E-5AC0-4805-AE57-A7C2932057BA
// Assembly location: C:\YandereSimulator\latest\YandereSimulator_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;

[Serializable]
public class BMGlyph
{
  public int index;
  public int x;
  public int y;
  public int width;
  public int height;
  public int offsetX;
  public int offsetY;
  public int advance;
  public int channel;
  public List<int> kerning;

  public int GetKerning(int previousChar)
  {
    if (this.kerning != null && previousChar != 0)
    {
      int index = 0;
      for (int count = this.kerning.Count; index < count; index += 2)
      {
        if (this.kerning[index] == previousChar)
          return this.kerning[index + 1];
      }
    }
    return 0;
  }

  public void SetKerning(int previousChar, int amount)
  {
    if (this.kerning == null)
      this.kerning = new List<int>();
    for (int index = 0; index < this.kerning.Count; index += 2)
    {
      if (this.kerning[index] == previousChar)
      {
        this.kerning[index + 1] = amount;
        return;
      }
    }
    this.kerning.Add(previousChar);
    this.kerning.Add(amount);
  }

  public void Trim(int xMin, int yMin, int xMax, int yMax)
  {
    int num1 = this.x + this.width;
    int num2 = this.y + this.height;
    if (this.x < xMin)
    {
      int num3 = xMin - this.x;
      this.x += num3;
      this.width -= num3;
      this.offsetX += num3;
    }
    if (this.y < yMin)
    {
      int num4 = yMin - this.y;
      this.y += num4;
      this.height -= num4;
      this.offsetY += num4;
    }
    if (num1 > xMax)
      this.width -= num1 - xMax;
    if (num2 <= yMax)
      return;
    this.height -= num2 - yMax;
  }
}
