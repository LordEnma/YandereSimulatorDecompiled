using System;
using UnityEngine;

// Token: 0x0200008F RID: 143
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/Tween/Tween Orthographic Size")]
public class TweenOrthoSize : UITweener
{
	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x0600059C RID: 1436 RVA: 0x0003502E File Offset: 0x0003322E
	public Camera cachedCamera
	{
		get
		{
			if (this.mCam == null)
			{
				this.mCam = base.GetComponent<Camera>();
			}
			return this.mCam;
		}
	}

	// Token: 0x170000C2 RID: 194
	// (get) Token: 0x0600059D RID: 1437 RVA: 0x00035050 File Offset: 0x00033250
	// (set) Token: 0x0600059E RID: 1438 RVA: 0x00035058 File Offset: 0x00033258
	[Obsolete("Use 'value' instead")]
	public float orthoSize
	{
		get
		{
			return this.value;
		}
		set
		{
			this.value = value;
		}
	}

	// Token: 0x170000C3 RID: 195
	// (get) Token: 0x0600059F RID: 1439 RVA: 0x00035061 File Offset: 0x00033261
	// (set) Token: 0x060005A0 RID: 1440 RVA: 0x0003506E File Offset: 0x0003326E
	public float value
	{
		get
		{
			return this.cachedCamera.orthographicSize;
		}
		set
		{
			this.cachedCamera.orthographicSize = value;
		}
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x0003507C File Offset: 0x0003327C
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x0003509C File Offset: 0x0003329C
	public static TweenOrthoSize Begin(GameObject go, float duration, float to)
	{
		TweenOrthoSize tweenOrthoSize = UITweener.Begin<TweenOrthoSize>(go, duration, 0f);
		tweenOrthoSize.from = tweenOrthoSize.value;
		tweenOrthoSize.to = to;
		if (duration <= 0f)
		{
			tweenOrthoSize.Sample(1f, true);
			tweenOrthoSize.enabled = false;
		}
		return tweenOrthoSize;
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x000350E5 File Offset: 0x000332E5
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x000350F3 File Offset: 0x000332F3
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005D3 RID: 1491
	public float from = 1f;

	// Token: 0x040005D4 RID: 1492
	public float to = 1f;

	// Token: 0x040005D5 RID: 1493
	private Camera mCam;
}
