using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055E RID: 1374
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FC RID: 1276
		// (get) Token: 0x0600230C RID: 8972 RVA: 0x001F194C File Offset: 0x001EFB4C
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x0600230D RID: 8973 RVA: 0x001F19BC File Offset: 0x001EFBBC
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x0600230E RID: 8974 RVA: 0x001F1A40 File Offset: 0x001EFC40
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006A7 RID: 1703
		private static class Uniforms
		{
			// Token: 0x040050C1 RID: 20673
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x040050C2 RID: 20674
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
