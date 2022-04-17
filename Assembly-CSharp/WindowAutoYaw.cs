using System;
using UnityEngine;

// Token: 0x0200003E RID: 62
[AddComponentMenu("NGUI/Examples/Window Auto-Yaw")]
public class WindowAutoYaw : MonoBehaviour
{
	// Token: 0x060000F7 RID: 247 RVA: 0x000130EE File Offset: 0x000112EE
	private void OnDisable()
	{
		this.mTrans.localRotation = Quaternion.identity;
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x00013100 File Offset: 0x00011300
	private void OnEnable()
	{
		if (this.uiCamera == null)
		{
			this.uiCamera = NGUITools.FindCameraForLayer(base.gameObject.layer);
		}
		this.mTrans = base.transform;
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x00013134 File Offset: 0x00011334
	private void Update()
	{
		if (this.uiCamera != null)
		{
			Vector3 vector = this.uiCamera.WorldToViewportPoint(this.mTrans.position);
			this.mTrans.localRotation = Quaternion.Euler(0f, (vector.x * 2f - 1f) * this.yawAmount, 0f);
		}
	}

	// Token: 0x040002C5 RID: 709
	public int updateOrder;

	// Token: 0x040002C6 RID: 710
	public Camera uiCamera;

	// Token: 0x040002C7 RID: 711
	public float yawAmount = 20f;

	// Token: 0x040002C8 RID: 712
	private Transform mTrans;
}
