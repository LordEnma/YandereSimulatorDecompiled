using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200054B RID: 1355
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x060022AB RID: 8875 RVA: 0x001F1EA3 File Offset: 0x001F00A3
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004AFF RID: 19199
		protected Transform m_Cam;

		// Token: 0x04004B00 RID: 19200
		protected Transform m_Pivot;

		// Token: 0x04004B01 RID: 19201
		protected Vector3 m_LastTargetPosition;
	}
}
