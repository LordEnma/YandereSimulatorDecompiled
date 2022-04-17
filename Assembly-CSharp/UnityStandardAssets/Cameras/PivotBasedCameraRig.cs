using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000551 RID: 1361
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x060022CA RID: 8906 RVA: 0x001F469F File Offset: 0x001F289F
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004B47 RID: 19271
		protected Transform m_Cam;

		// Token: 0x04004B48 RID: 19272
		protected Transform m_Pivot;

		// Token: 0x04004B49 RID: 19273
		protected Vector3 m_LastTargetPosition;
	}
}
