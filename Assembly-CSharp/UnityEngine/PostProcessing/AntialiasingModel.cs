using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055D RID: 1373
	[Serializable]
	public class AntialiasingModel : PostProcessingModel
	{
		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x060022F8 RID: 8952 RVA: 0x001EF541 File Offset: 0x001ED741
		// (set) Token: 0x060022F9 RID: 8953 RVA: 0x001EF549 File Offset: 0x001ED749
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

		// Token: 0x060022FA RID: 8954 RVA: 0x001EF552 File Offset: 0x001ED752
		public override void Reset()
		{
			this.m_Settings = AntialiasingModel.Settings.defaultSettings;
		}

		// Token: 0x04004A79 RID: 19065
		[SerializeField]
		private AntialiasingModel.Settings m_Settings = AntialiasingModel.Settings.defaultSettings;

		// Token: 0x020006A6 RID: 1702
		public enum Method
		{
			// Token: 0x0400506D RID: 20589
			Fxaa,
			// Token: 0x0400506E RID: 20590
			Taa
		}

		// Token: 0x020006A7 RID: 1703
		public enum FxaaPreset
		{
			// Token: 0x04005070 RID: 20592
			ExtremePerformance,
			// Token: 0x04005071 RID: 20593
			Performance,
			// Token: 0x04005072 RID: 20594
			Default,
			// Token: 0x04005073 RID: 20595
			Quality,
			// Token: 0x04005074 RID: 20596
			ExtremeQuality
		}

		// Token: 0x020006A8 RID: 1704
		[Serializable]
		public struct FxaaQualitySettings
		{
			// Token: 0x04005075 RID: 20597
			[Tooltip("The amount of desired sub-pixel aliasing removal. Effects the sharpeness of the output.")]
			[Range(0f, 1f)]
			public float subpixelAliasingRemovalAmount;

			// Token: 0x04005076 RID: 20598
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.063f, 0.333f)]
			public float edgeDetectionThreshold;

			// Token: 0x04005077 RID: 20599
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0f, 0.0833f)]
			public float minimumRequiredLuminance;

			// Token: 0x04005078 RID: 20600
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

		// Token: 0x020006A9 RID: 1705
		[Serializable]
		public struct FxaaConsoleSettings
		{
			// Token: 0x04005079 RID: 20601
			[Tooltip("The amount of spread applied to the sampling coordinates while sampling for subpixel information.")]
			[Range(0.33f, 0.5f)]
			public float subpixelSpreadAmount;

			// Token: 0x0400507A RID: 20602
			[Tooltip("This value dictates how sharp the edges in the image are kept; a higher value implies sharper edges.")]
			[Range(2f, 8f)]
			public float edgeSharpnessAmount;

			// Token: 0x0400507B RID: 20603
			[Tooltip("The minimum amount of local contrast required to qualify a region as containing an edge.")]
			[Range(0.125f, 0.25f)]
			public float edgeDetectionThreshold;

			// Token: 0x0400507C RID: 20604
			[Tooltip("Local contrast adaptation value to disallow the algorithm from executing on the darker regions.")]
			[Range(0.04f, 0.06f)]
			public float minimumRequiredLuminance;

			// Token: 0x0400507D RID: 20605
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

		// Token: 0x020006AA RID: 1706
		[Serializable]
		public struct FxaaSettings
		{
			// Token: 0x17000587 RID: 1415
			// (get) Token: 0x0600270B RID: 9995 RVA: 0x001FDD68 File Offset: 0x001FBF68
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

			// Token: 0x0400507E RID: 20606
			public AntialiasingModel.FxaaPreset preset;
		}

		// Token: 0x020006AB RID: 1707
		[Serializable]
		public struct TaaSettings
		{
			// Token: 0x17000588 RID: 1416
			// (get) Token: 0x0600270C RID: 9996 RVA: 0x001FDD88 File Offset: 0x001FBF88
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

			// Token: 0x0400507F RID: 20607
			[Tooltip("The diameter (in texels) inside which jitter samples are spread. Smaller values result in crisper but more aliased output, while larger values result in more stable but blurrier output.")]
			[Range(0.1f, 1f)]
			public float jitterSpread;

			// Token: 0x04005080 RID: 20608
			[Tooltip("Controls the amount of sharpening applied to the color buffer.")]
			[Range(0f, 3f)]
			public float sharpen;

			// Token: 0x04005081 RID: 20609
			[Tooltip("The blend coefficient for a stationary fragment. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float stationaryBlending;

			// Token: 0x04005082 RID: 20610
			[Tooltip("The blend coefficient for a fragment with significant motion. Controls the percentage of history sample blended into the final color.")]
			[Range(0f, 0.99f)]
			public float motionBlending;
		}

		// Token: 0x020006AC RID: 1708
		[Serializable]
		public struct Settings
		{
			// Token: 0x17000589 RID: 1417
			// (get) Token: 0x0600270D RID: 9997 RVA: 0x001FDDD0 File Offset: 0x001FBFD0
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

			// Token: 0x04005083 RID: 20611
			public AntialiasingModel.Method method;

			// Token: 0x04005084 RID: 20612
			public AntialiasingModel.FxaaSettings fxaaSettings;

			// Token: 0x04005085 RID: 20613
			public AntialiasingModel.TaaSettings taaSettings;
		}
	}
}
