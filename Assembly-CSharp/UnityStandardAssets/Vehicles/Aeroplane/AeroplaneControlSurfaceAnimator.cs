using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053B RID: 1339
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x0600220A RID: 8714 RVA: 0x001F3350 File Offset: 0x001F1550
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x0600220B RID: 8715 RVA: 0x001F3394 File Offset: 0x001F1594
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

		// Token: 0x0600220C RID: 8716 RVA: 0x001F34F4 File Offset: 0x001F16F4
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x04004AC5 RID: 19141
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x04004AC6 RID: 19142
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x04004AC7 RID: 19143
		private AeroplaneController m_Plane;

		// Token: 0x02000690 RID: 1680
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x040050CA RID: 20682
			public Transform transform;

			// Token: 0x040050CB RID: 20683
			public float amount;

			// Token: 0x040050CC RID: 20684
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x040050CD RID: 20685
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006F8 RID: 1784
			public enum Type
			{
				// Token: 0x040052D8 RID: 21208
				Aileron,
				// Token: 0x040052D9 RID: 21209
				Elevator,
				// Token: 0x040052DA RID: 21210
				Rudder,
				// Token: 0x040052DB RID: 21211
				RuddervatorNegative,
				// Token: 0x040052DC RID: 21212
				RuddervatorPositive
			}
		}
	}
}
