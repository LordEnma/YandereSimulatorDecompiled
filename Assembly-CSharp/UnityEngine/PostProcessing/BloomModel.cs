using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000503 RID: 1283
		// (get) Token: 0x0600236C RID: 9068 RVA: 0x001F8E36 File Offset: 0x001F7036
		// (set) Token: 0x0600236D RID: 9069 RVA: 0x001F8E3E File Offset: 0x001F703E
		public BloomModel.Settings settings
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

		// Token: 0x0600236E RID: 9070 RVA: 0x001F8E47 File Offset: 0x001F7047
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004BBC RID: 19388
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006BC RID: 1724
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x17000590 RID: 1424
			// (get) Token: 0x06002774 RID: 10100 RVA: 0x00207230 File Offset: 0x00205430
			// (set) Token: 0x06002773 RID: 10099 RVA: 0x00207222 File Offset: 0x00205422
			public float thresholdLinear
			{
				get
				{
					return Mathf.GammaToLinearSpace(this.threshold);
				}
				set
				{
					this.threshold = Mathf.LinearToGammaSpace(value);
				}
			}

			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x06002775 RID: 10101 RVA: 0x00207240 File Offset: 0x00205440
			public static BloomModel.BloomSettings defaultSettings
			{
				get
				{
					return new BloomModel.BloomSettings
					{
						intensity = 0.5f,
						threshold = 1.1f,
						softKnee = 0.5f,
						radius = 4f,
						antiFlicker = false
					};
				}
			}

			// Token: 0x040051AB RID: 20907
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040051AC RID: 20908
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040051AD RID: 20909
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040051AE RID: 20910
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040051AF RID: 20911
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x06002776 RID: 10102 RVA: 0x00207290 File Offset: 0x00205490
			public static BloomModel.LensDirtSettings defaultSettings
			{
				get
				{
					return new BloomModel.LensDirtSettings
					{
						texture = null,
						intensity = 3f
					};
				}
			}

			// Token: 0x040051B0 RID: 20912
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040051B1 RID: 20913
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x06002777 RID: 10103 RVA: 0x002072BC File Offset: 0x002054BC
			public static BloomModel.Settings defaultSettings
			{
				get
				{
					return new BloomModel.Settings
					{
						bloom = BloomModel.BloomSettings.defaultSettings,
						lensDirt = BloomModel.LensDirtSettings.defaultSettings
					};
				}
			}

			// Token: 0x040051B2 RID: 20914
			public BloomModel.BloomSettings bloom;

			// Token: 0x040051B3 RID: 20915
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
