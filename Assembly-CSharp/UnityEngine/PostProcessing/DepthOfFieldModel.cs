using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class DepthOfFieldModel : PostProcessingModel
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06002338 RID: 9016 RVA: 0x001F32E4 File Offset: 0x001F14E4
		// (set) Token: 0x06002339 RID: 9017 RVA: 0x001F32EC File Offset: 0x001F14EC
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

		// Token: 0x0600233A RID: 9018 RVA: 0x001F32F5 File Offset: 0x001F14F5
		public override void Reset()
		{
			this.m_Settings = DepthOfFieldModel.Settings.defaultSettings;
		}

		// Token: 0x04004AEE RID: 19182
		[SerializeField]
		private DepthOfFieldModel.Settings m_Settings = DepthOfFieldModel.Settings.defaultSettings;

		// Token: 0x020006BF RID: 1727
		public enum KernelSize
		{
			// Token: 0x04005126 RID: 20774
			Small,
			// Token: 0x04005127 RID: 20775
			Medium,
			// Token: 0x04005128 RID: 20776
			Large,
			// Token: 0x04005129 RID: 20777
			VeryLarge
		}

		// Token: 0x020006C0 RID: 1728
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x06002730 RID: 10032 RVA: 0x002019EC File Offset: 0x001FFBEC
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

			// Token: 0x0400512A RID: 20778
			[Min(0.1f)]
			[Tooltip("Distance to the point of focus.")]
			public float focusDistance;

			// Token: 0x0400512B RID: 20779
			[Range(0.05f, 32f)]
			[Tooltip("Ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
			public float aperture;

			// Token: 0x0400512C RID: 20780
			[Range(1f, 300f)]
			[Tooltip("Distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
			public float focalLength;

			// Token: 0x0400512D RID: 20781
			[Tooltip("Calculate the focal length automatically from the field-of-view value set on the camera. Using this setting isn't recommended.")]
			public bool useCameraFov;

			// Token: 0x0400512E RID: 20782
			[Tooltip("Convolution kernel size of the bokeh filter, which determines the maximum radius of bokeh. It also affects the performance (the larger the kernel is, the longer the GPU time is required).")]
			public DepthOfFieldModel.KernelSize kernelSize;
		}
	}
}
