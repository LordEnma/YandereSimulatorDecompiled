using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056E RID: 1390
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x17000501 RID: 1281
		// (get) Token: 0x06002378 RID: 9080 RVA: 0x001FC180 File Offset: 0x001FA380
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x06002379 RID: 9081 RVA: 0x001FC1F0 File Offset: 0x001FA3F0
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x0600237A RID: 9082 RVA: 0x001FC274 File Offset: 0x001FA474
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006B3 RID: 1715
		private static class Uniforms
		{
			// Token: 0x040051D5 RID: 20949
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x040051D6 RID: 20950
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
