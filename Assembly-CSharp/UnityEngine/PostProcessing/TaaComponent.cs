using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000559 RID: 1369
	public sealed class TaaComponent : PostProcessingComponentRenderTexture<AntialiasingModel>
	{
		// Token: 0x170004F9 RID: 1273
		// (get) Token: 0x060022E0 RID: 8928 RVA: 0x001EEB30 File Offset: 0x001ECD30
		public override bool active
		{
			get
			{
				return base.model.enabled && base.model.settings.method == AntialiasingModel.Method.Taa && SystemInfo.supportsMotionVectors && SystemInfo.supportedRenderTargetCount >= 2 && !this.context.interrupted;
			}
		}

		// Token: 0x060022E1 RID: 8929 RVA: 0x001EEB7C File Offset: 0x001ECD7C
		public override DepthTextureMode GetCameraFlags()
		{
			return DepthTextureMode.Depth | DepthTextureMode.MotionVectors;
		}

		// Token: 0x170004FA RID: 1274
		// (get) Token: 0x060022E2 RID: 8930 RVA: 0x001EEB7F File Offset: 0x001ECD7F
		// (set) Token: 0x060022E3 RID: 8931 RVA: 0x001EEB87 File Offset: 0x001ECD87
		public Vector2 jitterVector { get; private set; }

		// Token: 0x060022E4 RID: 8932 RVA: 0x001EEB90 File Offset: 0x001ECD90
		public void ResetHistory()
		{
			this.m_ResetHistory = true;
		}

		// Token: 0x060022E5 RID: 8933 RVA: 0x001EEB9C File Offset: 0x001ECD9C
		public void SetProjectionMatrix(Func<Vector2, Matrix4x4> jitteredFunc)
		{
			AntialiasingModel.TaaSettings taaSettings = base.model.settings.taaSettings;
			Vector2 vector = this.GenerateRandomOffset();
			vector *= taaSettings.jitterSpread;
			this.context.camera.nonJitteredProjectionMatrix = this.context.camera.projectionMatrix;
			if (jitteredFunc != null)
			{
				this.context.camera.projectionMatrix = jitteredFunc(vector);
			}
			else
			{
				this.context.camera.projectionMatrix = (this.context.camera.orthographic ? this.GetOrthographicProjectionMatrix(vector) : this.GetPerspectiveProjectionMatrix(vector));
			}
			this.context.camera.useJitteredProjectionMatrixForTransparentRendering = false;
			vector.x /= (float)this.context.width;
			vector.y /= (float)this.context.height;
			this.context.materialFactory.Get("Hidden/Post FX/Temporal Anti-aliasing").SetVector(TaaComponent.Uniforms._Jitter, vector);
			this.jitterVector = vector;
		}

		// Token: 0x060022E6 RID: 8934 RVA: 0x001EECA8 File Offset: 0x001ECEA8
		public void Render(RenderTexture source, RenderTexture destination)
		{
			Material material = this.context.materialFactory.Get("Hidden/Post FX/Temporal Anti-aliasing");
			material.shaderKeywords = null;
			AntialiasingModel.TaaSettings taaSettings = base.model.settings.taaSettings;
			if (this.m_ResetHistory || this.m_HistoryTexture == null || this.m_HistoryTexture.width != source.width || this.m_HistoryTexture.height != source.height)
			{
				if (this.m_HistoryTexture)
				{
					RenderTexture.ReleaseTemporary(this.m_HistoryTexture);
				}
				this.m_HistoryTexture = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
				this.m_HistoryTexture.name = "TAA History";
				Graphics.Blit(source, this.m_HistoryTexture, material, 2);
			}
			material.SetVector(TaaComponent.Uniforms._SharpenParameters, new Vector4(taaSettings.sharpen, 0f, 0f, 0f));
			material.SetVector(TaaComponent.Uniforms._FinalBlendParameters, new Vector4(taaSettings.stationaryBlending, taaSettings.motionBlending, 6000f, 0f));
			material.SetTexture(TaaComponent.Uniforms._MainTex, source);
			material.SetTexture(TaaComponent.Uniforms._HistoryTex, this.m_HistoryTexture);
			RenderTexture temporary = RenderTexture.GetTemporary(source.width, source.height, 0, source.format);
			temporary.name = "TAA History";
			this.m_MRT[0] = destination.colorBuffer;
			this.m_MRT[1] = temporary.colorBuffer;
			Graphics.SetRenderTarget(this.m_MRT, source.depthBuffer);
			GraphicsUtils.Blit(material, this.context.camera.orthographic ? 1 : 0);
			RenderTexture.ReleaseTemporary(this.m_HistoryTexture);
			this.m_HistoryTexture = temporary;
			this.m_ResetHistory = false;
		}

		// Token: 0x060022E7 RID: 8935 RVA: 0x001EEE6C File Offset: 0x001ED06C
		private float GetHaltonValue(int index, int radix)
		{
			float num = 0f;
			float num2 = 1f / (float)radix;
			while (index > 0)
			{
				num += (float)(index % radix) * num2;
				index /= radix;
				num2 /= (float)radix;
			}
			return num;
		}

		// Token: 0x060022E8 RID: 8936 RVA: 0x001EEEA4 File Offset: 0x001ED0A4
		private Vector2 GenerateRandomOffset()
		{
			Vector2 result = new Vector2(this.GetHaltonValue(this.m_SampleIndex & 1023, 2), this.GetHaltonValue(this.m_SampleIndex & 1023, 3));
			int num = this.m_SampleIndex + 1;
			this.m_SampleIndex = num;
			if (num >= 8)
			{
				this.m_SampleIndex = 0;
			}
			return result;
		}

		// Token: 0x060022E9 RID: 8937 RVA: 0x001EEEF8 File Offset: 0x001ED0F8
		private Matrix4x4 GetPerspectiveProjectionMatrix(Vector2 offset)
		{
			float num = Mathf.Tan(0.008726646f * this.context.camera.fieldOfView);
			float num2 = num * this.context.camera.aspect;
			offset.x *= num2 / (0.5f * (float)this.context.width);
			offset.y *= num / (0.5f * (float)this.context.height);
			float num3 = (offset.x - num2) * this.context.camera.nearClipPlane;
			float num4 = (offset.x + num2) * this.context.camera.nearClipPlane;
			float num5 = (offset.y + num) * this.context.camera.nearClipPlane;
			float num6 = (offset.y - num) * this.context.camera.nearClipPlane;
			Matrix4x4 result = default(Matrix4x4);
			result[0, 0] = 2f * this.context.camera.nearClipPlane / (num4 - num3);
			result[0, 1] = 0f;
			result[0, 2] = (num4 + num3) / (num4 - num3);
			result[0, 3] = 0f;
			result[1, 0] = 0f;
			result[1, 1] = 2f * this.context.camera.nearClipPlane / (num5 - num6);
			result[1, 2] = (num5 + num6) / (num5 - num6);
			result[1, 3] = 0f;
			result[2, 0] = 0f;
			result[2, 1] = 0f;
			result[2, 2] = -(this.context.camera.farClipPlane + this.context.camera.nearClipPlane) / (this.context.camera.farClipPlane - this.context.camera.nearClipPlane);
			result[2, 3] = -(2f * this.context.camera.farClipPlane * this.context.camera.nearClipPlane) / (this.context.camera.farClipPlane - this.context.camera.nearClipPlane);
			result[3, 0] = 0f;
			result[3, 1] = 0f;
			result[3, 2] = -1f;
			result[3, 3] = 0f;
			return result;
		}

		// Token: 0x060022EA RID: 8938 RVA: 0x001EF180 File Offset: 0x001ED380
		private Matrix4x4 GetOrthographicProjectionMatrix(Vector2 offset)
		{
			float orthographicSize = this.context.camera.orthographicSize;
			float num = orthographicSize * this.context.camera.aspect;
			offset.x *= num / (0.5f * (float)this.context.width);
			offset.y *= orthographicSize / (0.5f * (float)this.context.height);
			float left = offset.x - num;
			float right = offset.x + num;
			float top = offset.y + orthographicSize;
			float bottom = offset.y - orthographicSize;
			return Matrix4x4.Ortho(left, right, bottom, top, this.context.camera.nearClipPlane, this.context.camera.farClipPlane);
		}

		// Token: 0x060022EB RID: 8939 RVA: 0x001EF23C File Offset: 0x001ED43C
		public override void OnDisable()
		{
			if (this.m_HistoryTexture != null)
			{
				RenderTexture.ReleaseTemporary(this.m_HistoryTexture);
			}
			this.m_HistoryTexture = null;
			this.m_SampleIndex = 0;
			this.ResetHistory();
		}

		// Token: 0x04004A71 RID: 19057
		private const string k_ShaderString = "Hidden/Post FX/Temporal Anti-aliasing";

		// Token: 0x04004A72 RID: 19058
		private const int k_SampleCount = 8;

		// Token: 0x04004A73 RID: 19059
		private readonly RenderBuffer[] m_MRT = new RenderBuffer[2];

		// Token: 0x04004A74 RID: 19060
		private int m_SampleIndex;

		// Token: 0x04004A75 RID: 19061
		private bool m_ResetHistory = true;

		// Token: 0x04004A76 RID: 19062
		private RenderTexture m_HistoryTexture;

		// Token: 0x020006A1 RID: 1697
		private static class Uniforms
		{
			// Token: 0x04005054 RID: 20564
			internal static int _Jitter = Shader.PropertyToID("_Jitter");

			// Token: 0x04005055 RID: 20565
			internal static int _SharpenParameters = Shader.PropertyToID("_SharpenParameters");

			// Token: 0x04005056 RID: 20566
			internal static int _FinalBlendParameters = Shader.PropertyToID("_FinalBlendParameters");

			// Token: 0x04005057 RID: 20567
			internal static int _HistoryTex = Shader.PropertyToID("_HistoryTex");

			// Token: 0x04005058 RID: 20568
			internal static int _MainTex = Shader.PropertyToID("_MainTex");
		}
	}
}
