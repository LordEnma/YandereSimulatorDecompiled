using System;
using UnityEngine;

// Token: 0x0200003B RID: 59
[AddComponentMenu("NGUI/Examples/Spin With Mouse")]
public class SpinWithMouse : MonoBehaviour
{
	// Token: 0x060000EF RID: 239 RVA: 0x00012CE5 File Offset: 0x00010EE5
	private void Start()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x00012CF4 File Offset: 0x00010EF4
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

	// Token: 0x040002B3 RID: 691
	public Transform target;

	// Token: 0x040002B4 RID: 692
	public float speed = 1f;

	// Token: 0x040002B5 RID: 693
	private Transform mTrans;
}
