using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200006D RID: 109
[Serializable]
public class BMFont
{
	// Token: 0x17000048 RID: 72
	// (get) Token: 0x060002F9 RID: 761 RVA: 0x00020186 File Offset: 0x0001E386
	public bool isValid
	{
		get
		{
			return this.mSaved.Count > 0;
		}
	}

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x060002FA RID: 762 RVA: 0x00020196 File Offset: 0x0001E396
	// (set) Token: 0x060002FB RID: 763 RVA: 0x0002019E File Offset: 0x0001E39E
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
	// (get) Token: 0x060002FC RID: 764 RVA: 0x000201A7 File Offset: 0x0001E3A7
	// (set) Token: 0x060002FD RID: 765 RVA: 0x000201AF File Offset: 0x0001E3AF
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
	// (get) Token: 0x060002FE RID: 766 RVA: 0x000201B8 File Offset: 0x0001E3B8
	// (set) Token: 0x060002FF RID: 767 RVA: 0x000201C0 File Offset: 0x0001E3C0
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
	// (get) Token: 0x06000300 RID: 768 RVA: 0x000201C9 File Offset: 0x0001E3C9
	// (set) Token: 0x06000301 RID: 769 RVA: 0x000201D1 File Offset: 0x0001E3D1
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
	// (get) Token: 0x06000302 RID: 770 RVA: 0x000201DA File Offset: 0x0001E3DA
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
	// (get) Token: 0x06000303 RID: 771 RVA: 0x000201F1 File Offset: 0x0001E3F1
	// (set) Token: 0x06000304 RID: 772 RVA: 0x000201F9 File Offset: 0x0001E3F9
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
	// (get) Token: 0x06000305 RID: 773 RVA: 0x00020202 File Offset: 0x0001E402
	public List<BMGlyph> glyphs
	{
		get
		{
			return this.mSaved;
		}
	}

	// Token: 0x06000306 RID: 774 RVA: 0x0002020C File Offset: 0x0001E40C
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

	// Token: 0x06000307 RID: 775 RVA: 0x0002029B File Offset: 0x0001E49B
	public BMGlyph GetGlyph(int index)
	{
		return this.GetGlyph(index, false);
	}

	// Token: 0x06000308 RID: 776 RVA: 0x000202A5 File Offset: 0x0001E4A5
	public void Clear()
	{
		this.mDict.Clear();
		this.mSaved.Clear();
	}

	// Token: 0x06000309 RID: 777 RVA: 0x000202C0 File Offset: 0x0001E4C0
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

	// Token: 0x0400048A RID: 1162
	[HideInInspector]
	[SerializeField]
	private int mSize = 16;

	// Token: 0x0400048B RID: 1163
	[HideInInspector]
	[SerializeField]
	private int mBase;

	// Token: 0x0400048C RID: 1164
	[HideInInspector]
	[SerializeField]
	private int mWidth;

	// Token: 0x0400048D RID: 1165
	[HideInInspector]
	[SerializeField]
	private int mHeight;

	// Token: 0x0400048E RID: 1166
	[HideInInspector]
	[SerializeField]
	private string mSpriteName;

	// Token: 0x0400048F RID: 1167
	[HideInInspector]
	[SerializeField]
	private List<BMGlyph> mSaved = new List<BMGlyph>();

	// Token: 0x04000490 RID: 1168
	private Dictionary<int, BMGlyph> mDict = new Dictionary<int, BMGlyph>();
}
