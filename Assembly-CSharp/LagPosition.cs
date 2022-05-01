using System;
using UnityEngine;

// Token: 0x02000031 RID: 49
public class LagPosition : MonoBehaviour
{
	// Token: 0x060000CC RID: 204 RVA: 0x0001274A File Offset: 0x0001094A
	public void OnRepositionEnd()
	{
		this.Interpolate(1000f);
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00012758 File Offset: 0x00010958
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

	// Token: 0x060000CE RID: 206 RVA: 0x00012844 File Offset: 0x00010A44
	private void Awake()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00012852 File Offset: 0x00010A52
	private void OnEnable()
	{
		if (this.mStarted)
		{
			this.ResetPosition();
		}
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00012862 File Offset: 0x00010A62
	private void Start()
	{
		this.mStarted = true;
		this.ResetPosition();
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00012871 File Offset: 0x00010A71
	public void ResetPosition()
	{
		this.mAbsolute = this.mTrans.position;
		this.mRelative = this.mTrans.localPosition;
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00012895 File Offset: 0x00010A95
	private void Update()
	{
		this.Interpolate(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
	}

	// Token: 0x040002A0 RID: 672
	public Vector3 speed = new Vector3(10f, 10f, 10f);

	// Token: 0x040002A1 RID: 673
	public bool ignoreTimeScale;

	// Token: 0x040002A2 RID: 674
	private Transform mTrans;

	// Token: 0x040002A3 RID: 675
	private Vector3 mRelative;

	// Token: 0x040002A4 RID: 676
	private Vector3 mAbsolute;

	// Token: 0x040002A5 RID: 677
	private bool mStarted;
}
