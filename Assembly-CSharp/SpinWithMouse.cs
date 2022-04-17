using System;
using UnityEngine;

// Token: 0x0200003B RID: 59
[AddComponentMenu("NGUI/Examples/Spin With Mouse")]
public class SpinWithMouse : MonoBehaviour
{
	// Token: 0x060000EF RID: 239 RVA: 0x00012E8D File Offset: 0x0001108D
	private void Start()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x00012E9C File Offset: 0x0001109C
	private void OnDrag(Vector2 delta)
	{
		UICamera.currentTouch.clickNotification = UICamera.ClickNotification.None;
		if (this.target != null)
		{
			this.target.localRotation = Quaternion.Euler(0f, -0.5f * delta.x * this.speed, 0f) * this.target.localRotation;
			return;
		}
		this.mTrans.localRotation = Quaternion.Euler(0f, -0.5f * delta.x * this.speed, 0f) * this.mTrans.localRotation;
	}

	// Token: 0x040002BE RID: 702
	public Transform target;

	// Token: 0x040002BF RID: 703
	public float speed = 1f;

	// Token: 0x040002C0 RID: 704
	private Transform mTrans;
}
