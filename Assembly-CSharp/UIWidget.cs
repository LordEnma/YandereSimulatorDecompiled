using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

// Token: 0x02000084 RID: 132
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Invisible Widget")]
public class UIWidget : UIRect
{
	// Token: 0x1700009B RID: 155
	// (get) Token: 0x06000501 RID: 1281 RVA: 0x00031BCF File Offset: 0x0002FDCF
	// (set) Token: 0x06000502 RID: 1282 RVA: 0x00031BD8 File Offset: 0x0002FDD8
	public UIDrawCall.OnRenderCallback onRender
	{
		get
		{
			return this.mOnRender;
		}
		set
		{
			if (this.mOnRender != value)
			{
				if (this.drawCall != null && this.drawCall.onRender != null && this.mOnRender != null)
				{
					UIDrawCall uidrawCall = this.drawCall;
					uidrawCall.onRender = (UIDrawCall.OnRenderCallback)Delegate.Remove(uidrawCall.onRender, this.mOnRender);
				}
				this.mOnRender = value;
				if (this.drawCall != null)
				{
					UIDrawCall uidrawCall2 = this.drawCall;
					uidrawCall2.onRender = (UIDrawCall.OnRenderCallback)Delegate.Combine(uidrawCall2.onRender, value);
				}
			}
		}
	}

