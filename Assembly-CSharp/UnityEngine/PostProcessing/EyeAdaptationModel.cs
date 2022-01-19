using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000569 RID: 1385
	[Serializable]
	public class EyeAdaptationModel : PostProcessingModel
	{
		// Token: 0x17000509 RID: 1289
		// (get) Token: 0x0600233C RID: 9020 RVA: 0x001F2AA6 File Offset: 0x001F0CA6
		// (set) Token: 0x0600233D RID: 9021 RVA: 0x001F2AAE File Offset: 0x001F0CAE
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

		// Token: 0x0600233E RID: 9022 RVA: 0x001F2AB7 File Offset: 0x001F0CB7
		public override void Reset()
		{
			this.m_Settings = EyeAdaptationModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE5 RID: 19173
		[SerializeField]
		private EyeAdaptationModel.Settings m_Settings = EyeAdaptationModel.Settings.defaultSettings;

		// Token: 0x020006C8 RID: 1736
		public enum EyeAdaptationType
		{
			// Token: 0x04005153 RID: 20819
			Progressive,
			// Token: 0x04005154 RID: 20820
			Fixed
		}

		// Token: 0x020006C9 RID: 1737
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700059D RID: 1437
			// (get) Token: 0x06002742 RID: 10050 RVA: 0x00201894 File Offset: 0x001FFA94
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

			// Token: 0x04005155 RID: 20821
			[Range(1f, 99f)]
			[Tooltip("Filters the dark part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
			public float lowPercent;

			// Token: 0x04005156 RID: 20822
			[Range(1f, 99f)]
			[Tooltip("Filters the bright part of the histogram when computing the average luminance to avoid very dark pixels from contributing to the auto exposure. Unit is in percent.")]
			public float highPercent;

			// Token: 0x04005157 RID: 20823
			[Tooltip("Minimum average luminance to consider for auto exposure (in EV).")]
			public float minLuminance;

			// Token: 0x04005158 RID: 20824
			[Tooltip("Maximum average luminance to consider for auto exposure (in EV).")]
			public float maxLuminance;

			// Token: 0x04005159 RID: 20825
			[Min(0f)]
			[Tooltip("Exposure bias. Use this to offset the global exposure of the scene.")]
			public float keyValue;

			// Token: 0x0400515A RID: 20826
			[Tooltip("Set this to true to let Unity handle the key value automatically based on average luminance.")]
			public bool dynamicKeyValue;

			// Token: 0x0400515B RID: 20827
			[Tooltip("Use \"Progressive\" if you want the auto exposure to be animated. Use \"Fixed\" otherwise.")]
			public EyeAdaptationModel.EyeAdaptationType adaptationType;

			// Token: 0x0400515C RID: 20828
			[Min(0f)]
			[Tooltip("Adaptation speed from a dark to a light environment.")]
			public float speedUp;

			// Token: 0x0400515D RID: 20829
			[Min(0f)]
			[Tooltip("Adaptation speed from a light to a dark environment.")]
			public float speedDown;

			// Token: 0x0400515E RID: 20830
			[Range(-16f, -1f)]
			[Tooltip("Lower bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
			public int logMin;

			// Token: 0x0400515F RID: 20831
			[Range(1f, 16f)]
			[Tooltip("Upper bound for the brightness range of the generated histogram (in EV). The bigger the spread between min & max, the lower the precision will be.")]
			public int logMax;
		}
	}
}
