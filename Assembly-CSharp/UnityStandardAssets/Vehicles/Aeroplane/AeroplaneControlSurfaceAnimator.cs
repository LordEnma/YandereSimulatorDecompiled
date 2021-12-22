using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052A RID: 1322
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x0600219B RID: 8603 RVA: 0x001E92D8 File Offset: 0x001E74D8
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x0600219C RID: 8604 RVA: 0x001E931C File Offset: 0x001E751C
		private void Update()
		{
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				switch (controlSurface.type)
				{
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.Aileron:
				{
					Quaternion rotation = Quaternion.Euler(controlSurface.amount * this.m_Plane.RollInput, 0f, 0f);
					this.RotateSurface(controlSurface, rotation);
					break;
				}
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.Elevator:
				{
					Quaternion rotation2 = Quaternion.Euler(controlSurface.amount * -this.m_Plane.PitchInput, 0f, 0f);
					this.RotateSurface(controlSurface, rotation2);
					break;
				}
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.Rudder:
				{
					Quaternion rotation3 = Quaternion.Euler(0f, controlSurface.amount * this.m_Plane.YawInput, 0f);
					this.RotateSurface(controlSurface, rotation3);
					break;
				}
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.RuddervatorNegative:
				{
					float num = this.m_Plane.YawInput - this.m_Plane.PitchInput;
					Quaternion rotation4 = Quaternion.Euler(0f, 0f, controlSurface.amount * num);
					this.RotateSurface(controlSurface, rotation4);
					break;
				}
				case AeroplaneControlSurfaceAnimator.ControlSurface.Type.RuddervatorPositive:
				{
					float num2 = this.m_Plane.YawInput + this.m_Plane.PitchInput;
					Quaternion rotation5 = Quaternion.Euler(0f, 0f, controlSurface.amount * num2);
					this.RotateSurface(controlSurface, rotation5);
					break;
				}
				}
			}
		}

		// Token: 0x0600219D RID: 8605 RVA: 0x001E947C File Offset: 0x001E767C
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x0400499A RID: 18842
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x0400499B RID: 18843
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x0400499C RID: 18844
		private AeroplaneController m_Plane;

		// Token: 0x02000683 RID: 1667
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04004FC0 RID: 20416
			public Transform transform;

			// Token: 0x04004FC1 RID: 20417
			public float amount;

			// Token: 0x04004FC2 RID: 20418
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04004FC3 RID: 20419
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006EC RID: 1772
			public enum Type
			{
				// Token: 0x040051D0 RID: 20944
				Aileron,
				// Token: 0x040051D1 RID: 20945
				Elevator,
				// Token: 0x040051D2 RID: 20946
				Rudder,
				// Token: 0x040051D3 RID: 20947
				RuddervatorNegative,
				// Token: 0x040051D4 RID: 20948
				RuddervatorPositive
			}
		}
	}
}
