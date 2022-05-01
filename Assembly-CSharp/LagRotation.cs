using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
[AddComponentMenu("NGUI/Examples/Lag Rotation")]
public class LagRotation : MonoBehaviour
{
	// Token: 0x060000D4 RID: 212 RVA: 0x000128D3 File Offset: 0x00010AD3
	public void OnRepositionEnd()
	{
		this.Interpolate(1000f);
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x000128E0 File Offset: 0x00010AE0
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

	// Token: 0x060000D6 RID: 214 RVA: 0x0001294B File Offset: 0x00010B4B
	private void Start()
	{
		this.mTrans = base.transform;
		this.mRelative = this.mTrans.localRotation;
		this.mAbsolute = this.mTrans.rotation;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x0001297B File Offset: 0x00010B7B
	private void Update()
	{
		this.Interpolate(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
	}

	// Token: 0x040002A6 RID: 678
	public float speed = 10f;

	// Token: 0x040002A7 RID: 679
	public bool ignoreTimeScale;

	// Token: 0x040002A8 RID: 680
	private Transform mTrans;

	// Token: 0x040002A9 RID: 681
	private Quaternion mRelative;

	// Token: 0x040002AA RID: 682
	private Quaternion mAbsolute;
}
