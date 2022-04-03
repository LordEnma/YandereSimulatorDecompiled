using System;
using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	// Token: 0x02000552 RID: 1362
	public class TargetFieldOfView : AbstractTargetFollower
	{
		// Token: 0x060022C2 RID: 8898 RVA: 0x001F3AB1 File Offset: 0x001F1CB1
		protected override void Start()
		{
			base.Start();
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(this.m_Target, this.m_IncludeEffectsInSize);
			this.m_Cam = base.GetComponentInChildren<Camera>();
		}

		// Token: 0x060022C3 RID: 8899 RVA: 0x001F3ADC File Offset: 0x001F1CDC
		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (this.m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(this.m_BoundSize, magnitude) * 57.29578f * this.m_ZoomAmountMultiplier;
			this.m_Cam.fieldOfView = Mathf.SmoothDamp(this.m_Cam.fieldOfView, target, ref this.m_FovAdjustVelocity, this.m_FovAdjustTime);
		}

		// Token: 0x060022C4 RID: 8900 RVA: 0x001F3B4F File Offset: 0x001F1D4F
		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			this.m_BoundSize = TargetFieldOfView.MaxBoundsExtent(newTransform, this.m_IncludeEffectsInSize);
		}

		// Token: 0x060022C5 RID: 8901 RVA: 0x001F3B6C File Offset: 0x001F1D6C
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

		// Token: 0x04004B43 RID: 19267
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		// Token: 0x04004B44 RID: 19268
		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		// Token: 0x04004B45 RID: 19269
		[SerializeField]
		private bool m_IncludeEffectsInSize;

		// Token: 0x04004B46 RID: 19270
		private float m_BoundSize;

		// Token: 0x04004B47 RID: 19271
		private float m_FovAdjustVelocity;

		// Token: 0x04004B48 RID: 19272
		private Camera m_Cam;

		// Token: 0x04004B49 RID: 19273
		private Transform m_LastTarget;
	}
}
