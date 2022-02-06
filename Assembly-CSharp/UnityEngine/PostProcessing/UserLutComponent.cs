using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055F RID: 1375
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FD RID: 1277
		// (get) Token: 0x06002317 RID: 8983 RVA: 0x001F33D8 File Offset: 0x001F15D8
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x06002318 RID: 8984 RVA: 0x001F3448 File Offset: 0x001F1648
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x06002319 RID: 8985 RVA: 0x001F34CC File Offset: 0x001F16CC
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006A2 RID: 1698
		private static class Uniforms
		{
			// Token: 0x040050AE RID: 20654
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x040050AF RID: 20655
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
