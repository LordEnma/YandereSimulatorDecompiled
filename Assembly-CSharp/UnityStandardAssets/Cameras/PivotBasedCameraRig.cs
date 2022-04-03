using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000550 RID: 1360
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x060022BB RID: 8891 RVA: 0x001F3713 File Offset: 0x001F1913
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004B31 RID: 19249
		protected Transform m_Cam;

		// Token: 0x04004B32 RID: 19250
		protected Transform m_Pivot;

		// Token: 0x04004B33 RID: 19251
		protected Vector3 m_LastTargetPosition;
	}
}
