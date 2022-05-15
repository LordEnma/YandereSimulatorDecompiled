using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000553 RID: 1363
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x060022DE RID: 8926 RVA: 0x001F7277 File Offset: 0x001F5477
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004B84 RID: 19332
		protected Transform m_Cam;

		// Token: 0x04004B85 RID: 19333
		protected Transform m_Pivot;

		// Token: 0x04004B86 RID: 19334
		protected Vector3 m_LastTargetPosition;
	}
}
