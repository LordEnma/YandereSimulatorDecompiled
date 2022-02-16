using System;
using UnityEngine;

// Token: 0x02000032 RID: 50
[AddComponentMenu("NGUI/Examples/Lag Rotation")]
public class LagRotation : MonoBehaviour
{
	// Token: 0x060000D4 RID: 212 RVA: 0x000125E3 File Offset: 0x000107E3
	public void OnRepositionEnd()
	{
		this.Interpolate(1000f);
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x000125F0 File Offset: 0x000107F0
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

	// Token: 0x060000D6 RID: 214 RVA: 0x0001265B File Offset: 0x0001085B
	private void Start()
	{
		this.mTrans = base.transform;
		this.mRelative = this.mTrans.localRotation;
		this.mAbsolute = this.mTrans.rotation;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x0001268B File Offset: 0x0001088B
	private void Update()
	{
		this.Interpolate(this.ignoreTimeScale ? RealTime.deltaTime : Time.deltaTime);
	}

	// Token: 0x0400029B RID: 667
	public float speed = 10f;

	// Token: 0x0400029C RID: 668
	public bool ignoreTimeScale;

	// Token: 0x0400029D RID: 669
	private Transform mTrans;

	// Token: 0x0400029E RID: 670
	private Quaternion mRelative;

	// Token: 0x0400029F RID: 671
	private Quaternion mAbsolute;
}
