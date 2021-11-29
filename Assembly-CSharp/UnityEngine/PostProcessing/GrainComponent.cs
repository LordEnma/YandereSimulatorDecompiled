using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000556 RID: 1366
	public sealed class GrainComponent : PostProcessingComponentRenderTexture<GrainModel>
	{
		// Token: 0x170004F4 RID: 1268
		// (get) Token: 0x060022CA RID: 8906 RVA: 0x001EDEF6 File Offset: 0x001EC0F6
		public override bool active
		{
			get
			{
				return base.model.enabled && base.model.settings.intensity > 0f && SystemInfo.SupportsRenderTextureFormat(RenderTextureFormat.ARGBHalf) && !this.context.interrupted;
			}
		}

		// Token: 0x060022CB RID: 8907 RVA: 0x001EDF34 File Offset: 0x001EC134
		public override void OnDisable()
		{
			GraphicsUtils.Destroy(this.m_GrainLookupRT);
			this.m_GrainLookupRT = null;
		}

		// Token: 0x060022CC RID: 8908 RVA: 0x001EDF48 File Offset: 0x001EC148
		public override void Prepare(Material uberMaterial)
		{
			GrainModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("GRAIN");
			float realtimeSinceStartup = Time.realtimeSinceStartup;
			float value = Random.value;
			float value2 = Random.value;
			if (this.m_GrainLookupRT == null || !this.m_GrainLookupRT.IsCreated())
			{
				GraphicsUtils.Destroy(this.m_GrainLookupRT);
				this.m_GrainLookupRT = new RenderTexture(192, 192, 0, RenderTextureFormat.ARGBHalf)
				{
					filterMode = FilterMode.Bilinear,
					wrapMode = TextureWrapMode.Repeat,
					anisoLevel = 0,
					name = "Grain Lookup Texture"
				};
				this.m_GrainLookupRT.Create();
			}
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Grain Generator");
			material.SetFloat(GrainComponent.Uniforms._Phase, realtimeSinceStartup / 20f);
			Graphics.Blit(null, this.m_GrainLookupRT, material, settings.colored ? 1 : 0);
			uberMaterial.SetTexture(GrainComponent.Uniforms._GrainTex, this.m_GrainLookupRT);
			uberMaterial.SetVector(GrainComponent.Uniforms._Grain_Params1, new Vector2(settings.luminanceContribution, settings.intensity * 20f));
			uberMaterial.SetVector(GrainComponent.Uniforms._Grain_Params2, new Vector4((float)this.context.width / (float)this.m_GrainLookupRT.width / settings.size, (float)this.context.height / (float)this.m_GrainLookupRT.height / settings.size, value, value2));
		}

		// Token: 0x04004A68 RID: 19048
		private RenderTexture m_GrainLookupRT;

		// Token: 0x0200069A RID: 1690
		private static class Uniforms
		{
			// Token: 0x04004FF9 RID: 20473
			internal static readonly int _Grain_Params1 = Shader.PropertyToID("_Grain_Params1");

			// Token: 0x04004FFA RID: 20474
			internal static readonly int _Grain_Params2 = Shader.PropertyToID("_Grain_Params2");

			// Token: 0x04004FFB RID: 20475
			internal static readonly int _GrainTex = Shader.PropertyToID("_GrainTex");

			// Token: 0x04004FFC RID: 20476
			internal static readonly int _Phase = Shader.PropertyToID("_Phase");
		}
	}
}
