using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052E RID: 1326
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021BB RID: 8635 RVA: 0x001EC1A8 File Offset: 0x001EA3A8
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021BC RID: 8636 RVA: 0x001EC1EC File Offset: 0x001EA3EC
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

		// Token: 0x060021BD RID: 8637 RVA: 0x001EC34C File Offset: 0x001EA54C
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x040049DB RID: 18907
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x040049DC RID: 18908
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x040049DD RID: 18909
		private AeroplaneController m_Plane;

		// Token: 0x02000681 RID: 1665
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04004FD3 RID: 20435
			public Transform transform;

			// Token: 0x04004FD4 RID: 20436
			public float amount;

			// Token: 0x04004FD5 RID: 20437
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04004FD6 RID: 20438
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006E9 RID: 1769
			public enum Type
			{
				// Token: 0x040051E1 RID: 20961
				Aileron,
				// Token: 0x040051E2 RID: 20962
				Elevator,
				// Token: 0x040051E3 RID: 20963
				Rudder,
				// Token: 0x040051E4 RID: 20964
				RuddervatorNegative,
				// Token: 0x040051E5 RID: 20965
				RuddervatorPositive
			}
		}
	}
}
