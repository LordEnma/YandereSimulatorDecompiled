using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A9 RID: 169
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Sprite")]
public class UISprite : UIBasicSprite
{
	// Token: 0x170001AB RID: 427
	// (get) Token: 0x06000851 RID: 2129 RVA: 0x000450C4 File Offset: 0x000432C4
	// (set) Token: 0x06000852 RID: 2130 RVA: 0x000450FA File Offset: 0x000432FA
	public override Texture mainTexture
	{
		get
		{
			Material material = null;
			INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
			if (inguiatlas != null)
			{
				material = inguiatlas.spriteMaterial;
			}
			if (!(material != null))
			{
				return null;
			}
			return material.mainTexture;
		}
		set
		{
			base.mainTexture = value;
		}
	}

	// Token: 0x170001AC RID: 428
	// (get) Token: 0x06000853 RID: 2131 RVA: 0x00045104 File Offset: 0x00043304
	// (set) Token: 0x06000854 RID: 2132 RVA: 0x0004513A File Offset: 0x0004333A
	public override Material material
	{
		get
		{
			Material material = base.material;
			if (material != null)
			{
				return material;
			}
			INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
			if (inguiatlas != null)
			{
				return inguiatlas.spriteMaterial;
			}
			return null;
		}
		set
		{
			base.material = value;
		}
	}

	// Token: 0x170001AD RID: 429
	// (get) Token: 0x06000855 RID: 2133 RVA: 0x00045143 File Offset: 0x00043343
	// (set) Token: 0x06000856 RID: 2134 RVA: 0x00045150 File Offset: 0x00043350
	public INGUIAtlas atlas
	{
		get
		{
			return this.mAtlas as INGUIAtlas;
		}
		set
		{
			if (this.mAtlas as INGUIAtlas != value)
			{
				base.RemoveFromPanel();
				this.mAtlas = (value as UnityEngine.Object);
				this.mSpriteSet = false;
				this.mSprite = null;
				if (string.IsNullOrEmpty(this.mSpriteName))
				{
					INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
					if (inguiatlas != null && inguiatlas.spriteList.Count > 0)
					{
						this.SetAtlasSprite(inguiatlas.spriteList[0]);
						this.mSpriteName = this.mSprite.name;
					}
				}
				if (!string.IsNullOrEmpty(this.mSpriteName))
				{
					string spriteName = this.mSpriteName;
					this.mSpriteName = "";
					this.spriteName = spriteName;
					this.MarkAsChanged();
				}
			}
		}
	}

