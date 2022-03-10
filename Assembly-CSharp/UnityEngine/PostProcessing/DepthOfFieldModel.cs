using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056A RID: 1386
	[Serializable]
	public class DepthOfFieldModel : PostProcessingModel
	{
		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x06002353 RID: 9043 RVA: 0x001F526C File Offset: 0x001F346C
		// (set) Token: 0x06002354 RID: 9044 RVA: 0x001F5274 File Offset: 0x001F3474
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

		// Token: 0x06002355 RID: 9045 RVA: 0x001F527D File Offset: 0x001F347D
		public override void Reset()
		{
			this.m_Settings = DepthOfFieldModel.Settings.defaultSettings;
		}

		// Token: 0x04004B2D RID: 19245
		[SerializeField]
		private DepthOfFieldModel.Settings m_Settings = DepthOfFieldModel.Settings.defaultSettings;

		// Token: 0x020006C4 RID: 1732
		public enum KernelSize
		{
			// Token: 0x0400516A RID: 20842
			Small,
			// Token: 0x0400516B RID: 20843
			Medium,
			// Token: 0x0400516C RID: 20844
			Large,
			// Token: 0x0400516D RID: 20845
			VeryLarge
		}

		// Token: 0x020006C5 RID: 1733
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059F RID: 1439
			// (get) Token: 0x06002754 RID: 10068 RVA: 0x00203A3C File Offset: 0x00201C3C
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

			// Token: 0x0400516E RID: 20846
			[Min(0.1f)]
			[Tooltip("Distance to the point of focus.")]
			public float focusDistance;

			// Token: 0x0400516F RID: 20847
			[Range(0.05f, 32f)]
			[Tooltip("Ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
			public float aperture;

			// Token: 0x04005170 RID: 20848
			[Range(1f, 300f)]
			[Tooltip("Distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
			public float focalLength;

			// Token: 0x04005171 RID: 20849
			[Tooltip("Calculate the focal length automatically from the field-of-view value set on the camera. Using this setting isn't recommended.")]
			public bool useCameraFov;

			// Token: 0x04005172 RID: 20850
			[Tooltip("Convolution kernel size of the bokeh filter, which determines the maximum radius of bokeh. It also affects the performance (the larger the kernel is, the longer the GPU time is required).")]
			public DepthOfFieldModel.KernelSize kernelSize;
		}
	}
}
