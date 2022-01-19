using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000567 RID: 1383
	[Serializable]
	public class DepthOfFieldModel : PostProcessingModel
	{
		// Token: 0x17000507 RID: 1287
		// (get) Token: 0x06002334 RID: 9012 RVA: 0x001F2A44 File Offset: 0x001F0C44
		// (set) Token: 0x06002335 RID: 9013 RVA: 0x001F2A4C File Offset: 0x001F0C4C
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

		// Token: 0x06002336 RID: 9014 RVA: 0x001F2A55 File Offset: 0x001F0C55
		public override void Reset()
		{
			this.m_Settings = DepthOfFieldModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE3 RID: 19171
		[SerializeField]
		private DepthOfFieldModel.Settings m_Settings = DepthOfFieldModel.Settings.defaultSettings;

		// Token: 0x020006C5 RID: 1733
		public enum KernelSize
		{
			// Token: 0x04005149 RID: 20809
			Small,
			// Token: 0x0400514A RID: 20810
			Medium,
			// Token: 0x0400514B RID: 20811
			Large,
			// Token: 0x0400514C RID: 20812
			VeryLarge
		}

		// Token: 0x020006C6 RID: 1734
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059B RID: 1435
			// (get) Token: 0x06002740 RID: 10048 RVA: 0x00201830 File Offset: 0x001FFA30
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

			// Token: 0x0400514D RID: 20813
			[Min(0.1f)]
			[Tooltip("Distance to the point of focus.")]
			public float focusDistance;

			// Token: 0x0400514E RID: 20814
			[Range(0.05f, 32f)]
			[Tooltip("Ratio of aperture (known as f-stop or f-number). The smaller the value is, the shallower the depth of field is.")]
			public float aperture;

			// Token: 0x0400514F RID: 20815
			[Range(1f, 300f)]
			[Tooltip("Distance between the lens and the film. The larger the value is, the shallower the depth of field is.")]
			public float focalLength;

			// Token: 0x04005150 RID: 20816
			[Tooltip("Calculate the focal length automatically from the field-of-view value set on the camera. Using this setting isn't recommended.")]
			public bool useCameraFov;

			// Token: 0x04005151 RID: 20817
			[Tooltip("Convolution kernel size of the bokeh filter, which determines the maximum radius of bokeh. It also affects the performance (the larger the kernel is, the longer the GPU time is required).")]
			public DepthOfFieldModel.KernelSize kernelSize;
		}
	}
}
