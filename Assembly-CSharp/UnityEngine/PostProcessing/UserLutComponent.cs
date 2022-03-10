using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000562 RID: 1378
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FE RID: 1278
		// (get) Token: 0x0600232D RID: 9005 RVA: 0x001F4E44 File Offset: 0x001F3044
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x0600232E RID: 9006 RVA: 0x001F4EB4 File Offset: 0x001F30B4
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x0600232F RID: 9007 RVA: 0x001F4F38 File Offset: 0x001F3138
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006A7 RID: 1703
		private static class Uniforms
		{
			// Token: 0x040050E9 RID: 20713
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x040050EA RID: 20714
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
