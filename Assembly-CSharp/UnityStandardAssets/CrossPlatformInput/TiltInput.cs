using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x0600220F RID: 8719 RVA: 0x001EA8D0 File Offset: 0x001E8AD0
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002210 RID: 8720 RVA: 0x001EA900 File Offset: 0x001E8B00
		private void Update()
		{
			float value = 0f;
			if (Input.acceleration != Vector3.zero)
			{
				TiltInput.AxisOptions axisOptions = this.tiltAroundAxis;
				if (axisOptions != TiltInput.AxisOptions.ForwardAxis)
				{
					if (axisOptions == TiltInput.AxisOptions.SidewaysAxis)
					{
						value = Mathf.Atan2(Input.acceleration.z, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
					}
				}
				else
				{
					value = Mathf.Atan2(Input.acceleration.x, -Input.acceleration.y) * 57.29578f + this.centreAngleOffset;
				}
			}
			float num = Mathf.InverseLerp(-this.fullTiltAngle, this.fullTiltAngle, value) * 2f - 1f;
			switch (this.mapping.type)
			{
			case TiltInput.AxisMapping.MappingType.NamedAxis:
				this.m_SteerAxis.Update(num);
				return;
			case TiltInput.AxisMapping.MappingType.MousePositionX:
				CrossPlatformInputManager.SetVirtualMousePositionX(num * (float)Screen.width);
				return;
			case TiltInput.AxisMapping.MappingType.MousePositionY:
				CrossPlatformInputManager.SetVirtualMousePositionY(num * (float)Screen.width);
				return;
			case TiltInput.AxisMapping.MappingType.MousePositionZ:
				CrossPlatformInputManager.SetVirtualMousePositionZ(num * (float)Screen.width);
				return;
			default:
				return;
			}
		}

		// Token: 0x06002211 RID: 8721 RVA: 0x001EA9FF File Offset: 0x001E8BFF
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x040049F1 RID: 18929
		public TiltInput.AxisMapping mapping;

		// Token: 0x040049F2 RID: 18930
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x040049F3 RID: 18931
		public float fullTiltAngle = 25f;

		// Token: 0x040049F4 RID: 18932
		public float centreAngleOffset;

		// Token: 0x040049F5 RID: 18933
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000689 RID: 1673
		public enum AxisOptions
		{
			// Token: 0x04004FD7 RID: 20439
			ForwardAxis,
			// Token: 0x04004FD8 RID: 20440
			SidewaysAxis
		}

		// Token: 0x0200068A RID: 1674
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04004FD9 RID: 20441
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04004FDA RID: 20442
			public string axisName;

			// Token: 0x020006ED RID: 1773
			public enum MappingType
			{
				// Token: 0x040051D6 RID: 20950
				NamedAxis,
				// Token: 0x040051D7 RID: 20951
				MousePositionX,
				// Token: 0x040051D8 RID: 20952
				MousePositionY,
				// Token: 0x040051D9 RID: 20953
				MousePositionZ
			}
		}
	}
}
