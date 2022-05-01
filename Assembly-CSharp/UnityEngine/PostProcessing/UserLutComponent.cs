using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056D RID: 1389
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x0600236D RID: 9069 RVA: 0x001FAA34 File Offset: 0x001F8C34
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x0600236E RID: 9070 RVA: 0x001FAAA4 File Offset: 0x001F8CA4
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x0600236F RID: 9071 RVA: 0x001FAB28 File Offset: 0x001F8D28
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006B2 RID: 1714
		private static class Uniforms
		{
			// Token: 0x040051AE RID: 20910
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x040051AF RID: 20911
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
