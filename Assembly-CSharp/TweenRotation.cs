using System;
using UnityEngine;

// Token: 0x02000091 RID: 145
[AddComponentMenu("NGUI/Tween/Tween Rotation")]
public class TweenRotation : UITweener
{
	// Token: 0x170000C7 RID: 199
	// (get) Token: 0x060005B4 RID: 1460 RVA: 0x00035018 File Offset: 0x00033218
	public Transform cachedTransform
	{
		get
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
			}
			return this.mTrans;
		}
	}

	// Token: 0x170000C8 RID: 200
	// (get) Token: 0x060005B5 RID: 1461 RVA: 0x0003503A File Offset: 0x0003323A
	// (set) Token: 0x060005B6 RID: 1462 RVA: 0x00035042 File Offset: 0x00033242
	[Obsolete("Use 'value' instead")]
	public Quaternion rotation
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

	// Token: 0x170000C9 RID: 201
	// (get) Token: 0x060005B7 RID: 1463 RVA: 0x0003504B File Offset: 0x0003324B
	// (set) Token: 0x060005B8 RID: 1464 RVA: 0x00035058 File Offset: 0x00033258
	public Quaternion value
	{
		get
		{
			return this.cachedTransform.localRotation;
		}
		set
		{
			this.cachedTransform.localRotation = value;
		}
	}

	// Token: 0x060005B9 RID: 1465 RVA: 0x00035068 File Offset: 0x00033268
	protected override void OnUpdate(float factor, bool isFinished)
	{
		this.value = (this.quaternionLerp ? Quaternion.Slerp(Quaternion.Euler(this.from), Quaternion.Euler(this.to), factor) : Quaternion.Euler(new Vector3(Mathf.Lerp(this.from.x, this.to.x, factor), Mathf.Lerp(this.from.y, this.to.y, factor), Mathf.Lerp(this.from.z, this.to.z, factor))));
	}

	// Token: 0x060005BA RID: 1466 RVA: 0x00035100 File Offset: 0x00033300
	public static TweenRotation Begin(GameObject go, float duration, Quaternion rot)
	{
		TweenRotation tweenRotation = UITweener.Begin<TweenRotation>(go, duration, 0f);
		tweenRotation.from = tweenRotation.value.eulerAngles;
		tweenRotation.to = rot.eulerAngles;
		if (duration <= 0f)
		{
			tweenRotation.Sample(1f, true);
			tweenRotation.enabled = false;
		}
		return tweenRotation;
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x00035158 File Offset: 0x00033358
	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue()
	{
		this.from = this.value.eulerAngles;
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x0003517C File Offset: 0x0003337C
	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue()
	{
		this.to = this.value.eulerAngles;
	}

	// Token: 0x060005BD RID: 1469 RVA: 0x0003519D File Offset: 0x0003339D
	[ContextMenu("Assume value of 'From'")]
	private void SetCurrentValueToStart()
	{
		this.value = Quaternion.Euler(this.from);
	}

	// Token: 0x060005BE RID: 1470 RVA: 0x000351B0 File Offset: 0x000333B0
	[ContextMenu("Assume value of 'To'")]
	private void SetCurrentValueToEnd()
	{
		this.value = Quaternion.Euler(this.to);
	}

	// Token: 0x040005CF RID: 1487
	public Vector3 from;

	// Token: 0x040005D0 RID: 1488
	public Vector3 to;

	// Token: 0x040005D1 RID: 1489
	public bool quaternionLerp;

	// Token: 0x040005D2 RID: 1490
	private Transform mTrans;
}
