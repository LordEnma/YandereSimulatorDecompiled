using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000570 RID: 1392
	[Serializable]
	public class BloomModel : PostProcessingModel
	{
		// Token: 0x17000504 RID: 1284
		// (get) Token: 0x06002373 RID: 9075 RVA: 0x001F9892 File Offset: 0x001F7A92
		// (set) Token: 0x06002374 RID: 9076 RVA: 0x001F989A File Offset: 0x001F7A9A
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

		// Token: 0x06002375 RID: 9077 RVA: 0x001F98A3 File Offset: 0x001F7AA3
		public override void Reset()
		{
			this.m_Settings = BloomModel.Settings.defaultSettings;
		}

		// Token: 0x04004BCE RID: 19406
		[SerializeField]
		private BloomModel.Settings m_Settings = BloomModel.Settings.defaultSettings;

		// Token: 0x020006BC RID: 1724
		[Serializable]
		public struct BloomSettings
		{
			// Token: 0x17000591 RID: 1425
			// (get) Token: 0x0600277B RID: 10107 RVA: 0x00207C8C File Offset: 0x00205E8C
			// (set) Token: 0x0600277A RID: 10106 RVA: 0x00207C7E File Offset: 0x00205E7E
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

			// Token: 0x17000592 RID: 1426
			// (get) Token: 0x0600277C RID: 10108 RVA: 0x00207C9C File Offset: 0x00205E9C
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

			// Token: 0x040051BD RID: 20925
			[Min(0f)]
			[Tooltip("Strength of the bloom filter.")]
			public float intensity;

			// Token: 0x040051BE RID: 20926
			[Min(0f)]
			[Tooltip("Filters out pixels under this level of brightness.")]
			public float threshold;

			// Token: 0x040051BF RID: 20927
			[Range(0f, 1f)]
			[Tooltip("Makes transition between under/over-threshold gradual (0 = hard threshold, 1 = soft threshold).")]
			public float softKnee;

			// Token: 0x040051C0 RID: 20928
			[Range(1f, 7f)]
			[Tooltip("Changes extent of veiling effects in a screen resolution-independent fashion.")]
			public float radius;

			// Token: 0x040051C1 RID: 20929
			[Tooltip("Reduces flashing noise with an additional filter.")]
			public bool antiFlicker;
		}

		// Token: 0x020006BD RID: 1725
		[Serializable]
		public struct LensDirtSettings
		{
			// Token: 0x17000593 RID: 1427
			// (get) Token: 0x0600277D RID: 10109 RVA: 0x00207CEC File Offset: 0x00205EEC
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

			// Token: 0x040051C2 RID: 20930
			[Tooltip("Dirtiness texture to add smudges or dust to the lens.")]
			public Texture texture;

			// Token: 0x040051C3 RID: 20931
			[Min(0f)]
			[Tooltip("Amount of lens dirtiness.")]
			public float intensity;
		}

		// Token: 0x020006BE RID: 1726
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000594 RID: 1428
			// (get) Token: 0x0600277E RID: 10110 RVA: 0x00207D18 File Offset: 0x00205F18
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

			// Token: 0x040051C4 RID: 20932
			public BloomModel.BloomSettings bloom;

			// Token: 0x040051C5 RID: 20933
			public BloomModel.LensDirtSettings lensDirt;
		}
	}
}
