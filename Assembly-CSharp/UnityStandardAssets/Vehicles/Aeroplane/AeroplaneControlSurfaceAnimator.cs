using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052D RID: 1325
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021B1 RID: 8625 RVA: 0x001EBAF0 File Offset: 0x001E9CF0
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021B2 RID: 8626 RVA: 0x001EBB34 File Offset: 0x001E9D34
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

		// Token: 0x060021B3 RID: 8627 RVA: 0x001EBC94 File Offset: 0x001E9E94
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x040049CF RID: 18895
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x040049D0 RID: 18896
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x040049D1 RID: 18897
		private AeroplaneController m_Plane;

		// Token: 0x02000680 RID: 1664
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04004FC7 RID: 20423
			public Transform transform;

			// Token: 0x04004FC8 RID: 20424
			public float amount;

			// Token: 0x04004FC9 RID: 20425
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04004FCA RID: 20426
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006E8 RID: 1768
			public enum Type
			{
				// Token: 0x040051D5 RID: 20949
				Aileron,
				// Token: 0x040051D6 RID: 20950
				Elevator,
				// Token: 0x040051D7 RID: 20951
				Rudder,
				// Token: 0x040051D8 RID: 20952
				RuddervatorNegative,
				// Token: 0x040051D9 RID: 20953
				RuddervatorPositive
			}
		}
	}
}
