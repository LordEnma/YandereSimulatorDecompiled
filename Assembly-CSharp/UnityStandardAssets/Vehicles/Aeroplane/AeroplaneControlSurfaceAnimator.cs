using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053A RID: 1338
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x06002201 RID: 8705 RVA: 0x001F1EC4 File Offset: 0x001F00C4
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x06002202 RID: 8706 RVA: 0x001F1F08 File Offset: 0x001F0108
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

		// Token: 0x06002203 RID: 8707 RVA: 0x001F2068 File Offset: 0x001F0268
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x04004AAF RID: 19119
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x04004AB0 RID: 19120
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x04004AB1 RID: 19121
		private AeroplaneController m_Plane;

		// Token: 0x0200068F RID: 1679
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x040050AC RID: 20652
			public Transform transform;

			// Token: 0x040050AD RID: 20653
			public float amount;

			// Token: 0x040050AE RID: 20654
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x040050AF RID: 20655
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006F7 RID: 1783
			public enum Type
			{
				// Token: 0x040052BA RID: 21178
				Aileron,
				// Token: 0x040052BB RID: 21179
				Elevator,
				// Token: 0x040052BC RID: 21180
				Rudder,
				// Token: 0x040052BD RID: 21181
				RuddervatorNegative,
				// Token: 0x040052BE RID: 21182
				RuddervatorPositive
			}
		}
	}
}
