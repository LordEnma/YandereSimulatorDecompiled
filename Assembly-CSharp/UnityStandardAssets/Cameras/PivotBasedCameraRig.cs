using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000544 RID: 1348
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x06002274 RID: 8820 RVA: 0x001ED713 File Offset: 0x001EB913
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004A56 RID: 19030
		protected Transform m_Cam;

		// Token: 0x04004A57 RID: 19031
		protected Transform m_Pivot;

		// Token: 0x04004A58 RID: 19032
		protected Vector3 m_LastTargetPosition;
	}
}
