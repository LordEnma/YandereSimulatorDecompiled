using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055C RID: 1372
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x060022FE RID: 8958 RVA: 0x001F09BC File Offset: 0x001EEBBC
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x060022FF RID: 8959 RVA: 0x001F0A2C File Offset: 0x001EEC2C
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x06002300 RID: 8960 RVA: 0x001F0AB0 File Offset: 0x001EECB0
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006A5 RID: 1701
		private static class Uniforms
		{
			// Token: 0x040050A4 RID: 20644
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x040050A5 RID: 20645
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
