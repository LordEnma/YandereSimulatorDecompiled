using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000551 RID: 1361
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x060022C3 RID: 8899 RVA: 0x001F3C43 File Offset: 0x001F1E43
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004B35 RID: 19253
		protected Transform m_Cam;

		// Token: 0x04004B36 RID: 19254
		protected Transform m_Pivot;

		// Token: 0x04004B37 RID: 19255
		protected Vector3 m_LastTargetPosition;
	}
}
