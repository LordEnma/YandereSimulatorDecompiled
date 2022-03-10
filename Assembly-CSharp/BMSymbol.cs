using System;
using UnityEngine;

// Token: 0x0200006F RID: 111
[Serializable]
public class BMSymbol
{
	// Token: 0x17000050 RID: 80
	// (get) Token: 0x0600030F RID: 783 RVA: 0x000202CB File Offset: 0x0001E4CB
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
	// (get) Token: 0x06000310 RID: 784 RVA: 0x000202EC File Offset: 0x0001E4EC
	public int offsetX
	{
		get
		{
			return this.mOffsetX;
		}
	}

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x06000311 RID: 785 RVA: 0x000202F4 File Offset: 0x0001E4F4
	public int offsetY
	{
		get
		{
			return this.mOffsetY;
		}
	}

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x06000312 RID: 786 RVA: 0x000202FC File Offset: 0x0001E4FC
	public int width
	{
		get
		{
			return this.mWidth;
		}
	}

	// Token: 0x17000054 RID: 84
	// (get) Token: 0x06000313 RID: 787 RVA: 0x00020304 File Offset: 0x0001E504
	public int height
	{
		get
		{
			return this.mHeight;
		}
	}

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x06000314 RID: 788 RVA: 0x0002030C File Offset: 0x0001E50C
	public int advance
	{
		get
		{
			return this.mAdvance;
		}
	}

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x06000315 RID: 789 RVA: 0x00020314 File Offset: 0x0001E514
	public Rect uvRect
	{
		get
		{
			return this.mUV;
		}
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0002031C File Offset: 0x0001E51C
	public void MarkAsChanged()
	{
		this.mIsValid = false;
	}

	// Token: 0x06000317 RID: 791 RVA: 0x00020328 File Offset: 0x0001E528
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

	// Token: 0x04000499 RID: 1177
	public string sequence;

	// Token: 0x0400049A RID: 1178
	public string spriteName;

	// Token: 0x0400049B RID: 1179
	private UISpriteData mSprite;

	// Token: 0x0400049C RID: 1180
	private bool mIsValid;

	// Token: 0x0400049D RID: 1181
	private int mLength;

	// Token: 0x0400049E RID: 1182
	private int mOffsetX;

	// Token: 0x0400049F RID: 1183
	private int mOffsetY;

	// Token: 0x040004A0 RID: 1184
	private int mWidth;

	// Token: 0x040004A1 RID: 1185
	private int mHeight;

	// Token: 0x040004A2 RID: 1186
	private int mAdvance;

	// Token: 0x040004A3 RID: 1187
	private Rect mUV;
}
