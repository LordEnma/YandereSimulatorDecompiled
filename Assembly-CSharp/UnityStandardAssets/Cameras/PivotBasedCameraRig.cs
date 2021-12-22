using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000541 RID: 1345
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x06002264 RID: 8804 RVA: 0x001EBAB3 File Offset: 0x001E9CB3
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004A32 RID: 18994
		protected Transform m_Cam;

		// Token: 0x04004A33 RID: 18995
		protected Transform m_Pivot;

		// Token: 0x04004A34 RID: 18996
		protected Vector3 m_LastTargetPosition;
	}
}
