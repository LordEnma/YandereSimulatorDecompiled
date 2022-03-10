using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000547 RID: 1351
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x06002293 RID: 8851 RVA: 0x001EFF3B File Offset: 0x001EE13B
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004AA0 RID: 19104
		protected Transform m_Cam;

		// Token: 0x04004AA1 RID: 19105
		protected Transform m_Pivot;

		// Token: 0x04004AA2 RID: 19106
		protected Vector3 m_LastTargetPosition;
	}
}
