using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
[AddComponentMenu("NGUI/Examples/Lag Rotation")]
public class LagRotation : MonoBehaviour
{
	// Token: 0x060000D4 RID: 212 RVA: 0x00012793 File Offset: 0x00010993
	public void OnRepositionEnd()
	{
		this.Interpolate(1000f);
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x000127A0 File Offset: 0x000109A0
	private void Interpolate(float delta)
	{
		if (this.mTrans != null)
		{
			Transform parent = this.mTrans.parent;
			if (parent != null)
			{
				this.mAbsolute = Quaternion.Slerp(this.mAbsolute, parent.rotation * this.mRelative, delta * this.speed);
				this.mTrans.rotation = this.mAbsolute;
			}
		}
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x0001280B File Offset: 0x00010A0B
	private void Start()
	{
		this.mTrans = base.transform;
		this.mRelative = this.mTrans.localRotation;
		this.mAbsolute = this.mTrans.rotation;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x0001283B File Offset: 0x00010A3B
	private void Update()
	{
		this.Interpolate(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
	}

	// Token: 0x040002A4 RID: 676
	public float speed = 10f;

	// Token: 0x040002A5 RID: 677
	public bool ignoreTimeScale;

	// Token: 0x040002A6 RID: 678
	private Transform mTrans;

	// Token: 0x040002A7 RID: 679
	private Quaternion mRelative;

	// Token: 0x040002A8 RID: 680
	private Quaternion mAbsolute;
}
