﻿using System;
using UnityEngine;

// Token: 0x0200003A RID: 58
[AddComponentMenu("NGUI/Examples/Spin")]
public class Spin : MonoBehaviour
{
	// Token: 0x060000EA RID: 234 RVA: 0x00012EDD File Offset: 0x000110DD
	private void Start()
	{
		this.mTrans = base.transform;
		this.mRb = base.GetComponent<Rigidbody>();
	}

	// Token: 0x060000EB RID: 235 RVA: 0x00012EF7 File Offset: 0x000110F7
	private void Update()
	{
		if (this.mRb == null)
		{
			this.ApplyDelta(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
		}
	}

	// Token: 0x060000EC RID: 236 RVA: 0x00012F21 File Offset: 0x00011121
	private void FixedUpdate()
	{
		if (this.mRb != null)
		{
			this.ApplyDelta(Time.deltaTime);
		}
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00012F3C File Offset: 0x0001113C
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

	// Token: 0x040002BC RID: 700
	public Vector3 rotationsPerSecond = new Vector3(0f, 0.1f, 0f);

	// Token: 0x040002BD RID: 701
	public bool ignoreTimeScale;

	// Token: 0x040002BE RID: 702
	private Rigidbody mRb;

	// Token: 0x040002BF RID: 703
	private Transform mTrans;
}
