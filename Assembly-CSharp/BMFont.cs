using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200006D RID: 109
[Serializable]
public class BMFont
{
	// Token: 0x17000048 RID: 72
	// (get) Token: 0x060002F9 RID: 761 RVA: 0x00020046 File Offset: 0x0001E246
	public bool isValid
	{
		get
		{
			return this.mSaved.Count > 0;
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x060002FA RID: 762 RVA: 0x00020056 File Offset: 0x0001E256
	// (set) Token: 0x060002FB RID: 763 RVA: 0x0002005E File Offset: 0x0001E25E
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
	// (get) Token: 0x060002FC RID: 764 RVA: 0x00020067 File Offset: 0x0001E267
	// (set) Token: 0x060002FD RID: 765 RVA: 0x0002006F File Offset: 0x0001E26F
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
	// (get) Token: 0x060002FE RID: 766 RVA: 0x00020078 File Offset: 0x0001E278
	// (set) Token: 0x060002FF RID: 767 RVA: 0x00020080 File Offset: 0x0001E280
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
	// (get) Token: 0x06000300 RID: 768 RVA: 0x00020089 File Offset: 0x0001E289
	// (set) Token: 0x06000301 RID: 769 RVA: 0x00020091 File Offset: 0x0001E291
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
	// (get) Token: 0x06000302 RID: 770 RVA: 0x0002009A File Offset: 0x0001E29A
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
	// (get) Token: 0x06000303 RID: 771 RVA: 0x000200B1 File Offset: 0x0001E2B1
	// (set) Token: 0x06000304 RID: 772 RVA: 0x000200B9 File Offset: 0x0001E2B9
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
	// (get) Token: 0x06000305 RID: 773 RVA: 0x000200C2 File Offset: 0x0001E2C2
	public List<BMGlyph> glyphs
	{
		get
		{
			return this.mSaved;
		}
	}

	// Token: 0x06000306 RID: 774 RVA: 0x000200CC File Offset: 0x0001E2CC
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

	// Token: 0x06000307 RID: 775 RVA: 0x0002015B File Offset: 0x0001E35B
	public BMGlyph GetGlyph(int index)
	{
		return this.GetGlyph(index, false);
	}

	// Token: 0x06000308 RID: 776 RVA: 0x00020165 File Offset: 0x0001E365
	public void Clear()
	{
		this.mDict.Clear();
		this.mSaved.Clear();
	}

	// Token: 0x06000309 RID: 777 RVA: 0x00020180 File Offset: 0x0001E380
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

	// Token: 0x04000488 RID: 1160
	[HideInInspector]
	[SerializeField]
	private int mSize = 16;

	// Token: 0x04000489 RID: 1161
	[HideInInspector]
	[SerializeField]
	private int mBase;

	// Token: 0x0400048A RID: 1162
	[HideInInspector]
	[SerializeField]
	private int mWidth;

	// Token: 0x0400048B RID: 1163
	[HideInInspector]
	[SerializeField]
	private int mHeight;

	// Token: 0x0400048C RID: 1164
	[HideInInspector]
	[SerializeField]
	private string mSpriteName;

	// Token: 0x0400048D RID: 1165
	[HideInInspector]
	[SerializeField]
	private List<BMGlyph> mSaved = new List<BMGlyph>();

	// Token: 0x0400048E RID: 1166
	private Dictionary<int, BMGlyph> mDict = new Dictionary<int, BMGlyph>();
}
