using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x020000A7 RID: 167
[ExecuteInEditMode]
[AddComponentMenu("NGUI/UI/Panel")]
public class UIPanel : UIRect
{
	// Token: 0x1700018E RID: 398
	// (get) Token: 0x060007F2 RID: 2034 RVA: 0x0004264B File Offset: 0x0004084B
	// (set) Token: 0x060007F3 RID: 2035 RVA: 0x00042653 File Offset: 0x00040853
	public string sortingLayerName
	{
		get
		{
			return this.mSortingLayerName;
		}
		set
		{
			if (this.mSortingLayerName != value)
			{
				this.mSortingLayerName = value;
				this.UpdateDrawCalls(UIPanel.list.IndexOf(this));
			}
		}
	}

	// Token: 0x1700018F RID: 399
	// (get) Token: 0x060007F4 RID: 2036 RVA: 0x0004267C File Offset: 0x0004087C
	public static int nextUnusedDepth
	{
		get
		{
			int num = int.MinValue;
			int i = 0;
			int count = UIPanel.list.Count;
			while (i < count)
			{
				num = Mathf.Max(num, UIPanel.list[i].depth);
				i++;
			}
			if (num != -2147483648)
			{
				return num + 1;
			}
			return 0;
		}
	}

	// Token: 0x17000190 RID: 400
	// (get) Token: 0x060007F5 RID: 2037 RVA: 0x000426CA File Offset: 0x000408CA
	public override bool canBeAnchored
	{
		get
		{
			return this.mClipping > UIDrawCall.Clipping.None;
		}
	}

	// Token: 0x17000191 RID: 401
	// (get) Token: 0x060007F6 RID: 2038 RVA: 0x000426D5 File Offset: 0x000408D5
	// (set) Token: 0x060007F7 RID: 2039 RVA: 0x000426E0 File Offset: 0x000408E0
	public override float alpha
	{
		get
		{
			return this.mAlpha;
		}
		set
		{
			float num = Mathf.Clamp01(value);
			if (this.mAlpha != num)
			{
				bool flag = this.mAlpha > 0.001f;
				this.mAlphaFrameID = -1;
				this.mResized = true;
				this.mAlpha = num;
				int i = 0;
				int count = this.drawCalls.Count;
				while (i < count)
				{
					this.drawCalls[i].isDirty = true;
					i++;
				}
				this.Invalidate(!flag && this.mAlpha > 0.001f);
			}
		}
	}

