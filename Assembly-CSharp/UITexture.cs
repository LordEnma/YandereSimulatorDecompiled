using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000AF RID: 175
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Texture")]
public class UITexture : UIBasicSprite
{
	// Token: 0x170001D0 RID: 464
	// (get) Token: 0x060008C5 RID: 2245 RVA: 0x00047EB0 File Offset: 0x000460B0
	// (set) Token: 0x060008C6 RID: 2246 RVA: 0x00047EE4 File Offset: 0x000460E4
	public override Texture mainTexture
	{
		get
		{
			if (this.mTexture != null)
			{
				return this.mTexture;
			}
			if (this.mMat != null)
			{
				return this.mMat.mainTexture;
			}
			return null;
		}
		set
		{
			if (this.mTexture != value)
			{
				if (this.drawCall != null && this.drawCall.widgetCount == 1 && this.mMat == null)
				{
					this.mTexture = value;
					this.drawCall.mainTexture = value;
					return;
				}
				base.RemoveFromPanel();
				this.mTexture = value;
				this.mPMA = -1;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170001D1 RID: 465
	// (get) Token: 0x060008C7 RID: 2247 RVA: 0x00047F57 File Offset: 0x00046157
	// (set) Token: 0x060008C8 RID: 2248 RVA: 0x00047F5F File Offset: 0x0004615F
	public override Material material
	{
		get
		{
			return this.mMat;
		}
		set
		{
			if (this.mMat != value)
			{
				base.RemoveFromPanel();
				this.mShader = null;
				this.mMat = value;
				this.mPMA = -1;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170001D2 RID: 466
	// (get) Token: 0x060008C9 RID: 2249 RVA: 0x00047F90 File Offset: 0x00046190
	// (set) Token: 0x060008CA RID: 2250 RVA: 0x00047FD0 File Offset: 0x000461D0
	public override Shader shader
	{
		get
		{
			if (this.mMat != null)
			{
				return this.mMat.shader;
			}
			if (this.mShader == null)
			{
				this.mShader = Shader.Find("Unlit/Transparent Colored");
			}
			return this.mShader;
		}
		set
		{
			if (this.mShader != value)
			{
				if (this.drawCall != null && this.drawCall.widgetCount == 1 && this.mMat == null)
				{
					this.mShader = value;
					this.drawCall.shader = value;
					return;
				}
				base.RemoveFromPanel();
				this.mShader = value;
				this.mPMA = -1;
				this.mMat = null;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170001D3 RID: 467
	// (get) Token: 0x060008CB RID: 2251 RVA: 0x0004804C File Offset: 0x0004624C
	public override bool premultipliedAlpha
	{
		get
		{
			if (this.mPMA == -1)
			{
				Material material = this.material;
				this.mPMA = ((material != null && material.shader != null && material.shader.name.Contains("Premultiplied")) ? 1 : 0);
			}
			return this.mPMA == 1;
		}
	}

	// Token: 0x170001D4 RID: 468
	// (get) Token: 0x060008CC RID: 2252 RVA: 0x000480AA File Offset: 0x000462AA
	// (set) Token: 0x060008CD RID: 2253 RVA: 0x000480B2 File Offset: 0x000462B2
	public override Vector4 border
	{
		get
		{
			return this.mBorder;
		}
		set
		{
			if (this.mBorder != value)
			{
				this.mBorder = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170001D5 RID: 469
	// (get) Token: 0x060008CE RID: 2254 RVA: 0x000480CF File Offset: 0x000462CF
	// (set) Token: 0x060008CF RID: 2255 RVA: 0x000480D7 File Offset: 0x000462D7
	public Rect uvRect
	{
		get
		{
			return this.mRect;
		}
		set
		{
			if (this.mRect != value)
			{
				this.mRect = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170001D6 RID: 470
	// (get) Token: 0x060008D0 RID: 2256 RVA: 0x000480F4 File Offset: 0x000462F4
	public override Vector4 drawingDimensions
	{
		get
		{
			Vector2 pivotOffset = base.pivotOffset;
			float num = -pivotOffset.x * (float)this.mWidth;
			float num2 = -pivotOffset.y * (float)this.mHeight;
			float num3 = num + (float)this.mWidth;
			float num4 = num2 + (float)this.mHeight;
			if (this.mTexture != null && this.mType != UIBasicSprite.Type.Tiled)
			{
				int width = this.mTexture.width;
				int height = this.mTexture.height;
				int num5 = 0;
				int num6 = 0;
				float num7 = 1f;
				float num8 = 1f;
				if (width > 0 && height > 0 && (this.mType == UIBasicSprite.Type.Simple || this.mType == UIBasicSprite.Type.Filled))
				{
					if ((width & 1) != 0)
					{
						num5++;
					}
					if ((height & 1) != 0)
					{
						num6++;
					}
					num7 = 1f / (float)width * (float)this.mWidth;
					num8 = 1f / (float)height * (float)this.mHeight;
				}
				if (this.mFlip == UIBasicSprite.Flip.Horizontally || this.mFlip == UIBasicSprite.Flip.Both)
				{
					num += (float)num5 * num7;
				}
				else
				{
					num3 -= (float)num5 * num7;
				}
				if (this.mFlip == UIBasicSprite.Flip.Vertically || this.mFlip == UIBasicSprite.Flip.Both)
				{
					num2 += (float)num6 * num8;
				}
				else
				{
					num4 -= (float)num6 * num8;
				}
			}
			float num9;
			float num10;
			if (this.mFixedAspect)
			{
				num9 = 0f;
				num10 = 0f;
			}
			else
			{
				Vector4 border = this.border;
				num9 = border.x + border.z;
				num10 = border.y + border.w;
			}
			float x = Mathf.Lerp(num, num3 - num9, this.mDrawRegion.x);
			float y = Mathf.Lerp(num2, num4 - num10, this.mDrawRegion.y);
			float z = Mathf.Lerp(num + num9, num3, this.mDrawRegion.z);
			float w = Mathf.Lerp(num2 + num10, num4, this.mDrawRegion.w);
			return new Vector4(x, y, z, w);
		}
	}

	// Token: 0x170001D7 RID: 471
	// (get) Token: 0x060008D1 RID: 2257 RVA: 0x000482D1 File Offset: 0x000464D1
	// (set) Token: 0x060008D2 RID: 2258 RVA: 0x000482D9 File Offset: 0x000464D9
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

	// Token: 0x060008D3 RID: 2259 RVA: 0x00048310 File Offset: 0x00046510
	public override void MakePixelPerfect()
	{
		base.MakePixelPerfect();
		if (this.mType == UIBasicSprite.Type.Tiled)
		{
			return;
		}
		Texture mainTexture = this.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		if ((this.mType == UIBasicSprite.Type.Simple || this.mType == UIBasicSprite.Type.Filled || !base.hasBorder) && mainTexture != null)
		{
			int num = mainTexture.width;
			int num2 = mainTexture.height;
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

	// Token: 0x060008D4 RID: 2260 RVA: 0x00048390 File Offset: 0x00046590
	protected override void OnUpdate()
	{
		base.OnUpdate();
		if (this.mFixedAspect)
		{
			Texture mainTexture = this.mainTexture;
			if (mainTexture != null)
			{
				int num = mainTexture.width;
				int num2 = mainTexture.height;
				if ((num & 1) == 1)
				{
					num++;
				}
				if ((num2 & 1) == 1)
				{
					num2++;
				}
				float num3 = (float)this.mWidth;
				float num4 = (float)this.mHeight;
				float num5 = num3 / num4;
				float num6 = (float)num / (float)num2;
				if (num6 < num5)
				{
					float num7 = (num3 - num4 * num6) / num3 * 0.5f;
					base.drawRegion = new Vector4(num7, 0f, 1f - num7, 1f);
					return;
				}
				float num8 = (num4 - num3 / num6) / num4 * 0.5f;
				base.drawRegion = new Vector4(0f, num8, 1f, 1f - num8);
			}
		}
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x0004846C File Offset: 0x0004666C
	public override void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
		Texture mainTexture = this.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		Rect rect = new Rect(this.mRect.x * (float)mainTexture.width, this.mRect.y * (float)mainTexture.height, (float)mainTexture.width * this.mRect.width, (float)mainTexture.height * this.mRect.height);
		Rect inner = rect;
		Vector4 border = this.border;
		inner.xMin += border.x;
		inner.yMin += border.y;
		inner.xMax -= border.z;
		inner.yMax -= border.w;
		float num = 1f / (float)mainTexture.width;
		float num2 = 1f / (float)mainTexture.height;
		rect.xMin *= num;
		rect.xMax *= num;
		rect.yMin *= num2;
		rect.yMax *= num2;
		inner.xMin *= num;
		inner.xMax *= num;
		inner.yMin *= num2;
		inner.yMax *= num2;
		int count = verts.Count;
		base.Fill(verts, uvs, cols, rect, inner);
		if (this.onPostFill != null)
		{
			this.onPostFill(this, count, verts, uvs, cols);
		}
	}

	// Token: 0x0400079D RID: 1949
	[HideInInspector]
	[SerializeField]
	private Rect mRect = new Rect(0f, 0f, 1f, 1f);

	// Token: 0x0400079E RID: 1950
	[HideInInspector]
	[SerializeField]
	private Texture mTexture;

	// Token: 0x0400079F RID: 1951
	[HideInInspector]
	[SerializeField]
	private Shader mShader;

	// Token: 0x040007A0 RID: 1952
	[HideInInspector]
	[SerializeField]
	private Vector4 mBorder = Vector4.zero;

	// Token: 0x040007A1 RID: 1953
	[HideInInspector]
	[SerializeField]
	private bool mFixedAspect;

	// Token: 0x040007A2 RID: 1954
	[NonSerialized]
	private int mPMA = -1;
}
