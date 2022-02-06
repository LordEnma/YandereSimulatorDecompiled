using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052D RID: 1325
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021B4 RID: 8628 RVA: 0x001EBCF4 File Offset: 0x001E9EF4
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021B5 RID: 8629 RVA: 0x001EBD38 File Offset: 0x001E9F38
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

		// Token: 0x060021B6 RID: 8630 RVA: 0x001EBE98 File Offset: 0x001EA098
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x040049D2 RID: 18898
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x040049D3 RID: 18899
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x040049D4 RID: 18900
		private AeroplaneController m_Plane;

		// Token: 0x02000680 RID: 1664
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04004FCA RID: 20426
			public Transform transform;

			// Token: 0x04004FCB RID: 20427
			public float amount;

			// Token: 0x04004FCC RID: 20428
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04004FCD RID: 20429
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006E8 RID: 1768
			public enum Type
			{
				// Token: 0x040051D8 RID: 20952
				Aileron,
				// Token: 0x040051D9 RID: 20953
				Elevator,
				// Token: 0x040051DA RID: 20954
				Rudder,
				// Token: 0x040051DB RID: 20955
				RuddervatorNegative,
				// Token: 0x040051DC RID: 20956
				RuddervatorPositive
			}
		}
	}
}
