using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000564 RID: 1380
	[Serializable]
	public class EyeAdaptationModel : PostProcessingModel
	{
		// Token: 0x17000508 RID: 1288
		// (get) Token: 0x0600231B RID: 8987 RVA: 0x001EF712 File Offset: 0x001ED912
		// (set) Token: 0x0600231C RID: 8988 RVA: 0x001EF71A File Offset: 0x001ED91A
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

		// Token: 0x0600231D RID: 8989 RVA: 0x001EF723 File Offset: 0x001ED923
		public override void Reset()
		{
			this.m_Settings = EyeAdaptationModel.Settings.defaultSettings;
		}

		// Token: 0x04004A82 RID: 19074
		[SerializeField]
		private EyeAdaptationModel.Settings m_Settings = EyeAdaptationModel.Settings.defaultSettings;

		// Token: 0x020006C2 RID: 1730
		public enum EyeAdaptationType
		{
			// Token: 0x040050E4 RID: 20708
			Progressive,
			// Token: 0x040050E5 RID: 20709
			Fixed
		}

		// Token: 0x020006C3 RID: 1731
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059C RID: 1436
			// (get) Token: 0x06002721 RID: 10017 RVA: 0x001FE4DC File Offset: 0x001FC6DC
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

			// Token: 0x040050E6 RID: 20710
			[Range(1f, 99f)]
			[Tooltip("Filters the dark part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
			public float lowPercent;

			// Token: 0x040050E7 RID: 20711
			[Range(1f, 99f)]
			[Tooltip("Filters the bright part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
			public float highPercent;

			// Token: 0x040050E8 RID: 20712
			[Tooltip("Minimum average luminance to consider for auto exposure (in EV).")]
			public float minLuminance;

			// Token: 0x040050E9 RID: 20713
			[Tooltip("Maximum average luminance to consider for auto exposure (in EV).")]
			public float maxLuminance;

			// Token: 0x040050EA RID: 20714
			[Min(0f)]
			[Tooltip("Exposure bias. Use this to offset the global exposure of the scene.")]
			public float keyValue;

			// Token: 0x040050EB RID: 20715
			[Tooltip("Set this to true to let Unity handle the key value automatically based on average luminance.")]
			public bool dynamicKeyValue;

			// Token: 0x040050EC RID: 20716
			[Tooltip("Use \"Progressive\" if you want the auto exposure to be animated. Use \"Fixed\" otherwise.")]
			public EyeAdaptationModel.EyeAdaptationType adaptationType;

			// Token: 0x040050ED RID: 20717
			[Min(0f)]
			[Tooltip("Adaptation speed from a dark to a light environment.")]
			public float speedUp;

			// Token: 0x040050EE RID: 20718
			[Min(0f)]
			[Tooltip("Adaptation speed from a light to a dark environment.")]
			public float speedDown;

			// Token: 0x040050EF RID: 20719
			[Range(-16f, -1f)]
			[Tooltip("Lower bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
			public int logMin;

			// Token: 0x040050F0 RID: 20720
			[Range(1f, 16f)]
			[Tooltip("Upper bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
			public int logMax;
		}
	}
}
