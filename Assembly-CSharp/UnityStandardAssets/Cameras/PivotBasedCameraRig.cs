using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x0200053F RID: 1343
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x06002253 RID: 8787 RVA: 0x001EA37F File Offset: 0x001E857F
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x040049F3 RID: 18931
		protected Transform m_Cam;

		// Token: 0x040049F4 RID: 18932
		protected Transform m_Pivot;

		// Token: 0x040049F5 RID: 18933
		protected Vector3 m_LastTargetPosition;
	}
}
