using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000573 RID: 1395
	[Serializable]
	public class DepthOfFieldModel : PostProcessingModel
	{
		// Token: 0x1700050A RID: 1290
		// (get) Token: 0x0600237B RID: 9083 RVA: 0x001F8A44 File Offset: 0x001F6C44
		// (set) Token: 0x0600237C RID: 9084 RVA: 0x001F8A4C File Offset: 0x001F6C4C
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

		// Token: 0x0600237D RID: 9085 RVA: 0x001F8A55 File Offset: 0x001F6C55
		public override void Reset()
		{
			this.m_Settings = DepthOfFieldModel.Settings.defaultSettings;
		}

		// Token: 0x04004BBE RID: 19390
		[SerializeField]
		private DepthOfFieldModel.Settings m_Settings = DepthOfFieldModel.Settings.defaultSettings;

		// Token: 0x020006CD RID: 1741
		public enum KernelSize
		{
			// Token: 0x040051FB RID: 20987
			Small,
			// Token: 0x040051FC RID: 20988
			Medium,
			// Token: 0x040051FD RID: 20989
			Large,
			// Token: 0x040051FE RID: 20990
			VeryLarge
		}

		// Token: 0x020006CE RID: 1742
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A0 RID: 1440
			// (get) Token: 0x0600277C RID: 10108 RVA: 0x00207364 File Offset: 0x00205564
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

			// Token: 0x040051FF RID: 20991
			[Min(0.1f)]
			[Tooltip("Distance to the point of focus.")]
			public float focusDistance;

			// Token: 0x04005200 RID: 20992
			[Range(0.05f, 32f)]
			[Tooltip("Ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
			public float aperture;

			// Token: 0x04005201 RID: 20993
			[Range(1f, 300f)]
			[Tooltip("Distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
			public float focalLength;

			// Token: 0x04005202 RID: 20994
			[Tooltip("Calculate the focal length automatically from the field-of-view value set on the camera. Using this setting isn't recommended.")]
			public bool useCameraFov;

			// Token: 0x04005203 RID: 20995
			[Tooltip("Convolution kernel size of the bokeh filter, which determines the maximum radius of bokeh. It also affects the performance (the larger the kernel is, the longer the GPU time is required).")]
			public DepthOfFieldModel.KernelSize kernelSize;
		}
	}
}
