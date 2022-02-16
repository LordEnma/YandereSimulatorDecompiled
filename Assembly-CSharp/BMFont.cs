using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200006D RID: 109
[Serializable]
public class BMFont
{
	// Token: 0x17000048 RID: 72
	// (get) Token: 0x060002F9 RID: 761 RVA: 0x0001FE96 File Offset: 0x0001E096
	public bool isValid
	{
		get
		{
			return this.mSaved.Count > 0;
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x060002FA RID: 762 RVA: 0x0001FEA6 File Offset: 0x0001E0A6
	// (set) Token: 0x060002FB RID: 763 RVA: 0x0001FEAE File Offset: 0x0001E0AE
	public int charSize
	{
		get
		{
			return this.mSize;
		}
		set
		{
			this.mSize = value;
		}
	}

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x060002FC RID: 764 RVA: 0x0001FEB7 File Offset: 0x0001E0B7
	// (set) Token: 0x060002FD RID: 765 RVA: 0x0001FEBF File Offset: 0x0001E0BF
	public int baseOffset
	{
		get
		{
			return this.mBase;
		}
		set
		{
			this.mBase = value;
		}
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x060002FE RID: 766 RVA: 0x0001FEC8 File Offset: 0x0001E0C8
	// (set) Token: 0x060002FF RID: 767 RVA: 0x0001FED0 File Offset: 0x0001E0D0
	public int texWidth
	{
		get
		{
			return this.mWidth;
		}
		set
		{
			this.mWidth = value;
		}
	}

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x06000300 RID: 768 RVA: 0x0001FED9 File Offset: 0x0001E0D9
	// (set) Token: 0x06000301 RID: 769 RVA: 0x0001FEE1 File Offset: 0x0001E0E1
	public int texHeight
	{
		get
		{
			return this.mHeight;
		}
		set
		{
			this.mHeight = value;
		}
	}

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000302 RID: 770 RVA: 0x0001FEEA File Offset: 0x0001E0EA
	public int glyphCount
	{
		get
		{
			if (!this.isValid)
			{
				return 0;
			}
			return this.mSaved.Count;
		}
	}

	// Token: 0x1700004E RID: 78
	// (get) Token: 0x06000303 RID: 771 RVA: 0x0001FF01 File Offset: 0x0001E101
	// (set) Token: 0x06000304 RID: 772 RVA: 0x0001FF09 File Offset: 0x0001E109
	public string spriteName
	{
		get
		{
			return this.mSpriteName;
		}
		set
		{
			this.mSpriteName = value;
		}
	}

	// Token: 0x1700004F RID: 79
	// (get) Token: 0x06000305 RID: 773 RVA: 0x0001FF12 File Offset: 0x0001E112
	public List<BMGlyph> glyphs
	{
		get
		{
			return this.mSaved;
		}
	}

	// Token: 0x06000306 RID: 774 RVA: 0x0001FF1C File Offset: 0x0001E11C
	public BMGlyph GetGlyph(int index, bool createIfMissing)
	{
		BMGlyph bmglyph = null;
		if (this.mDict.Count == 0)
		{
			int i = 0;
			int count = this.mSaved.Count;
			while (i < count)
			{
				BMGlyph bmglyph2 = this.mSaved[i];
				this.mDict.Add(bmglyph2.index, bmglyph2);
				i++;
			}
		}
		if (!this.mDict.TryGetValue(index, out bmglyph) && createIfMissing)
		{
			bmglyph = new BMGlyph();
			bmglyph.index = index;
			this.mSaved.Add(bmglyph);
			this.mDict.Add(index, bmglyph);
		}
		return bmglyph;
	}

	// Token: 0x06000307 RID: 775 RVA: 0x0001FFAB File Offset: 0x0001E1AB
	public BMGlyph GetGlyph(int index)
	{
		return this.GetGlyph(index, false);
	}

	// Token: 0x06000308 RID: 776 RVA: 0x0001FFB5 File Offset: 0x0001E1B5
	public void Clear()
	{
		this.mDict.Clear();
		this.mSaved.Clear();
	}

	// Token: 0x06000309 RID: 777 RVA: 0x0001FFD0 File Offset: 0x0001E1D0
	public void Trim(int xMin, int yMin, int xMax, int yMax)
	{
		if (this.isValid)
		{
			int i = 0;
			int count = this.mSaved.Count;
			while (i < count)
			{
				BMGlyph bmglyph = this.mSaved[i];
				if (bmglyph != null)
				{
					bmglyph.Trim(xMin, yMin, xMax, yMax);
				}
				i++;
			}
		}
	}

	// Token: 0x0400047F RID: 1151
	[HideInInspector]
	[SerializeField]
	private int mSize = 16;

	// Token: 0x04000480 RID: 1152
	[HideInInspector]
	[SerializeField]
	private int mBase;

	// Token: 0x04000481 RID: 1153
	[HideInInspector]
	[SerializeField]
	private int mWidth;

	// Token: 0x04000482 RID: 1154
	[HideInInspector]
	[SerializeField]
	private int mHeight;

	// Token: 0x04000483 RID: 1155
	[HideInInspector]
	[SerializeField]
	private string mSpriteName;

	// Token: 0x04000484 RID: 1156
	[HideInInspector]
	[SerializeField]
	private List<BMGlyph> mSaved = new List<BMGlyph>();

	// Token: 0x04000485 RID: 1157
	private Dictionary<int, BMGlyph> mDict = new Dictionary<int, BMGlyph>();
}
