using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200055A RID: 1370
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x170004FB RID: 1275
		// (get) Token: 0x060022ED RID: 8941 RVA: 0x001EF288 File Offset: 0x001ED488
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x060022EE RID: 8942 RVA: 0x001EF2F8 File Offset: 0x001ED4F8
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x060022EF RID: 8943 RVA: 0x001EF37C File Offset: 0x001ED57C
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006A2 RID: 1698
		private static class Uniforms
		{
			// Token: 0x04005059 RID: 20569
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x0400505A RID: 20570
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