	// Token: 0x1700009C RID: 156
	// (get) Token: 0x06000503 RID: 1283 RVA: 0x00031C68 File Offset: 0x0002FE68
	// (set) Token: 0x06000504 RID: 1284 RVA: 0x00031C70 File Offset: 0x0002FE70
	public Vector4 drawRegion
	{
		get
		{
			return this.mDrawRegion;
		}
		set
		{
			if (this.mDrawRegion != value)
			{
				this.mDrawRegion = value;
				if (this.autoResizeBoxCollider)
				{
					this.ResizeCollider();
				}
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x1700009D RID: 157
	// (get) Token: 0x06000505 RID: 1285 RVA: 0x00031C9B File Offset: 0x0002FE9B
	public Vector2 pivotOffset
	{
		get
		{
			return NGUIMath.GetPivotOffset(this.pivot);
		}
	}

	// Token: 0x1700009E RID: 158
	// (get) Token: 0x06000506 RID: 1286 RVA: 0x00031CA8 File Offset: 0x0002FEA8
	// (set) Token: 0x06000507 RID: 1287 RVA: 0x00031CB0 File Offset: 0x0002FEB0
	public int width
	{
		get
		{
			return this.mWidth;
		}
		set
		{
			int minWidth = this.minWidth;
			if (value < minWidth)
			{
				value = minWidth;
			}
			if (this.mWidth != value && this.keepAspectRatio != UIWidget.AspectRatioSource.BasedOnHeight)
			{
				if (this.isAnchoredHorizontally)
				{
					if (this.leftAnchor.target != null && this.rightAnchor.target != null)
					{
						if (this.mPivot == UIWidget.Pivot.BottomLeft || this.mPivot == UIWidget.Pivot.Left || this.mPivot == UIWidget.Pivot.TopLeft)
						{
							NGUIMath.AdjustWidget(this, 0f, 0f, (float)(value - this.mWidth), 0f);
							return;
						}
						if (this.mPivot == UIWidget.Pivot.BottomRight || this.mPivot == UIWidget.Pivot.Right || this.mPivot == UIWidget.Pivot.TopRight)
						{
							NGUIMath.AdjustWidget(this, (float)(this.mWidth - value), 0f, 0f, 0f);
							return;
						}
						int num = value - this.mWidth;
						num -= (num & 1);
						if (num != 0)
						{
							NGUIMath.AdjustWidget(this, (float)(-(float)num) * 0.5f, 0f, (float)num * 0.5f, 0f);
							return;
						}
					}
					else
					{
						if (this.leftAnchor.target != null)
						{
							NGUIMath.AdjustWidget(this, 0f, 0f, (float)(value - this.mWidth), 0f);
							return;
						}
						NGUIMath.AdjustWidget(this, (float)(this.mWidth - value), 0f, 0f, 0f);
						return;
					}
				}
				else
				{
					this.SetDimensions(value, this.mHeight);
				}
			}
		}
	}

	// Token: 0x1700009F RID: 159
	// (get) Token: 0x06000508 RID: 1288 RVA: 0x00031E22 File Offset: 0x00030022
	// (set) Token: 0x06000509 RID: 1289 RVA: 0x00031E2C File Offset: 0x0003002C
	public int height
	{
		get
		{
			return this.mHeight;
		}
		set
		{
			int minHeight = this.minHeight;
			if (value < minHeight)
			{
				value = minHeight;
			}
			if (this.mHeight != value && this.keepAspectRatio != UIWidget.AspectRatioSource.BasedOnWidth)
			{
				if (this.isAnchoredVertically)
				{
					if (this.bottomAnchor.target != null && this.topAnchor.target != null)
					{
						if (this.mPivot == UIWidget.Pivot.BottomLeft || this.mPivot == UIWidget.Pivot.Bottom || this.mPivot == UIWidget.Pivot.BottomRight)
						{
							NGUIMath.AdjustWidget(this, 0f, 0f, 0f, (float)(value - this.mHeight));
							return;
						}
						if (this.mPivot == UIWidget.Pivot.TopLeft || this.mPivot == UIWidget.Pivot.Top || this.mPivot == UIWidget.Pivot.TopRight)
						{
							NGUIMath.AdjustWidget(this, 0f, (float)(this.mHeight - value), 0f, 0f);
							return;
						}
						int num = value - this.mHeight;
						num -= (num & 1);
						if (num != 0)
						{
							NGUIMath.AdjustWidget(this, 0f, (float)(-(float)num) * 0.5f, 0f, (float)num * 0.5f);
							return;
						}
					}
					else
					{
						if (this.bottomAnchor.target != null)
						{
							NGUIMath.AdjustWidget(this, 0f, 0f, 0f, (float)(value - this.mHeight));
							return;
						}
						NGUIMath.AdjustWidget(this, 0f, (float)(this.mHeight - value), 0f, 0f);
						return;
					}
				}
				else
				{
					this.SetDimensions(this.mWidth, value);
				}
			}
		}
	}

	// Token: 0x170000A0 RID: 160
	// (get) Token: 0x0600050A RID: 1290 RVA: 0x00031F9E File Offset: 0x0003019E
	// (set) Token: 0x0600050B RID: 1291 RVA: 0x00031FA8 File Offset: 0x000301A8
	public Color color
	{
		get
		{
			return this.mColor;
		}
		set
		{
			if (this.mColor != value)
			{
				bool includeChildren = this.mColor.a != value.a;
				this.mColor = value;
				this.Invalidate(includeChildren);
			}
		}
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00031FE8 File Offset: 0x000301E8
	public void SetColorNoAlpha(Color c)
	{
		if (this.mColor.r != c.r || this.mColor.g != c.g || this.mColor.b != c.b)
		{
			this.mColor.r = c.r;
			this.mColor.g = c.g;
			this.mColor.b = c.b;
			this.Invalidate(false);
		}
	}

	// Token: 0x170000A1 RID: 161
	// (get) Token: 0x0600050D RID: 1293 RVA: 0x00032068 File Offset: 0x00030268
	// (set) Token: 0x0600050E RID: 1294 RVA: 0x00032075 File Offset: 0x00030275
	public override float alpha
	{
		get
		{
			return this.mColor.a;
		}
		set
		{
			if (this.mColor.a != value)
			{
				this.mColor.a = value;
				this.Invalidate(true);
			}
		}
	}

	// Token: 0x170000A2 RID: 162
	// (get) Token: 0x0600050F RID: 1295 RVA: 0x00032098 File Offset: 0x00030298
	public bool isVisible
	{
		get
		{
			return this.mIsVisibleByPanel && this.mIsVisibleByAlpha && this.mIsInFront && this.finalAlpha > 0.001f && NGUITools.GetActive(this);
		}
	}

	// Token: 0x170000A3 RID: 163
	// (get) Token: 0x06000510 RID: 1296 RVA: 0x000320C7 File Offset: 0x000302C7
	public bool hasVertices
	{
		get
		{
			return this.geometry != null && this.geometry.hasVertices;
		}
	}

	// Token: 0x170000A4 RID: 164
	// (get) Token: 0x06000511 RID: 1297 RVA: 0x000320DE File Offset: 0x000302DE
	// (set) Token: 0x06000512 RID: 1298 RVA: 0x000320E6 File Offset: 0x000302E6
	public UIWidget.Pivot rawPivot
	{
		get
		{
			return this.mPivot;
		}
		set
		{
			if (this.mPivot != value)
			{
				this.mPivot = value;
				if (this.autoResizeBoxCollider)
				{
					this.ResizeCollider();
				}
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170000A5 RID: 165
	// (get) Token: 0x06000513 RID: 1299 RVA: 0x0003210C File Offset: 0x0003030C
	// (set) Token: 0x06000514 RID: 1300 RVA: 0x00032114 File Offset: 0x00030314
	public UIWidget.Pivot pivot
	{
		get
		{
			return this.mPivot;
		}
		set
		{
			if (this.mPivot != value)
			{
				Vector3 vector = this.worldCorners[0];
				this.mPivot = value;
				this.mChanged = true;
				Vector3 vector2 = this.worldCorners[0];
				Transform cachedTransform = base.cachedTransform;
				Vector3 vector3 = cachedTransform.position;
				float z = cachedTransform.localPosition.z;
				vector3.x += vector.x - vector2.x;
				vector3.y += vector.y - vector2.y;
				base.cachedTransform.position = vector3;
				vector3 = base.cachedTransform.localPosition;
				vector3.x = Mathf.Round(vector3.x);
				vector3.y = Mathf.Round(vector3.y);
				vector3.z = z;
				base.cachedTransform.localPosition = vector3;
			}
		}
	}

	// Token: 0x170000A6 RID: 166
	// (get) Token: 0x06000515 RID: 1301 RVA: 0x000321ED File Offset: 0x000303ED
	// (set) Token: 0x06000516 RID: 1302 RVA: 0x000321F8 File Offset: 0x000303F8
	public int depth
	{
		get
		{
			return this.mDepth;
		}
		set
		{
			if (this.mDepth != value)
			{
				if (this.panel != null)
				{
					this.panel.RemoveWidget(this);
				}
				this.mDepth = value;
				if (this.panel != null)
				{
					this.panel.AddWidget(this);
					if (!Application.isPlaying)
					{
						this.panel.SortWidgets();
						this.panel.RebuildAllDrawCalls();
					}
				}
			}
		}
	}

	// Token: 0x170000A7 RID: 167
	// (get) Token: 0x06000517 RID: 1303 RVA: 0x00032268 File Offset: 0x00030468
	public int raycastDepth
	{
		get
		{
			if (this.panel == null)
			{
				this.CreatePanel();
			}
			if (!(this.panel != null))
			{
				return this.mDepth;
			}
			return this.mDepth + this.panel.depth * 1000;
		}
	}

	// Token: 0x170000A8 RID: 168
	// (get) Token: 0x06000518 RID: 1304 RVA: 0x000322B8 File Offset: 0x000304B8
	public override Vector3[] localCorners
	{
		get
		{
			Vector2 pivotOffset = this.pivotOffset;
			float num = -pivotOffset.x * (float)this.mWidth;
			float num2 = -pivotOffset.y * (float)this.mHeight;
			float x = num + (float)this.mWidth;
			float y = num2 + (float)this.mHeight;
			this.mCorners[0] = new Vector3(num, num2);
			this.mCorners[1] = new Vector3(num, y);
			this.mCorners[2] = new Vector3(x, y);
			this.mCorners[3] = new Vector3(x, num2);
			return this.mCorners;
		}
	}

	// Token: 0x170000A9 RID: 169
	// (get) Token: 0x06000519 RID: 1305 RVA: 0x00032350 File Offset: 0x00030550
	public virtual Vector2 localSize
	{
		get
		{
			Vector3[] localCorners = this.localCorners;
			return localCorners[2] - localCorners[0];
		}
	}

	// Token: 0x170000AA RID: 170
	// (get) Token: 0x0600051A RID: 1306 RVA: 0x0003237C File Offset: 0x0003057C
	public Vector3 localCenter
	{
		get
		{
			Vector3[] localCorners = this.localCorners;
			return Vector3.Lerp(localCorners[0], localCorners[2], 0.5f);
		}
	}

	// Token: 0x170000AB RID: 171
	// (get) Token: 0x0600051B RID: 1307 RVA: 0x000323A8 File Offset: 0x000305A8
	public override Vector3[] worldCorners
	{
		get
		{
			Vector2 pivotOffset = this.pivotOffset;
			float num = -pivotOffset.x * (float)this.mWidth;
			float num2 = -pivotOffset.y * (float)this.mHeight;
			float x = num + (float)this.mWidth;
			float y = num2 + (float)this.mHeight;
			Transform cachedTransform = base.cachedTransform;
			this.mCorners[0] = cachedTransform.TransformPoint(num, num2, 0f);
			this.mCorners[1] = cachedTransform.TransformPoint(num, y, 0f);
			this.mCorners[2] = cachedTransform.TransformPoint(x, y, 0f);
			this.mCorners[3] = cachedTransform.TransformPoint(x, num2, 0f);
			return this.mCorners;
		}
	}

	// Token: 0x170000AC RID: 172
	// (get) Token: 0x0600051C RID: 1308 RVA: 0x00032464 File Offset: 0x00030664
	public Vector3 worldCenter
	{
		get
		{
			return base.cachedTransform.TransformPoint(this.localCenter);
		}
	}

	// Token: 0x170000AD RID: 173
	// (get) Token: 0x0600051D RID: 1309 RVA: 0x00032478 File Offset: 0x00030678
	public virtual Vector4 drawingDimensions
	{
		get
		{
			Vector2 pivotOffset = this.pivotOffset;
			float num = -pivotOffset.x * (float)this.mWidth;
			float num2 = -pivotOffset.y * (float)this.mHeight;
			float num3 = num + (float)this.mWidth;
			float num4 = num2 + (float)this.mHeight;
			return new Vector4((this.mDrawRegion.x == 0f) ? num : Mathf.Lerp(num, num3, this.mDrawRegion.x), (this.mDrawRegion.y == 0f) ? num2 : Mathf.Lerp(num2, num4, this.mDrawRegion.y), (this.mDrawRegion.z == 1f) ? num3 : Mathf.Lerp(num, num3, this.mDrawRegion.z), (this.mDrawRegion.w == 1f) ? num4 : Mathf.Lerp(num2, num4, this.mDrawRegion.w));
		}
	}

	// Token: 0x170000AE RID: 174
	// (get) Token: 0x0600051E RID: 1310 RVA: 0x0003255F File Offset: 0x0003075F
	// (set) Token: 0x0600051F RID: 1311 RVA: 0x00032567 File Offset: 0x00030767
	public virtual Material material
	{
		get
		{
			return this.mMat;
		}
		set
		{
			if (this.mMat != value)
			{
				this.RemoveFromPanel();
				this.mMat = value;
				this.MarkAsChanged();
			}
		}
	}

	// Token: 0x170000AF RID: 175
	// (get) Token: 0x06000520 RID: 1312 RVA: 0x0003258C File Offset: 0x0003078C
	// (set) Token: 0x06000521 RID: 1313 RVA: 0x000325B1 File Offset: 0x000307B1
	public virtual Texture mainTexture
	{
		get
		{
			Material material = this.material;
			if (!(material != null))
			{
				return null;
			}
			return material.mainTexture;
		}
		set
		{
			Type type = base.GetType();
			throw new NotImplementedException(((type != null) ? type.ToString() : null) + " has no mainTexture setter");
		}
	}

	// Token: 0x170000B0 RID: 176
	// (get) Token: 0x06000522 RID: 1314 RVA: 0x000325D4 File Offset: 0x000307D4
	// (set) Token: 0x06000523 RID: 1315 RVA: 0x000325F9 File Offset: 0x000307F9
	public virtual Shader shader
	{
		get
		{
			Material material = this.material;
			if (!(material != null))
			{
				return null;
			}
			return material.shader;
		}
		set
		{
			Type type = base.GetType();
			throw new NotImplementedException(((type != null) ? type.ToString() : null) + " has no shader setter");
		}
	}

	// Token: 0x170000B1 RID: 177
	// (get) Token: 0x06000524 RID: 1316 RVA: 0x0003261C File Offset: 0x0003081C
	[Obsolete("There is no relative scale anymore. Widgets now have width and height instead")]
	public Vector2 relativeSize
	{
		get
		{
			return Vector2.one;
		}
	}

	// Token: 0x170000B2 RID: 178
	// (get) Token: 0x06000525 RID: 1317 RVA: 0x00032623 File Offset: 0x00030823
	public bool hasBoxCollider
	{
		get
		{
			return base.GetComponent<Collider>() as BoxCollider != null || base.GetComponent<BoxCollider2D>() != null;
		}
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x00032648 File Offset: 0x00030848
	public void SetDimensions(int w, int h)
	{
		if (this.mWidth != w || this.mHeight != h)
		{
			this.mWidth = w;
			this.mHeight = h;
			if (this.keepAspectRatio == UIWidget.AspectRatioSource.BasedOnWidth)
			{
				this.mHeight = Mathf.RoundToInt((float)this.mWidth / this.aspectRatio);
			}
			else if (this.keepAspectRatio == UIWidget.AspectRatioSource.BasedOnHeight)
			{
				this.mWidth = Mathf.RoundToInt((float)this.mHeight * this.aspectRatio);
			}
			else if (this.keepAspectRatio == UIWidget.AspectRatioSource.Free)
			{
				this.aspectRatio = (float)this.mWidth / (float)this.mHeight;
			}
			this.mMoved = true;
			if (this.autoResizeBoxCollider)
			{
				this.ResizeCollider();
			}
			this.MarkAsChanged();
		}
	}

	// Token: 0x06000527 RID: 1319 RVA: 0x000326F8 File Offset: 0x000308F8
	public override Vector3[] GetSides(Transform relativeTo)
	{
		Vector2 pivotOffset = this.pivotOffset;
		float num = -pivotOffset.x * (float)this.mWidth;
		float num2 = -pivotOffset.y * (float)this.mHeight;
		float num3 = num + (float)this.mWidth;
		float num4 = num2 + (float)this.mHeight;
		float x = (num + num3) * 0.5f;
		float y = (num2 + num4) * 0.5f;
		Transform cachedTransform = base.cachedTransform;
		this.mCorners[0] = cachedTransform.TransformPoint(num, y, 0f);
		this.mCorners[1] = cachedTransform.TransformPoint(x, num4, 0f);
		this.mCorners[2] = cachedTransform.TransformPoint(num3, y, 0f);
		this.mCorners[3] = cachedTransform.TransformPoint(x, num2, 0f);
		if (relativeTo != null)
		{
			for (int i = 0; i < 4; i++)
			{
				this.mCorners[i] = relativeTo.InverseTransformPoint(this.mCorners[i]);
			}
		}
		return this.mCorners;
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x00032807 File Offset: 0x00030A07
	public override float CalculateFinalAlpha(int frameID)
	{
		if (this.mAlphaFrameID != frameID)
		{
			this.mAlphaFrameID = frameID;
			this.UpdateFinalAlpha(frameID);
		}
		return this.finalAlpha;
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x00032828 File Offset: 0x00030A28
	protected void UpdateFinalAlpha(int frameID)
	{
		if (!this.mIsVisibleByAlpha || !this.mIsInFront)
		{
			this.finalAlpha = 0f;
			return;
		}
		UIRect parent = base.parent;
		this.finalAlpha = ((parent != null) ? (parent.CalculateFinalAlpha(frameID) * this.mColor.a) : this.mColor.a);
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x00032888 File Offset: 0x00030A88
	public override void Invalidate(bool includeChildren)
	{
		this.mChanged = true;
		this.mAlphaFrameID = -1;
		if (this.panel != null)
		{
			bool visibleByPanel = (!this.hideIfOffScreen && !this.panel.hasCumulativeClipping) || this.panel.IsVisible(this);
			this.UpdateVisibility(this.CalculateCumulativeAlpha(Time.frameCount) > 0.001f, visibleByPanel);
			this.UpdateFinalAlpha(Time.frameCount);
			if (includeChildren)
			{
				base.Invalidate(true);
			}
		}
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x00032908 File Offset: 0x00030B08
	public float CalculateCumulativeAlpha(int frameID)
	{
		UIRect parent = base.parent;
		if (!(parent != null))
		{
			return this.mColor.a;
		}
		return parent.CalculateFinalAlpha(frameID) * this.mColor.a;
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00032944 File Offset: 0x00030B44
	public override void SetRect(float x, float y, float width, float height)
	{
		Vector2 pivotOffset = this.pivotOffset;
		float num = Mathf.Lerp(x, x + width, pivotOffset.x);
		float num2 = Mathf.Lerp(y, y + height, pivotOffset.y);
		int num3 = Mathf.FloorToInt(width + 0.5f);
		int num4 = Mathf.FloorToInt(height + 0.5f);
		if (pivotOffset.x == 0.5f)
		{
			num3 = num3 >> 1 << 1;
		}
		if (pivotOffset.y == 0.5f)
		{
			num4 = num4 >> 1 << 1;
		}
		Transform transform = base.cachedTransform;
		Vector3 localPosition = transform.localPosition;
		localPosition.x = Mathf.Floor(num + 0.5f);
		localPosition.y = Mathf.Floor(num2 + 0.5f);
		if (num3 < this.minWidth)
		{
			num3 = this.minWidth;
		}
		if (num4 < this.minHeight)
		{
			num4 = this.minHeight;
		}
		transform.localPosition = localPosition;
		this.width = num3;
		this.height = num4;
		if (base.isAnchored)
		{
			transform = transform.parent;
			if (this.leftAnchor.target)
			{
				this.leftAnchor.SetHorizontal(transform, x);
			}
			if (this.rightAnchor.target)
			{
				this.rightAnchor.SetHorizontal(transform, x + width);
			}
			if (this.bottomAnchor.target)
			{
				this.bottomAnchor.SetVertical(transform, y);
			}
			if (this.topAnchor.target)
			{
				this.topAnchor.SetVertical(transform, y + height);
			}
		}
	}

	// Token: 0x0600052D RID: 1325 RVA: 0x00032AC8 File Offset: 0x00030CC8
	public void ResizeCollider()
	{
		BoxCollider component = base.GetComponent<BoxCollider>();
		if (component != null)
		{
			NGUITools.UpdateWidgetCollider(this, component);
			return;
		}
		NGUITools.UpdateWidgetCollider(this, base.GetComponent<BoxCollider2D>());
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x00032AFC File Offset: 0x00030CFC
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static int FullCompareFunc(UIWidget left, UIWidget right)
	{
		int num = UIPanel.CompareFunc(left.panel, right.panel);
		if (num != 0)
		{
			return num;
		}
		return UIWidget.PanelCompareFunc(left, right);
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x00032B28 File Offset: 0x00030D28
	[DebuggerHidden]
	[DebuggerStepThrough]
	public static int PanelCompareFunc(UIWidget left, UIWidget right)
	{
		if (left.mDepth < right.mDepth)
		{
			return -1;
		}
		if (left.mDepth > right.mDepth)
		{
			return 1;
		}
		Material material = left.material;
		Material material2 = right.material;
		if (material == material2)
		{
			return 0;
		}
		if (material == null)
		{
			return 1;
		}
		if (material2 == null)
		{
			return -1;
		}
		if (material.GetInstanceID() >= material2.GetInstanceID())
		{
			return 1;
		}
		return -1;
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x00032B95 File Offset: 0x00030D95
	public Bounds CalculateBounds()
	{
		return this.CalculateBounds(null);
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x00032BA0 File Offset: 0x00030DA0
	public Bounds CalculateBounds(Transform relativeParent)
	{
		if (relativeParent == null)
		{
			Vector3[] localCorners = this.localCorners;
			Bounds result = new Bounds(localCorners[0], Vector3.zero);
			for (int i = 1; i < 4; i++)
			{
				result.Encapsulate(localCorners[i]);
			}
			return result;
		}
		Matrix4x4 worldToLocalMatrix = relativeParent.worldToLocalMatrix;
		Vector3[] worldCorners = this.worldCorners;
		Bounds result2 = new Bounds(worldToLocalMatrix.MultiplyPoint3x4(worldCorners[0]), Vector3.zero);
		for (int j = 1; j < 4; j++)
		{
			result2.Encapsulate(worldToLocalMatrix.MultiplyPoint3x4(worldCorners[j]));
		}
		return result2;
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x00032C3F File Offset: 0x00030E3F
	public void SetDirty()
	{
		if (this.drawCall != null)
		{
			this.drawCall.isDirty = true;
			return;
		}
		if (this.isVisible && this.hasVertices)
		{
			this.CreatePanel();
		}
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x00032C73 File Offset: 0x00030E73
	public void RemoveFromPanel()
	{
		if (this.panel != null)
		{
			this.panel.RemoveWidget(this);
			this.panel = null;
		}
		this.drawCall = null;
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x00032CA0 File Offset: 0x00030EA0
	public virtual void MarkAsChanged()
	{
		if (NGUITools.GetActive(this))
		{
			this.mChanged = true;
			if (this.panel != null && base.enabled && NGUITools.GetActive(base.gameObject) && !this.mPlayMode)
			{
				this.SetDirty();
				this.CheckLayer();
			}
		}
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x00032CF4 File Offset: 0x00030EF4
	public UIPanel CreatePanel()
	{
		if (this.mStarted && this.panel == null && base.enabled && NGUITools.GetActive(base.gameObject))
		{
			this.panel = UIPanel.Find(base.cachedTransform, true, base.cachedGameObject.layer);
			if (this.panel != null)
			{
				this.mParentFound = false;
				this.panel.AddWidget(this);
				this.CheckLayer();
				this.Invalidate(true);
			}
		}
		return this.panel;
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x00032D80 File Offset: 0x00030F80
	public void CheckLayer()
	{
		if (this.panel != null && this.panel.gameObject.layer != base.gameObject.layer)
		{
			UnityEngine.Debug.LogWarning("You can't place widgets on a layer different than the UIPanel that manages them.\nIf you want to move widgets to a different layer, parent them to a new panel instead.", this);
			base.gameObject.layer = this.panel.gameObject.layer;
		}
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x00032DE0 File Offset: 0x00030FE0
	public override void ParentHasChanged()
	{
		base.ParentHasChanged();
		if (this.panel != null)
		{
			UIPanel y = UIPanel.Find(base.cachedTransform, true, base.cachedGameObject.layer);
			if (this.panel != y)
			{
				this.RemoveFromPanel();
				this.CreatePanel();
			}
		}
	}

	// Token: 0x06000538 RID: 1336 RVA: 0x00032E34 File Offset: 0x00031034
	protected override void Awake()
	{
		base.Awake();
		this.mPlayMode = Application.isPlaying;
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x00032E47 File Offset: 0x00031047
	protected override void OnInit()
	{
		base.OnInit();
		this.RemoveFromPanel();
		this.mMoved = true;
		base.Update();
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x00032E64 File Offset: 0x00031064
	protected virtual void UpgradeFrom265()
	{
		Vector3 localScale = base.cachedTransform.localScale;
		this.mWidth = Mathf.Abs(Mathf.RoundToInt(localScale.x));
		this.mHeight = Mathf.Abs(Mathf.RoundToInt(localScale.y));
		NGUITools.UpdateWidgetCollider(base.gameObject, true);
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x00032EB5 File Offset: 0x000310B5
	protected override void OnStart()
	{
		this.CreatePanel();
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x00032EC0 File Offset: 0x000310C0
	protected override void OnAnchor()
	{
		Transform cachedTransform = base.cachedTransform;
		Transform parent = cachedTransform.parent;
		Vector3 localPosition = cachedTransform.localPosition;
		Vector2 pivotOffset = this.pivotOffset;
		float num;
		float num2;
		float num3;
		float num4;
		if (this.leftAnchor.target == this.bottomAnchor.target && this.leftAnchor.target == this.rightAnchor.target && this.leftAnchor.target == this.topAnchor.target)
		{
			Vector3[] sides = this.leftAnchor.GetSides(parent);
			if (sides != null)
			{
				num = NGUIMath.Lerp(sides[0].x, sides[2].x, this.leftAnchor.relative) + (float)this.leftAnchor.absolute;
				num2 = NGUIMath.Lerp(sides[0].x, sides[2].x, this.rightAnchor.relative) + (float)this.rightAnchor.absolute;
				num3 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.bottomAnchor.relative) + (float)this.bottomAnchor.absolute;
				num4 = NGUIMath.Lerp(sides[3].y, sides[1].y, this.topAnchor.relative) + (float)this.topAnchor.absolute;
				this.mIsInFront = true;
			}
			else
			{
				Vector3 localPos = base.GetLocalPos(this.leftAnchor, parent);
				num = localPos.x + (float)this.leftAnchor.absolute;
				num3 = localPos.y + (float)this.bottomAnchor.absolute;
				num2 = localPos.x + (float)this.rightAnchor.absolute;
				num4 = localPos.y + (float)this.topAnchor.absolute;
				this.mIsInFront = (!this.hideIfOffScreen || localPos.z >= 0f);
			}
		}
		else
		{
			this.mIsInFront = true;
			if (this.leftAnchor.target)
			{
				Vector3[] sides2 = this.leftAnchor.GetSides(parent);
				if (sides2 != null)
				{
					num = NGUIMath.Lerp(sides2[0].x, sides2[2].x, this.leftAnchor.relative) + (float)this.leftAnchor.absolute;
				}
				else
				{
					num = base.GetLocalPos(this.leftAnchor, parent).x + (float)this.leftAnchor.absolute;
				}
			}
			else
			{
				num = localPosition.x - pivotOffset.x * (float)this.mWidth;
			}
			if (this.rightAnchor.target)
			{
				Vector3[] sides3 = this.rightAnchor.GetSides(parent);
				if (sides3 != null)
				{
					num2 = NGUIMath.Lerp(sides3[0].x, sides3[2].x, this.rightAnchor.relative) + (float)this.rightAnchor.absolute;
				}
				else
				{
					num2 = base.GetLocalPos(this.rightAnchor, parent).x + (float)this.rightAnchor.absolute;
				}
			}
			else
			{
				num2 = localPosition.x - pivotOffset.x * (float)this.mWidth + (float)this.mWidth;
			}
			if (this.bottomAnchor.target)
			{
				Vector3[] sides4 = this.bottomAnchor.GetSides(parent);
				if (sides4 != null)
				{
					num3 = NGUIMath.Lerp(sides4[3].y, sides4[1].y, this.bottomAnchor.relative) + (float)this.bottomAnchor.absolute;
				}
				else
				{
					num3 = base.GetLocalPos(this.bottomAnchor, parent).y + (float)this.bottomAnchor.absolute;
				}
			}
			else
			{
				num3 = localPosition.y - pivotOffset.y * (float)this.mHeight;
			}
			if (this.topAnchor.target)
			{
				Vector3[] sides5 = this.topAnchor.GetSides(parent);
				if (sides5 != null)
				{
					num4 = NGUIMath.Lerp(sides5[3].y, sides5[1].y, this.topAnchor.relative) + (float)this.topAnchor.absolute;
				}
				else
				{
					num4 = base.GetLocalPos(this.topAnchor, parent).y + (float)this.topAnchor.absolute;
				}
			}
			else
			{
				num4 = localPosition.y - pivotOffset.y * (float)this.mHeight + (float)this.mHeight;
			}
		}
		Vector3 vector = new Vector3(Mathf.Lerp(num, num2, pivotOffset.x), Mathf.Lerp(num3, num4, pivotOffset.y), localPosition.z);
		vector.x = Mathf.Round(vector.x);
		vector.y = Mathf.Round(vector.y);
		int num5 = Mathf.FloorToInt(num2 - num + 0.5f);
		int num6 = Mathf.FloorToInt(num4 - num3 + 0.5f);
		if (this.keepAspectRatio != UIWidget.AspectRatioSource.Free && this.aspectRatio != 0f)
		{
			if (this.keepAspectRatio == UIWidget.AspectRatioSource.BasedOnHeight)
			{
				num5 = Mathf.RoundToInt((float)num6 * this.aspectRatio);
			}
			else
			{
				num6 = Mathf.RoundToInt((float)num5 / this.aspectRatio);
			}
		}
		if (num5 < this.minWidth)
		{
			num5 = this.minWidth;
		}
		if (num6 < this.minHeight)
		{
			num6 = this.minHeight;
		}
		if (Vector3.SqrMagnitude(localPosition - vector) > 0.001f)
		{
			base.cachedTransform.localPosition = vector;
			if (this.mIsInFront)
			{
				this.mChanged = true;
			}
		}
		if (this.mWidth != num5 || this.mHeight != num6)
		{
			this.mWidth = num5;
			this.mHeight = num6;
			if (this.mIsInFront)
			{
				this.mChanged = true;
			}
			if (this.autoResizeBoxCollider)
			{
				this.ResizeCollider();
			}
		}
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x0003349E File Offset: 0x0003169E
	protected override void OnUpdate()
	{
		if (this.panel == null)
		{
			this.CreatePanel();
		}
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x000334B5 File Offset: 0x000316B5
	private void OnApplicationPause(bool paused)
	{
		if (!paused)
		{
			this.MarkAsChanged();
		}
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x000334C0 File Offset: 0x000316C0
	protected override void OnDisable()
	{
		this.RemoveFromPanel();
		base.OnDisable();
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x000334CE File Offset: 0x000316CE
	private void OnDestroy()
	{
		this.RemoveFromPanel();
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x000334D6 File Offset: 0x000316D6
	public bool UpdateVisibility(bool visibleByAlpha, bool visibleByPanel)
	{
		if (this.mIsVisibleByAlpha != visibleByAlpha || this.mIsVisibleByPanel != visibleByPanel)
		{
			this.mChanged = true;
			this.mIsVisibleByAlpha = visibleByAlpha;
			this.mIsVisibleByPanel = visibleByPanel;
			return true;
		}
		return false;
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x00033504 File Offset: 0x00031704
	public bool UpdateTransform(int frame)
	{
		Transform cachedTransform = base.cachedTransform;
		this.mPlayMode = Application.isPlaying;
		if (this.mMoved)
		{
			this.mMoved = true;
			this.mMatrixFrame = -1;
			cachedTransform.hasChanged = false;
			Vector2 pivotOffset = this.pivotOffset;
			float num = -pivotOffset.x * (float)this.mWidth;
			float num2 = -pivotOffset.y * (float)this.mHeight;
			float x = num + (float)this.mWidth;
			float y = num2 + (float)this.mHeight;
			this.mOldV0 = this.panel.worldToLocal.MultiplyPoint3x4(cachedTransform.TransformPoint(num, num2, 0f));
			this.mOldV1 = this.panel.worldToLocal.MultiplyPoint3x4(cachedTransform.TransformPoint(x, y, 0f));
		}
		else if (!this.panel.widgetsAreStatic && cachedTransform.hasChanged)
		{
			this.mMatrixFrame = -1;
			cachedTransform.hasChanged = false;
			Vector2 pivotOffset2 = this.pivotOffset;
			float num3 = -pivotOffset2.x * (float)this.mWidth;
			float num4 = -pivotOffset2.y * (float)this.mHeight;
			float x2 = num3 + (float)this.mWidth;
			float y2 = num4 + (float)this.mHeight;
			Vector3 b = this.panel.worldToLocal.MultiplyPoint3x4(cachedTransform.TransformPoint(num3, num4, 0f));
			Vector3 b2 = this.panel.worldToLocal.MultiplyPoint3x4(cachedTransform.TransformPoint(x2, y2, 0f));
			if (Vector3.SqrMagnitude(this.mOldV0 - b) > 1E-06f || Vector3.SqrMagnitude(this.mOldV1 - b2) > 1E-06f)
			{
				this.mMoved = true;
				this.mOldV0 = b;
				this.mOldV1 = b2;
			}
		}
		if (this.mMoved && this.onChange != null)
		{
			this.onChange();
		}
		return this.mMoved || this.mChanged;
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x000336E8 File Offset: 0x000318E8
	public bool UpdateGeometry(int frame)
	{
		float num = this.CalculateFinalAlpha(frame);
		if (this.mIsVisibleByAlpha && this.mLastAlpha != num)
		{
			this.mChanged = true;
		}
		this.mLastAlpha = num;
		if (this.mChanged)
		{
			if (this.mIsVisibleByAlpha && num > 0.001f && this.shader != null)
			{
				bool hasVertices = this.geometry.hasVertices;
				if (this.fillGeometry)
				{
					this.geometry.Clear();
					this.OnFill(this.geometry.verts, this.geometry.uvs, this.geometry.cols);
				}
				if (this.geometry.hasVertices)
				{
					if (this.mMatrixFrame != frame)
					{
						this.mLocalToPanel = this.panel.worldToLocal * base.cachedTransform.localToWorldMatrix;
						this.mMatrixFrame = frame;
					}
					this.geometry.ApplyTransform(this.mLocalToPanel, this.panel.generateNormals);
					this.mMoved = false;
					this.mChanged = false;
					return true;
				}
				this.mChanged = false;
				return hasVertices;
			}
			else if (this.geometry.hasVertices)
			{
				if (this.fillGeometry)
				{
					this.geometry.Clear();
				}
				this.mMoved = false;
				this.mChanged = false;
				return true;
			}
		}
		else if (this.mMoved && this.geometry.hasVertices)
		{
			if (this.mMatrixFrame != frame)
			{
				this.mLocalToPanel = this.panel.worldToLocal * base.cachedTransform.localToWorldMatrix;
				this.mMatrixFrame = frame;
			}
			this.geometry.ApplyTransform(this.mLocalToPanel, this.panel.generateNormals);
			this.mMoved = false;
			this.mChanged = false;
			return true;
		}
		this.mMoved = false;
		this.mChanged = false;
		return false;
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x000338BB File Offset: 0x00031ABB
	public void WriteToBuffers(List<Vector3> v, List<Vector2> u, List<Color> c, List<Vector3> n, List<Vector4> t, List<Vector4> u2)
	{
		this.geometry.WriteToBuffers(v, u, c, n, t, u2);
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x000338D4 File Offset: 0x00031AD4
	public virtual void MakePixelPerfect()
	{
		Vector3 localPosition = base.cachedTransform.localPosition;
		localPosition.z = Mathf.Round(localPosition.z);
		localPosition.x = Mathf.Round(localPosition.x);
		localPosition.y = Mathf.Round(localPosition.y);
		base.cachedTransform.localPosition = localPosition;
		Vector3 localScale = base.cachedTransform.localScale;
		base.cachedTransform.localScale = new Vector3(Mathf.Sign(localScale.x), Mathf.Sign(localScale.y), 1f);
	}

	// Token: 0x170000B3 RID: 179
	// (get) Token: 0x06000546 RID: 1350 RVA: 0x00033966 File Offset: 0x00031B66
	public virtual int minWidth
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x170000B4 RID: 180
	// (get) Token: 0x06000547 RID: 1351 RVA: 0x00033969 File Offset: 0x00031B69
	public virtual int minHeight
	{
		get
		{
			return 2;
		}
	}

	// Token: 0x170000B5 RID: 181
	// (get) Token: 0x06000548 RID: 1352 RVA: 0x0003396C File Offset: 0x00031B6C
	// (set) Token: 0x06000549 RID: 1353 RVA: 0x00033973 File Offset: 0x00031B73
	public virtual Vector4 border
	{
		get
		{
			return Vector4.zero;
		}
		set
		{
		}
	}

	// Token: 0x0600054A RID: 1354 RVA: 0x00033975 File Offset: 0x00031B75
	public virtual void OnFill(List<Vector3> verts, List<Vector2> uvs, List<Color> cols)
	{
	}

	// Token: 0x0400056E RID: 1390
	[HideInInspector]
	[SerializeField]
	protected Color mColor = Color.white;

	// Token: 0x0400056F RID: 1391
	[HideInInspector]
	[SerializeField]
	protected UIWidget.Pivot mPivot = UIWidget.Pivot.Center;

	// Token: 0x04000570 RID: 1392
	[HideInInspector]
	[SerializeField]
	protected int mWidth = 100;

	// Token: 0x04000571 RID: 1393
	[HideInInspector]
	[SerializeField]
	protected int mHeight = 100;

	// Token: 0x04000572 RID: 1394
	[HideInInspector]
	[SerializeField]
	protected int mDepth;

	// Token: 0x04000573 RID: 1395
	[Tooltip("Custom material, if desired")]
	[HideInInspector]
	[SerializeField]
	protected Material mMat;

	// Token: 0x04000574 RID: 1396
	public UIWidget.OnDimensionsChanged onChange;

	// Token: 0x04000575 RID: 1397
	public UIWidget.OnPostFillCallback onPostFill;

	// Token: 0x04000576 RID: 1398
	public UIDrawCall.OnRenderCallback mOnRender;

	// Token: 0x04000577 RID: 1399
	public bool autoResizeBoxCollider;

	// Token: 0x04000578 RID: 1400
	public bool hideIfOffScreen;

	// Token: 0x04000579 RID: 1401
	public UIWidget.AspectRatioSource keepAspectRatio;

	// Token: 0x0400057A RID: 1402
	public float aspectRatio = 1f;

	// Token: 0x0400057B RID: 1403
	public UIWidget.HitCheck hitCheck;

	// Token: 0x0400057C RID: 1404
	[NonSerialized]
	public UIPanel panel;

	// Token: 0x0400057D RID: 1405
	[NonSerialized]
	public UIGeometry geometry = new UIGeometry();

	// Token: 0x0400057E RID: 1406
	[NonSerialized]
	public bool fillGeometry = true;

	// Token: 0x0400057F RID: 1407
	[NonSerialized]
	protected bool mPlayMode = true;

	// Token: 0x04000580 RID: 1408
	[NonSerialized]
	protected Vector4 mDrawRegion = new Vector4(0f, 0f, 1f, 1f);

	// Token: 0x04000581 RID: 1409
	[NonSerialized]
	private Matrix4x4 mLocalToPanel;

	// Token: 0x04000582 RID: 1410
	[NonSerialized]
	private bool mIsVisibleByAlpha = true;

	// Token: 0x04000583 RID: 1411
	[NonSerialized]
	private bool mIsVisibleByPanel = true;

	// Token: 0x04000584 RID: 1412
	[NonSerialized]
	private bool mIsInFront = true;

	// Token: 0x04000585 RID: 1413
	[NonSerialized]
	private float mLastAlpha;

	// Token: 0x04000586 RID: 1414
	[NonSerialized]
	private bool mMoved;

	// Token: 0x04000587 RID: 1415
	[NonSerialized]
	public UIDrawCall drawCall;

	// Token: 0x04000588 RID: 1416
	[NonSerialized]
	protected Vector3[] mCorners = new Vector3[4];

	// Token: 0x04000589 RID: 1417
	[NonSerialized]
	private int mAlphaFrameID = -1;

	// Token: 0x0400058A RID: 1418
	private int mMatrixFrame = -1;

	// Token: 0x0400058B RID: 1419
	private Vector3 mOldV0;

	// Token: 0x0400058C RID: 1420
	private Vector3 mOldV1;

	// Token: 0x02000601 RID: 1537
	[DoNotObfuscateNGUI]
	public enum Pivot
	{
		// Token: 0x04004DD8 RID: 19928
		TopLeft,
		// Token: 0x04004DD9 RID: 19929
		Top,
		// Token: 0x04004DDA RID: 19930
		TopRight,
		// Token: 0x04004DDB RID: 19931
		Left,
		// Token: 0x04004DDC RID: 19932
		Center,
		// Token: 0x04004DDD RID: 19933
		Right,
		// Token: 0x04004DDE RID: 19934
		BottomLeft,
		// Token: 0x04004DDF RID: 19935
		Bottom,
		// Token: 0x04004DE0 RID: 19936
		BottomRight
	}

	// Token: 0x02000602 RID: 1538
	// (Invoke) Token: 0x06002586 RID: 9606
	public delegate void OnDimensionsChanged();

	// Token: 0x02000603 RID: 1539
	// (Invoke) Token: 0x0600258A RID: 9610
	public delegate void OnPostFillCallback(UIWidget widget, int bufferOffset, List<Vector3> verts, List<Vector2> uvs, List<Color> cols);

	// Token: 0x02000604 RID: 1540
	[DoNotObfuscateNGUI]
	public enum AspectRatioSource
	{
		// Token: 0x04004DE2 RID: 19938
		Free,
		// Token: 0x04004DE3 RID: 19939
		BasedOnWidth,
		// Token: 0x04004DE4 RID: 19940
		BasedOnHeight
	}

	// Token: 0x02000605 RID: 1541
	// (Invoke) Token: 0x0600258E RID: 9614
	public delegate bool HitCheck(Vector3 worldPos);
}
