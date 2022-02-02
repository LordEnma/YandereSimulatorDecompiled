using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Token: 0x0200007E RID: 126
public abstract class UIBasicSprite : UIWidget
{
	// Token: 0x1700006E RID: 110
	// (get) Token: 0x06000470 RID: 1136 RVA: 0x0002CA1A File Offset: 0x0002AC1A
	// (set) Token: 0x06000471 RID: 1137 RVA: 0x0002CA22 File Offset: 0x0002AC22
	public virtual UIBasicSprite.Type type
	{
		get
		{
			return this.mType;
		}
		set
		{
			if (this.mType != value)
			{
				this.mType = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x06000472 RID: 1138 RVA: 0x0002CA3A File Offset: 0x0002AC3A
	// (set) Token: 0x06000473 RID: 1139 RVA: 0x0002CA42 File Offset: 0x0002AC42
	public UIBasicSprite.Flip flip
	{
		get
		{
			return this.mFlip;
		}
		set
		{
			if (this.mFlip != value)
			{
				this.mFlip = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x17000070 RID: 112
	// (get) Token: 0x06000474 RID: 1140 RVA: 0x0002CA5A File Offset: 0x0002AC5A
	// (set) Token: 0x06000475 RID: 1141 RVA: 0x0002CA62 File Offset: 0x0002AC62
	public UIBasicSprite.FillDirection fillDirection
	{
		get
		{
			return this.mFillDirection;
		}
		set
		{
			if (this.mFillDirection != value)
			{
				this.mFillDirection = value;
				this.mChanged = true;
			}
		}
	}

	// Token: 0x17000071 RID: 113
	// (get) Token: 0x06000476 RID: 1142 RVA: 0x0002CA7B File Offset: 0x0002AC7B
	// (set) Token: 0x06000477 RID: 1143 RVA: 0x0002CA84 File Offset: 0x0002AC84
	public float fillAmount
	{
		get
		{
			return this.mFillAmount;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (this.mFillAmount != num)
			{
				this.mFillAmount = num;
				this.mChanged = true;
			}
		}
	}

	// Token: 0x17000072 RID: 114
	// (get) Token: 0x06000478 RID: 1144 RVA: 0x0002CAB0 File Offset: 0x0002ACB0
	public override int minWidth
	{
		get
		{
			if (this.type == UIBasicSprite.Type.Sliced || this.type == UIBasicSprite.Type.Advanced)
			{
				Vector4 vector = this.border * this.pixelSize;
				int num = Mathf.RoundToInt(vector.x + vector.z);
				return Mathf.Max(base.minWidth, ((num & 1) == 1) ? (num + 1) : num);
			}
			return base.minWidth;
		}
	}

	// Token: 0x17000073 RID: 115
	// (get) Token: 0x06000479 RID: 1145 RVA: 0x0002CB14 File Offset: 0x0002AD14
	public override int minHeight
	{
		get
		{
			if (this.type == UIBasicSprite.Type.Sliced || this.type == UIBasicSprite.Type.Advanced)
			{
				Vector4 vector = this.border * this.pixelSize;
				int num = Mathf.RoundToInt(vector.y + vector.w);
				return Mathf.Max(base.minHeight, ((num & 1) == 1) ? (num + 1) : num);
			}
			return base.minHeight;
		}
	}

	// Token: 0x17000074 RID: 116
	// (get) Token: 0x0600047A RID: 1146 RVA: 0x0002CB76 File Offset: 0x0002AD76
	// (set) Token: 0x0600047B RID: 1147 RVA: 0x0002CB7E File Offset: 0x0002AD7E
	public bool invert
	{
		get
		{
			return this.mInvert;
		}
		set
		{
			if (this.mInvert != value)
			{
				this.mInvert = value;
				this.mChanged = true;
			}
		}
	}

	// Token: 0x17000075 RID: 117
	// (get) Token: 0x0600047C RID: 1148 RVA: 0x0002CB98 File Offset: 0x0002AD98
	public bool hasBorder
	{
		get
		{
			Vector4 border = this.border;
			return border.x != 0f || border.y != 0f || border.z != 0f || border.w != 0f;
		}
	}

	// Token: 0x17000076 RID: 118
	// (get) Token: 0x0600047D RID: 1149 RVA: 0x0002CBE5 File Offset: 0x0002ADE5
	public virtual bool premultipliedAlpha
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000077 RID: 119
	// (get) Token: 0x0600047E RID: 1150 RVA: 0x0002CBE8 File Offset: 0x0002ADE8
	public virtual float pixelSize
	{
		get
		{
			return 1f;
		}
	}

	// Token: 0x17000078 RID: 120
	// (get) Token: 0x0600047F RID: 1151 RVA: 0x0002CBEF File Offset: 0x0002ADEF
	protected virtual Vector4 padding
	{
		get
		{
			return new Vector4(0f, 0f, 0f, 0f);
		}
	}

	// Token: 0x17000079 RID: 121
	// (get) Token: 0x06000480 RID: 1152 RVA: 0x0002CC0C File Offset: 0x0002AE0C
	protected Vector4 drawingUVs
	{
		get
		{
			switch (this.mFlip)
			{
			case UIBasicSprite.Flip.Horizontally:
				return new Vector4(this.mOuterUV.xMax, this.mOuterUV.yMin, this.mOuterUV.xMin, this.mOuterUV.yMax);
			case UIBasicSprite.Flip.Vertically:
				return new Vector4(this.mOuterUV.xMin, this.mOuterUV.yMax, this.mOuterUV.xMax, this.mOuterUV.yMin);
			case UIBasicSprite.Flip.Both:
				return new Vector4(this.mOuterUV.xMax, this.mOuterUV.yMax, this.mOuterUV.xMin, this.mOuterUV.yMin);
			default:
				return new Vector4(this.mOuterUV.xMin, this.mOuterUV.yMin, this.mOuterUV.xMax, this.mOuterUV.yMax);
			}
		}
	}

	// Token: 0x1700007A RID: 122
	// (get) Token: 0x06000481 RID: 1153 RVA: 0x0002CD00 File Offset: 0x0002AF00
	protected Color drawingColor
	{
		get
		{
			Color color = base.color;
			color.a = this.finalAlpha;
			if (this.premultipliedAlpha)
			{
				color = NGUITools.ApplyPMA(color);
			}
			return color;
		}
	}

	// Token: 0x06000482 RID: 1154 RVA: 0x0002CD34 File Offset: 0x0002AF34
	protected void Fill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols, Rect outer, Rect inner)
	{
		this.mOuterUV = outer;
		this.mInnerUV = inner;
		Vector4 drawingDimensions = this.drawingDimensions;
		Vector4 drawingUVs = this.drawingUVs;
		Color drawingColor = this.drawingColor;
		switch (this.type)
		{
		case UIBasicSprite.Type.Simple:
			this.SimpleFill(verts, uvs, cols, ref drawingDimensions, ref drawingUVs, ref drawingColor);
			return;
		case UIBasicSprite.Type.Sliced:
			this.SlicedFill(verts, uvs, cols, ref drawingDimensions, ref drawingUVs, ref drawingColor);
			return;
		case UIBasicSprite.Type.Tiled:
			this.TiledFill(verts, uvs, cols, ref drawingDimensions, ref drawingColor);
			return;
		case UIBasicSprite.Type.Filled:
			this.FilledFill(verts, uvs, cols, ref drawingDimensions, ref drawingUVs, ref drawingColor);
			return;
		case UIBasicSprite.Type.Advanced:
			this.AdvancedFill(verts, uvs, cols, ref drawingDimensions, ref drawingUVs, ref drawingColor);
			return;
		default:
			return;
		}
	}

	// Token: 0x06000483 RID: 1155 RVA: 0x0002CDD8 File Offset: 0x0002AFD8
	protected void SimpleFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols, ref Vector4 v, ref Vector4 u, ref Color c)
	{
		verts.Add(new Vector3(v.x, v.y));
		verts.Add(new Vector3(v.x, v.w));
		verts.Add(new Vector3(v.z, v.w));
		verts.Add(new Vector3(v.z, v.y));
		uvs.Add(new Vector2(u.x, u.y));
		uvs.Add(new Vector2(u.x, u.w));
		uvs.Add(new Vector2(u.z, u.w));
		uvs.Add(new Vector2(u.z, u.y));
		if (!this.mApplyGradient)
		{
			cols.Add(c);
			cols.Add(c);
			cols.Add(c);
			cols.Add(c);
			return;
		}
		this.AddVertexColours(cols, ref c, 1, 1);
		this.AddVertexColours(cols, ref c, 1, 2);
		this.AddVertexColours(cols, ref c, 2, 2);
		this.AddVertexColours(cols, ref c, 2, 1);
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0002CF18 File Offset: 0x0002B118
	protected void SlicedFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols, ref Vector4 v, ref Vector4 u, ref Color gc)
	{
		Vector4 vector = this.border * this.pixelSize;
		if (vector.x == 0f && vector.y == 0f && vector.z == 0f && vector.w == 0f)
		{
			this.SimpleFill(verts, uvs, cols, ref v, ref u, ref gc);
			return;
		}
		UIBasicSprite.mTempPos[0].x = v.x;
		UIBasicSprite.mTempPos[0].y = v.y;
		UIBasicSprite.mTempPos[3].x = v.z;
		UIBasicSprite.mTempPos[3].y = v.w;
		if (this.mFlip == UIBasicSprite.Flip.Horizontally || this.mFlip == UIBasicSprite.Flip.Both)
		{
			UIBasicSprite.mTempPos[1].x = UIBasicSprite.mTempPos[0].x + vector.z;
			UIBasicSprite.mTempPos[2].x = UIBasicSprite.mTempPos[3].x - vector.x;
			UIBasicSprite.mTempUVs[3].x = this.mOuterUV.xMin;
			UIBasicSprite.mTempUVs[2].x = this.mInnerUV.xMin;
			UIBasicSprite.mTempUVs[1].x = this.mInnerUV.xMax;
			UIBasicSprite.mTempUVs[0].x = this.mOuterUV.xMax;
		}
		else
		{
			UIBasicSprite.mTempPos[1].x = UIBasicSprite.mTempPos[0].x + vector.x;
			UIBasicSprite.mTempPos[2].x = UIBasicSprite.mTempPos[3].x - vector.z;
			UIBasicSprite.mTempUVs[0].x = this.mOuterUV.xMin;
			UIBasicSprite.mTempUVs[1].x = this.mInnerUV.xMin;
			UIBasicSprite.mTempUVs[2].x = this.mInnerUV.xMax;
			UIBasicSprite.mTempUVs[3].x = this.mOuterUV.xMax;
		}
		if (this.mFlip == UIBasicSprite.Flip.Vertically || this.mFlip == UIBasicSprite.Flip.Both)
		{
			UIBasicSprite.mTempPos[1].y = UIBasicSprite.mTempPos[0].y + vector.w;
			UIBasicSprite.mTempPos[2].y = UIBasicSprite.mTempPos[3].y - vector.y;
			UIBasicSprite.mTempUVs[3].y = this.mOuterUV.yMin;
			UIBasicSprite.mTempUVs[2].y = this.mInnerUV.yMin;
			UIBasicSprite.mTempUVs[1].y = this.mInnerUV.yMax;
			UIBasicSprite.mTempUVs[0].y = this.mOuterUV.yMax;
		}
		else
		{
			UIBasicSprite.mTempPos[1].y = UIBasicSprite.mTempPos[0].y + vector.y;
			UIBasicSprite.mTempPos[2].y = UIBasicSprite.mTempPos[3].y - vector.w;
			UIBasicSprite.mTempUVs[0].y = this.mOuterUV.yMin;
			UIBasicSprite.mTempUVs[1].y = this.mInnerUV.yMin;
			UIBasicSprite.mTempUVs[2].y = this.mInnerUV.yMax;
			UIBasicSprite.mTempUVs[3].y = this.mOuterUV.yMax;
		}
		for (int i = 0; i < 3; i++)
		{
			int num = i + 1;
			for (int j = 0; j < 3; j++)
			{
				if (this.centerType != UIBasicSprite.AdvancedType.Invisible || i != 1 || j != 1)
				{
					int num2 = j + 1;
					verts.Add(new Vector3(UIBasicSprite.mTempPos[i].x, UIBasicSprite.mTempPos[j].y));
					verts.Add(new Vector3(UIBasicSprite.mTempPos[i].x, UIBasicSprite.mTempPos[num2].y));
					verts.Add(new Vector3(UIBasicSprite.mTempPos[num].x, UIBasicSprite.mTempPos[num2].y));
					verts.Add(new Vector3(UIBasicSprite.mTempPos[num].x, UIBasicSprite.mTempPos[j].y));
					uvs.Add(new Vector2(UIBasicSprite.mTempUVs[i].x, UIBasicSprite.mTempUVs[j].y));
					uvs.Add(new Vector2(UIBasicSprite.mTempUVs[i].x, UIBasicSprite.mTempUVs[num2].y));
					uvs.Add(new Vector2(UIBasicSprite.mTempUVs[num].x, UIBasicSprite.mTempUVs[num2].y));
					uvs.Add(new Vector2(UIBasicSprite.mTempUVs[num].x, UIBasicSprite.mTempUVs[j].y));
					if (!this.mApplyGradient)
					{
						cols.Add(gc);
						cols.Add(gc);
						cols.Add(gc);
						cols.Add(gc);
					}
					else
					{
						this.AddVertexColours(cols, ref gc, i, j);
						this.AddVertexColours(cols, ref gc, i, num2);
						this.AddVertexColours(cols, ref gc, num, num2);
						this.AddVertexColours(cols, ref gc, num, j);
					}
				}
			}
		}
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x0002D4FC File Offset: 0x0002B6FC
	[DebuggerHidden]
	[DebuggerStepThrough]
	private void AddVertexColours(List<Color> cols, ref Color color, int x, int y)
	{
		Vector4 vector = this.border * this.pixelSize;
		if (this.type == UIBasicSprite.Type.Simple || (vector.x == 0f && vector.y == 0f && vector.z == 0f && vector.w == 0f))
		{
			if (y == 0 || y == 1)
			{
				cols.Add(color * this.mGradientBottom);
				return;
			}
			if (y == 2 || y == 3)
			{
				cols.Add(color * this.mGradientTop);
				return;
			}
		}
		else
		{
			if (y == 0)
			{
				cols.Add(color * this.mGradientBottom);
			}
			if (y == 1)
			{
				Color b = Color.Lerp(this.mGradientBottom, this.mGradientTop, vector.y / (float)this.mHeight);
				cols.Add(color * b);
			}
			if (y == 2)
			{
				Color b2 = Color.Lerp(this.mGradientTop, this.mGradientBottom, vector.w / (float)this.mHeight);
				cols.Add(color * b2);
			}
			if (y == 3)
			{
				cols.Add(color * this.mGradientTop);
			}
		}
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x0002D644 File Offset: 0x0002B844
	protected void TiledFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols, ref Vector4 v, ref Color c)
	{
		Texture mainTexture = this.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		Vector2 vector = new Vector2(this.mInnerUV.width * (float)mainTexture.width, this.mInnerUV.height * (float)mainTexture.height);
		vector *= this.pixelSize;
		if (vector.x < 2f || vector.y < 2f)
		{
			return;
		}
		Vector4 padding = this.padding;
		Vector4 vector2;
		Vector4 vector3;
		if (this.mFlip == UIBasicSprite.Flip.Horizontally || this.mFlip == UIBasicSprite.Flip.Both)
		{
			vector2.x = this.mInnerUV.xMax;
			vector2.z = this.mInnerUV.xMin;
			vector3.x = padding.z * this.pixelSize;
			vector3.z = padding.x * this.pixelSize;
		}
		else
		{
			vector2.x = this.mInnerUV.xMin;
			vector2.z = this.mInnerUV.xMax;
			vector3.x = padding.x * this.pixelSize;
			vector3.z = padding.z * this.pixelSize;
		}
		if (this.mFlip == UIBasicSprite.Flip.Vertically || this.mFlip == UIBasicSprite.Flip.Both)
		{
			vector2.y = this.mInnerUV.yMax;
			vector2.w = this.mInnerUV.yMin;
			vector3.y = padding.w * this.pixelSize;
			vector3.w = padding.y * this.pixelSize;
		}
		else
		{
			vector2.y = this.mInnerUV.yMin;
			vector2.w = this.mInnerUV.yMax;
			vector3.y = padding.y * this.pixelSize;
			vector3.w = padding.w * this.pixelSize;
		}
		float num = v.x;
		float num2 = v.y;
		float x = vector2.x;
		float y = vector2.y;
		while (num2 < v.w)
		{
			num2 += vector3.y;
			num = v.x;
			float num3 = num2 + vector.y;
			float y2 = vector2.w;
			if (num3 > v.w)
			{
				y2 = Mathf.Lerp(vector2.y, vector2.w, (v.w - num2) / vector.y);
				num3 = v.w;
			}
			while (num < v.z)
			{
				num += vector3.x;
				float num4 = num + vector.x;
				float x2 = vector2.z;
				if (num4 > v.z)
				{
					x2 = Mathf.Lerp(vector2.x, vector2.z, (v.z - num) / vector.x);
					num4 = v.z;
				}
				verts.Add(new Vector3(num, num2));
				verts.Add(new Vector3(num, num3));
				verts.Add(new Vector3(num4, num3));
				verts.Add(new Vector3(num4, num2));
				uvs.Add(new Vector2(x, y));
				uvs.Add(new Vector2(x, y2));
				uvs.Add(new Vector2(x2, y2));
				uvs.Add(new Vector2(x2, y));
				cols.Add(c);
				cols.Add(c);
				cols.Add(c);
				cols.Add(c);
				num += vector.x + vector3.z;
			}
			num2 += vector.y + vector3.w;
		}
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x0002D9F0 File Offset: 0x0002BBF0
	protected void FilledFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols, ref Vector4 v, ref Vector4 u, ref Color c)
	{
		if (this.mFillAmount < 0.001f)
		{
			return;
		}
		if (this.mFillDirection == UIBasicSprite.FillDirection.Horizontal || this.mFillDirection == UIBasicSprite.FillDirection.Vertical)
		{
			if (this.mFillDirection == UIBasicSprite.FillDirection.Horizontal)
			{
				float num = (u.z - u.x) * this.mFillAmount;
				if (this.mInvert)
				{
					v.x = v.z - (v.z - v.x) * this.mFillAmount;
					u.x = u.z - num;
				}
				else
				{
					v.z = v.x + (v.z - v.x) * this.mFillAmount;
					u.z = u.x + num;
				}
			}
			else if (this.mFillDirection == UIBasicSprite.FillDirection.Vertical)
			{
				float num2 = (u.w - u.y) * this.mFillAmount;
				if (this.mInvert)
				{
					v.y = v.w - (v.w - v.y) * this.mFillAmount;
					u.y = u.w - num2;
				}
				else
				{
					v.w = v.y + (v.w - v.y) * this.mFillAmount;
					u.w = u.y + num2;
				}
			}
		}
		UIBasicSprite.mTempPos[0] = new Vector2(v.x, v.y);
		UIBasicSprite.mTempPos[1] = new Vector2(v.x, v.w);
		UIBasicSprite.mTempPos[2] = new Vector2(v.z, v.w);
		UIBasicSprite.mTempPos[3] = new Vector2(v.z, v.y);
		UIBasicSprite.mTempUVs[0] = new Vector2(u.x, u.y);
		UIBasicSprite.mTempUVs[1] = new Vector2(u.x, u.w);
		UIBasicSprite.mTempUVs[2] = new Vector2(u.z, u.w);
		UIBasicSprite.mTempUVs[3] = new Vector2(u.z, u.y);
		if (this.mFillAmount < 1f)
		{
			if (this.mFillDirection == UIBasicSprite.FillDirection.Radial90)
			{
				if (UIBasicSprite.RadialCut(UIBasicSprite.mTempPos, UIBasicSprite.mTempUVs, this.mFillAmount, this.mInvert, 0))
				{
					for (int i = 0; i < 4; i++)
					{
						verts.Add(UIBasicSprite.mTempPos[i]);
						uvs.Add(UIBasicSprite.mTempUVs[i]);
						cols.Add(c);
					}
				}
				return;
			}
			if (this.mFillDirection == UIBasicSprite.FillDirection.Radial180)
			{
				for (int j = 0; j < 2; j++)
				{
					float t = 0f;
					float t2 = 1f;
					float t3;
					float t4;
					if (j == 0)
					{
						t3 = 0f;
						t4 = 0.5f;
					}
					else
					{
						t3 = 0.5f;
						t4 = 1f;
					}
					UIBasicSprite.mTempPos[0].x = Mathf.Lerp(v.x, v.z, t3);
					UIBasicSprite.mTempPos[1].x = UIBasicSprite.mTempPos[0].x;
					UIBasicSprite.mTempPos[2].x = Mathf.Lerp(v.x, v.z, t4);
					UIBasicSprite.mTempPos[3].x = UIBasicSprite.mTempPos[2].x;
					UIBasicSprite.mTempPos[0].y = Mathf.Lerp(v.y, v.w, t);
					UIBasicSprite.mTempPos[1].y = Mathf.Lerp(v.y, v.w, t2);
					UIBasicSprite.mTempPos[2].y = UIBasicSprite.mTempPos[1].y;
					UIBasicSprite.mTempPos[3].y = UIBasicSprite.mTempPos[0].y;
					UIBasicSprite.mTempUVs[0].x = Mathf.Lerp(u.x, u.z, t3);
					UIBasicSprite.mTempUVs[1].x = UIBasicSprite.mTempUVs[0].x;
					UIBasicSprite.mTempUVs[2].x = Mathf.Lerp(u.x, u.z, t4);
					UIBasicSprite.mTempUVs[3].x = UIBasicSprite.mTempUVs[2].x;
					UIBasicSprite.mTempUVs[0].y = Mathf.Lerp(u.y, u.w, t);
					UIBasicSprite.mTempUVs[1].y = Mathf.Lerp(u.y, u.w, t2);
					UIBasicSprite.mTempUVs[2].y = UIBasicSprite.mTempUVs[1].y;
					UIBasicSprite.mTempUVs[3].y = UIBasicSprite.mTempUVs[0].y;
					float value = (!this.mInvert) ? (this.fillAmount * 2f - (float)j) : (this.mFillAmount * 2f - (float)(1 - j));
					if (UIBasicSprite.RadialCut(UIBasicSprite.mTempPos, UIBasicSprite.mTempUVs, Mathf.Clamp01(value), !this.mInvert, NGUIMath.RepeatIndex(j + 3, 4)))
					{
						for (int k = 0; k < 4; k++)
						{
							verts.Add(UIBasicSprite.mTempPos[k]);
							uvs.Add(UIBasicSprite.mTempUVs[k]);
							cols.Add(c);
						}
					}
				}
				return;
			}
			if (this.mFillDirection == UIBasicSprite.FillDirection.Radial360)
			{
				for (int l = 0; l < 4; l++)
				{
					float t5;
					float t6;
					if (l < 2)
					{
						t5 = 0f;
						t6 = 0.5f;
					}
					else
					{
						t5 = 0.5f;
						t6 = 1f;
					}
					float t7;
					float t8;
					if (l == 0 || l == 3)
					{
						t7 = 0f;
						t8 = 0.5f;
					}
					else
					{
						t7 = 0.5f;
						t8 = 1f;
					}
					UIBasicSprite.mTempPos[0].x = Mathf.Lerp(v.x, v.z, t5);
					UIBasicSprite.mTempPos[1].x = UIBasicSprite.mTempPos[0].x;
					UIBasicSprite.mTempPos[2].x = Mathf.Lerp(v.x, v.z, t6);
					UIBasicSprite.mTempPos[3].x = UIBasicSprite.mTempPos[2].x;
					UIBasicSprite.mTempPos[0].y = Mathf.Lerp(v.y, v.w, t7);
					UIBasicSprite.mTempPos[1].y = Mathf.Lerp(v.y, v.w, t8);
					UIBasicSprite.mTempPos[2].y = UIBasicSprite.mTempPos[1].y;
					UIBasicSprite.mTempPos[3].y = UIBasicSprite.mTempPos[0].y;
					UIBasicSprite.mTempUVs[0].x = Mathf.Lerp(u.x, u.z, t5);
					UIBasicSprite.mTempUVs[1].x = UIBasicSprite.mTempUVs[0].x;
					UIBasicSprite.mTempUVs[2].x = Mathf.Lerp(u.x, u.z, t6);
					UIBasicSprite.mTempUVs[3].x = UIBasicSprite.mTempUVs[2].x;
					UIBasicSprite.mTempUVs[0].y = Mathf.Lerp(u.y, u.w, t7);
					UIBasicSprite.mTempUVs[1].y = Mathf.Lerp(u.y, u.w, t8);
					UIBasicSprite.mTempUVs[2].y = UIBasicSprite.mTempUVs[1].y;
					UIBasicSprite.mTempUVs[3].y = UIBasicSprite.mTempUVs[0].y;
					float value2 = this.mInvert ? (this.mFillAmount * 4f - (float)NGUIMath.RepeatIndex(l + 2, 4)) : (this.mFillAmount * 4f - (float)(3 - NGUIMath.RepeatIndex(l + 2, 4)));
					if (UIBasicSprite.RadialCut(UIBasicSprite.mTempPos, UIBasicSprite.mTempUVs, Mathf.Clamp01(value2), this.mInvert, NGUIMath.RepeatIndex(l + 2, 4)))
					{
						for (int m = 0; m < 4; m++)
						{
							verts.Add(UIBasicSprite.mTempPos[m]);
							uvs.Add(UIBasicSprite.mTempUVs[m]);
							cols.Add(c);
						}
					}
				}
				return;
			}
		}
		for (int n = 0; n < 4; n++)
		{
			verts.Add(UIBasicSprite.mTempPos[n]);
			uvs.Add(UIBasicSprite.mTempUVs[n]);
			cols.Add(c);
		}
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0002E358 File Offset: 0x0002C558
	protected void AdvancedFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols, ref Vector4 v, ref Vector4 u, ref Color c)
	{
		Texture mainTexture = this.mainTexture;
		if (mainTexture == null)
		{
			return;
		}
		Vector4 vector = this.border * this.pixelSize;
		if (vector.x == 0f && vector.y == 0f && vector.z == 0f && vector.w == 0f)
		{
			this.SimpleFill(verts, uvs, cols, ref v, ref u, ref c);
			return;
		}
		Vector2 vector2 = new Vector2(this.mInnerUV.width * (float)mainTexture.width, this.mInnerUV.height * (float)mainTexture.height);
		vector2 *= this.pixelSize;
		if (vector2.x < 1f)
		{
			vector2.x = 1f;
		}
		if (vector2.y < 1f)
		{
			vector2.y = 1f;
		}
		UIBasicSprite.mTempPos[0].x = v.x;
		UIBasicSprite.mTempPos[0].y = v.y;
		UIBasicSprite.mTempPos[3].x = v.z;
		UIBasicSprite.mTempPos[3].y = v.w;
		if (this.mFlip == UIBasicSprite.Flip.Horizontally || this.mFlip == UIBasicSprite.Flip.Both)
		{
			UIBasicSprite.mTempPos[1].x = UIBasicSprite.mTempPos[0].x + vector.z;
			UIBasicSprite.mTempPos[2].x = UIBasicSprite.mTempPos[3].x - vector.x;
			UIBasicSprite.mTempUVs[3].x = this.mOuterUV.xMin;
			UIBasicSprite.mTempUVs[2].x = this.mInnerUV.xMin;
			UIBasicSprite.mTempUVs[1].x = this.mInnerUV.xMax;
			UIBasicSprite.mTempUVs[0].x = this.mOuterUV.xMax;
		}
		else
		{
			UIBasicSprite.mTempPos[1].x = UIBasicSprite.mTempPos[0].x + vector.x;
			UIBasicSprite.mTempPos[2].x = UIBasicSprite.mTempPos[3].x - vector.z;
			UIBasicSprite.mTempUVs[0].x = this.mOuterUV.xMin;
			UIBasicSprite.mTempUVs[1].x = this.mInnerUV.xMin;
			UIBasicSprite.mTempUVs[2].x = this.mInnerUV.xMax;
			UIBasicSprite.mTempUVs[3].x = this.mOuterUV.xMax;
		}
		if (this.mFlip == UIBasicSprite.Flip.Vertically || this.mFlip == UIBasicSprite.Flip.Both)
		{
			UIBasicSprite.mTempPos[1].y = UIBasicSprite.mTempPos[0].y + vector.w;
			UIBasicSprite.mTempPos[2].y = UIBasicSprite.mTempPos[3].y - vector.y;
			UIBasicSprite.mTempUVs[3].y = this.mOuterUV.yMin;
			UIBasicSprite.mTempUVs[2].y = this.mInnerUV.yMin;
			UIBasicSprite.mTempUVs[1].y = this.mInnerUV.yMax;
			UIBasicSprite.mTempUVs[0].y = this.mOuterUV.yMax;
		}
		else
		{
			UIBasicSprite.mTempPos[1].y = UIBasicSprite.mTempPos[0].y + vector.y;
			UIBasicSprite.mTempPos[2].y = UIBasicSprite.mTempPos[3].y - vector.w;
			UIBasicSprite.mTempUVs[0].y = this.mOuterUV.yMin;
			UIBasicSprite.mTempUVs[1].y = this.mInnerUV.yMin;
			UIBasicSprite.mTempUVs[2].y = this.mInnerUV.yMax;
			UIBasicSprite.mTempUVs[3].y = this.mOuterUV.yMax;
		}
		for (int i = 0; i < 3; i++)
		{
			int num = i + 1;
			for (int j = 0; j < 3; j++)
			{
				if (this.centerType != UIBasicSprite.AdvancedType.Invisible || i != 1 || j != 1)
				{
					int num2 = j + 1;
					if (i == 1 && j == 1)
					{
						if (this.centerType == UIBasicSprite.AdvancedType.Tiled)
						{
							float x = UIBasicSprite.mTempPos[i].x;
							float x2 = UIBasicSprite.mTempPos[num].x;
							float y = UIBasicSprite.mTempPos[j].y;
							float y2 = UIBasicSprite.mTempPos[num2].y;
							float x3 = UIBasicSprite.mTempUVs[i].x;
							float y3 = UIBasicSprite.mTempUVs[j].y;
							for (float num3 = y; num3 < y2; num3 += vector2.y)
							{
								float num4 = x;
								float num5 = UIBasicSprite.mTempUVs[num2].y;
								float num6 = num3 + vector2.y;
								if (num6 > y2)
								{
									num5 = Mathf.Lerp(y3, num5, (y2 - num3) / vector2.y);
									num6 = y2;
								}
								while (num4 < x2)
								{
									float num7 = num4 + vector2.x;
									float num8 = UIBasicSprite.mTempUVs[num].x;
									if (num7 > x2)
									{
										num8 = Mathf.Lerp(x3, num8, (x2 - num4) / vector2.x);
										num7 = x2;
									}
									UIBasicSprite.Fill(verts, uvs, cols, num4, num7, num3, num6, x3, num8, y3, num5, c);
									num4 += vector2.x;
								}
							}
						}
						else if (this.centerType == UIBasicSprite.AdvancedType.Sliced)
						{
							UIBasicSprite.Fill(verts, uvs, cols, UIBasicSprite.mTempPos[i].x, UIBasicSprite.mTempPos[num].x, UIBasicSprite.mTempPos[j].y, UIBasicSprite.mTempPos[num2].y, UIBasicSprite.mTempUVs[i].x, UIBasicSprite.mTempUVs[num].x, UIBasicSprite.mTempUVs[j].y, UIBasicSprite.mTempUVs[num2].y, c);
						}
					}
					else if (i == 1)
					{
						if ((j == 0 && this.bottomType == UIBasicSprite.AdvancedType.Tiled) || (j == 2 && this.topType == UIBasicSprite.AdvancedType.Tiled))
						{
							float x4 = UIBasicSprite.mTempPos[i].x;
							float x5 = UIBasicSprite.mTempPos[num].x;
							float y4 = UIBasicSprite.mTempPos[j].y;
							float y5 = UIBasicSprite.mTempPos[num2].y;
							float x6 = UIBasicSprite.mTempUVs[i].x;
							float y6 = UIBasicSprite.mTempUVs[j].y;
							float y7 = UIBasicSprite.mTempUVs[num2].y;
							for (float num9 = x4; num9 < x5; num9 += vector2.x)
							{
								float num10 = num9 + vector2.x;
								float num11 = UIBasicSprite.mTempUVs[num].x;
								if (num10 > x5)
								{
									num11 = Mathf.Lerp(x6, num11, (x5 - num9) / vector2.x);
									num10 = x5;
								}
								UIBasicSprite.Fill(verts, uvs, cols, num9, num10, y4, y5, x6, num11, y6, y7, c);
							}
						}
						else if ((j == 0 && this.bottomType != UIBasicSprite.AdvancedType.Invisible) || (j == 2 && this.topType != UIBasicSprite.AdvancedType.Invisible))
						{
							UIBasicSprite.Fill(verts, uvs, cols, UIBasicSprite.mTempPos[i].x, UIBasicSprite.mTempPos[num].x, UIBasicSprite.mTempPos[j].y, UIBasicSprite.mTempPos[num2].y, UIBasicSprite.mTempUVs[i].x, UIBasicSprite.mTempUVs[num].x, UIBasicSprite.mTempUVs[j].y, UIBasicSprite.mTempUVs[num2].y, c);
						}
					}
					else if (j == 1)
					{
						if ((i == 0 && this.leftType == UIBasicSprite.AdvancedType.Tiled) || (i == 2 && this.rightType == UIBasicSprite.AdvancedType.Tiled))
						{
							float x7 = UIBasicSprite.mTempPos[i].x;
							float x8 = UIBasicSprite.mTempPos[num].x;
							float y8 = UIBasicSprite.mTempPos[j].y;
							float y9 = UIBasicSprite.mTempPos[num2].y;
							float x9 = UIBasicSprite.mTempUVs[i].x;
							float x10 = UIBasicSprite.mTempUVs[num].x;
							float y10 = UIBasicSprite.mTempUVs[j].y;
							for (float num12 = y8; num12 < y9; num12 += vector2.y)
							{
								float num13 = UIBasicSprite.mTempUVs[num2].y;
								float num14 = num12 + vector2.y;
								if (num14 > y9)
								{
									num13 = Mathf.Lerp(y10, num13, (y9 - num12) / vector2.y);
									num14 = y9;
								}
								UIBasicSprite.Fill(verts, uvs, cols, x7, x8, num12, num14, x9, x10, y10, num13, c);
							}
						}
						else if ((i == 0 && this.leftType != UIBasicSprite.AdvancedType.Invisible) || (i == 2 && this.rightType != UIBasicSprite.AdvancedType.Invisible))
						{
							UIBasicSprite.Fill(verts, uvs, cols, UIBasicSprite.mTempPos[i].x, UIBasicSprite.mTempPos[num].x, UIBasicSprite.mTempPos[j].y, UIBasicSprite.mTempPos[num2].y, UIBasicSprite.mTempUVs[i].x, UIBasicSprite.mTempUVs[num].x, UIBasicSprite.mTempUVs[j].y, UIBasicSprite.mTempUVs[num2].y, c);
						}
					}
					else if ((j != 0 || this.bottomType != UIBasicSprite.AdvancedType.Invisible) && (j != 2 || this.topType != UIBasicSprite.AdvancedType.Invisible) && (i != 0 || this.leftType != UIBasicSprite.AdvancedType.Invisible) && (i != 2 || this.rightType != UIBasicSprite.AdvancedType.Invisible))
					{
						UIBasicSprite.Fill(verts, uvs, cols, UIBasicSprite.mTempPos[i].x, UIBasicSprite.mTempPos[num].x, UIBasicSprite.mTempPos[j].y, UIBasicSprite.mTempPos[num2].y, UIBasicSprite.mTempUVs[i].x, UIBasicSprite.mTempUVs[num].x, UIBasicSprite.mTempUVs[j].y, UIBasicSprite.mTempUVs[num2].y, c);
					}
				}
			}
		}
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x0002EE80 File Offset: 0x0002D080
	private static bool RadialCut(Vector2[] xy, Vector2[] uv, float fill, bool invert, int corner)
	{
		if (fill < 0.001f)
		{
			return false;
		}
		if ((corner & 1) == 1)
		{
			invert = !invert;
		}
		if (!invert && fill > 0.999f)
		{
			return true;
		}
		float num = Mathf.Clamp01(fill);
		if (invert)
		{
			num = 1f - num;
		}
		num *= 1.5707964f;
		float cos = Mathf.Cos(num);
		float sin = Mathf.Sin(num);
		UIBasicSprite.RadialCut(xy, cos, sin, invert, corner);
		UIBasicSprite.RadialCut(uv, cos, sin, invert, corner);
		return true;
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x0002EEF0 File Offset: 0x0002D0F0
	private static void RadialCut(Vector2[] xy, float cos, float sin, bool invert, int corner)
	{
		int num = NGUIMath.RepeatIndex(corner + 1, 4);
		int num2 = NGUIMath.RepeatIndex(corner + 2, 4);
		int num3 = NGUIMath.RepeatIndex(corner + 3, 4);
		if ((corner & 1) == 1)
		{
			if (sin > cos)
			{
				cos /= sin;
				sin = 1f;
				if (invert)
				{
					xy[num].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
					xy[num2].x = xy[num].x;
				}
			}
			else if (cos > sin)
			{
				sin /= cos;
				cos = 1f;
				if (!invert)
				{
					xy[num2].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
					xy[num3].y = xy[num2].y;
				}
			}
			else
			{
				cos = 1f;
				sin = 1f;
			}
			if (!invert)
			{
				xy[num3].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
				return;
			}
			xy[num].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
			return;
		}
		else
		{
			if (cos > sin)
			{
				sin /= cos;
				cos = 1f;
				if (!invert)
				{
					xy[num].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
					xy[num2].y = xy[num].y;
				}
			}
			else if (sin > cos)
			{
				cos /= sin;
				sin = 1f;
				if (invert)
				{
					xy[num2].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
					xy[num3].x = xy[num2].x;
				}
			}
			else
			{
				cos = 1f;
				sin = 1f;
			}
			if (invert)
			{
				xy[num3].y = Mathf.Lerp(xy[corner].y, xy[num2].y, sin);
				return;
			}
			xy[num].x = Mathf.Lerp(xy[corner].x, xy[num2].x, cos);
			return;
		}
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x0002F15C File Offset: 0x0002D35C
	private static void Fill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols, float v0x, float v1x, float v0y, float v1y, float u0x, float u1x, float u0y, float u1y, Color col)
	{
		verts.Add(new Vector3(v0x, v0y));
		verts.Add(new Vector3(v0x, v1y));
		verts.Add(new Vector3(v1x, v1y));
		verts.Add(new Vector3(v1x, v0y));
		uvs.Add(new Vector2(u0x, u0y));
		uvs.Add(new Vector2(u0x, u1y));
		uvs.Add(new Vector2(u1x, u1y));
		uvs.Add(new Vector2(u1x, u0y));
		cols.Add(col);
		cols.Add(col);
		cols.Add(col);
		cols.Add(col);
	}

	// Token: 0x040004FE RID: 1278
	[HideInInspector]
	[SerializeField]
	protected UIBasicSprite.Type mType;

	// Token: 0x040004FF RID: 1279
	[HideInInspector]
	[SerializeField]
	protected UIBasicSprite.FillDirection mFillDirection = UIBasicSprite.FillDirection.Radial360;

	// Token: 0x04000500 RID: 1280
	[Range(0f, 1f)]
	[HideInInspector]
	[SerializeField]
	protected float mFillAmount = 1f;

	// Token: 0x04000501 RID: 1281
	[HideInInspector]
	[SerializeField]
	protected bool mInvert;

	// Token: 0x04000502 RID: 1282
	[HideInInspector]
	[SerializeField]
	protected UIBasicSprite.Flip mFlip;

	// Token: 0x04000503 RID: 1283
	[HideInInspector]
	[SerializeField]
	protected bool mApplyGradient;

	// Token: 0x04000504 RID: 1284
	[HideInInspector]
	[SerializeField]
	protected Color mGradientTop = Color.white;

	// Token: 0x04000505 RID: 1285
	[HideInInspector]
	[SerializeField]
	protected Color mGradientBottom = new Color(0.7f, 0.7f, 0.7f);

	// Token: 0x04000506 RID: 1286
	[NonSerialized]
	protected Rect mInnerUV;

	// Token: 0x04000507 RID: 1287
	[NonSerialized]
	protected Rect mOuterUV;

	// Token: 0x04000508 RID: 1288
	public UIBasicSprite.AdvancedType centerType = UIBasicSprite.AdvancedType.Sliced;

	// Token: 0x04000509 RID: 1289
	public UIBasicSprite.AdvancedType leftType = UIBasicSprite.AdvancedType.Sliced;

	// Token: 0x0400050A RID: 1290
	public UIBasicSprite.AdvancedType rightType = UIBasicSprite.AdvancedType.Sliced;

	// Token: 0x0400050B RID: 1291
	public UIBasicSprite.AdvancedType bottomType = UIBasicSprite.AdvancedType.Sliced;

	// Token: 0x0400050C RID: 1292
	public UIBasicSprite.AdvancedType topType = UIBasicSprite.AdvancedType.Sliced;

	// Token: 0x0400050D RID: 1293
	protected static Vector2[] mTempPos = new Vector2[4];

	// Token: 0x0400050E RID: 1294
	protected static Vector2[] mTempUVs = new Vector2[4];

	// Token: 0x020005EE RID: 1518
	[DoNotObfuscateNGUI]
	public enum Type
	{
		// Token: 0x04004D8F RID: 19855
		Simple,
		// Token: 0x04004D90 RID: 19856
		Sliced,
		// Token: 0x04004D91 RID: 19857
		Tiled,
		// Token: 0x04004D92 RID: 19858
		Filled,
		// Token: 0x04004D93 RID: 19859
		Advanced
	}

	// Token: 0x020005EF RID: 1519
	[DoNotObfuscateNGUI]
	public enum FillDirection
	{
		// Token: 0x04004D95 RID: 19861
		Horizontal,
		// Token: 0x04004D96 RID: 19862
		Vertical,
		// Token: 0x04004D97 RID: 19863
		Radial90,
		// Token: 0x04004D98 RID: 19864
		Radial180,
		// Token: 0x04004D99 RID: 19865
		Radial360
	}

	// Token: 0x020005F0 RID: 1520
	[DoNotObfuscateNGUI]
	public enum AdvancedType
	{
		// Token: 0x04004D9B RID: 19867
		Invisible,
		// Token: 0x04004D9C RID: 19868
		Sliced,
		// Token: 0x04004D9D RID: 19869
		Tiled
	}

	// Token: 0x020005F1 RID: 1521
	[DoNotObfuscateNGUI]
	public enum Flip
	{
		// Token: 0x04004D9F RID: 19871
		Nothing,
		// Token: 0x04004DA0 RID: 19872
		Horizontally,
		// Token: 0x04004DA1 RID: 19873
		Vertically,
		// Token: 0x04004DA2 RID: 19874
		Both
	}
}
