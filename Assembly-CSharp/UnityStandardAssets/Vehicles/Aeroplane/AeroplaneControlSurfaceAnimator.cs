using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000530 RID: 1328
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021CA RID: 8650 RVA: 0x001ED760 File Offset: 0x001EB960
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021CB RID: 8651 RVA: 0x001ED7A4 File Offset: 0x001EB9A4
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

		// Token: 0x060021CC RID: 8652 RVA: 0x001ED904 File Offset: 0x001EBB04
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x04004A08 RID: 18952
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x04004A09 RID: 18953
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x04004A0A RID: 18954
		private AeroplaneController m_Plane;

		// Token: 0x02000685 RID: 1669
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04005005 RID: 20485
			public Transform transform;

			// Token: 0x04005006 RID: 20486
			public float amount;

			// Token: 0x04005007 RID: 20487
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04005008 RID: 20488
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006ED RID: 1773
			public enum Type
			{
				// Token: 0x04005213 RID: 21011
				Aileron,
				// Token: 0x04005214 RID: 21012
				Elevator,
				// Token: 0x04005215 RID: 21013
				Rudder,
				// Token: 0x04005216 RID: 21014
				RuddervatorNegative,
				// Token: 0x04005217 RID: 21015
				RuddervatorPositive
			}
		}
	}
}
