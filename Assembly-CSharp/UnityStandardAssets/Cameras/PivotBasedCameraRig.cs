using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000546 RID: 1350
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x0600228D RID: 8845 RVA: 0x001EF563 File Offset: 0x001ED763
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004A83 RID: 19075
		protected Transform m_Cam;

		// Token: 0x04004A84 RID: 19076
		protected Transform m_Pivot;

		// Token: 0x04004A85 RID: 19077
		protected Vector3 m_LastTargetPosition;
	}
}
