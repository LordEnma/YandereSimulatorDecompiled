using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053C RID: 1340
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x06002216 RID: 8726 RVA: 0x001F5004 File Offset: 0x001F3204
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x06002217 RID: 8727 RVA: 0x001F5048 File Offset: 0x001F3248
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

		// Token: 0x06002218 RID: 8728 RVA: 0x001F51A8 File Offset: 0x001F33A8
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x04004AF5 RID: 19189
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x04004AF6 RID: 19190
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x04004AF7 RID: 19191
		private AeroplaneController m_Plane;

		// Token: 0x02000691 RID: 1681
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x040050FA RID: 20730
			public Transform transform;

			// Token: 0x040050FB RID: 20731
			public float amount;

			// Token: 0x040050FC RID: 20732
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x040050FD RID: 20733
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006F9 RID: 1785
			public enum Type
			{
				// Token: 0x04005308 RID: 21256
				Aileron,
				// Token: 0x04005309 RID: 21257
				Elevator,
				// Token: 0x0400530A RID: 21258
				Rudder,
				// Token: 0x0400530B RID: 21259
				RuddervatorNegative,
				// Token: 0x0400530C RID: 21260
				RuddervatorPositive
			}
		}
	}
}
