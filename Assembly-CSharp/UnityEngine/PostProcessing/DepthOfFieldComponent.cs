using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000551 RID: 1361
	public sealed class DepthOfFieldComponent : PostProcessingComponentRenderTexture<DepthOfFieldModel>
	{
		// Token: 0x170004EF RID: 1263
		// (get) Token: 0x060022AB RID: 8875 RVA: 0x001ED1B7 File Offset: 0x001EB3B7
		public override bool active
		{
			get
			{
				return base.model.enabled && !this.context.interrupted;
			}
		}

		// Token: 0x060022AC RID: 8876 RVA: 0x001ED1D6 File Offset: 0x001EB3D6
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth;
		}

		// Token: 0x060022AD RID: 8877 RVA: 0x001ED1DC File Offset: 0x001EB3DC
		private float CalculateFocalLength()
		{
			DepthOfFieldModel.Settings settings = base.model.settings;
			if (!settings.useCameraFov)
			{
				return settings.focalLength / 1000f;
			}
			float num = this.context.camera.fieldOfView * 0.017453292f;
			return 0.012f / Mathf.Tan(0.5f * num);
		}

		// Token: 0x060022AE RID: 8878 RVA: 0x001ED234 File Offset: 0x001EB434
		private float CalculateMaxCoCRadius(int screenHeight)
		{
			float num = (float)base.model.settings.kernelSize * 4f + 6f;
			return Mathf.Min(0.05f, num / (float)screenHeight);
		}

		// Token: 0x060022AF RID: 8879 RVA: 0x001ED26D File Offset: 0x001EB46D
		private bool CheckHistory(int width, int height)
		{
			return this.m_CoCHistory != null && this.m_CoCHistory.IsCreated() && this.m_CoCHistory.width == width && this.m_CoCHistory.height == height;
		}

		// Token: 0x060022B0 RID: 8880 RVA: 0x001ED2A8 File Offset: 0x001EB4A8
		private RenderTextureFormat SelectFormat(RenderTextureFormat primary, RenderTextureFormat secondary)
		{
			if (SystemInfo.SupportsRenderTextureFormat(primary))
			{
				return primary;
			}
			if (SystemInfo.SupportsRenderTextureFormat(secondary))
			{
				return secondary;
			}
			return RenderTextureFormat.Default;
		}

		// Token: 0x060022B1 RID: 8881 RVA: 0x001ED2C0 File Offset: 0x001EB4C0
		public void Prepare(RenderTexture source, Material uberMaterial, bool antialiasCoC, Vector2 taaJitter, float taaBlending)
		{
			DepthOfFieldModel.Settings settings = base.model.settings;
			RenderTextureFormat format = RenderTextureFormat.DefaultHDR;
			RenderTextureFormat format2 = this.SelectFormat(RenderTextureFormat.R8, RenderTextureFormat.RHalf);
			float num = this.CalculateFocalLength();
			float num2 = Mathf.Max(settings.focusDistance, num);
			float num3 = (float)source.width / (float)source.height;
			float num4 = num * num / (settings.aperture * (num2 - num) * 0.024f * 2f);
			float num5 = this.CalculateMaxCoCRadius(source.height);
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Depth Of Field");
			material.SetFloat(DepthOfFieldComponent.Uniforms._Distance, num2);
			material.SetFloat(DepthOfFieldComponent.Uniforms._LensCoeff, num4);
			material.SetFloat(DepthOfFieldComponent.Uniforms._MaxCoC, num5);
			material.SetFloat(DepthOfFieldComponent.Uniforms._RcpMaxCoC, 1f / num5);
			material.SetFloat(DepthOfFieldComponent.Uniforms._RcpAspect, 1f / num3);
			RenderTexture renderTexture = this.context.renderTextureFactory.Get(this.context.width, this.context.height, 0, format2, RenderTextureReadWrite.Linear, FilterMode.Bilinear, TextureWrapMode.Clamp, "FactoryTempTexture");
			Graphics.Blit(null, renderTexture, material, 0);
			if (antialiasCoC)
			{
				material.SetTexture(DepthOfFieldComponent.Uniforms._CoCTex, renderTexture);
				float z = this.CheckHistory(this.context.width, this.context.height) ? taaBlending : 0f;
				material.SetVector(DepthOfFieldComponent.Uniforms._TaaParams, new Vector3(taaJitter.x, taaJitter.y, z));
				RenderTexture temporary = RenderTexture.GetTemporary(this.context.width, this.context.height, 0, format2);
				Graphics.Blit(this.m_CoCHistory, temporary, material, 1);
				this.context.renderTextureFactory.Release(renderTexture);
				if (this.m_CoCHistory != null)
				{
					RenderTexture.ReleaseTemporary(this.m_CoCHistory);
				}
				renderTexture = (this.m_CoCHistory = temporary);
			}
			RenderTexture renderTexture2 = this.context.renderTextureFactory.Get(this.context.width / 2, this.context.height / 2, 0, format, RenderTextureReadWrite.Default, FilterMode.Bilinear, TextureWrapMode.Clamp, "FactoryTempTexture");
			material.SetTexture(DepthOfFieldComponent.Uniforms._CoCTex, renderTexture);
			Graphics.Blit(source, renderTexture2, material, 2);
			RenderTexture renderTexture3 = this.context.renderTextureFactory.Get(this.context.width / 2, this.context.height / 2, 0, format, RenderTextureReadWrite.Default, FilterMode.Bilinear, TextureWrapMode.Clamp, "FactoryTempTexture");
			Graphics.Blit(renderTexture2, renderTexture3, material, (int)(3 + settings.kernelSize));
			Graphics.Blit(renderTexture3, renderTexture2, material, 7);
			uberMaterial.SetVector(DepthOfFieldComponent.Uniforms._DepthOfFieldParams, new Vector3(num2, num4, num5));
			if (this.context.profile.debugViews.IsModeActive(BuiltinDebugViewsModel.Mode.FocusPlane))
			{
				uberMaterial.EnableKeyword("DEPTH_OF_FIELD_COC_VIEW");
				this.context.Interrupt();
			}
			else
			{
				uberMaterial.SetTexture(DepthOfFieldComponent.Uniforms._DepthOfFieldTex, renderTexture2);
				uberMaterial.SetTexture(DepthOfFieldComponent.Uniforms._DepthOfFieldCoCTex, renderTexture);
				uberMaterial.EnableKeyword("DEPTH_OF_FIELD");
			}
			this.context.renderTextureFactory.Release(renderTexture3);
		}

		// Token: 0x060022B2 RID: 8882 RVA: 0x001ED5CC File Offset: 0x001EB7CC
		public override void OnDisable()
		{
			if (this.m_CoCHistory != null)
			{
				RenderTexture.ReleaseTemporary(this.m_CoCHistory);
			}
			this.m_CoCHistory = null;
		}

		// Token: 0x04004A56 RID: 19030
		private const string k_ShaderString = "Hidden/Post FX/Depth Of Field";

		// Token: 0x04004A57 RID: 19031
		private RenderTexture m_CoCHistory;

		// Token: 0x04004A58 RID: 19032
		private const float k_FilmHeight = 0.024f;

		// Token: 0x02000695 RID: 1685
		private static class Uniforms
		{
			// Token: 0x04004FDF RID: 20447
			internal static readonly int _DepthOfFieldTex = Shader.PropertyToID("_DepthOfFieldTex");

			// Token: 0x04004FE0 RID: 20448
			internal static readonly int _DepthOfFieldCoCTex = Shader.PropertyToID("_DepthOfFieldCoCTex");

			// Token: 0x04004FE1 RID: 20449
			internal static readonly int _Distance = Shader.PropertyToID("_Distance");

			// Token: 0x04004FE2 RID: 20450
			internal static readonly int _LensCoeff = Shader.PropertyToID("_LensCoeff");

			// Token: 0x04004FE3 RID: 20451
			internal static readonly int _MaxCoC = Shader.PropertyToID("_MaxCoC");

			// Token: 0x04004FE4 RID: 20452
			internal static readonly int _RcpMaxCoC = Shader.PropertyToID("_RcpMaxCoC");

			// Token: 0x04004FE5 RID: 20453
			internal static readonly int _RcpAspect = Shader.PropertyToID("_RcpAspect");

			// Token: 0x04004FE6 RID: 20454
			internal static readonly int _MainTex = Shader.PropertyToID("_MainTex");

			// Token: 0x04004FE7 RID: 20455
			internal static readonly int _CoCTex = Shader.PropertyToID("_CoCTex");

			// Token: 0x04004FE8 RID: 20456
			internal static readonly int _TaaParams = Shader.PropertyToID("_TaaParams");

			// Token: 0x04004FE9 RID: 20457
			internal static readonly int _DepthOfFieldParams = Shader.PropertyToID("_DepthOfFieldParams");
		}
	}
}
