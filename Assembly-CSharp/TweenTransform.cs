using System;
using UnityEngine;

// Token: 0x02000093 RID: 147
[AddComponentMenu("NGUI/Tween/Tween Transform")]
public class TweenTransform : UITweener
{
	// Token: 0x060005CC RID: 1484 RVA: 0x00035344 File Offset: 0x00033544
	protected override void OnUpdate(float factor, bool isFinished)
	{
		if (this.to != null)
		{
			if (this.mTrans == null)
			{
				this.mTrans = base.transform;
				this.mPos = this.mTrans.position;
				this.mRot = this.mTrans.rotation;
				this.mScale = this.mTrans.localScale;
			}
			if (this.from != null)
			{
				this.mTrans.position = this.from.position * (1f - factor) + this.to.position * factor;
				this.mTrans.localScale = this.from.localScale * (1f - factor) + this.to.localScale * factor;
				this.mTrans.rotation = Quaternion.Slerp(this.from.rotation, this.to.rotation, factor);
			}
			else
			{
				this.mTrans.position = this.mPos * (1f - factor) + this.to.position * factor;
				this.mTrans.localScale = this.mScale * (1f - factor) + this.to.localScale * factor;
				this.mTrans.rotation = Quaternion.Slerp(this.mRot, this.to.rotation, factor);
			}
			if (this.parentWhenFinished && isFinished)
			{
				this.mTrans.parent = this.to;
			}
		}
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x000354FF File Offset: 0x000336FF
	public static TweenTransform Begin(GameObject go, float duration, Transform to)
	{
		return TweenTransform.Begin(go, duration, null, to);
	}

	// Token: 0x060005CE RID: 1486 RVA: 0x0003550C File Offset: 0x0003370C
	public static TweenTransform Begin(GameObject go, float duration, Transform from, Transform to)
	{
		TweenTransform tweenTransform = UITweener.Begin<TweenTransform>(go, duration, 0f);
		tweenTransform.from = from;
		tweenTransform.to = to;
		if (duration <= 0f)
		{
			tweenTransform.Sample(1f, true);
			tweenTransform.enabled = false;
		}
		return tweenTransform;
	}

	// Token: 0x040005D7 RID: 1495
	public Transform from;

	// Token: 0x040005D8 RID: 1496
	public Transform to;

	// Token: 0x040005D9 RID: 1497
	public bool parentWhenFinished;

	// Token: 0x040005DA RID: 1498
	private Transform mTrans;

	// Token: 0x040005DB RID: 1499
	private Vector3 mPos;

	// Token: 0x040005DC RID: 1500
	private Quaternion mRot;

	// Token: 0x040005DD RID: 1501
	private Vector3 mScale;
}
