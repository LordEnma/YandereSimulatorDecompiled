using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000543 RID: 1347
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x06002272 RID: 8818 RVA: 0x001ECA43 File Offset: 0x001EAC43
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004A4F RID: 19023
		protected Transform m_Cam;

		// Token: 0x04004A50 RID: 19024
		protected Transform m_Pivot;

		// Token: 0x04004A51 RID: 19025
		protected Vector3 m_LastTargetPosition;
	}
}
