using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000575 RID: 1397
	[Serializable]
	public class DepthOfFieldModel : PostProcessingModel
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x06002393 RID: 9107 RVA: 0x001FAE5C File Offset: 0x001F905C
		// (set) Token: 0x06002394 RID: 9108 RVA: 0x001FAE64 File Offset: 0x001F9064
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

		// Token: 0x06002395 RID: 9109 RVA: 0x001FAE6D File Offset: 0x001F906D
		public override void Reset()
		{
			this.m_Settings = DepthOfFieldModel.Settings.defaultSettings;
		}

		// Token: 0x04004BEA RID: 19434
		[SerializeField]
		private DepthOfFieldModel.Settings m_Settings = DepthOfFieldModel.Settings.defaultSettings;

		// Token: 0x020006CF RID: 1743
		public enum KernelSize
		{
			// Token: 0x0400522F RID: 21039
			Small,
			// Token: 0x04005230 RID: 21040
			Medium,
			// Token: 0x04005231 RID: 21041
			Large,
			// Token: 0x04005232 RID: 21042
			VeryLarge
		}

		// Token: 0x020006D0 RID: 1744
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A1 RID: 1441
			// (get) Token: 0x06002794 RID: 10132 RVA: 0x00209890 File Offset: 0x00207A90
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

			// Token: 0x04005233 RID: 21043
			[Min(0.1f)]
			[Tooltip("Distance to the point of focus.")]
			public float focusDistance;

			// Token: 0x04005234 RID: 21044
			[Range(0.05f, 32f)]
			[Tooltip("Ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
			public float aperture;

			// Token: 0x04005235 RID: 21045
			[Range(1f, 300f)]
			[Tooltip("Distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
			public float focalLength;

			// Token: 0x04005236 RID: 21046
			[Tooltip("Calculate the focal length automatically from the field-of-view value set on the camera. Using this setting isn't recommended.")]
			public bool useCameraFov;

			// Token: 0x04005237 RID: 21047
			[Tooltip("Convolution kernel size of the bokeh filter, which determines the maximum radius of bokeh. It also affects the performance (the larger the kernel is, the longer the GPU time is required).")]
			public DepthOfFieldModel.KernelSize kernelSize;
		}
	}
}
