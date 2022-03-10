using System;
using System.Collections.Generic;

// Token: 0x0200006E RID: 110
[Serializable]
public class BMGlyph
{
	// Token: 0x0600030B RID: 779 RVA: 0x00020138 File Offset: 0x0001E338
	public int GetKerning(int previousChar)
	{
		if (this.kerning != null && previousChar != 0)
		{
			int i = 0;
			int count = this.kerning.Count;
			while (i < count)
			{
				if (this.kerning[i] == previousChar)
				{
					return this.kerning[i + 1];
				}
				i += 2;
			}
		}
		return 0;
	}

	// Token: 0x0600030C RID: 780 RVA: 0x00020188 File Offset: 0x0001E388
	public void SetKerning(int previousChar, int amount)
	{
		if (this.kerning == null)
		{
			this.kerning = new List<int>();
		}
		for (int i = 0; i < this.kerning.Count; i += 2)
		{
			if (this.kerning[i] == previousChar)
			{
				this.kerning[i + 1] = amount;
				return;
			}
		}
		this.kerning.Add(previousChar);
		this.kerning.Add(amount);
	}

	// Token: 0x0600030D RID: 781 RVA: 0x000201F8 File Offset: 0x0001E3F8
	public void Trim(int xMin, int yMin, int xMax, int yMax)
	{
		int num = this.x + this.width;
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
		if (num > xMax)
		{
			this.width -= num - xMax;
		}
		if (num2 > yMax)
		{
			this.height -= num2 - yMax;
		}
	}

	// Token: 0x0400048F RID: 1167
	public int index;

	// Token: 0x04000490 RID: 1168
	public int x;

	// Token: 0x04000491 RID: 1169
	public int y;

	// Token: 0x04000492 RID: 1170
	public int width;

	// Token: 0x04000493 RID: 1171
	public int height;

	// Token: 0x04000494 RID: 1172
	public int offsetX;

	// Token: 0x04000495 RID: 1173
	public int offsetY;

	// Token: 0x04000496 RID: 1174
	public int advance;

	// Token: 0x04000497 RID: 1175
	public int channel;

	// Token: 0x04000498 RID: 1176
	public List<int> kerning;
}
