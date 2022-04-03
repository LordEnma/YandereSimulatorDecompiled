using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x02000539 RID: 1337
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021F2 RID: 8690 RVA: 0x001F0F38 File Offset: 0x001EF138
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021F3 RID: 8691 RVA: 0x001F0F7C File Offset: 0x001EF17C
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

		// Token: 0x060021F4 RID: 8692 RVA: 0x001F10DC File Offset: 0x001EF2DC
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x04004A99 RID: 19097
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x04004A9A RID: 19098
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x04004A9B RID: 19099
		private AeroplaneController m_Plane;

		// Token: 0x0200068E RID: 1678
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04005096 RID: 20630
			public Transform transform;

			// Token: 0x04005097 RID: 20631
			public float amount;

			// Token: 0x04005098 RID: 20632
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04005099 RID: 20633
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006F6 RID: 1782
			public enum Type
			{
				// Token: 0x040052A4 RID: 21156
				Aileron,
				// Token: 0x040052A5 RID: 21157
				Elevator,
				// Token: 0x040052A6 RID: 21158
				Rudder,
				// Token: 0x040052A7 RID: 21159
				RuddervatorNegative,
				// Token: 0x040052A8 RID: 21160
				RuddervatorPositive
			}
		}
	}
}
