using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056D RID: 1389
	[Serializable]
	public class ScreenSpaceReflectionModel : PostProcessingModel
	{
		// Token: 0x1700050D RID: 1293
		// (get) Token: 0x0600234C RID: 9036 RVA: 0x001F2B6A File Offset: 0x001F0D6A
		// (set) Token: 0x0600234D RID: 9037 RVA: 0x001F2B72 File Offset: 0x001F0D72
		public ScreenSpaceReflectionModel.Settings settings
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

		// Token: 0x0600234E RID: 9038 RVA: 0x001F2B7B File Offset: 0x001F0D7B
		public override void Reset()
		{
			this.m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;
		}

		// Token: 0x04004AE9 RID: 19177
		[SerializeField]
		private ScreenSpaceReflectionModel.Settings m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;

		// Token: 0x020006CD RID: 1741
		public enum SSRResolution
		{
			// Token: 0x04005169 RID: 20841
			High,
			// Token: 0x0400516A RID: 20842
			Low = 2
		}

		// Token: 0x020006CE RID: 1742
		public enum SSRReflectionBlendType
		{
			// Token: 0x0400516C RID: 20844
			PhysicallyBased,
			// Token: 0x0400516D RID: 20845
			Additive
		}

		// Token: 0x020006CF RID: 1743
		[Serializable]
		public struct IntensitySettings
		{
			// Token: 0x0400516E RID: 20846
			[Tooltip("Nonphysical multiplier for the SSR reflections. 1.0 is physically based.")]
			[Range(0f, 2f)]
			public float reflectionMultiplier;

			// Token: 0x0400516F RID: 20847
			[Tooltip("How far away from the maxDistance to begin fading SSR.")]
			[Range(0f, 1000f)]
			public float fadeDistance;

			// Token: 0x04005170 RID: 20848
			[Tooltip("Amplify Fresnel fade out. Increase if floor reflections look good close to the surface and bad farther 'under' the floor.")]
			[Range(0f, 1f)]
			public float fresnelFade;

			// Token: 0x04005171 RID: 20849
			[Tooltip("Higher values correspond to a faster Fresnel fade as the reflection changes from the grazing angle.")]
			[Range(0.1f, 10f)]
			public float fresnelFadePower;
		}

		// Token: 0x020006D0 RID: 1744
		[Serializable]
		public struct ReflectionSettings
		{
			// Token: 0x04005172 RID: 20850
			[Tooltip("How the reflections are blended into the render.")]
			public ScreenSpaceReflectionModel.SSRReflectionBlendType blendType;

			// Token: 0x04005173 RID: 20851
			[Tooltip("Half resolution SSRR is much faster, but less accurate.")]
			public ScreenSpaceReflectionModel.SSRResolution reflectionQuality;

			// Token: 0x04005174 RID: 20852
			[Tooltip("Maximum reflection distance in world units.")]
			[Range(0.1f, 300f)]
			public float maxDistance;

			// Token: 0x04005175 RID: 20853
			[Tooltip("Max raytracing length.")]
			[Range(16f, 1024f)]
			public int iterationCount;

			// Token: 0x04005176 RID: 20854
			[Tooltip("Log base 2 of ray tracing coarse step size. Higher traces farther, lower gives better quality silhouettes.")]
			[Range(1f, 16f)]
			public int stepSize;

			// Token: 0x04005177 RID: 20855
			[Tooltip("Typical thickness of columns, walls, furniture, and other objects that reflection rays might pass behind.")]
			[Range(0.01f, 10f)]
			public float widthModifier;

			// Token: 0x04005178 RID: 20856
			[Tooltip("Blurriness of reflections.")]
			[Range(0.1f, 8f)]
			public float reflectionBlur;

			// Token: 0x04005179 RID: 20857
			[Tooltip("Disable for a performance gain in scenes where most glossy objects are horizontal, like floors, water, and tables. Leave on for scenes with glossy vertical objects.")]
			public bool reflectBackfaces;
		}

		// Token: 0x020006D1 RID: 1745
		[Serializable]
		public struct ScreenEdgeMask
		{
			// Token: 0x0400517A RID: 20858
			[Tooltip("Higher = fade out SSRR near the edge of the screen so that reflections don't pop under camera motion.")]
			[Range(0f, 1f)]
			public float intensity;
		}

		// Token: 0x020006D2 RID: 1746
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A1 RID: 1441
			// (get) Token: 0x06002746 RID: 10054 RVA: 0x002019BC File Offset: 0x001FFBBC
			public static ScreenSpaceReflectionModel.Settings defaultSettings
			{
				get
				{
					return new ScreenSpaceReflectionModel.Settings
					{
						reflection = new ScreenSpaceReflectionModel.ReflectionSettings
						{
							blendType = ScreenSpaceReflectionModel.SSRReflectionBlendType.PhysicallyBased,
							reflectionQuality = ScreenSpaceReflectionModel.SSRResolution.Low,
							maxDistance = 100f,
							iterationCount = 256,
							stepSize = 3,
							widthModifier = 0.5f,
							reflectionBlur = 1f,
							reflectBackfaces = false
						},
						intensity = new ScreenSpaceReflectionModel.IntensitySettings
						{
							reflectionMultiplier = 1f,
							fadeDistance = 100f,
							fresnelFade = 1f,
							fresnelFadePower = 1f
						},
						screenEdgeMask = new ScreenSpaceReflectionModel.ScreenEdgeMask
						{
							intensity = 0.03f
						}
					};
				}
			}

			// Token: 0x0400517B RID: 20859
			public ScreenSpaceReflectionModel.ReflectionSettings reflection;

			// Token: 0x0400517C RID: 20860
			public ScreenSpaceReflectionModel.IntensitySettings intensity;

			// Token: 0x0400517D RID: 20861
			public ScreenSpaceReflectionModel.ScreenEdgeMask screenEdgeMask;
		}
	}
}
