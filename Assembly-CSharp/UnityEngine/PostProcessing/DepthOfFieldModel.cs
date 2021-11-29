using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000562 RID: 1378
	[Serializable]
	public class DepthOfFieldModel : PostProcessingModel
	{
		// Token: 0x17000506 RID: 1286
		// (get) Token: 0x06002313 RID: 8979 RVA: 0x001EF6B0 File Offset: 0x001ED8B0
		// (set) Token: 0x06002314 RID: 8980 RVA: 0x001EF6B8 File Offset: 0x001ED8B8
		public DepthOfFieldModel.Settings settings
		{
			get
			{
				return this.m_Settings;
			}
			set
			{
				this.m_Settings = value;
			}
		}

		// Token: 0x06002315 RID: 8981 RVA: 0x001EF6C1 File Offset: 0x001ED8C1
		public override void Reset()
		{
			this.m_Settings = DepthOfFieldModel.Settings.defaultSettings;
		}

		// Token: 0x04004A80 RID: 19072
		[SerializeField]
		private DepthOfFieldModel.Settings m_Settings = DepthOfFieldModel.Settings.defaultSettings;

		// Token: 0x020006BF RID: 1727
		public enum KernelSize
		{
			// Token: 0x040050DA RID: 20698
			Small,
			// Token: 0x040050DB RID: 20699
			Medium,
			// Token: 0x040050DC RID: 20700
			Large,
			// Token: 0x040050DD RID: 20701
			VeryLarge
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059A RID: 1434
			// (get) Token: 0x0600271F RID: 10015 RVA: 0x001FE478 File Offset: 0x001FC678
			public static DepthOfFieldModel.Settings defaultSettings
			{
				get
				{
					return new DepthOfFieldModel.Settings
					{
						focusDistance = 10f,
						aperture = 5.6f,
						focalLength = 50f,
						useCameraFov = false,
						kernelSize = DepthOfFieldModel.KernelSize.Medium
					};
				}
			}

			// Token: 0x040050DE RID: 20702
			[Min(0.1f)]
			[Tooltip("Distance to the point of focus.")]
			public float focusDistance;

			// Token: 0x040050DF RID: 20703
			[Range(0.05f, 32f)]
			[Tooltip("Ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
			public float aperture;

			// Token: 0x040050E0 RID: 20704
			[Range(1f, 300f)]
			[Tooltip("Distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
			public float focalLength;

			// Token: 0x040050E1 RID: 20705
			[Tooltip("Calculate the focal length automatically from the field-of-view value set on the camera. Using this setting isn't recommended.")]
			public bool useCameraFov;

			// Token: 0x040050E2 RID: 20706
			[Tooltip("Convolution kernel size of the bokeh filter, which determines the maximum radius of bokeh. It also affects the performance (the larger the kernel is, the longer the GPU time is required).")]
			public DepthOfFieldModel.KernelSize kernelSize;
		}
	}
}
