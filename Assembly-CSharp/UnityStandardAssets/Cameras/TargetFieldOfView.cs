using UnityEngine;

namespace UnityStandardAssets.Cameras
{
	public class TargetFieldOfView : AbstractTargetFollower
	{
		[SerializeField]
		private float m_FovAdjustTime = 1f;

		[SerializeField]
		private float m_ZoomAmountMultiplier = 2f;

		[SerializeField]
		private bool m_IncludeEffectsInSize;

		private float m_BoundSize;

		private float m_FovAdjustVelocity;

		private Camera m_Cam;

		private Transform m_LastTarget;

		protected override void Start()
		{
			base.Start();
			m_BoundSize = MaxBoundsExtent(m_Target, m_IncludeEffectsInSize);
			m_Cam = GetComponentInChildren<Camera>();
		}

		protected override void FollowTarget(float deltaTime)
		{
			float magnitude = (m_Target.position - base.transform.position).magnitude;
			float target = Mathf.Atan2(m_BoundSize, magnitude) * 57.29578f * m_ZoomAmountMultiplier;
			m_Cam.fieldOfView = Mathf.SmoothDamp(m_Cam.fieldOfView, target, ref m_FovAdjustVelocity, m_FovAdjustTime);
		}

		public override void SetTarget(Transform newTransform)
		{
			base.SetTarget(newTransform);
			m_BoundSize = MaxBoundsExtent(newTransform, m_IncludeEffectsInSize);
		}

		public static float MaxBoundsExtent(Transform obj, bool includeEffects)
		{
			Renderer[] componentsInChildren = obj.GetComponentsInChildren<Renderer>();
			Bounds bounds = default(Bounds);
			bool flag = false;
			Renderer[] array = componentsInChildren;
			foreach (Renderer renderer in array)
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
			return Mathf.Max(bounds.extents.x, bounds.extents.y, bounds.extents.z);
		}
	}
}
