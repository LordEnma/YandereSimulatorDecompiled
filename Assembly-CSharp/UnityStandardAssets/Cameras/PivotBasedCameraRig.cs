using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000545 RID: 1349
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x06002284 RID: 8836 RVA: 0x001EE983 File Offset: 0x001ECB83
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004A73 RID: 19059
		protected Transform m_Cam;

		// Token: 0x04004A74 RID: 19060
		protected Transform m_Pivot;

		// Token: 0x04004A75 RID: 19061
		protected Vector3 m_LastTargetPosition;
	}
}
