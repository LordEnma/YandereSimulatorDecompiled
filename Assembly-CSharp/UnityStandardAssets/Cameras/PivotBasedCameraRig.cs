using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000544 RID: 1348
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x0600227D RID: 8829 RVA: 0x001EE4CF File Offset: 0x001EC6CF
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004A6A RID: 19050
		protected Transform m_Cam;

		// Token: 0x04004A6B RID: 19051
		protected Transform m_Pivot;

		// Token: 0x04004A6C RID: 19052
		protected Vector3 m_LastTargetPosition;
	}
}