	// Token: 0x170001AE RID: 430
	// (get) Token: 0x06000857 RID: 2135 RVA: 0x00045207 File Offset: 0x00043407
	// (set) Token: 0x06000858 RID: 2136 RVA: 0x0004520F File Offset: 0x0004340F
	public bool fixedAspect
	{
		get
		{
			return this.mFixedAspect;
		}
		set
		{
			if (this.mFixedAspect != value)
			{
				this.mFixedAspect = value;
				this.mDrawRegion = new Vector4(0f, 0f, 1f, 1f);
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x00045248 File Offset: 0x00043448
	public UISpriteData GetSprite(string spriteName)
	{
		INGUIAtlas atlas = this.atlas;
		if (atlas == null)
		{
			return null;
		}
		return atlas.GetSprite(spriteName);
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x00045268 File Offset: 0x00043468
	public override void MarkAsChanged()
	{
		this.mSprite = null;
		this.mSpriteSet = false;
		base.MarkAsChanged();
	}

	// Token: 0x170001AF RID: 431
	// (get) Token: 0x0600085B RID: 2139 RVA: 0x0004527E File Offset: 0x0004347E
	// (set) Token: 0x0600085C RID: 2140 RVA: 0x00045288 File Offset: 0x00043488
	public string spriteName
	{
		get
		{
			return this.mSpriteName;
		}
		set
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (this.mSpriteName != value)
				{
					this.mSpriteName = value;
					this.mSprite = null;
					this.mChanged = true;
					this.mSpriteSet = false;
					this.MarkAsChanged();
				}
				return;
			}
			if (string.IsNullOrEmpty(this.mSpriteName))
			{
				return;
			}
			this.mSpriteName = "";
			this.mSprite = null;
			this.mChanged = true;
			this.mSpriteSet = false;
			this.MarkAsChanged();
		}
	}

	// Token: 0x170001B0 RID: 432
	// (get) Token: 0x0600085D RID: 2141 RVA: 0x00045302 File Offset: 0x00043502
	public bool isValid
	{
		get
		{
			return this.GetAtlasSprite() != null;
		}
	}

	// Token: 0x170001B1 RID: 433
	// (get) Token: 0x0600085E RID: 2142 RVA: 0x0004530D File Offset: 0x0004350D
	// (set) Token: 0x0600085F RID: 2143 RVA: 0x00045318 File Offset: 0x00043518
	[Obsolete("Use 'centerType' instead")]
	public bool fillCenter
	{
		get
		{
			return this.centerType > UIBasicSprite.AdvancedType.Invisible;
		}
		set
		{
			if (value != this.centerType > UIBasicSprite.AdvancedType.Invisible)
			{
				this.centerType = (value ? UIBasicSprite.AdvancedType.Sliced : UIBasicSprite.AdvancedType.Invisible);
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170001B2 RID: 434
	// (get) Token: 0x06000860 RID: 2144 RVA: 0x00045339 File Offset: 0x00043539
	// (set) Token: 0x06000861 RID: 2145 RVA: 0x00045341 File Offset: 0x00043541
	public bool applyGradient
	{
		get
		{
			return this.mApplyGradient;
		}
		set
		{
			if (this.mApplyGradient != value)
			{
				this.mApplyGradient = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170001B3 RID: 435
	// (get) Token: 0x06000862 RID: 2146 RVA: 0x00045359 File Offset: 0x00043559
	// (set) Token: 0x06000863 RID: 2147 RVA: 0x00045361 File Offset: 0x00043561
	public Color gradientTop
	{
		get
		{
			return this.mGradientTop;
		}
		set
		{
			if (this.mGradientTop != value)
			{
				this.mGradientTop = value;
				if (this.mApplyGradient)
				{
					this.MarkAsChanged();
				}
			}
		}
	}

	// Token: 0x170001B4 RID: 436
	// (get) Token: 0x06000864 RID: 2148 RVA: 0x00045386 File Offset: 0x00043586
	// (set) Token: 0x06000865 RID: 2149 RVA: 0x0004538E File Offset: 0x0004358E
	public Color gradientBottom
	{
		get
		{
			return this.mGradientBottom;
		}
		set
		{
			if (this.mGradientBottom != value)
			{
				this.mGradientBottom = value;
				if (this.mApplyGradient)
				{
					this.MarkAsChanged();
				}
			}
		}
	}

	// Token: 0x170001B5 RID: 437
	// (get) Token: 0x06000866 RID: 2150 RVA: 0x000453B4 File Offset: 0x000435B4
	public override Vector4 border
	{
		get
		{
			UISpriteData atlasSprite = this.GetAtlasSprite();
			if (atlasSprite == null)
			{
				return base.border;
			}
			return new Vector4((float)atlasSprite.borderLeft, (float)atlasSprite.borderBottom, (float)atlasSprite.borderRight, (float)atlasSprite.borderTop);
		}
	}

	// Token: 0x170001B6 RID: 438
	// (get) Token: 0x06000867 RID: 2151 RVA: 0x000453F4 File Offset: 0x000435F4
	protected override Vector4 padding
	{
		get
		{
			UISpriteData atlasSprite = this.GetAtlasSprite();
			Vector4 result = new Vector4(0f, 0f, 0f, 0f);
			if (atlasSprite != null)
			{
				result.x = (float)atlasSprite.paddingLeft;
				result.y = (float)atlasSprite.paddingBottom;
				result.z = (float)atlasSprite.paddingRight;
				result.w = (float)atlasSprite.paddingTop;
			}
			return result;
		}
	}

	// Token: 0x170001B7 RID: 439
	// (get) Token: 0x06000868 RID: 2152 RVA: 0x00045460 File Offset: 0x00043660
	public override float pixelSize
	{
		get
		{
			if (this.mAtlas == null)
			{
				return 1f;
			}
			INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
			if (inguiatlas != null)
			{
				return inguiatlas.pixelSize;
			}
			return 1f;
		}
	}

	// Token: 0x170001B8 RID: 440
	// (get) Token: 0x06000869 RID: 2153 RVA: 0x0004549C File Offset: 0x0004369C
	public override int minWidth
	{
		get
		{
			if (this.type == UIBasicSprite.Type.Sliced || this.type == UIBasicSprite.Type.Advanced)
			{
				float pixelSize = this.pixelSize;
				Vector4 vector = this.border * this.pixelSize;
				int num = Mathf.RoundToInt(vector.x + vector.z);
				UISpriteData atlasSprite = this.GetAtlasSprite();
				if (atlasSprite != null)
				{
					num += Mathf.RoundToInt(pixelSize * (float)(atlasSprite.paddingLeft + atlasSprite.paddingRight));
				}
				return Mathf.Max(base.minWidth, ((num & 1) == 1) ? (num + 1) : num);
			}
			return base.minWidth;
		}
	}

	// Token: 0x170001B9 RID: 441
	// (get) Token: 0x0600086A RID: 2154 RVA: 0x00045528 File Offset: 0x00043728
	public override int minHeight
	{
		get
		{
			if (this.type == UIBasicSprite.Type.Sliced || this.type == UIBasicSprite.Type.Advanced)
			{
				float pixelSize = this.pixelSize;
				Vector4 vector = this.border * this.pixelSize;
				int num = Mathf.RoundToInt(vector.y + vector.w);
				UISpriteData atlasSprite = this.GetAtlasSprite();
				if (atlasSprite != null)
				{
					num += Mathf.RoundToInt(pixelSize * (float)(atlasSprite.paddingTop + atlasSprite.paddingBottom));
				}
				return Mathf.Max(base.minHeight, ((num & 1) == 1) ? (num + 1) : num);
			}
			return base.minHeight;
		}
	}

	// Token: 0x170001BA RID: 442
	// (get) Token: 0x0600086B RID: 2155 RVA: 0x000455B4 File Offset: 0x000437B4
	public override Vector4 drawingDimensions
	{
		get
		{
			Vector2 pivotOffset = base.pivotOffset;
			float num = -pivotOffset.x * (float)this.mWidth;
			float num2 = -pivotOffset.y * (float)this.mHeight;
			float num3 = num + (float)this.mWidth;
			float num4 = num2 + (float)this.mHeight;
			if (this.GetAtlasSprite() != null && this.mType != UIBasicSprite.Type.Tiled)
			{
				int num5 = this.mSprite.paddingLeft;
				int num6 = this.mSprite.paddingBottom;
				int num7 = this.mSprite.paddingRight;
				int num8 = this.mSprite.paddingTop;
				if (this.mType != UIBasicSprite.Type.Simple)
				{
					float pixelSize = this.pixelSize;
					if (pixelSize != 1f)
					{
						num5 = Mathf.RoundToInt(pixelSize * (float)num5);
						num6 = Mathf.RoundToInt(pixelSize * (float)num6);
						num7 = Mathf.RoundToInt(pixelSize * (float)num7);
						num8 = Mathf.RoundToInt(pixelSize * (float)num8);
					}
				}
				int num9 = this.mSprite.width + num5 + num7;
				int num10 = this.mSprite.height + num6 + num8;
				float num11 = 1f;
				float num12 = 1f;
				if (num9 > 0 && num10 > 0 && (this.mType == UIBasicSprite.Type.Simple || this.mType == UIBasicSprite.Type.Filled))
				{
					if ((num9 & 1) != 0)
					{
						num7++;
					}
					if ((num10 & 1) != 0)
					{
						num8++;
					}
					num11 = 1f / (float)num9 * (float)this.mWidth;
					num12 = 1f / (float)num10 * (float)this.mHeight;
				}
				if (this.mFlip == UIBasicSprite.Flip.Horizontally || this.mFlip == UIBasicSprite.Flip.Both)
				{
					num += (float)num7 * num11;
					num3 -= (float)num5 * num11;
				}
				else
				{
					num += (float)num5 * num11;
					num3 -= (float)num7 * num11;
				}
				if (this.mFlip == UIBasicSprite.Flip.Vertically || this.mFlip == UIBasicSprite.Flip.Both)
				{
					num2 += (float)num8 * num12;
					num4 -= (float)num6 * num12;
				}
				else
				{
					num2 += (float)num6 * num12;
					num4 -= (float)num8 * num12;
				}
			}
			if (this.mDrawRegion.x != 0f || this.mDrawRegion.y != 0f || this.mDrawRegion.z != 1f || this.mDrawRegion.w != 0f)
			{
				float num13;
				float num14;
				if (this.mFixedAspect)
				{
					num13 = 0f;
					num14 = 0f;
				}
				else
				{
					Vector4 vector = (this.mAtlas != null) ? (this.border * this.pixelSize) : Vector4.zero;
					num13 = vector.x + vector.z;
					num14 = vector.y + vector.w;
				}
				float x = Mathf.Lerp(num, num3 - num13, this.mDrawRegion.x);
				float y = Mathf.Lerp(num2, num4 - num14, this.mDrawRegion.y);
				float z = Mathf.Lerp(num + num13, num3, this.mDrawRegion.z);
				float w = Mathf.Lerp(num2 + num14, num4, this.mDrawRegion.w);
				return new Vector4(x, y, z, w);
			}
			return new Vector4(num, num2, num3, num4);
		}
	}

	// Token: 0x170001BB RID: 443
	// (get) Token: 0x0600086C RID: 2156 RVA: 0x000458AC File Offset: 0x00043AAC
	public override bool premultipliedAlpha
	{
		get
		{
			INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
			return inguiatlas != null && inguiatlas.premultipliedAlpha;
		}
	}

	// Token: 0x0600086D RID: 2157 RVA: 0x000458D0 File Offset: 0x00043AD0
	public UISpriteData GetAtlasSprite()
	{
		if (!this.mSpriteSet)
		{
			this.mSprite = null;
		}
		if (this.mSprite == null)
		{
			INGUIAtlas inguiatlas = this.mAtlas as INGUIAtlas;
			if (inguiatlas != null)
			{
				if (!string.IsNullOrEmpty(this.mSpriteName))
				{
					UISpriteData sprite = inguiatlas.GetSprite(this.mSpriteName);
					if (sprite == null)
					{
						return null;
					}
					this.SetAtlasSprite(sprite);
				}
				if (this.mSprite == null && inguiatlas.spriteList.Count > 0)
				{
					UISpriteData uispriteData = inguiatlas.spriteList[0];
					if (uispriteData == null)
					{
						return null;
					}
					this.SetAtlasSprite(uispriteData);
					if (this.mSprite == null)
					{
						Debug.LogError((inguiatlas as UnityEngine.Object).name + " seems to have a null sprite!");
						return null;
					}
					this.mSpriteName = this.mSprite.name;
				}
			}
		}
		return this.mSprite;
	}

	// Token: 0x0600086E RID: 2158 RVA: 0x0004599C File Offset: 0x00043B9C
	protected void SetAtlasSprite(UISpriteData sp)
	{
		this.mChanged = true;
		this.mSpriteSet = true;
		if (sp != null)
		{
			this.mSprite = sp;
			this.mSpriteName = this.mSprite.name;
			return;
		}
		this.mSpriteName = ((this.mSprite != null) ? this.mSprite.name : "");
		this.mSprite = sp;
	}

	// Token: 0x0600086F RID: 2159 RVA: 0x000459FC File Offset: 0x00043BFC
	public override void MakePixelPerfect()
	{
		if (!this.isValid)
		{
			return;
		}
		base.MakePixelPerfect();
		if (this.mType == UIBasicSprite.Type.Tiled)
		{
			return;
		}
		UISpriteData atlasSprite = this.GetAtlasSprite();
		if (atlasSprite == null)
		{
			return;
		}
		Texture mainTexture = this.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		if ((this.mType == UIBasicSprite.Type.Simple || this.mType == UIBasicSprite.Type.Filled || !atlasSprite.hasBorder) && mainTexture != null)
		{
			int num = Mathf.RoundToInt(this.pixelSize * (float)(atlasSprite.width + atlasSprite.paddingLeft + atlasSprite.paddingRight));
			int num2 = Mathf.RoundToInt(this.pixelSize * (float)(atlasSprite.height + atlasSprite.paddingTop + atlasSprite.paddingBottom));
			if ((num & 1) == 1)
			{
				num++;
			}
			if ((num2 & 1) == 1)
			{
				num2++;
			}
			base.width = num;
			base.height = num2;
		}
	}

	// Token: 0x06000870 RID: 2160 RVA: 0x00045AC6 File Offset: 0x00043CC6
	protected override void OnInit()
	{
		if (!this.mFillCenter)
		{
			this.mFillCenter = true;
			this.centerType = UIBasicSprite.AdvancedType.Invisible;
		}
		base.OnInit();
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x00045AE4 File Offset: 0x00043CE4
	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (this.mChanged || !this.mSpriteSet)
		{
			this.mSpriteSet = true;
			this.mSprite = null;
			this.mChanged = true;
		}
		if (this.mFixedAspect)
		{
			if ((!this.mSpriteSet || this.mSprite == null) && this.GetAtlasSprite() == null)
			{
				return;
			}
			if (this.mSprite != null)
			{
				int paddingLeft = this.mSprite.paddingLeft;
				int paddingBottom = this.mSprite.paddingBottom;
				int paddingRight = this.mSprite.paddingRight;
				int paddingTop = this.mSprite.paddingTop;
				float num = (float)Mathf.RoundToInt((float)this.mSprite.width);
				int num2 = Mathf.RoundToInt((float)this.mSprite.height);
				float num3 = num + (float)(paddingLeft + paddingRight);
				num2 += paddingTop + paddingBottom;
				float num4 = (float)this.mWidth;
				float num5 = (float)this.mHeight;
				float num6 = num4 / num5;
				float num7 = num3 / (float)num2;
				if (num7 < num6)
				{
					float num8 = (num4 - num5 * num7) / num4 * 0.5f;
					base.drawRegion = new Vector4(num8, 0f, 1f - num8, 1f);
					return;
				}
				float num9 = (num5 - num4 / num7) / num5 * 0.5f;
				base.drawRegion = new Vector4(0f, num9, 1f, 1f - num9);
			}
		}
	}

	// Token: 0x06000872 RID: 2162 RVA: 0x00045C38 File Offset: 0x00043E38
	public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		Texture mainTexture = this.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		if ((!this.mSpriteSet || this.mSprite == null) && this.GetAtlasSprite() == null)
		{
			return;
		}
		Rect rect = new Rect((float)this.mSprite.x, (float)this.mSprite.y, (float)this.mSprite.width, (float)this.mSprite.height);
		Rect rect2 = new Rect((float)(this.mSprite.x + this.mSprite.borderLeft), (float)(this.mSprite.y + this.mSprite.borderTop), (float)(this.mSprite.width - this.mSprite.borderLeft - this.mSprite.borderRight), (float)(this.mSprite.height - this.mSprite.borderBottom - this.mSprite.borderTop));
		rect = NGUIMath.ConvertToTexCoords(rect, mainTexture.width, mainTexture.height);
		rect2 = NGUIMath.ConvertToTexCoords(rect2, mainTexture.width, mainTexture.height);
		int count = verts.Count;
		base.Fill(verts, uvs, cols, rect, rect2);
		if (this.onPostFill != null)
		{
			this.onPostFill(this, count, verts, uvs, cols);
		}
	}

	// Token: 0x04000750 RID: 1872
	[HideInInspector]
	[SerializeField]
	private UnityEngine.Object mAtlas;

	// Token: 0x04000751 RID: 1873
	[HideInInspector]
	[SerializeField]
	private string mSpriteName;

	// Token: 0x04000752 RID: 1874
	[HideInInspector]
	[SerializeField]
	private bool mFixedAspect;

	// Token: 0x04000753 RID: 1875
	[HideInInspector]
	[SerializeField]
	private bool mFillCenter = true;

	// Token: 0x04000754 RID: 1876
	[NonSerialized]
	protected UISpriteData mSprite;

	// Token: 0x04000755 RID: 1877
	[NonSerialized]
	private bool mSpriteSet;
}
