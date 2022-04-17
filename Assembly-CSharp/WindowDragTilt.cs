using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour
{
	// Token: 0x060000FB RID: 251 RVA: 0x000131AC File Offset: 0x000113AC
	private void OnEnable()
	{
		this.mTrans = base.transform;
		this.mLastPos = this.mTrans.position;
	}

	// Token: 0x060000FC RID: 252 RVA: 0x000131CC File Offset: 0x000113CC
	private void Update()
	{
		Vector3 vector = this.mTrans.position - this.mLastPos;
		this.mLastPos = this.mTrans.position;
		this.mAngle += vector.x * this.degrees;
		this.mAngle = NGUIMath.SpringLerp(this.mAngle, 0f, 20f, Time.deltaTime);
		this.mTrans.localRotation = Quaternion.Euler(0f, 0f, -this.mAngle);
	}

	// Token: 0x040002C9 RID: 713
	public int updateOrder;

	// Token: 0x040002CA RID: 714
	public float degrees = 30f;

	// Token: 0x040002CB RID: 715
	private Vector3 mLastPos;

	// Token: 0x040002CC RID: 716
	private Transform mTrans;

	// Token: 0x040002CD RID: 717
	private float mAngle;
}
