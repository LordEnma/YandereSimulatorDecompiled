using System;
using UnityEngine;

// Token: 0x0200003E RID: 62
[AddComponentMenu("NGUI/Examples/Window Auto-Yaw")]
public class WindowAutoYaw : MonoBehaviour
{
	// Token: 0x060000F7 RID: 247 RVA: 0x0001322E File Offset: 0x0001142E
	private void OnDisable()
	{
		this.mTrans.localRotation = Quaternion.identity;
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00013240 File Offset: 0x00011440
	private void OnEnable()
	{
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.mTrans = base.transform;
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x00013274 File Offset: 0x00011474
	private void Update()
	{
		if (this.uiCamera != null)
		{
			Vector3 vector = this.uiCamera.WorldToViewportPoint(this.mTrans.position);
			this.mTrans.localRotation = Quaternion.Euler(0f, (vector.x * 2f - 1f) * this.yawAmount, 0f);
		}
	}

	// Token: 0x040002C7 RID: 711
	public int updateOrder;

	// Token: 0x040002C8 RID: 712
	public Camera uiCamera;

	// Token: 0x040002C9 RID: 713
	public float yawAmount = 20f;

	// Token: 0x040002CA RID: 714
	private Transform mTrans;
}
