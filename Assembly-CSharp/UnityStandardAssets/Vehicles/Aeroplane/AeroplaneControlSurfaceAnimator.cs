using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000534 RID: 1332
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021E2 RID: 8674 RVA: 0x001EF6C8 File Offset: 0x001ED8C8
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021E3 RID: 8675 RVA: 0x001EF70C File Offset: 0x001ED90C
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

		// Token: 0x060021E4 RID: 8676 RVA: 0x001EF86C File Offset: 0x001EDA6C
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x04004A67 RID: 19047
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x04004A68 RID: 19048
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x04004A69 RID: 19049
		private AeroplaneController m_Plane;

		// Token: 0x02000689 RID: 1673
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04005064 RID: 20580
			public Transform transform;

			// Token: 0x04005065 RID: 20581
			public float amount;

			// Token: 0x04005066 RID: 20582
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04005067 RID: 20583
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006F1 RID: 1777
			public enum Type
			{
				// Token: 0x04005272 RID: 21106
				Aileron,
				// Token: 0x04005273 RID: 21107
				Elevator,
				// Token: 0x04005274 RID: 21108
				Rudder,
				// Token: 0x04005275 RID: 21109
				RuddervatorNegative,
				// Token: 0x04005276 RID: 21110
				RuddervatorPositive
			}
		}
	}
}
