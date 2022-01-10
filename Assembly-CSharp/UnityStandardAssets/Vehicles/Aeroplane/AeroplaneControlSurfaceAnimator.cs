using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052C RID: 1324
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021A9 RID: 8617 RVA: 0x001EA268 File Offset: 0x001E8468
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021AA RID: 8618 RVA: 0x001EA2AC File Offset: 0x001E84AC
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

		// Token: 0x060021AB RID: 8619 RVA: 0x001EA40C File Offset: 0x001E860C
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x040049B7 RID: 18871
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x040049B8 RID: 18872
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x040049B9 RID: 18873
		private AeroplaneController m_Plane;

		// Token: 0x02000685 RID: 1669
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04004FDD RID: 20445
			public Transform transform;

			// Token: 0x04004FDE RID: 20446
			public float amount;

			// Token: 0x04004FDF RID: 20447
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04004FE0 RID: 20448
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006EE RID: 1774
			public enum Type
			{
				// Token: 0x040051ED RID: 20973
				Aileron,
				// Token: 0x040051EE RID: 20974
				Elevator,
				// Token: 0x040051EF RID: 20975
				Rudder,
				// Token: 0x040051F0 RID: 20976
				RuddervatorNegative,
				// Token: 0x040051F1 RID: 20977
				RuddervatorPositive
			}
		}
	}
}
