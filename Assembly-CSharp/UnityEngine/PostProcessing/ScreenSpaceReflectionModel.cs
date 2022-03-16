using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000574 RID: 1396
	[Serializable]
	public class ScreenSpaceReflectionModel : PostProcessingModel
	{
		// Token: 0x17000510 RID: 1296
		// (get) Token: 0x06002383 RID: 9091 RVA: 0x001F72FA File Offset: 0x001F54FA
		// (set) Token: 0x06002384 RID: 9092 RVA: 0x001F7302 File Offset: 0x001F5502
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

		// Token: 0x06002385 RID: 9093 RVA: 0x001F730B File Offset: 0x001F550B
		public override void Reset()
		{
			this.m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;
		}

		// Token: 0x04004B92 RID: 19346
		[SerializeField]
		private ScreenSpaceReflectionModel.Settings m_Settings = ScreenSpaceReflectionModel.Settings.defaultSettings;

		// Token: 0x020006D0 RID: 1744
		public enum SSRResolution
		{
			// Token: 0x040051E9 RID: 20969
			High,
			// Token: 0x040051EA RID: 20970
			Low = 2
		}

		// Token: 0x020006D1 RID: 1745
		public enum SSRReflectionBlendType
		{
			// Token: 0x040051EC RID: 20972
			PhysicallyBased,
			// Token: 0x040051ED RID: 20973
			Additive
		}

		// Token: 0x020006D2 RID: 1746
		[Serializable]
		public struct IntensitySettings
		{
			// Token: 0x040051EE RID: 20974
			[Tooltip("Nonphysical multiplier for the SSR reflections. 1.0 is physically based.")]
			[Range(0f, 2f)]
			public float reflectionMultiplier;

			// Token: 0x040051EF RID: 20975
			[Tooltip("How far away from the maxDistance to begin fading SSR.")]
			[Range(0f, 1000f)]
			public float fadeDistance;

			// Token: 0x040051F0 RID: 20976
			[Tooltip("Amplify Fresnel fade out. Increase if floor reflections look good close to the surface and bad farther 'under' the floor.")]
			[Range(0f, 1f)]
			public float fresnelFade;

			// Token: 0x040051F1 RID: 20977
			[Tooltip("Higher values correspond to a faster Fresnel fade as the reflection changes from the grazing angle.")]
			[Range(0.1f, 10f)]
			public float fresnelFadePower;
		}

		// Token: 0x020006D3 RID: 1747
		[Serializable]
		public struct ReflectionSettings
		{
			// Token: 0x040051F2 RID: 20978
			[Tooltip("How the reflections are blended into the render.")]
			public ScreenSpaceReflectionModel.SSRReflectionBlendType blendType;

			// Token: 0x040051F3 RID: 20979
			[Tooltip("Half resolution SSRR is much faster, but less accurate.")]
			public ScreenSpaceReflectionModel.SSRResolution reflectionQuality;

			// Token: 0x040051F4 RID: 20980
			[Tooltip("Maximum reflection distance in world units.")]
			[Range(0.1f, 300f)]
			public float maxDistance;

			// Token: 0x040051F5 RID: 20981
			[Tooltip("Max raytracing length.")]
			[Range(16f, 1024f)]
			public int iterationCount;

			// Token: 0x040051F6 RID: 20982
			[Tooltip("Log base 2 of ray tracing coarse step size. Higher traces farther, lower gives better quality silhouettes.")]
			[Range(1f, 16f)]
			public int stepSize;

			// Token: 0x040051F7 RID: 20983
			[Tooltip("Typical thickness of columns, walls, furniture, and other objects that reflection rays might pass behind.")]
			[Range(0.01f, 10f)]
			public float widthModifier;

			// Token: 0x040051F8 RID: 20984
			[Tooltip("Blurriness of reflections.")]
			[Range(0.1f, 8f)]
			public float reflectionBlur;

			// Token: 0x040051F9 RID: 20985
			[Tooltip("Disable for a performance gain in scenes where most glossy objects are horizontal, like floors, water, and tables. Leave on for scenes with glossy vertical objects.")]
			public bool reflectBackfaces;
		}

		// Token: 0x020006D4 RID: 1748
		[Serializable]
		public struct ScreenEdgeMask
		{
			// Token: 0x040051FA RID: 20986
			[Tooltip("Higher = fade out SSRR near the edge of the screen so that reflections don't pop under camera motion.")]
			[Range(0f, 1f)]
			public float intensity;
		}

		// Token: 0x020006D5 RID: 1749
		[Serializable]
		public struct Settings
		{
			// Token: 0x170005A6 RID: 1446
			// (get) Token: 0x06002772 RID: 10098 RVA: 0x00205B30 File Offset: 0x00203D30
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

			// Token: 0x040051FB RID: 20987
			public ScreenSpaceReflectionModel.ReflectionSettings reflection;

			// Token: 0x040051FC RID: 20988
			public ScreenSpaceReflectionModel.IntensitySettings intensity;

			// Token: 0x040051FD RID: 20989
			public ScreenSpaceReflectionModel.ScreenEdgeMask screenEdgeMask;
		}
	}
}
