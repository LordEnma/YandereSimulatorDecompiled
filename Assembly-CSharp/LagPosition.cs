using System;
using UnityEngine;

// Token: 0x02000031 RID: 49
public class LagPosition : MonoBehaviour
{
	// Token: 0x060000CC RID: 204 RVA: 0x0001260A File Offset: 0x0001080A
	public void OnRepositionEnd()
	{
		this.Interpolate(1000f);
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00012618 File Offset: 0x00010818
	private void Interpolate(float delta)
	{
		Transform parent = this.mTrans.parent;
		if (parent != null)
		{
			Vector3 vector = parent.position + parent.rotation * this.mRelative;
			this.mAbsolute.x = Mathf.Lerp(this.mAbsolute.x, vector.x, Mathf.Clamp01(delta * this.speed.x));
			this.mAbsolute.y = Mathf.Lerp(this.mAbsolute.y, vector.y, Mathf.Clamp01(delta * this.speed.y));
			this.mAbsolute.z = Mathf.Lerp(this.mAbsolute.z, vector.z, Mathf.Clamp01(delta * this.speed.z));
			this.mTrans.position = this.mAbsolute;
		}
	}

	// Token: 0x060000CE RID: 206 RVA: 0x00012704 File Offset: 0x00010904
	private void Awake()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00012712 File Offset: 0x00010912
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.ResetPosition();
		}
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00012722 File Offset: 0x00010922
	private void Start()
	{
		this.mStarted = true;
		this.ResetPosition();
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00012731 File Offset: 0x00010931
	public void ResetPosition()
	{
		this.mAbsolute = this.mTrans.position;
		this.mRelative = this.mTrans.localPosition;
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00012755 File Offset: 0x00010955
	private void Update()
	{
		this.Interpolate(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
	}

	// Token: 0x0400029E RID: 670
	public Vector3 speed = new Vector3(10f, 10f, 10f);

	// Token: 0x0400029F RID: 671
	public bool ignoreTimeScale;

	// Token: 0x040002A0 RID: 672
	private Transform mTrans;

	// Token: 0x040002A1 RID: 673
	private Vector3 mRelative;

	// Token: 0x040002A2 RID: 674
	private Vector3 mAbsolute;

	// Token: 0x040002A3 RID: 675
	private bool mStarted;
}
