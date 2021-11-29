using System;
using UnityEngine;

// Token: 0x02000034 RID: 52
[AddComponentMenu("NGUI/Examples/Look At Target")]
public class LookAtTarget : MonoBehaviour
{
	// Token: 0x060000DB RID: 219 RVA: 0x000126E4 File Offset: 0x000108E4
	private void Start()
	{
		this.mTrans = base.transform;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x000126F4 File Offset: 0x000108F4
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

	// Token: 0x0400029F RID: 671
	public int level;

	// Token: 0x040002A0 RID: 672
	public Transform target;

	// Token: 0x040002A1 RID: 673
	public float speed = 8f;

	// Token: 0x040002A2 RID: 674
	private Transform mTrans;
}
