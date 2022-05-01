using System;
using UnityEngine;

// Token: 0x0200003F RID: 63
[AddComponentMenu("NGUI/Examples/Window Drag Tilt")]
public class WindowDragTilt : MonoBehaviour
{
	// Token: 0x060000FB RID: 251 RVA: 0x000132EC File Offset: 0x000114EC
	private void OnEnable()
	{
		this.mTrans = base.transform;
		this.mLastPos = this.mTrans.position;
	}

	// Token: 0x060000FC RID: 252 RVA: 0x0001330C File Offset: 0x0001150C
	private void Update()
	{
		Vector3 vector = this.mTrans.position - this.mLastPos;
		this.mLastPos = this.mTrans.position;
		this.mAngle += vector.x * this.degrees;
		this.mAngle = NGUIMath.SpringLerp(this.mAngle, 0f, 20f, Time.deltaTime);
		this.mTrans.localRotation = Quaternion.Euler(0f, 0f, -this.mAngle);
	}

	// Token: 0x040002CB RID: 715
	public int updateOrder;

	// Token: 0x040002CC RID: 716
	public float degrees = 30f;

	// Token: 0x040002CD RID: 717
	private Vector3 mLastPos;

	// Token: 0x040002CE RID: 718
	private Transform mTrans;

	// Token: 0x040002CF RID: 719
	private float mAngle;
}
