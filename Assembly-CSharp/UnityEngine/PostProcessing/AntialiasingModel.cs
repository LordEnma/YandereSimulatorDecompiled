using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000562 RID: 1378
	[Serializable]
	public class AntialiasingModel : PostProcessingModel
	{
		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06002319 RID: 8985 RVA: 0x001F28D5 File Offset: 0x001F0AD5
		// (set) Token: 0x0600231A RID: 8986 RVA: 0x001F28DD File Offset: 0x001F0ADD
		public AntialiasingModel.Settings settings
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

		// Token: 0x0600231B RID: 8987 RVA: 0x001F28E6 File Offset: 0x001F0AE6
		public override void Reset()
		{
			this.m_Settings = AntialiasingModel.Settings.defaultSettings;
		}

		// Token: 0x04004ADC RID: 19164
		[SerializeField]
		private AntialiasingModel.Settings m_Settings = AntialiasingModel.Settings.defaultSettings;

		// Token: 0x020006AC RID: 1708
		public enum Method
		{
			// Token: 0x040050DC RID: 20700
			Fxaa,
			// Token: 0x040050DD RID: 20701
			Taa
		}

		// Token: 0x020006AD RID: 1709
		public enum FxaaPreset
		{
			// Token: 0x040050DF RID: 20703
			ExtremePerformance,
			// Token: 0x040050E0 RID: 20704
			Performance,
			// Token: 0x040050E1 RID: 20705
			Default,
			// Token: 0x040050E2 RID: 20706
			Quality,
			// Token: 0x040050E3 RID: 20707
			ExtremeQuality
		}

		// Token: 0x020006AE RID: 1710
		[Serializable]
		public struct FxaaQualitySettings
		{
			// Token: 0x040050E4 RID: 20708
			[Tooltip("The amount of desired sub-pixel aliasing removal. Effects the sharpeness of the output.")]
			[Range(0f, 1f)]
			public float subpixelAliasingRemovalAmount;

			// Token: 0x040050E5 RID: 20709
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.063f, 0.333f)]
			public float edgeDetectionThreshold;

			// Token: 0x040050E6 RID: 20710
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0f, 0.0833f)]
			public float minimumRequiredLuminance;

			// Token: 0x040050E7 RID: 20711
			public static AntialiasingModel.FxaaQualitySettings[] presets = new AntialiasingModel.FxaaQualitySettings[]
			{
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 0f,
					edgeDetectionThreshold = 0.333f,
					minimumRequiredLuminance = 0.0833f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 0.25f,
					edgeDetectionThreshold = 0.25f,
					minimumRequiredLuminance = 0.0833f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 0.75f,
					edgeDetectionThreshold = 0.166f,
					minimumRequiredLuminance = 0.0833f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 1f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.0625f
				},
				new AntialiasingModel.FxaaQualitySettings
				{
					subpixelAliasingRemovalAmount = 1f,
					edgeDetectionThreshold = 0.063f,
					minimumRequiredLuminance = 0.0312f
				}
			};
		}

		// Token: 0x020006AF RID: 1711
		[Serializable]
		public struct FxaaConsoleSettings
		{
			// Token: 0x040050E8 RID: 20712
			[Tooltip("The amount of spread applied to the sampling coordinates while sampling for subpixel information.")]
			[Range(0.33f, 0.5f)]
			public float subpixelSpreadAmount;

			// Token: 0x040050E9 RID: 20713
			[Tooltip("This value dictates how sharp the edges in the image are kept; a higher value implies sharper edges.")]
			[Range(2f, 8f)]
			public float edgeSharpnessAmount;

			// Token: 0x040050EA RID: 20714
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.125f, 0.25f)]
			public float edgeDetectionThreshold;

			// Token: 0x040050EB RID: 20715
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0.04f, 0.06f)]
			public float minimumRequiredLuminance;

			// Token: 0x040050EC RID: 20716
			public static AntialiasingModel.FxaaConsoleSettings[] presets = new AntialiasingModel.FxaaConsoleSettings[]
			{
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.33f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.25f,
					minimumRequiredLuminance = 0.06f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.33f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.06f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 8f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.05f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 4f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.04f
				},
				new AntialiasingModel.FxaaConsoleSettings
				{
					subpixelSpreadAmount = 0.5f,
					edgeSharpnessAmount = 2f,
					edgeDetectionThreshold = 0.125f,
					minimumRequiredLuminance = 0.04f
				}
			};
		}

		// Token: 0x020006B0 RID: 1712
		[Serializable]
		public struct FxaaSettings
		{
			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x0600272C RID: 10028 RVA: 0x00201120 File Offset: 0x001FF320
			public static AntialiasingModel.FxaaSettings defaultSettings
			{
				get
				{
					return new AntialiasingModel.FxaaSettings
					{
						preset = AntialiasingModel.FxaaPreset.Default
					};
				}
			}

			// Token: 0x040050ED RID: 20717
			public AntialiasingModel.FxaaPreset preset;
		}

		// Token: 0x020006B1 RID: 1713
		[Serializable]
		public struct TaaSettings
		{
			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x0600272D RID: 10029 RVA: 0x00201140 File Offset: 0x001FF340
			public static AntialiasingModel.TaaSettings defaultSettings
			{
				get
				{
					return new AntialiasingModel.TaaSettings
					{
						jitterSpread = 0.75f,
						sharpen = 0.3f,
						stationaryBlending = 0.95f,
						motionBlending = 0.85f
					};
				}
			}

			// Token: 0x040050EE RID: 20718
			[Tooltip("The diameter (in texels) inside which jitter samples are spread. Smaller values result in crisper but more aliased output, while larger values result in more stable but blurrier output.")]
			[Range(0.1f, 1f)]
			public float jitterSpread;

			// Token: 0x040050EF RID: 20719
			[Tooltip("Controls the amount of sharpening applied to the color buffer.")]
			[Range(0f, 3f)]
			public float sharpen;

			// Token: 0x040050F0 RID: 20720
			[Tooltip("The blend coefficient for a stationary fragment. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float stationaryBlending;

			// Token: 0x040050F1 RID: 20721
			[Tooltip("The blend coefficient for a fragment with significant motion. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float motionBlending;
		}

		// Token: 0x020006B2 RID: 1714
		[Serializable]
		public struct Settings
		{
			// Token: 0x1700058A RID: 1418
			// (get) Token: 0x0600272E RID: 10030 RVA: 0x00201188 File Offset: 0x001FF388
			public static AntialiasingModel.Settings defaultSettings
			{
				get
				{
					return new AntialiasingModel.Settings
					{
						method = AntialiasingModel.Method.Fxaa,
						fxaaSettings = AntialiasingModel.FxaaSettings.defaultSettings,
						taaSettings = AntialiasingModel.TaaSettings.defaultSettings
					};
				}
			}

			// Token: 0x040050F2 RID: 20722
			public AntialiasingModel.Method method;

			// Token: 0x040050F3 RID: 20723
			public AntialiasingModel.FxaaSettings fxaaSettings;

			// Token: 0x040050F4 RID: 20724
			public AntialiasingModel.TaaSettings taaSettings;
		}
	}
}
