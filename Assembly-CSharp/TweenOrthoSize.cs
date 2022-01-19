using System;
using UnityEngine;

// Token: 0x0200008F RID: 143
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/Tween/Tween Orthographic Size")]
public class TweenOrthoSize : UITweener
{
	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x0600059C RID: 1436 RVA: 0x00034D3E File Offset: 0x00032F3E
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
	// (get) Token: 0x0600059D RID: 1437 RVA: 0x00034D60 File Offset: 0x00032F60
	// (set) Token: 0x0600059E RID: 1438 RVA: 0x00034D68 File Offset: 0x00032F68
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
	// (get) Token: 0x0600059F RID: 1439 RVA: 0x00034D71 File Offset: 0x00032F71
	// (set) Token: 0x060005A0 RID: 1440 RVA: 0x00034D7E File Offset: 0x00032F7E
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

	// Token: 0x060005A1 RID: 1441 RVA: 0x00034D8C File Offset: 0x00032F8C
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00034DAC File Offset: 0x00032FAC
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

	// Token: 0x060005A3 RID: 1443 RVA: 0x00034DF5 File Offset: 0x00032FF5
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00034E03 File Offset: 0x00033003
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005C7 RID: 1479
	public float from = 1f;

	// Token: 0x040005C8 RID: 1480
	public float to = 1f;

	// Token: 0x040005C9 RID: 1481
	private Camera mCam;
}
