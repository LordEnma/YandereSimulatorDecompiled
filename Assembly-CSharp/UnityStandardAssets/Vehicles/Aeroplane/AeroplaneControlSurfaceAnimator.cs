using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200053C RID: 1340
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x06002215 RID: 8725 RVA: 0x001F4A9C File Offset: 0x001F2C9C
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x06002216 RID: 8726 RVA: 0x001F4AE0 File Offset: 0x001F2CE0
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

		// Token: 0x06002217 RID: 8727 RVA: 0x001F4C40 File Offset: 0x001F2E40
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x04004AEC RID: 19180
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x04004AED RID: 19181
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x04004AEE RID: 19182
		private AeroplaneController m_Plane;

		// Token: 0x02000691 RID: 1681
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x040050F1 RID: 20721
			public Transform transform;

			// Token: 0x040050F2 RID: 20722
			public float amount;

			// Token: 0x040050F3 RID: 20723
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x040050F4 RID: 20724
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006F9 RID: 1785
			public enum Type
			{
				// Token: 0x040052FF RID: 21247
				Aileron,
				// Token: 0x04005300 RID: 21248
				Elevator,
				// Token: 0x04005301 RID: 21249
				Rudder,
				// Token: 0x04005302 RID: 21250
				RuddervatorNegative,
				// Token: 0x04005303 RID: 21251
				RuddervatorPositive
			}
		}
	}
}
