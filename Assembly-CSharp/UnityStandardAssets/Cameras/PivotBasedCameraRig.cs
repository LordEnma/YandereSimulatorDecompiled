using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000553 RID: 1363
	public abstract class PivotBasedCameraRig : AbstractTargetFollower
	{
		// Token: 0x060022DF RID: 8927 RVA: 0x001F77DF File Offset: 0x001F59DF
		protected virtual void Awake()
		{
			this.m_Cam = base.GetComponentInChildren<Camera>().transform;
			this.m_Pivot = this.m_Cam.parent;
		}

		// Token: 0x04004B8D RID: 19341
		protected Transform m_Cam;

		// Token: 0x04004B8E RID: 19342
		protected Transform m_Pivot;

		// Token: 0x04004B8F RID: 19343
		protected Vector3 m_LastTargetPosition;
	}
}
