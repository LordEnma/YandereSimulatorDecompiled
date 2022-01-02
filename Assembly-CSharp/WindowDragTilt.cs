using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour
{
	// Token: 0x060000FB RID: 251 RVA: 0x00013004 File Offset: 0x00011204
	private void OnEnable()
	{
		this.mTrans = base.transform;
		this.mLastPos = this.mTrans.position;
	}

	// Token: 0x060000FC RID: 252 RVA: 0x00013024 File Offset: 0x00011224
	private void Update()
	{
		Vector3 vector = this.mTrans.position - this.mLastPos;
		this.mLastPos = this.mTrans.position;
		this.mAngle += vector.x * this.degrees;
		this.mAngle = NGUIMath.SpringLerp(this.mAngle, 0f, 20f, Time.deltaTime);
		this.mTrans.localRotation = Quaternion.Euler(0f, 0f, -this.mAngle);
	}

	// Token: 0x040002BE RID: 702
	public int updateOrder;

	// Token: 0x040002BF RID: 703
	public float degrees = 30f;

	// Token: 0x040002C0 RID: 704
	private Vector3 mLastPos;

	// Token: 0x040002C1 RID: 705
	private Transform mTrans;

	// Token: 0x040002C2 RID: 706
	private float mAngle;
}
