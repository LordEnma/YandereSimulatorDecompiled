using System;
using UnityEngine;

// Token: 0x02000034 RID: 52
[AddComponentMenu("NGUI/Examples/Look At Target")]
public class LookAtTarget : MonoBehaviour
{
	// Token: 0x060000DB RID: 219 RVA: 0x000126DC File Offset: 0x000108DC
	private void Start()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x000126EC File Offset: 0x000108EC
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

	// Token: 0x040002A1 RID: 673
	public int level;

	// Token: 0x040002A2 RID: 674
	public Transform target;

	// Token: 0x040002A3 RID: 675
	public float speed = 8f;

	// Token: 0x040002A4 RID: 676
	private Transform mTrans;
}
