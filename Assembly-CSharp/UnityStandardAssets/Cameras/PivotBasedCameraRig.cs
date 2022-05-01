using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000552 RID: 1362
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x060022D3 RID: 8915 RVA: 0x001F5B2B File Offset: 0x001F3D2B
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
