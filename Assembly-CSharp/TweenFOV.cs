using System;
using UnityEngine;

// Token: 0x0200008B RID: 139
[RequireComponent(typeof(Camera))]
[AddComponentMenu("NGUI/Tween/Tween Field of View")]
public class TweenFOV : UITweener
{
	// Token: 0x170000BA RID: 186
	// (get) Token: 0x06000571 RID: 1393 RVA: 0x0003453B File Offset: 0x0003273B
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

	// Token: 0x170000BB RID: 187
	// (get) Token: 0x06000572 RID: 1394 RVA: 0x0003455D File Offset: 0x0003275D
	// (set) Token: 0x06000573 RID: 1395 RVA: 0x00034565 File Offset: 0x00032765
	[Obsolete("Use 'value' instead")]
	public float fov
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

	// Token: 0x170000BC RID: 188
	// (get) Token: 0x06000574 RID: 1396 RVA: 0x0003456E File Offset: 0x0003276E
	// (set) Token: 0x06000575 RID: 1397 RVA: 0x0003457B File Offset: 0x0003277B
	public float value
	{
		get
		{
			return this.cachedCamera.fieldOfView;
		}
		set
		{
			this.cachedCamera.fieldOfView = value;
		}
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x00034589 File Offset: 0x00032789
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = this.from * (1f - factor) + this.to * factor;
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x000345A8 File Offset: 0x000327A8
	public static TweenFOV Begin(GameObject go, float duration, float to)
	{
		TweenFOV tweenFOV = UITweener.Begin<TweenFOV>(go, duration, 0f);
		tweenFOV.from = tweenFOV.value;
		tweenFOV.to = to;
		if (duration <= 0f)
		{
			tweenFOV.Sample(1f, true);
			tweenFOV.enabled = false;
		}
		return tweenFOV;
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x000345F1 File Offset: 0x000327F1
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value;
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x000345FF File Offset: 0x000327FF
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value;
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x0003460D File Offset: 0x0003280D
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = this.from;
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x0003461B File Offset: 0x0003281B
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = this.to;
	}

	// Token: 0x040005BC RID: 1468
	public float from = 45f;

	// Token: 0x040005BD RID: 1469
	public float to = 45f;

	// Token: 0x040005BE RID: 1470
	private Camera mCam;
}
