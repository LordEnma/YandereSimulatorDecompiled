using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x0200053A RID: 1338
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06002223 RID: 8739 RVA: 0x001ECDD0 File Offset: 0x001EAFD0
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002224 RID: 8740 RVA: 0x001ECE00 File Offset: 0x001EB000
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

		// Token: 0x06002225 RID: 8741 RVA: 0x001ECEFF File Offset: 0x001EB0FF
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x04004A20 RID: 18976
		public TiltInput.AxisMapping mapping;

		// Token: 0x04004A21 RID: 18977
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x04004A22 RID: 18978
		public float fullTiltAngle = 25f;

		// Token: 0x04004A23 RID: 18979
		public float centreAngleOffset;

		// Token: 0x04004A24 RID: 18980
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000686 RID: 1670
		public enum AxisOptions
		{
			// Token: 0x04004FD8 RID: 20440
			ForwardAxis,
			// Token: 0x04004FD9 RID: 20441
			SidewaysAxis
		}

		// Token: 0x02000687 RID: 1671
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04004FDA RID: 20442
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04004FDB RID: 20443
			public string axisName;

			// Token: 0x020006E9 RID: 1769
			public enum MappingType
			{
				// Token: 0x040051D5 RID: 20949
				NamedAxis,
				// Token: 0x040051D6 RID: 20950
				MousePositionX,
				// Token: 0x040051D7 RID: 20951
				MousePositionY,
				// Token: 0x040051D8 RID: 20952
				MousePositionZ
			}
		}
	}
}
