using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053A RID: 1338
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021FA RID: 8698 RVA: 0x001F1468 File Offset: 0x001EF668
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021FB RID: 8699 RVA: 0x001F14AC File Offset: 0x001EF6AC
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

		// Token: 0x060021FC RID: 8700 RVA: 0x001F160C File Offset: 0x001EF80C
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x04004A9D RID: 19101
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x04004A9E RID: 19102
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x04004A9F RID: 19103
		private AeroplaneController m_Plane;

		// Token: 0x0200068F RID: 1679
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x0400509A RID: 20634
			public Transform transform;

			// Token: 0x0400509B RID: 20635
			public float amount;

			// Token: 0x0400509C RID: 20636
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x0400509D RID: 20637
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006F7 RID: 1783
			public enum Type
			{
				// Token: 0x040052A8 RID: 21160
				Aileron,
				// Token: 0x040052A9 RID: 21161
				Elevator,
				// Token: 0x040052AA RID: 21162
				Rudder,
				// Token: 0x040052AB RID: 21163
				RuddervatorNegative,
				// Token: 0x040052AC RID: 21164
				RuddervatorPositive
			}
		}
	}
}
