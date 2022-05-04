using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000552 RID: 1362
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x060022D4 RID: 8916 RVA: 0x001F5C27 File Offset: 0x001F3E27
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004B5D RID: 19293
		protected Transform m_Cam;

		// Token: 0x04004B5E RID: 19294
		protected Transform m_Pivot;

		// Token: 0x04004B5F RID: 19295
		protected Vector3 m_LastTargetPosition;
	}
}
