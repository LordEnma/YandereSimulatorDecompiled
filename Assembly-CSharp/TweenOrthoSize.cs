using System;
using UnityEngine;

// Token: 0x0200008F RID: 143
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/Tween/Tween Orthographic Size")]
public class TweenOrthoSize : UITweener
{
	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x0600059C RID: 1436 RVA: 0x00034EEE File Offset: 0x000330EE
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
	// (get) Token: 0x0600059D RID: 1437 RVA: 0x00034F10 File Offset: 0x00033110
	// (set) Token: 0x0600059E RID: 1438 RVA: 0x00034F18 File Offset: 0x00033118
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
	// (get) Token: 0x0600059F RID: 1439 RVA: 0x00034F21 File Offset: 0x00033121
	// (set) Token: 0x060005A0 RID: 1440 RVA: 0x00034F2E File Offset: 0x0003312E
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

	// Token: 0x060005A1 RID: 1441 RVA: 0x00034F3C File Offset: 0x0003313C
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00034F5C File Offset: 0x0003315C
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

	// Token: 0x060005A3 RID: 1443 RVA: 0x00034FA5 File Offset: 0x000331A5
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00034FB3 File Offset: 0x000331B3
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005D1 RID: 1489
	public float from = 1f;

	// Token: 0x040005D2 RID: 1490
	public float to = 1f;

	// Token: 0x040005D3 RID: 1491
	private Camera mCam;
}
