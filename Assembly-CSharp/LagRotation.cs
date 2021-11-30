using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
[AddComponentMenu("NGUI/Examples/Lag Rotation")]
public class LagRotation : MonoBehaviour
{
	// Token: 0x060000D4 RID: 212 RVA: 0x000125EB File Offset: 0x000107EB
	public void OnRepositionEnd()
	{
		this.Interpolate(1000f);
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x000125F8 File Offset: 0x000107F8
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

	// Token: 0x060000D6 RID: 214 RVA: 0x00012663 File Offset: 0x00010863
	private void Start()
	{
		this.mTrans = base.transform;
		this.mRelative = this.mTrans.localRotation;
		this.mAbsolute = this.mTrans.rotation;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00012693 File Offset: 0x00010893
	private void Update()
	{
		this.Interpolate(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
	}

	// Token: 0x04000299 RID: 665
	public float speed = 10f;

	// Token: 0x0400029A RID: 666
	public bool ignoreTimeScale;

	// Token: 0x0400029B RID: 667
	private Transform mTrans;

	// Token: 0x0400029C RID: 668
	private Quaternion mRelative;

	// Token: 0x0400029D RID: 669
	private Quaternion mAbsolute;
}
