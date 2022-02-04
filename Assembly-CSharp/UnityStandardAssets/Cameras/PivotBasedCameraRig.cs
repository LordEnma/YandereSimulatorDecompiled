using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000544 RID: 1348
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x0600227A RID: 8826 RVA: 0x001EE2CB File Offset: 0x001EC4CB
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004A67 RID: 19047
		protected Transform m_Cam;

		// Token: 0x04004A68 RID: 19048
		protected Transform m_Pivot;

		// Token: 0x04004A69 RID: 19049
		protected Vector3 m_LastTargetPosition;
	}
}
