using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000528 RID: 1320
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x0600218A RID: 8586 RVA: 0x001E7BA4 File Offset: 0x001E5DA4
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x0600218B RID: 8587 RVA: 0x001E7BE8 File Offset: 0x001E5DE8
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

		// Token: 0x0600218C RID: 8588 RVA: 0x001E7D48 File Offset: 0x001E5F48
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x0400495B RID: 18779
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x0400495C RID: 18780
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x0400495D RID: 18781
		private AeroplaneController m_Plane;

		// Token: 0x02000680 RID: 1664
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04004F75 RID: 20341
			public Transform transform;

			// Token: 0x04004F76 RID: 20342
			public float amount;

			// Token: 0x04004F77 RID: 20343
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04004F78 RID: 20344
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006E9 RID: 1769
			public enum Type
			{
				// Token: 0x04005185 RID: 20869
				Aileron,
				// Token: 0x04005186 RID: 20870
				Elevator,
				// Token: 0x04005187 RID: 20871
				Rudder,
				// Token: 0x04005188 RID: 20872
				RuddervatorNegative,
				// Token: 0x04005189 RID: 20873
				RuddervatorPositive
			}
		}
	}
}
