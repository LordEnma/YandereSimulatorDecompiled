using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056B RID: 1387
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06002355 RID: 9045 RVA: 0x001F861C File Offset: 0x001F681C
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x06002356 RID: 9046 RVA: 0x001F868C File Offset: 0x001F688C
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x06002357 RID: 9047 RVA: 0x001F8710 File Offset: 0x001F6910
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006B0 RID: 1712
		private static class Uniforms
		{
			// Token: 0x0400517A RID: 20858
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x0400517B RID: 20859
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
