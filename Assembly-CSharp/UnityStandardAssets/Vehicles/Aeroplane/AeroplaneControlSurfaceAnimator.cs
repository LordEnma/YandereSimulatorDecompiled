using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052F RID: 1327
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021C4 RID: 8644 RVA: 0x001ECD88 File Offset: 0x001EAF88
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021C5 RID: 8645 RVA: 0x001ECDCC File Offset: 0x001EAFCC
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

		// Token: 0x060021C6 RID: 8646 RVA: 0x001ECF2C File Offset: 0x001EB12C
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x040049EB RID: 18923
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x040049EC RID: 18924
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x040049ED RID: 18925
		private AeroplaneController m_Plane;

		// Token: 0x02000684 RID: 1668
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04004FE8 RID: 20456
			public Transform transform;

			// Token: 0x04004FE9 RID: 20457
			public float amount;

			// Token: 0x04004FEA RID: 20458
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04004FEB RID: 20459
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006EC RID: 1772
			public enum Type
			{
				// Token: 0x040051F6 RID: 20982
				Aileron,
				// Token: 0x040051F7 RID: 20983
				Elevator,
				// Token: 0x040051F8 RID: 20984
				Rudder,
				// Token: 0x040051F9 RID: 20985
				RuddervatorNegative,
				// Token: 0x040051FA RID: 20986
				RuddervatorPositive
			}
		}
	}
}
