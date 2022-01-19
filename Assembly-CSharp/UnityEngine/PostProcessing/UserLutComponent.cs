using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055F RID: 1375
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x0600230E RID: 8974 RVA: 0x001F261C File Offset: 0x001F081C
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x0600230F RID: 8975 RVA: 0x001F268C File Offset: 0x001F088C
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x06002310 RID: 8976 RVA: 0x001F2710 File Offset: 0x001F0910
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006A8 RID: 1704
		private static class Uniforms
		{
			// Token: 0x040050C8 RID: 20680
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x040050C9 RID: 20681
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
