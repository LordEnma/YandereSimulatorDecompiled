using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000541 RID: 1345
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x06002267 RID: 8807 RVA: 0x001EC0A3 File Offset: 0x001EA2A3
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004A3B RID: 19003
		protected Transform m_Cam;

		// Token: 0x04004A3C RID: 19004
		protected Transform m_Pivot;

		// Token: 0x04004A3D RID: 19005
		protected Vector3 m_LastTargetPosition;
	}
}
