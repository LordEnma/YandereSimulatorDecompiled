using System;
using UnityEngine;

// Token: 0x0200003A RID: 58
[AddComponentMenu("NGUI/Examples/Spin")]
public class Spin : MonoBehaviour
{
	// Token: 0x060000EA RID: 234 RVA: 0x00012BF5 File Offset: 0x00010DF5
	private void Start()
	{
		this.mTrans = base.transform;
		this.mRb = base.GetComponent<Rigidbody>();
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00012C0F File Offset: 0x00010E0F
	private void Update()
	{
		if (this.mRb == null)
		{
			this.ApplyDelta(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
		}
	}

	// Token: 0x060000EC RID: 236 RVA: 0x00012C39 File Offset: 0x00010E39
	private void FixedUpdate()
	{
		if (this.mRb != null)
		{
			this.ApplyDelta(Time.deltaTime);
		}
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00012C54 File Offset: 0x00010E54
	public void ApplyDelta(float delta)
	{
		delta *= 360f;
		Quaternion rhs = Quaternion.Euler(this.rotationsPerSecond * delta);
		if (this.mRb == null)
		{
			this.mTrans.rotation = this.mTrans.rotation * rhs;
			return;
		}
		this.mRb.MoveRotation(this.mRb.rotation * rhs);
	}

	// Token: 0x040002AF RID: 687
	public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);

	// Token: 0x040002B0 RID: 688
	public bool ignoreTimeScale;

	// Token: 0x040002B1 RID: 689
	private Rigidbody mRb;

	// Token: 0x040002B2 RID: 690
	private Transform mTrans;
}
