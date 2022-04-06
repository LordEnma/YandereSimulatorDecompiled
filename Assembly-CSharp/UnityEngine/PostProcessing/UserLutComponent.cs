using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056C RID: 1388
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x0600235D RID: 9053 RVA: 0x001F8B4C File Offset: 0x001F6D4C
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x0600235E RID: 9054 RVA: 0x001F8BBC File Offset: 0x001F6DBC
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x0600235F RID: 9055 RVA: 0x001F8C40 File Offset: 0x001F6E40
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006B1 RID: 1713
		private static class Uniforms
		{
			// Token: 0x0400517E RID: 20862
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x0400517F RID: 20863
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