	// Token: 0x17000192 RID: 402
	// (get) Token: 0x060007F8 RID: 2040 RVA: 0x00042763 File Offset: 0x00040963
	// (set) Token: 0x060007F9 RID: 2041 RVA: 0x0004276B File Offset: 0x0004096B
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
				this.mDepth = value;
				UIPanel.list.Sort(new Comparison<UIPanel>(UIPanel.CompareFunc));
			}
		}
	}

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x060007FA RID: 2042 RVA: 0x00042793 File Offset: 0x00040993
	// (set) Token: 0x060007FB RID: 2043 RVA: 0x0004279B File Offset: 0x0004099B
	public int sortingOrder
	{
		get
		{
			return this.mSortingOrder;
		}
		set
		{
			if (this.mSortingOrder != value)
			{
				this.mSortingOrder = value;
				this.UpdateDrawCalls(UIPanel.list.IndexOf(this));
			}
		}
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x000427C0 File Offset: 0x000409C0
	public static int CompareFunc(UIPanel a, UIPanel b)
	{
		if (!(a != b) || !(a != null) || !(b != null))
		{
			return 0;
		}
		if (a.mDepth < b.mDepth)
		{
			return -1;
		}
		if (a.mDepth > b.mDepth)
		{
			return 1;
		}
		if (a.GetInstanceID() >= b.GetInstanceID())
		{
			return 1;
		}
		return -1;
	}

	// Token: 0x17000194 RID: 404
	// (get) Token: 0x060007FD RID: 2045 RVA: 0x0004281B File Offset: 0x00040A1B
	public float width
	{
		get
		{
			return this.GetViewSize().x;
		}
	}

	// Token: 0x17000195 RID: 405
	// (get) Token: 0x060007FE RID: 2046 RVA: 0x00042828 File Offset: 0x00040A28
	public float height
	{
		get
		{
			return this.GetViewSize().y;
		}
	}

	// Token: 0x17000196 RID: 406
	// (get) Token: 0x060007FF RID: 2047 RVA: 0x00042835 File Offset: 0x00040A35
	public bool halfPixelOffset
	{
		get
		{
			return false;
		}
	}

	// Token: 0x17000197 RID: 407
	// (get) Token: 0x06000800 RID: 2048 RVA: 0x00042838 File Offset: 0x00040A38
	public bool usedForUI
	{
		get
		{
			return base.anchorCamera != null && this.mCam.orthographic;
		}
	}

	// Token: 0x17000198 RID: 408
	// (get) Token: 0x06000801 RID: 2049 RVA: 0x00042858 File Offset: 0x00040A58
	public Vector3 drawCallOffset
	{
		get
		{
			if (base.anchorCamera != null && this.mCam.orthographic)
			{
				Vector2 windowSize = this.GetWindowSize();
				float num = ((base.root != null) ? base.root.pixelSizeAdjustment : 1f) / windowSize.y / this.mCam.orthographicSize;
				bool flag = false;
				bool flag2 = false;
				if ((Mathf.RoundToInt(windowSize.x) & 1) == 1)
				{
					flag = !flag;
				}
				if ((Mathf.RoundToInt(windowSize.y) & 1) == 1)
				{
					flag2 = !flag2;
				}
				return new Vector3(flag ? (-num) : 0f, flag2 ? num : 0f);
			}
			return Vector3.zero;
		}
	}

	// Token: 0x17000199 RID: 409
	// (get) Token: 0x06000802 RID: 2050 RVA: 0x00042911 File Offset: 0x00040B11
	// (set) Token: 0x06000803 RID: 2051 RVA: 0x00042919 File Offset: 0x00040B19
	public UIDrawCall.Clipping clipping
	{
		get
		{
			return this.mClipping;
		}
		set
		{
			if (this.mClipping != value)
			{
				this.mResized = true;
				this.mClipping = value;
				this.mMatrixFrame = -1;
			}
		}
	}

	// Token: 0x1700019A RID: 410
	// (get) Token: 0x06000804 RID: 2052 RVA: 0x00042939 File Offset: 0x00040B39
	public UIPanel parentPanel
	{
		get
		{
			return this.mParentPanel;
		}
	}

	// Token: 0x1700019B RID: 411
	// (get) Token: 0x06000805 RID: 2053 RVA: 0x00042944 File Offset: 0x00040B44
	public int clipCount
	{
		get
		{
			int num = 0;
			UIPanel uipanel = this;
			while (uipanel != null)
			{
				if (uipanel.mClipping == UIDrawCall.Clipping.SoftClip || uipanel.mClipping == UIDrawCall.Clipping.TextureMask)
				{
					num++;
				}
				uipanel = uipanel.mParentPanel;
			}
			return num;
		}
	}

	// Token: 0x1700019C RID: 412
	// (get) Token: 0x06000806 RID: 2054 RVA: 0x0004297E File Offset: 0x00040B7E
	public bool hasClipping
	{
		get
		{
			return this.mClipping == UIDrawCall.Clipping.SoftClip || this.mClipping == UIDrawCall.Clipping.TextureMask;
		}
	}

	// Token: 0x1700019D RID: 413
	// (get) Token: 0x06000807 RID: 2055 RVA: 0x00042994 File Offset: 0x00040B94
	public bool hasCumulativeClipping
	{
		get
		{
			return this.clipCount != 0;
		}
	}

	// Token: 0x1700019E RID: 414
	// (get) Token: 0x06000808 RID: 2056 RVA: 0x0004299F File Offset: 0x00040B9F
	[Obsolete("Use 'hasClipping' or 'hasCumulativeClipping' instead")]
	public bool clipsChildren
	{
		get
		{
			return this.hasCumulativeClipping;
		}
	}

	// Token: 0x1700019F RID: 415
	// (get) Token: 0x06000809 RID: 2057 RVA: 0x000429A7 File Offset: 0x00040BA7
	// (set) Token: 0x0600080A RID: 2058 RVA: 0x000429B0 File Offset: 0x00040BB0
	public Vector2 clipOffset
	{
		get
		{
			return this.mClipOffset;
		}
		set
		{
			if (Mathf.Abs(this.mClipOffset.x - value.x) > 0.001f || Mathf.Abs(this.mClipOffset.y - value.y) > 0.001f)
			{
				this.mClipOffset = value;
				this.InvalidateClipping();
				if (this.onClipMove != null)
				{
					this.onClipMove(this);
				}
			}
		}
	}

	// Token: 0x0600080B RID: 2059 RVA: 0x00042A1C File Offset: 0x00040C1C
	private void InvalidateClipping()
	{
		this.mResized = true;
		this.mMatrixFrame = -1;
		int i = 0;
		int count = UIPanel.list.Count;
		while (i < count)
		{
			UIPanel uipanel = UIPanel.list[i];
			if (uipanel != this && uipanel.parentPanel == this)
			{
				uipanel.InvalidateClipping();
			}
			i++;
		}
	}

	// Token: 0x170001A0 RID: 416
	// (get) Token: 0x0600080C RID: 2060 RVA: 0x00042A77 File Offset: 0x00040C77
	// (set) Token: 0x0600080D RID: 2061 RVA: 0x00042A7F File Offset: 0x00040C7F
	public Texture2D clipTexture
	{
		get
		{
			return this.mClipTexture;
		}
		set
		{
			if (this.mClipTexture != value)
			{
				this.mClipTexture = value;
			}
		}
	}

	// Token: 0x170001A1 RID: 417
	// (get) Token: 0x0600080E RID: 2062 RVA: 0x00042A96 File Offset: 0x00040C96
	// (set) Token: 0x0600080F RID: 2063 RVA: 0x00042A9E File Offset: 0x00040C9E
	[Obsolete("Use 'finalClipRegion' or 'baseClipRegion' instead")]
	public Vector4 clipRange
	{
		get
		{
			return this.baseClipRegion;
		}
		set
		{
			this.baseClipRegion = value;
		}
	}

	// Token: 0x170001A2 RID: 418
	// (get) Token: 0x06000810 RID: 2064 RVA: 0x00042AA7 File Offset: 0x00040CA7
	// (set) Token: 0x06000811 RID: 2065 RVA: 0x00042AB0 File Offset: 0x00040CB0
	public Vector4 baseClipRegion
	{
		get
		{
			return this.mClipRange;
		}
		set
		{
			if (Mathf.Abs(this.mClipRange.x - value.x) > 0.001f || Mathf.Abs(this.mClipRange.y - value.y) > 0.001f || Mathf.Abs(this.mClipRange.z - value.z) > 0.001f || Mathf.Abs(this.mClipRange.w - value.w) > 0.001f)
			{
				this.mResized = true;
				this.mClipRange = value;
				this.mMatrixFrame = -1;
				UIScrollView component = base.GetComponent<UIScrollView>();
				if (component != null)
				{
					component.UpdatePosition();
				}
				if (this.onClipMove != null)
				{
					this.onClipMove(this);
				}
			}
		}
	}

	// Token: 0x170001A3 RID: 419
	// (get) Token: 0x06000812 RID: 2066 RVA: 0x00042B74 File Offset: 0x00040D74
	public Vector4 finalClipRegion
	{
		get
		{
			Vector2 viewSize = this.GetViewSize();
			if (this.mClipping != UIDrawCall.Clipping.None)
			{
				return new Vector4(this.mClipRange.x + this.mClipOffset.x, this.mClipRange.y + this.mClipOffset.y, viewSize.x, viewSize.y);
			}
			Vector4 result = new Vector4(0f, 0f, viewSize.x, viewSize.y);
			Vector3 vector = base.anchorCamera.WorldToScreenPoint(base.cachedTransform.position);
			vector.x -= viewSize.x * 0.5f;
			vector.y -= viewSize.y * 0.5f;
			result.x -= vector.x;
			result.y -= vector.y;
			return result;
		}
	}

	// Token: 0x170001A4 RID: 420
	// (get) Token: 0x06000813 RID: 2067 RVA: 0x00042C55 File Offset: 0x00040E55
	// (set) Token: 0x06000814 RID: 2068 RVA: 0x00042C5D File Offset: 0x00040E5D
	public Vector2 clipSoftness
	{
		get
		{
			return this.mClipSoftness;
		}
		set
		{
			if (this.mClipSoftness != value)
			{
				this.mClipSoftness = value;
			}
		}
	}

	// Token: 0x170001A5 RID: 421
	// (get) Token: 0x06000815 RID: 2069 RVA: 0x00042C74 File Offset: 0x00040E74
	public override Vector3[] localCorners
	{
		get
		{
			if (this.mClipping == UIDrawCall.Clipping.None)
			{
				Vector3[] worldCorners = this.worldCorners;
				Transform cachedTransform = base.cachedTransform;
				for (int i = 0; i < 4; i++)
				{
					worldCorners[i] = cachedTransform.InverseTransformPoint(worldCorners[i]);
				}
				return worldCorners;
			}
			float num = this.mClipOffset.x + this.mClipRange.x - 0.5f * this.mClipRange.z;
			float num2 = this.mClipOffset.y + this.mClipRange.y - 0.5f * this.mClipRange.w;
			float x = num + this.mClipRange.z;
			float y = num2 + this.mClipRange.w;
			UIPanel.mCorners[0] = new Vector3(num, num2);
			UIPanel.mCorners[1] = new Vector3(num, y);
			UIPanel.mCorners[2] = new Vector3(x, y);
			UIPanel.mCorners[3] = new Vector3(x, num2);
			return UIPanel.mCorners;
		}
	}

	// Token: 0x170001A6 RID: 422
	// (get) Token: 0x06000816 RID: 2070 RVA: 0x00042D80 File Offset: 0x00040F80
	public override Vector3[] worldCorners
	{
		get
		{
			if (this.mClipping != UIDrawCall.Clipping.None)
			{
				float num = this.mClipOffset.x + this.mClipRange.x - 0.5f * this.mClipRange.z;
				float num2 = this.mClipOffset.y + this.mClipRange.y - 0.5f * this.mClipRange.w;
				float x = num + this.mClipRange.z;
				float y = num2 + this.mClipRange.w;
				Transform cachedTransform = base.cachedTransform;
				UIPanel.mCorners[0] = cachedTransform.TransformPoint(num, num2, 0f);
				UIPanel.mCorners[1] = cachedTransform.TransformPoint(num, y, 0f);
				UIPanel.mCorners[2] = cachedTransform.TransformPoint(x, y, 0f);
				UIPanel.mCorners[3] = cachedTransform.TransformPoint(x, num2, 0f);
			}
			else
			{
				if (base.anchorCamera != null)
				{
					return this.mCam.GetWorldCorners(base.cameraRayDistance);
				}
				Vector2 viewSize = this.GetViewSize();
				float num3 = -0.5f * viewSize.x;
				float num4 = -0.5f * viewSize.y;
				float x2 = num3 + viewSize.x;
				float y2 = num4 + viewSize.y;
				UIPanel.mCorners[0] = new Vector3(num3, num4);
				UIPanel.mCorners[1] = new Vector3(num3, y2);
				UIPanel.mCorners[2] = new Vector3(x2, y2);
				UIPanel.mCorners[3] = new Vector3(x2, num4);
				if (this.anchorOffset && (this.mCam == null || this.mCam.transform.parent != base.cachedTransform))
				{
					Vector3 position = base.cachedTransform.position;
					for (int i = 0; i < 4; i++)
					{
						UIPanel.mCorners[i] += position;
					}
				}
			}
			return UIPanel.mCorners;
		}
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x00042F9C File Offset: 0x0004119C
	public override Vector3[] GetSides(Transform relativeTo)
	{
		if (this.mClipping != UIDrawCall.Clipping.None)
		{
			float num = this.mClipOffset.x + this.mClipRange.x - 0.5f * this.mClipRange.z;
			float num2 = this.mClipOffset.y + this.mClipRange.y - 0.5f * this.mClipRange.w;
			float num3 = num + this.mClipRange.z;
			float num4 = num2 + this.mClipRange.w;
			float x = (num + num3) * 0.5f;
			float y = (num2 + num4) * 0.5f;
			Transform cachedTransform = base.cachedTransform;
			UIRect.mSides[0] = cachedTransform.TransformPoint(num, y, 0f);
			UIRect.mSides[1] = cachedTransform.TransformPoint(x, num4, 0f);
			UIRect.mSides[2] = cachedTransform.TransformPoint(num3, y, 0f);
			UIRect.mSides[3] = cachedTransform.TransformPoint(x, num2, 0f);
			if (relativeTo != null)
			{
				for (int i = 0; i < 4; i++)
				{
					UIRect.mSides[i] = relativeTo.InverseTransformPoint(UIRect.mSides[i]);
				}
			}
			return UIRect.mSides;
		}
		if (base.anchorCamera != null && this.anchorOffset)
		{
			Vector3[] sides = this.mCam.GetSides(base.cameraRayDistance);
			Vector3 position = base.cachedTransform.position;
			for (int j = 0; j < 4; j++)
			{
				sides[j] += position;
			}
			if (relativeTo != null)
			{
				for (int k = 0; k < 4; k++)
				{
					sides[k] = relativeTo.InverseTransformPoint(sides[k]);
				}
			}
			return sides;
		}
		return base.GetSides(relativeTo);
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x00043186 File Offset: 0x00041386
	public override void Invalidate(bool includeChildren)
	{
		this.mAlphaFrameID = -1;
		base.Invalidate(includeChildren);
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x00043198 File Offset: 0x00041398
	public override float CalculateFinalAlpha(int frameID)
	{
		if (this.mAlphaFrameID != frameID)
		{
			this.mAlphaFrameID = frameID;
			UIRect parent = base.parent;
			this.finalAlpha = ((base.parent != null) ? (parent.CalculateFinalAlpha(frameID) * this.mAlpha) : this.mAlpha);
		}
		return this.finalAlpha;
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x000431EC File Offset: 0x000413EC
	public override void SetRect(float x, float y, float width, float height)
	{
		int num = Mathf.FloorToInt(width + 0.5f);
		int num2 = Mathf.FloorToInt(height + 0.5f);
		num = num >> 1 << 1;
		num2 = num2 >> 1 << 1;
		Transform transform = base.cachedTransform;
		Vector3 localPosition = transform.localPosition;
		localPosition.x = Mathf.Floor(x + 0.5f);
		localPosition.y = Mathf.Floor(y + 0.5f);
		if (num < 2)
		{
			num = 2;
		}
		if (num2 < 2)
		{
			num2 = 2;
		}
		this.baseClipRegion = new Vector4(localPosition.x, localPosition.y, (float)num, (float)num2);
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

	// Token: 0x0600081B RID: 2075 RVA: 0x00043310 File Offset: 0x00041510
	public bool IsVisible(Vector3 a, Vector3 b, Vector3 c, Vector3 d)
	{
		this.UpdateTransformMatrix();
		a = this.worldToLocal.MultiplyPoint3x4(a);
		b = this.worldToLocal.MultiplyPoint3x4(b);
		c = this.worldToLocal.MultiplyPoint3x4(c);
		d = this.worldToLocal.MultiplyPoint3x4(d);
		UIPanel.mTemp[0] = a.x;
		UIPanel.mTemp[1] = b.x;
		UIPanel.mTemp[2] = c.x;
		UIPanel.mTemp[3] = d.x;
		float num = Mathf.Min(UIPanel.mTemp);
		float num2 = Mathf.Max(UIPanel.mTemp);
		UIPanel.mTemp[0] = a.y;
		UIPanel.mTemp[1] = b.y;
		UIPanel.mTemp[2] = c.y;
		UIPanel.mTemp[3] = d.y;
		float num3 = Mathf.Min(UIPanel.mTemp);
		float num4 = Mathf.Max(UIPanel.mTemp);
		return num2 >= this.mMin.x && num4 >= this.mMin.y && num <= this.mMax.x && num3 <= this.mMax.y;
	}

	// Token: 0x0600081C RID: 2076 RVA: 0x00043434 File Offset: 0x00041634
	public bool IsVisible(Vector3 worldPos)
	{
		if (this.mAlpha < 0.001f)
		{
			return false;
		}
		if (this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip)
		{
			return true;
		}
		this.UpdateTransformMatrix();
		Vector3 vector = this.worldToLocal.MultiplyPoint3x4(worldPos);
		return vector.x >= this.mMin.x && vector.y >= this.mMin.y && vector.x <= this.mMax.x && vector.y <= this.mMax.y;
	}

	// Token: 0x0600081D RID: 2077 RVA: 0x000434CC File Offset: 0x000416CC
	public bool IsVisible(UIWidget w)
	{
		UIPanel uipanel = this;
		Vector3[] array = null;
		while (uipanel != null)
		{
			if ((uipanel.mClipping == UIDrawCall.Clipping.None || uipanel.mClipping == UIDrawCall.Clipping.ConstrainButDontClip) && !w.hideIfOffScreen)
			{
				uipanel = uipanel.mParentPanel;
			}
			else
			{
				if (array == null)
				{
					array = w.worldCorners;
				}
				if (!uipanel.IsVisible(array[0], array[1], array[2], array[3]))
				{
					return false;
				}
				uipanel = uipanel.mParentPanel;
			}
		}
		return true;
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x00043544 File Offset: 0x00041744
	public bool Affects(UIWidget w)
	{
		if (w == null)
		{
			return false;
		}
		UIPanel panel = w.panel;
		if (panel == null)
		{
			return false;
		}
		UIPanel uipanel = this;
		while (uipanel != null)
		{
			if (uipanel == panel)
			{
				return true;
			}
			if (!uipanel.hasCumulativeClipping)
			{
				return false;
			}
			uipanel = uipanel.mParentPanel;
		}
		return false;
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x00043598 File Offset: 0x00041798
	[ContextMenu("Force Refresh")]
	public void RebuildAllDrawCalls()
	{
		this.mRebuild = true;
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x000435A4 File Offset: 0x000417A4
	public void SetDirty()
	{
		int i = 0;
		int count = this.drawCalls.Count;
		while (i < count)
		{
			this.drawCalls[i].isDirty = true;
			i++;
		}
		this.Invalidate(true);
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x000435E2 File Offset: 0x000417E2
	protected override void Awake()
	{
		base.Awake();
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x000435EC File Offset: 0x000417EC
	private void FindParent()
	{
		Transform parent = base.cachedTransform.parent;
		this.mParentPanel = ((parent != null) ? NGUITools.FindInParents<UIPanel>(parent.gameObject) : null);
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x00043622 File Offset: 0x00041822
	public override void ParentHasChanged()
	{
		base.ParentHasChanged();
		this.FindParent();
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x00043630 File Offset: 0x00041830
	protected override void OnStart()
	{
		this.mLayer = base.cachedGameObject.layer;
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x00043643 File Offset: 0x00041843
	protected override void OnEnable()
	{
		this.mRebuild = true;
		this.mAlphaFrameID = -1;
		this.mMatrixFrame = -1;
		this.OnStart();
		base.OnEnable();
		this.mMatrixFrame = -1;
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x00043670 File Offset: 0x00041870
	protected override void OnInit()
	{
		if (UIPanel.list.Contains(this))
		{
			return;
		}
		base.OnInit();
		this.FindParent();
		if (base.GetComponent<Rigidbody>() == null && this.mParentPanel == null)
		{
			UICamera uicamera = (base.anchorCamera != null) ? this.mCam.GetComponent<UICamera>() : null;
			if (uicamera != null && (uicamera.eventType == UICamera.EventType.UI_3D || uicamera.eventType == UICamera.EventType.World_3D))
			{
				Rigidbody rigidbody = base.gameObject.AddComponent<Rigidbody>();
				rigidbody.isKinematic = true;
				rigidbody.useGravity = false;
			}
		}
		this.mRebuild = true;
		this.mAlphaFrameID = -1;
		this.mMatrixFrame = -1;
		UIPanel.list.Add(this);
		UIPanel.list.Sort(new Comparison<UIPanel>(UIPanel.CompareFunc));
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x00043738 File Offset: 0x00041938
	protected override void OnDisable()
	{
		int i = 0;
		int count = this.drawCalls.Count;
		while (i < count)
		{
			UIDrawCall uidrawCall = this.drawCalls[i];
			if (uidrawCall != null)
			{
				UIDrawCall.Destroy(uidrawCall);
			}
			i++;
		}
		this.drawCalls.Clear();
		UIPanel.list.Remove(this);
		this.mAlphaFrameID = -1;
		this.mMatrixFrame = -1;
		if (UIPanel.list.Count == 0)
		{
			UIDrawCall.ReleaseAll();
			UIPanel.mUpdateFrame = -1;
		}
		base.OnDisable();
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x000437BC File Offset: 0x000419BC
	private void UpdateTransformMatrix()
	{
		int frameCount = Time.frameCount;
		if (this.mHasMoved || this.mMatrixFrame != frameCount)
		{
			this.mMatrixFrame = frameCount;
			this.worldToLocal = base.cachedTransform.worldToLocalMatrix;
			Vector2 vector = this.GetViewSize() * 0.5f;
			float num = this.mClipOffset.x + this.mClipRange.x;
			float num2 = this.mClipOffset.y + this.mClipRange.y;
			this.mMin.x = num - vector.x;
			this.mMin.y = num2 - vector.y;
			this.mMax.x = num + vector.x;
			this.mMax.y = num2 + vector.y;
		}
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x00043888 File Offset: 0x00041A88
	protected override void OnAnchor()
	{
		if (this.mClipping == UIDrawCall.Clipping.None)
		{
			return;
		}
		Transform cachedTransform = base.cachedTransform;
		Transform parent = cachedTransform.parent;
		Vector2 viewSize = this.GetViewSize();
		Vector2 vector = cachedTransform.localPosition;
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
			}
			else
			{
				Vector2 vector2 = base.GetLocalPos(this.leftAnchor, parent);
				num = vector2.x + (float)this.leftAnchor.absolute;
				num3 = vector2.y + (float)this.bottomAnchor.absolute;
				num2 = vector2.x + (float)this.rightAnchor.absolute;
				num4 = vector2.y + (float)this.topAnchor.absolute;
			}
		}
		else
		{
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
				num = this.mClipRange.x - 0.5f * viewSize.x;
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
				num2 = this.mClipRange.x + 0.5f * viewSize.x;
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
				num3 = this.mClipRange.y - 0.5f * viewSize.y;
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
				num4 = this.mClipRange.y + 0.5f * viewSize.y;
			}
		}
		num -= vector.x + this.mClipOffset.x;
		num2 -= vector.x + this.mClipOffset.x;
		num3 -= vector.y + this.mClipOffset.y;
		num4 -= vector.y + this.mClipOffset.y;
		float x = Mathf.Lerp(num, num2, 0.5f);
		float y = Mathf.Lerp(num3, num4, 0.5f);
		float num5 = num2 - num;
		float num6 = num4 - num3;
		float num7 = Mathf.Max(2f, this.mClipSoftness.x);
		float num8 = Mathf.Max(2f, this.mClipSoftness.y);
		if (num5 < num7)
		{
			num5 = num7;
		}
		if (num6 < num8)
		{
			num6 = num8;
		}
		this.baseClipRegion = new Vector4(x, y, num5, num6);
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x00043DCC File Offset: 0x00041FCC
	private void LateUpdate()
	{
		if (UIPanel.mUpdateFrame != Time.frameCount)
		{
			UIPanel.mUpdateFrame = Time.frameCount;
			int i = 0;
			int count = UIPanel.list.Count;
			while (i < count)
			{
				UIPanel.list[i].UpdateSelf();
				i++;
			}
			int num = 3000;
			int j = 0;
			int count2 = UIPanel.list.Count;
			while (j < count2)
			{
				UIPanel uipanel = UIPanel.list[j];
				if (uipanel.renderQueue == UIPanel.RenderQueue.Automatic)
				{
					uipanel.startingRenderQueue = num;
					uipanel.UpdateDrawCalls(j);
					num += uipanel.drawCalls.Count;
				}
				else if (uipanel.renderQueue == UIPanel.RenderQueue.StartAt)
				{
					uipanel.UpdateDrawCalls(j);
					if (uipanel.drawCalls.Count != 0)
					{
						num = Mathf.Max(num, uipanel.startingRenderQueue + uipanel.drawCalls.Count);
					}
				}
				else
				{
					uipanel.UpdateDrawCalls(j);
					if (uipanel.drawCalls.Count != 0)
					{
						num = Mathf.Max(num, uipanel.startingRenderQueue + 1);
					}
				}
				j++;
			}
		}
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x00043ED8 File Offset: 0x000420D8
	private void UpdateSelf()
	{
		this.mHasMoved = base.cachedTransform.hasChanged;
		this.UpdateTransformMatrix();
		this.UpdateLayers();
		this.UpdateWidgets();
		if (this.mRebuild)
		{
			this.mRebuild = false;
			this.FillAllDrawCalls();
		}
		else
		{
			bool needsCulling = this.mCam == null || this.mCam.useOcclusionCulling;
			int i = 0;
			while (i < this.drawCalls.Count)
			{
				UIDrawCall uidrawCall = this.drawCalls[i];
				if (uidrawCall.isDirty && !this.FillDrawCall(uidrawCall, needsCulling))
				{
					UIDrawCall.Destroy(uidrawCall);
					this.drawCalls.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
		}
		if (this.mUpdateScroll)
		{
			this.mUpdateScroll = false;
			UIScrollView component = base.GetComponent<UIScrollView>();
			if (component != null)
			{
				component.UpdateScrollbars();
			}
		}
		if (this.mHasMoved)
		{
			this.mHasMoved = false;
			this.mTrans.hasChanged = false;
		}
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x00043FC5 File Offset: 0x000421C5
	public void SortWidgets()
	{
		this.mSortWidgets = false;
		this.widgets.Sort(new Comparison<UIWidget>(UIWidget.PanelCompareFunc));
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x00043FE8 File Offset: 0x000421E8
	private void FillAllDrawCalls()
	{
		for (int i = 0; i < this.drawCalls.Count; i++)
		{
			UIDrawCall.Destroy(this.drawCalls[i]);
		}
		this.drawCalls.Clear();
		Material material = null;
		Texture texture = null;
		Shader shader = null;
		UIDrawCall uidrawCall = null;
		int num = 0;
		bool needsBounds = this.mCam == null || this.mCam.useOcclusionCulling;
		if (this.mSortWidgets)
		{
			this.SortWidgets();
		}
		for (int j = 0; j < this.widgets.Count; j++)
		{
			UIWidget uiwidget = this.widgets[j];
			if (uiwidget.isVisible && uiwidget.hasVertices)
			{
				Material material2 = uiwidget.material;
				if (this.onCreateMaterial != null)
				{
					material2 = this.onCreateMaterial(uiwidget, material2);
				}
				Texture mainTexture = uiwidget.mainTexture;
				Shader shader2 = uiwidget.shader;
				if (material != material2 || texture != mainTexture || shader != shader2)
				{
					if (uidrawCall != null && uidrawCall.verts.Count != 0)
					{
						this.drawCalls.Add(uidrawCall);
						uidrawCall.UpdateGeometry(num, needsBounds);
						uidrawCall.onRender = this.mOnRender;
						this.mOnRender = null;
						num = 0;
						uidrawCall = null;
					}
					material = material2;
					texture = mainTexture;
					shader = shader2;
				}
				if (material != null || shader != null || texture != null)
				{
					if (uidrawCall == null)
					{
						if (true)
						{
							uidrawCall = UIDrawCall.Create(this, material, texture, shader);
							uidrawCall.depthStart = uiwidget.depth;
							uidrawCall.depthEnd = uidrawCall.depthStart;
							uidrawCall.panel = this;
							uidrawCall.onCreateDrawCall = this.onCreateDrawCall;
						}
					}
					else
					{
						int depth = uiwidget.depth;
						if (depth < uidrawCall.depthStart)
						{
							uidrawCall.depthStart = depth;
						}
						if (depth > uidrawCall.depthEnd)
						{
							uidrawCall.depthEnd = depth;
						}
					}
					uiwidget.drawCall = uidrawCall;
					if (uidrawCall != null)
					{
						num++;
						if (this.generateNormals)
						{
							uiwidget.WriteToBuffers(uidrawCall.verts, uidrawCall.uvs, uidrawCall.cols, uidrawCall.norms, uidrawCall.tans, this.generateUV2 ? uidrawCall.uv2 : null);
						}
						else
						{
							uiwidget.WriteToBuffers(uidrawCall.verts, uidrawCall.uvs, uidrawCall.cols, null, null, this.generateUV2 ? uidrawCall.uv2 : null);
						}
						if (uiwidget.mOnRender != null)
						{
							if (this.mOnRender == null)
							{
								this.mOnRender = uiwidget.mOnRender;
							}
							else
							{
								this.mOnRender = (UIDrawCall.OnRenderCallback)Delegate.Combine(this.mOnRender, uiwidget.mOnRender);
							}
						}
					}
				}
			}
			else
			{
				uiwidget.drawCall = null;
			}
		}
		if (uidrawCall != null && uidrawCall.verts.Count != 0)
		{
			this.drawCalls.Add(uidrawCall);
			uidrawCall.UpdateGeometry(num, needsBounds);
			uidrawCall.onRender = this.mOnRender;
			this.mOnRender = null;
		}
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x000442E4 File Offset: 0x000424E4
	public bool FillDrawCall(UIDrawCall dc)
	{
		bool needsCulling = this.mCam == null || this.mCam.useOcclusionCulling;
		return this.FillDrawCall(dc, needsCulling);
	}

	// Token: 0x0600082F RID: 2095 RVA: 0x00044318 File Offset: 0x00042518
	public bool FillDrawCall(UIDrawCall dc, bool needsCulling)
	{
		if (dc != null)
		{
			dc.isDirty = false;
			int num = 0;
			int i = 0;
			while (i < this.widgets.Count)
			{
				UIWidget uiwidget = this.widgets[i];
				if (uiwidget == null)
				{
					this.widgets.RemoveAt(i);
				}
				else
				{
					if (uiwidget.drawCall == dc)
					{
						if (uiwidget.isVisible && uiwidget.hasVertices)
						{
							num++;
							if (this.generateNormals)
							{
								uiwidget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, dc.norms, dc.tans, this.generateUV2 ? dc.uv2 : null);
							}
							else
							{
								uiwidget.WriteToBuffers(dc.verts, dc.uvs, dc.cols, null, null, this.generateUV2 ? dc.uv2 : null);
							}
							if (uiwidget.mOnRender != null)
							{
								if (this.mOnRender == null)
								{
									this.mOnRender = uiwidget.mOnRender;
								}
								else
								{
									this.mOnRender = (UIDrawCall.OnRenderCallback)Delegate.Combine(this.mOnRender, uiwidget.mOnRender);
								}
							}
						}
						else
						{
							uiwidget.drawCall = null;
						}
					}
					i++;
				}
			}
			if (dc.verts.Count != 0)
			{
				dc.UpdateGeometry(num, needsCulling);
				dc.onRender = this.mOnRender;
				this.mOnRender = null;
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x00044480 File Offset: 0x00042680
	private void UpdateDrawCalls(int sortOrder)
	{
		Transform cachedTransform = base.cachedTransform;
		bool usedForUI = this.usedForUI;
		if (this.clipping != UIDrawCall.Clipping.None)
		{
			this.drawCallClipRange = this.finalClipRegion;
			this.drawCallClipRange.z = this.drawCallClipRange.z * 0.5f;
			this.drawCallClipRange.w = this.drawCallClipRange.w * 0.5f;
		}
		else
		{
			this.drawCallClipRange = Vector4.zero;
		}
		int width = Screen.width;
		int height = Screen.height;
		if (this.drawCallClipRange.z == 0f)
		{
			this.drawCallClipRange.z = (float)width * 0.5f;
		}
		if (this.drawCallClipRange.w == 0f)
		{
			this.drawCallClipRange.w = (float)height * 0.5f;
		}
		if (this.halfPixelOffset)
		{
			this.drawCallClipRange.x = this.drawCallClipRange.x - 0.5f;
			this.drawCallClipRange.y = this.drawCallClipRange.y + 0.5f;
		}
		Vector3 vector;
		if (usedForUI)
		{
			Transform parent = base.cachedTransform.parent;
			vector = base.cachedTransform.localPosition;
			if (this.clipping != UIDrawCall.Clipping.None)
			{
				vector.x = (float)Mathf.RoundToInt(vector.x);
				vector.y = (float)Mathf.RoundToInt(vector.y);
			}
			if (parent != null)
			{
				vector = parent.TransformPoint(vector);
			}
			vector += this.drawCallOffset;
		}
		else
		{
			vector = cachedTransform.position;
		}
		Quaternion rotation = cachedTransform.rotation;
		Vector3 lossyScale = cachedTransform.lossyScale;
		for (int i = 0; i < this.drawCalls.Count; i++)
		{
			UIDrawCall uidrawCall = this.drawCalls[i];
			Transform cachedTransform2 = uidrawCall.cachedTransform;
			cachedTransform2.position = vector;
			cachedTransform2.rotation = rotation;
			cachedTransform2.localScale = lossyScale;
			uidrawCall.renderQueue = ((this.renderQueue == UIPanel.RenderQueue.Explicit) ? this.startingRenderQueue : (this.startingRenderQueue + i));
			uidrawCall.alwaysOnScreen = (this.alwaysOnScreen && (this.mClipping == UIDrawCall.Clipping.None || this.mClipping == UIDrawCall.Clipping.ConstrainButDontClip));
			uidrawCall.sortingOrder = (this.useSortingOrder ? ((this.mSortingOrder == 0 && this.renderQueue == UIPanel.RenderQueue.Automatic) ? sortOrder : this.mSortingOrder) : 0);
			uidrawCall.sortingLayerName = (this.useSortingOrder ? this.mSortingLayerName : null);
			uidrawCall.clipTexture = this.mClipTexture;
			uidrawCall.shadowMode = this.shadowMode;
		}
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x000446D4 File Offset: 0x000428D4
	private void UpdateLayers()
	{
		if (this.mLayer != base.cachedGameObject.layer)
		{
			this.mLayer = this.mGo.layer;
			int i = 0;
			int count = this.widgets.Count;
			while (i < count)
			{
				UIWidget uiwidget = this.widgets[i];
				if (uiwidget && uiwidget.parent == this)
				{
					uiwidget.gameObject.layer = this.mLayer;
				}
				i++;
			}
			base.ResetAnchors();
			for (int j = 0; j < this.drawCalls.Count; j++)
			{
				this.drawCalls[j].gameObject.layer = this.mLayer;
			}
		}
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x0004478C File Offset: 0x0004298C
	private void UpdateWidgets()
	{
		bool flag = false;
		bool flag2 = false;
		bool hasCumulativeClipping = this.hasCumulativeClipping;
		if (!this.cullWhileDragging)
		{
			for (int i = 0; i < UIScrollView.list.size; i++)
			{
				UIScrollView uiscrollView = UIScrollView.list.buffer[i];
				if (uiscrollView.panel == this && uiscrollView.isDragging)
				{
					flag2 = true;
				}
			}
		}
		if (this.mForced != flag2)
		{
			this.mForced = flag2;
			this.mResized = true;
		}
		int frameCount = Time.frameCount;
		int j = 0;
		int count = this.widgets.Count;
		while (j < count)
		{
			UIWidget uiwidget = this.widgets[j];
			if (uiwidget.panel == this && uiwidget.enabled)
			{
				if (uiwidget.UpdateTransform(frameCount) || this.mResized || (this.mHasMoved && !this.alwaysOnScreen))
				{
					bool visibleByAlpha = flag2 || uiwidget.CalculateCumulativeAlpha(frameCount) > 0.001f;
					uiwidget.UpdateVisibility(visibleByAlpha, flag2 || this.alwaysOnScreen || (!hasCumulativeClipping && !uiwidget.hideIfOffScreen) || this.IsVisible(uiwidget));
				}
				if (uiwidget.UpdateGeometry(frameCount))
				{
					flag = true;
					if (!this.mRebuild)
					{
						if (uiwidget.drawCall != null)
						{
							uiwidget.drawCall.isDirty = true;
						}
						else
						{
							this.FindDrawCall(uiwidget);
						}
					}
				}
			}
			j++;
		}
		if (flag && this.onGeometryUpdated != null)
		{
			this.onGeometryUpdated();
		}
		this.mResized = false;
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x0004491C File Offset: 0x00042B1C
	public UIDrawCall FindDrawCall(UIWidget w)
	{
		Material material = w.material;
		Texture mainTexture = w.mainTexture;
		Shader shader = w.shader;
		int depth = w.depth;
		for (int i = 0; i < this.drawCalls.Count; i++)
		{
			UIDrawCall uidrawCall = this.drawCalls[i];
			int num = (i == 0) ? int.MinValue : (this.drawCalls[i - 1].depthEnd + 1);
			int num2 = (i + 1 == this.drawCalls.Count) ? int.MaxValue : (this.drawCalls[i + 1].depthStart - 1);
			if (num <= depth && num2 >= depth)
			{
				if (uidrawCall.baseMaterial == material && uidrawCall.shader == shader && uidrawCall.mainTexture == mainTexture)
				{
					if (w.isVisible)
					{
						w.drawCall = uidrawCall;
						if (w.hasVertices)
						{
							uidrawCall.isDirty = true;
						}
						return uidrawCall;
					}
				}
				else
				{
					this.mRebuild = true;
				}
				return null;
			}
		}
		this.mRebuild = true;
		return null;
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x00044A30 File Offset: 0x00042C30
	public void AddWidget(UIWidget w)
	{
		this.mUpdateScroll = true;
		if (this.widgets.Count == 0)
		{
			this.widgets.Add(w);
		}
		else if (this.mSortWidgets)
		{
			this.widgets.Add(w);
			this.SortWidgets();
		}
		else if (UIWidget.PanelCompareFunc(w, this.widgets[0]) == -1)
		{
			this.widgets.Insert(0, w);
		}
		else
		{
			int i = this.widgets.Count;
			while (i > 0)
			{
				if (UIWidget.PanelCompareFunc(w, this.widgets[--i]) != -1)
				{
					this.widgets.Insert(i + 1, w);
					break;
				}
			}
		}
		this.FindDrawCall(w);
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x00044AE4 File Offset: 0x00042CE4
	public void RemoveWidget(UIWidget w)
	{
		if (this.widgets.Remove(w) && w.drawCall != null)
		{
			int depth = w.depth;
			if (depth == w.drawCall.depthStart || depth == w.drawCall.depthEnd)
			{
				this.mRebuild = true;
			}
			w.drawCall.isDirty = true;
			w.drawCall = null;
		}
	}

	// Token: 0x06000836 RID: 2102 RVA: 0x00044B4A File Offset: 0x00042D4A
	public void Refresh()
	{
		this.mRebuild = true;
		UIPanel.mUpdateFrame = -1;
		if (UIPanel.list.Count > 0)
		{
			UIPanel.list[0].LateUpdate();
		}
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x00044B78 File Offset: 0x00042D78
	public virtual Vector3 CalculateConstrainOffset(Vector2 min, Vector2 max)
	{
		Vector4 finalClipRegion = this.finalClipRegion;
		float num = finalClipRegion.z * 0.5f;
		float num2 = finalClipRegion.w * 0.5f;
		Vector2 minRect = new Vector2(min.x, min.y);
		Vector2 maxRect = new Vector2(max.x, max.y);
		Vector2 minArea = new Vector2(finalClipRegion.x - num, finalClipRegion.y - num2);
		Vector2 maxArea = new Vector2(finalClipRegion.x + num, finalClipRegion.y + num2);
		if (this.softBorderPadding && this.clipping == UIDrawCall.Clipping.SoftClip)
		{
			minArea.x += this.mClipSoftness.x;
			minArea.y += this.mClipSoftness.y;
			maxArea.x -= this.mClipSoftness.x;
			maxArea.y -= this.mClipSoftness.y;
		}
		return NGUIMath.ConstrainRect(minRect, maxRect, minArea, maxArea);
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x00044C70 File Offset: 0x00042E70
	public bool ConstrainTargetToBounds(Transform target, ref Bounds targetBounds, bool immediate)
	{
		Vector3 vector = targetBounds.min;
		Vector3 vector2 = targetBounds.max;
		float num = 1f;
		if (this.mClipping == UIDrawCall.Clipping.None)
		{
			UIRoot root = base.root;
			if (root != null)
			{
				num = root.pixelSizeAdjustment;
			}
		}
		if (num != 1f)
		{
			vector /= num;
			vector2 /= num;
		}
		Vector3 b = this.CalculateConstrainOffset(vector, vector2) * num;
		if (b.sqrMagnitude > 0f)
		{
			if (immediate)
			{
				target.localPosition += b;
				targetBounds.center += b;
				SpringPosition component = target.GetComponent<SpringPosition>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			else
			{
				SpringPosition springPosition = SpringPosition.Begin(target.gameObject, target.localPosition + b, 13f);
				springPosition.ignoreTimeScale = true;
				springPosition.worldSpace = false;
			}
			return true;
		}
		return false;
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x00044D64 File Offset: 0x00042F64
	public bool ConstrainTargetToBounds(Transform target, bool immediate)
	{
		Bounds bounds = NGUIMath.CalculateRelativeWidgetBounds(base.cachedTransform, target);
		return this.ConstrainTargetToBounds(target, ref bounds, immediate);
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x00044D88 File Offset: 0x00042F88
	public static UIPanel Find(Transform trans)
	{
		return UIPanel.Find(trans, false, -1);
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x00044D92 File Offset: 0x00042F92
	public static UIPanel Find(Transform trans, bool createIfMissing)
	{
		return UIPanel.Find(trans, createIfMissing, -1);
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x00044D9C File Offset: 0x00042F9C
	public static UIPanel Find(Transform trans, bool createIfMissing, int layer)
	{
		UIPanel uipanel = NGUITools.FindInParents<UIPanel>(trans);
		if (uipanel != null)
		{
			return uipanel;
		}
		while (trans.parent != null)
		{
			trans = trans.parent;
		}
		if (!createIfMissing)
		{
			return null;
		}
		return NGUITools.CreateUI(trans, false, layer);
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x00044DE0 File Offset: 0x00042FE0
	public Vector2 GetWindowSize()
	{
		UIRoot root = base.root;
		Vector2 vector = NGUITools.screenSize;
		if (root != null)
		{
			vector *= root.GetPixelSizeAdjustment(Mathf.RoundToInt(vector.y));
		}
		return vector;
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x00044E1C File Offset: 0x0004301C
	public Vector2 GetViewSize()
	{
		if (this.mClipping != UIDrawCall.Clipping.None)
		{
			return new Vector2(this.mClipRange.z, this.mClipRange.w);
		}
		return NGUITools.screenSize;
	}

	// Token: 0x04000724 RID: 1828
	public static List<UIPanel> list = new List<UIPanel>();

	// Token: 0x04000725 RID: 1829
	public UIPanel.OnGeometryUpdated onGeometryUpdated;

	// Token: 0x04000726 RID: 1830
	public bool showInPanelTool = true;

	// Token: 0x04000727 RID: 1831
	public bool generateNormals;

	// Token: 0x04000728 RID: 1832
	public bool generateUV2;

	// Token: 0x04000729 RID: 1833
	public UIDrawCall.ShadowMode shadowMode;

	// Token: 0x0400072A RID: 1834
	public bool widgetsAreStatic;

	// Token: 0x0400072B RID: 1835
	public bool cullWhileDragging = true;

	// Token: 0x0400072C RID: 1836
	public bool alwaysOnScreen;

	// Token: 0x0400072D RID: 1837
	public bool anchorOffset;

	// Token: 0x0400072E RID: 1838
	public bool softBorderPadding = true;

	// Token: 0x0400072F RID: 1839
	public UIPanel.RenderQueue renderQueue;

	// Token: 0x04000730 RID: 1840
	public int startingRenderQueue = 3000;

	// Token: 0x04000731 RID: 1841
	[NonSerialized]
	public List<UIWidget> widgets = new List<UIWidget>();

	// Token: 0x04000732 RID: 1842
	[NonSerialized]
	public List<UIDrawCall> drawCalls = new List<UIDrawCall>();

	// Token: 0x04000733 RID: 1843
	[NonSerialized]
	public Matrix4x4 worldToLocal = Matrix4x4.identity;

	// Token: 0x04000734 RID: 1844
	[NonSerialized]
	public Vector4 drawCallClipRange = new Vector4(0f, 0f, 1f, 1f);

	// Token: 0x04000735 RID: 1845
	public UIPanel.OnClippingMoved onClipMove;

	// Token: 0x04000736 RID: 1846
	public UIPanel.OnCreateMaterial onCreateMaterial;

	// Token: 0x04000737 RID: 1847
	public UIDrawCall.OnCreateDrawCall onCreateDrawCall;

	// Token: 0x04000738 RID: 1848
	[HideInInspector]
	[SerializeField]
	private Texture2D mClipTexture;

	// Token: 0x04000739 RID: 1849
	[HideInInspector]
	[SerializeField]
	private float mAlpha = 1f;

	// Token: 0x0400073A RID: 1850
	[HideInInspector]
	[SerializeField]
	private UIDrawCall.Clipping mClipping;

	// Token: 0x0400073B RID: 1851
	[HideInInspector]
	[SerializeField]
	private Vector4 mClipRange = new Vector4(0f, 0f, 300f, 200f);

	// Token: 0x0400073C RID: 1852
	[HideInInspector]
	[SerializeField]
	private Vector2 mClipSoftness = new Vector2(4f, 4f);

	// Token: 0x0400073D RID: 1853
	[HideInInspector]
	[SerializeField]
	private int mDepth;

	// Token: 0x0400073E RID: 1854
	[HideInInspector]
	[SerializeField]
	private int mSortingOrder;

	// Token: 0x0400073F RID: 1855
	[HideInInspector]
	[SerializeField]
	private string mSortingLayerName;

	// Token: 0x04000740 RID: 1856
	private bool mRebuild;

	// Token: 0x04000741 RID: 1857
	private bool mResized;

	// Token: 0x04000742 RID: 1858
	[SerializeField]
	private Vector2 mClipOffset = Vector2.zero;

	// Token: 0x04000743 RID: 1859
	private int mMatrixFrame = -1;

	// Token: 0x04000744 RID: 1860
	private int mAlphaFrameID;

	// Token: 0x04000745 RID: 1861
	private int mLayer = -1;

	// Token: 0x04000746 RID: 1862
	private static float[] mTemp = new float[4];

	// Token: 0x04000747 RID: 1863
	private Vector2 mMin = Vector2.zero;

	// Token: 0x04000748 RID: 1864
	private Vector2 mMax = Vector2.zero;

	// Token: 0x04000749 RID: 1865
	private bool mSortWidgets;

	// Token: 0x0400074A RID: 1866
	private bool mUpdateScroll;

	// Token: 0x0400074B RID: 1867
	public bool useSortingOrder;

	// Token: 0x0400074C RID: 1868
	private UIPanel mParentPanel;

	// Token: 0x0400074D RID: 1869
	private static Vector3[] mCorners = new Vector3[4];

	// Token: 0x0400074E RID: 1870
	private static int mUpdateFrame = -1;

	// Token: 0x0400074F RID: 1871
	[NonSerialized]
	private bool mHasMoved;

	// Token: 0x04000750 RID: 1872
	private UIDrawCall.OnRenderCallback mOnRender;

	// Token: 0x04000751 RID: 1873
	private bool mForced;

	// Token: 0x02000642 RID: 1602
	[DoNotObfuscateNGUI]
	public enum RenderQueue
	{
		// Token: 0x04004F58 RID: 20312
		Automatic,
		// Token: 0x04004F59 RID: 20313
		StartAt,
		// Token: 0x04004F5A RID: 20314
		Explicit
	}

	// Token: 0x02000643 RID: 1603
	// (Invoke) Token: 0x06002646 RID: 9798
	public delegate void OnGeometryUpdated();

	// Token: 0x02000644 RID: 1604
	// (Invoke) Token: 0x0600264A RID: 9802
	public delegate void OnClippingMoved(UIPanel panel);

	// Token: 0x02000645 RID: 1605
	// (Invoke) Token: 0x0600264E RID: 9806
	public delegate Material OnCreateMaterial(UIWidget widget, Material mat);
}
