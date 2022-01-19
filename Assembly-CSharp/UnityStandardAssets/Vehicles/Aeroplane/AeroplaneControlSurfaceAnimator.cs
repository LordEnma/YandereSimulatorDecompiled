using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052D RID: 1325
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021AB RID: 8619 RVA: 0x001EAF38 File Offset: 0x001E9138
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021AC RID: 8620 RVA: 0x001EAF7C File Offset: 0x001E917C
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

		// Token: 0x060021AD RID: 8621 RVA: 0x001EB0DC File Offset: 0x001E92DC
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x040049BE RID: 18878
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x040049BF RID: 18879
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x040049C0 RID: 18880
		private AeroplaneController m_Plane;

		// Token: 0x02000686 RID: 1670
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04004FE4 RID: 20452
			public Transform transform;

			// Token: 0x04004FE5 RID: 20453
			public float amount;

			// Token: 0x04004FE6 RID: 20454
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04004FE7 RID: 20455
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006EF RID: 1775
			public enum Type
			{
				// Token: 0x040051F4 RID: 20980
				Aileron,
				// Token: 0x040051F5 RID: 20981
				Elevator,
				// Token: 0x040051F6 RID: 20982
				Rudder,
				// Token: 0x040051F7 RID: 20983
				RuddervatorNegative,
				// Token: 0x040051F8 RID: 20984
				RuddervatorPositive
			}
		}
	}
}
