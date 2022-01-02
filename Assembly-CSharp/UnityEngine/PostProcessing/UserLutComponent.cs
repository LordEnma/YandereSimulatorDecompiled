using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x06002301 RID: 8961 RVA: 0x001F0FAC File Offset: 0x001EF1AC
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x06002302 RID: 8962 RVA: 0x001F101C File Offset: 0x001EF21C
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x06002303 RID: 8963 RVA: 0x001F10A0 File Offset: 0x001EF2A0
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006A5 RID: 1701
		private static class Uniforms
		{
			// Token: 0x040050AD RID: 20653
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x040050AE RID: 20654
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
