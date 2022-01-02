using System;
using UnityEngine;

// Token: 0x0200008F RID: 143
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/Tween/Tween Orthographic Size")]
public class TweenOrthoSize : UITweener
{
	// Token: 0x170000C1 RID: 193
	// (get) Token: 0x0600059C RID: 1436 RVA: 0x00034D46 File Offset: 0x00032F46
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
	// (get) Token: 0x0600059D RID: 1437 RVA: 0x00034D68 File Offset: 0x00032F68
	// (set) Token: 0x0600059E RID: 1438 RVA: 0x00034D70 File Offset: 0x00032F70
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
	// (get) Token: 0x0600059F RID: 1439 RVA: 0x00034D79 File Offset: 0x00032F79
	// (set) Token: 0x060005A0 RID: 1440 RVA: 0x00034D86 File Offset: 0x00032F86
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

	// Token: 0x060005A1 RID: 1441 RVA: 0x00034D94 File Offset: 0x00032F94
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x00034DB4 File Offset: 0x00032FB4
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

	// Token: 0x060005A3 RID: 1443 RVA: 0x00034DFD File Offset: 0x00032FFD
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00034E0B File Offset: 0x0003300B
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x040005C6 RID: 1478
	public float from = 1f;

	// Token: 0x040005C7 RID: 1479
	public float to = 1f;

	// Token: 0x040005C8 RID: 1480
	private Camera mCam;
}
