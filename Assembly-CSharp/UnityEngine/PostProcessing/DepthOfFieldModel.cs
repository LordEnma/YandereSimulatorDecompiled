using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	[Serializable]
	public class DepthOfFieldModel : PostProcessingModel
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x0600238A RID: 9098 RVA: 0x001F99D0 File Offset: 0x001F7BD0
		// (set) Token: 0x0600238B RID: 9099 RVA: 0x001F99D8 File Offset: 0x001F7BD8
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

		// Token: 0x0600238C RID: 9100 RVA: 0x001F99E1 File Offset: 0x001F7BE1
		public override void Reset()
		{
			this.m_Settings = DepthOfFieldModel.Settings.defaultSettings;
		}

		// Token: 0x04004BD4 RID: 19412
		[SerializeField]
		private DepthOfFieldModel.Settings m_Settings = DepthOfFieldModel.Settings.defaultSettings;

		// Token: 0x020006CE RID: 1742
		public enum KernelSize
		{
			// Token: 0x04005211 RID: 21009
			Small,
			// Token: 0x04005212 RID: 21010
			Medium,
			// Token: 0x04005213 RID: 21011
			Large,
			// Token: 0x04005214 RID: 21012
			VeryLarge
		}

		// Token: 0x020006CF RID: 1743
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A1 RID: 1441
			// (get) Token: 0x0600278B RID: 10123 RVA: 0x002082F0 File Offset: 0x002064F0
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

			// Token: 0x04005215 RID: 21013
			[Min(0.1f)]
			[Tooltip("Distance to the point of focus.")]
			public float focusDistance;

			// Token: 0x04005216 RID: 21014
			[Range(0.05f, 32f)]
			[Tooltip("Ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
			public float aperture;

			// Token: 0x04005217 RID: 21015
			[Range(1f, 300f)]
			[Tooltip("Distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
			public float focalLength;

			// Token: 0x04005218 RID: 21016
			[Tooltip("Calculate the focal length automatically from the field-of-view value set on the camera. Using this setting isn't recommended.")]
			public bool useCameraFov;

			// Token: 0x04005219 RID: 21017
			[Tooltip("Convolution kernel size of the bokeh filter, which determines the maximum radius of bokeh. It also affects the performance (the larger the kernel is, the longer the GPU time is required).")]
			public DepthOfFieldModel.KernelSize kernelSize;
		}
	}
}
