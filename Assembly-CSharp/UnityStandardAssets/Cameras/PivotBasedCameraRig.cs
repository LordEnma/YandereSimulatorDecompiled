using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000544 RID: 1348
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x06002278 RID: 8824 RVA: 0x001EDFB3 File Offset: 0x001EC1B3
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004A61 RID: 19041
		protected Transform m_Cam;

		// Token: 0x04004A62 RID: 19042
		protected Transform m_Pivot;

		// Token: 0x04004A63 RID: 19043
		protected Vector3 m_LastTargetPosition;
	}
}
