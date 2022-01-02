using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
	// Token: 0x02000537 RID: 1335
	public class TiltInput : MonoBehaviour
	{
		// Token: 0x06002212 RID: 8722 RVA: 0x001EAEC0 File Offset: 0x001E90C0
		private void OnEnable()
		{
			if (this.mapping.type == TiltInput.AxisMapping.MappingType.NamedAxis)
			{
				this.m_SteerAxis = new CrossPlatformInputManager.VirtualAxis(this.mapping.axisName);
				CrossPlatformInputManager.RegisterVirtualAxis(this.m_SteerAxis);
			}
		}

		// Token: 0x06002213 RID: 8723 RVA: 0x001EAEF0 File Offset: 0x001E90F0
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

		// Token: 0x06002214 RID: 8724 RVA: 0x001EAFEF File Offset: 0x001E91EF
		private void OnDisable()
		{
			this.m_SteerAxis.Remove();
		}

		// Token: 0x040049FA RID: 18938
		public TiltInput.AxisMapping mapping;

		// Token: 0x040049FB RID: 18939
		public TiltInput.AxisOptions tiltAroundAxis;

		// Token: 0x040049FC RID: 18940
		public float fullTiltAngle = 25f;

		// Token: 0x040049FD RID: 18941
		public float centreAngleOffset;

		// Token: 0x040049FE RID: 18942
		private CrossPlatformInputManager.VirtualAxis m_SteerAxis;

		// Token: 0x02000689 RID: 1673
		public enum AxisOptions
		{
			// Token: 0x04004FE0 RID: 20448
			ForwardAxis,
			// Token: 0x04004FE1 RID: 20449
			SidewaysAxis
		}

		// Token: 0x0200068A RID: 1674
		[Serializable]
		public class AxisMapping
		{
			// Token: 0x04004FE2 RID: 20450
			public TiltInput.AxisMapping.MappingType type;

			// Token: 0x04004FE3 RID: 20451
			public string axisName;

			// Token: 0x020006ED RID: 1773
			public enum MappingType
			{
				// Token: 0x040051DF RID: 20959
				NamedAxis,
				// Token: 0x040051E0 RID: 20960
				MousePositionX,
				// Token: 0x040051E1 RID: 20961
				MousePositionY,
				// Token: 0x040051E2 RID: 20962
				MousePositionZ
			}
		}
	}
}
