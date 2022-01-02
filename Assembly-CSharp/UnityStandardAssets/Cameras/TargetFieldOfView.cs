using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000543 RID: 1347
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x0600226E RID: 8814 RVA: 0x001EC441 File Offset: 0x001EA641
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x0600226F RID: 8815 RVA: 0x001EC46C File Offset: 0x001EA66C
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x06002270 RID: 8816 RVA: 0x001EC4DF File Offset: 0x001EA6DF
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x06002271 RID: 8817 RVA: 0x001EC4FC File Offset: 0x001EA6FC
		public static float MaxBoundsExtent(Transform obj, bool includeEffects)
		{
			Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
			Bounds bounds = default(Bounds);
			bool flag = false;
			foreach (Renderer renderer in componentsInChildren)
			{
				if (!(renderer is TrailRenderer) && !(renderer is ParticleSystemRenderer))
				{
					if (!flag)
					{
						flag = true;
						bounds = renderer.bounds;
					}
					else
					{
						bounds.Encapsulate(renderer.bounds);
					}
				}
			}
			return Mathf.Max(new float[]
			{
				bounds.extents.x,
				bounds.extents.y,
				bounds.extents.z
			});
		}

		// Token: 0x04004A4D RID: 19021
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004A4E RID: 19022
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004A4F RID: 19023
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004A50 RID: 19024
		private float m_BoundSize;

		// Token: 0x04004A51 RID: 19025
		private float m_FovAdjustVelocity;

		// Token: 0x04004A52 RID: 19026
		private Camera m_Cam;

		// Token: 0x04004A53 RID: 19027
		private Transform m_LastTarget;
	}
}
