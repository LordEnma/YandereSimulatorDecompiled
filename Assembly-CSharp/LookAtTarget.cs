using System;
using UnityEngine;

// Token: 0x02000034 RID: 52
[AddComponentMenu("NGUI/Examples/Look At Target")]
public class LookAtTarget : MonoBehaviour
{
	// Token: 0x060000DB RID: 219 RVA: 0x000129CC File Offset: 0x00010BCC
	private void Start()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x000129DC File Offset: 0x00010BDC
	private void LateUpdate()
	{
		if (this.target != null)
		{
			Vector3 forward = this.target.position - this.mTrans.position;
			if (forward.magnitude > 0.001f)
			{
				Quaternion b = Quaternion.LookRotation(forward);
				this.mTrans.rotation = Quaternion.Slerp(this.mTrans.rotation, b, Mathf.Clamp01(this.speed * Time.deltaTime));
			}
		}
	}

	// Token: 0x040002AC RID: 684
	public int level;

	// Token: 0x040002AD RID: 685
	public Transform target;

	// Token: 0x040002AE RID: 686
	public float speed = 8f;

	// Token: 0x040002AF RID: 687
	private Transform mTrans;
}
