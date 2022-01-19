using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour
{
	// Token: 0x060000FB RID: 251 RVA: 0x00012FFC File Offset: 0x000111FC
	private void OnEnable()
	{
		this.mTrans = base.transform;
		this.mLastPos = this.mTrans.position;
	}

	// Token: 0x060000FC RID: 252 RVA: 0x0001301C File Offset: 0x0001121C
	private void Update()
	{
		Vector3 vector = this.mTrans.position - this.mLastPos;
		this.mLastPos = this.mTrans.position;
		this.mAngle += vector.x * this.degrees;
		this.mAngle = NGUIMath.SpringLerp(this.mAngle, 0f, 20f, Time.deltaTime);
		this.mTrans.localRotation = Quaternion.Euler(0f, 0f, -this.mAngle);
	}

	// Token: 0x040002BF RID: 703
	public int updateOrder;

	// Token: 0x040002C0 RID: 704
	public float degrees = 30f;

	// Token: 0x040002C1 RID: 705
	private Vector3 mLastPos;

	// Token: 0x040002C2 RID: 706
	private Transform mTrans;

	// Token: 0x040002C3 RID: 707
	private float mAngle;
}
