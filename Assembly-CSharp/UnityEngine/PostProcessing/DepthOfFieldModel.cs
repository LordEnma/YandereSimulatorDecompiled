using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class DepthOfFieldModel : PostProcessingModel
	{
		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x0600233D RID: 9021 RVA: 0x001F3800 File Offset: 0x001F1A00
		// (set) Token: 0x0600233E RID: 9022 RVA: 0x001F3808 File Offset: 0x001F1A08
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

		// Token: 0x0600233F RID: 9023 RVA: 0x001F3811 File Offset: 0x001F1A11
		public override void Reset()
		{
			this.m_Settings = DepthOfFieldModel.Settings.defaultSettings;
		}

		// Token: 0x04004AF7 RID: 19191
		[SerializeField]
		private DepthOfFieldModel.Settings m_Settings = DepthOfFieldModel.Settings.defaultSettings;

		// Token: 0x020006BF RID: 1727
		public enum KernelSize
		{
			// Token: 0x0400512F RID: 20783
			Small,
			// Token: 0x04005130 RID: 20784
			Medium,
			// Token: 0x04005131 RID: 20785
			Large,
			// Token: 0x04005132 RID: 20786
			VeryLarge
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002735 RID: 10037 RVA: 0x00201F08 File Offset: 0x00200108
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

			// Token: 0x04005133 RID: 20787
			[Min(0.1f)]
			[Tooltip("Distance to the point of focus.")]
			public float focusDistance;

			// Token: 0x04005134 RID: 20788
			[Range(0.05f, 32f)]
			[Tooltip("Ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
			public float aperture;

			// Token: 0x04005135 RID: 20789
			[Range(1f, 300f)]
			[Tooltip("Distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
			public float focalLength;

			// Token: 0x04005136 RID: 20790
			[Tooltip("Calculate the focal length automatically from the field-of-view value set on the camera. Using this setting isn't recommended.")]
			public bool useCameraFov;

			// Token: 0x04005137 RID: 20791
			[Tooltip("Convolution kernel size of the bokeh filter, which determines the maximum radius of bokeh. It also affects the performance (the larger the kernel is, the longer the GPU time is required).")]
			public DepthOfFieldModel.KernelSize kernelSize;
		}
	}
}
