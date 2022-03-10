using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056C RID: 1388
	[Serializable]
	public class EyeAdaptationModel : PostProcessingModel
	{
		// Token: 0x1700050B RID: 1291
		// (get) Token: 0x0600235B RID: 9051 RVA: 0x001F52CE File Offset: 0x001F34CE
		// (set) Token: 0x0600235C RID: 9052 RVA: 0x001F52D6 File Offset: 0x001F34D6
		public EyeAdaptationModel.Settings settings
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

		// Token: 0x0600235D RID: 9053 RVA: 0x001F52DF File Offset: 0x001F34DF
		public override void Reset()
		{
			this.m_Settings = EyeAdaptationModel.Settings.defaultSettings;
		}

		// Token: 0x04004B2F RID: 19247
		[SerializeField]
		private EyeAdaptationModel.Settings m_Settings = EyeAdaptationModel.Settings.defaultSettings;

		// Token: 0x020006C7 RID: 1735
		public enum EyeAdaptationType
		{
			// Token: 0x04005174 RID: 20852
			Progressive,
			// Token: 0x04005175 RID: 20853
			Fixed
		}

		// Token: 0x020006C8 RID: 1736
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A1 RID: 1441
			// (get) Token: 0x06002756 RID: 10070 RVA: 0x00203AA0 File Offset: 0x00201CA0
			public static EyeAdaptationModel.Settings defaultSettings
			{
				get
				{
					return new EyeAdaptationModel.Settings
					{
						lowPercent = 45f,
						highPercent = 95f,
						minLuminance = -5f,
						maxLuminance = 1f,
						keyValue = 0.25f,
						dynamicKeyValue = true,
						adaptationType = EyeAdaptationModel.EyeAdaptationType.Progressive,
						speedUp = 2f,
						speedDown = 1f,
						logMin = -8,
						logMax = 4
					};
				}
			}

			// Token: 0x04005176 RID: 20854
			[Range(1f, 99f)]
			[Tooltip("Filters the dark part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
			public float lowPercent;

			// Token: 0x04005177 RID: 20855
			[Range(1f, 99f)]
			[Tooltip("Filters the bright part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
			public float highPercent;

			// Token: 0x04005178 RID: 20856
			[Tooltip("Minimum average luminance to consider for auto exposure (in EV).")]
			public float minLuminance;

			// Token: 0x04005179 RID: 20857
			[Tooltip("Maximum average luminance to consider for auto exposure (in EV).")]
			public float maxLuminance;

			// Token: 0x0400517A RID: 20858
			[Min(0f)]
			[Tooltip("Exposure bias. Use this to offset the global exposure of the scene.")]
			public float keyValue;

			// Token: 0x0400517B RID: 20859
			[Tooltip("Set this to true to let Unity handle the key value automatically based on average luminance.")]
			public bool dynamicKeyValue;

			// Token: 0x0400517C RID: 20860
			[Tooltip("Use \"Progressive\" if you want the auto exposure to be animated. Use \"Fixed\" otherwise.")]
			public EyeAdaptationModel.EyeAdaptationType adaptationType;

			// Token: 0x0400517D RID: 20861
			[Min(0f)]
			[Tooltip("Adaptation speed from a dark to a light environment.")]
			public float speedUp;

			// Token: 0x0400517E RID: 20862
			[Min(0f)]
			[Tooltip("Adaptation speed from a light to a dark environment.")]
			public float speedDown;

			// Token: 0x0400517F RID: 20863
			[Range(-16f, -1f)]
			[Tooltip("Lower bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
			public int logMin;

			// Token: 0x04005180 RID: 20864
			[Range(1f, 16f)]
			[Tooltip("Upper bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
			public int logMax;
		}
	}
}
