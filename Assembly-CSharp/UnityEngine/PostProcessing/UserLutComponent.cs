using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x02000566 RID: 1382
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FF RID: 1279
		// (get) Token: 0x06002345 RID: 9029 RVA: 0x001F6DAC File Offset: 0x001F4FAC
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x06002346 RID: 9030 RVA: 0x001F6E1C File Offset: 0x001F501C
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x06002347 RID: 9031 RVA: 0x001F6EA0 File Offset: 0x001F50A0
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006AB RID: 1707
		private static class Uniforms
		{
			// Token: 0x04005148 RID: 20808
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x04005149 RID: 20809
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
