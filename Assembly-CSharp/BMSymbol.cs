using System;
using UnityEngine;

// Token: 0x0200006F RID: 111
[Serializable]
public class BMSymbol
{
	// Token: 0x17000050 RID: 80
	// (get) Token: 0x0600030F RID: 783 RVA: 0x000201DB File Offset: 0x0001E3DB
	public int length
	{
		get
		{
			if (this.mLength == 0)
			{
				this.mLength = this.sequence.Length;
			}
			return this.mLength;
		}
	}

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x06000310 RID: 784 RVA: 0x000201FC File Offset: 0x0001E3FC
	public int offsetX
	{
		get
		{
			return this.mOffsetX;
		}
	}

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x06000311 RID: 785 RVA: 0x00020204 File Offset: 0x0001E404
	public int offsetY
	{
		get
		{
			return this.mOffsetY;
		}
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x06000312 RID: 786 RVA: 0x0002020C File Offset: 0x0001E40C
	public int width
	{
		get
		{
			return this.mWidth;
		}
	}

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x06000313 RID: 787 RVA: 0x00020214 File Offset: 0x0001E414
	public int height
	{
		get
		{
			return this.mHeight;
		}
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x06000314 RID: 788 RVA: 0x0002021C File Offset: 0x0001E41C
	public int advance
	{
		get
		{
			return this.mAdvance;
		}
	}

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x06000315 RID: 789 RVA: 0x00020224 File Offset: 0x0001E424
	public Rect uvRect
	{
		get
		{
			return this.mUV;
		}
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0002022C File Offset: 0x0001E42C
	public void MarkAsChanged()
	{
		this.mIsValid = false;
	}

	// Token: 0x06000317 RID: 791 RVA: 0x00020238 File Offset: 0x0001E438
	public bool Validate(INGUIAtlas atlas)
	{
		if (atlas == null)
		{
			return false;
		}
		if (!this.mIsValid)
		{
			if (string.IsNullOrEmpty(this.spriteName))
			{
				return false;
			}
			this.mSprite = atlas.GetSprite(this.spriteName);
			Texture texture = atlas.texture;
			if (this.mSprite != null)
			{
				if (texture == null)
				{
					this.mSprite = null;
				}
				else
				{
					this.mUV = new Rect((float)this.mSprite.x, (float)this.mSprite.y, (float)this.mSprite.width, (float)this.mSprite.height);
					this.mUV = NGUIMath.ConvertToTexCoords(this.mUV, texture.width, texture.height);
					this.mOffsetX = this.mSprite.paddingLeft;
					this.mOffsetY = this.mSprite.paddingTop;
					this.mWidth = this.mSprite.width;
					this.mHeight = this.mSprite.height;
					this.mAdvance = this.mSprite.width + (this.mSprite.paddingLeft + this.mSprite.paddingRight);
					this.mIsValid = true;
				}
			}
		}
		return this.mSprite != null;
	}

	// Token: 0x0400048E RID: 1166
	public string sequence;

	// Token: 0x0400048F RID: 1167
	public string spriteName;

	// Token: 0x04000490 RID: 1168
	private UISpriteData mSprite;

	// Token: 0x04000491 RID: 1169
	private bool mIsValid;

	// Token: 0x04000492 RID: 1170
	private int mLength;

	// Token: 0x04000493 RID: 1171
	private int mOffsetX;

	// Token: 0x04000494 RID: 1172
	private int mOffsetY;

	// Token: 0x04000495 RID: 1173
	private int mWidth;

	// Token: 0x04000496 RID: 1174
	private int mHeight;

	// Token: 0x04000497 RID: 1175
	private int mAdvance;

	// Token: 0x04000498 RID: 1176
	private Rect mUV;
}
