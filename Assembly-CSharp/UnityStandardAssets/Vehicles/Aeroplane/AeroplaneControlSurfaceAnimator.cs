using System;
using UnityEngine;

namespace UnityStandardAssets.Vehicles.Aeroplane
{
	// Token: 0x0200052D RID: 1325
	public class AeroplaneControlSurfaceAnimator : MonoBehaviour
	{
		// Token: 0x060021AF RID: 8623 RVA: 0x001EB7D8 File Offset: 0x001E99D8
		private void Start()
		{
			this.m_Plane = base.GetComponent<AeroplaneController>();
			foreach (AeroplaneControlSurfaceAnimator.ControlSurface controlSurface in this.m_ControlSurfaces)
			{
				controlSurface.originalLocalRotation = controlSurface.transform.localRotation;
			}
		}

		// Token: 0x060021B0 RID: 8624 RVA: 0x001EB81C File Offset: 0x001E9A1C
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

		// Token: 0x060021B1 RID: 8625 RVA: 0x001EB97C File Offset: 0x001E9B7C
		private void RotateSurface(AeroplaneControlSurfaceAnimator.ControlSurface surface, Quaternion rotation)
		{
			Quaternion b = surface.originalLocalRotation * rotation;
			surface.transform.localRotation = Quaternion.Slerp(surface.transform.localRotation, b, this.m_Smoothing * Time.deltaTime);
		}

		// Token: 0x040049C9 RID: 18889
		[SerializeField]
		private float m_Smoothing = 5f;

		// Token: 0x040049CA RID: 18890
		[SerializeField]
		private AeroplaneControlSurfaceAnimator.ControlSurface[] m_ControlSurfaces;

		// Token: 0x040049CB RID: 18891
		private AeroplaneController m_Plane;

		// Token: 0x02000680 RID: 1664
		[Serializable]
		public class ControlSurface
		{
			// Token: 0x04004FC1 RID: 20417
			public Transform transform;

			// Token: 0x04004FC2 RID: 20418
			public float amount;

			// Token: 0x04004FC3 RID: 20419
			public AeroplaneControlSurfaceAnimator.ControlSurface.Type type;

			// Token: 0x04004FC4 RID: 20420
			[HideInInspector]
			public Quaternion originalLocalRotation;

			// Token: 0x020006E8 RID: 1768
			public enum Type
			{
				// Token: 0x040051CF RID: 20943
				Aileron,
				// Token: 0x040051D0 RID: 20944
				Elevator,
				// Token: 0x040051D1 RID: 20945
				Rudder,
				// Token: 0x040051D2 RID: 20946
				RuddervatorNegative,
				// Token: 0x040051D3 RID: 20947
				RuddervatorPositive
			}
		}
	}
}
