using System;

namespace UnityEngine.PostProcessing
{
	// Token: 0x0200056C RID: 1388
	public sealed class UserLutComponent : PostProcessingComponentRenderTexture<UserLutModel>
	{
		// Token: 0x17000500 RID: 1280
		// (get) Token: 0x06002364 RID: 9060 RVA: 0x001F95A8 File Offset: 0x001F77A8
		public override bool active
		{
			get
			{
				UserLutModel.Settings settings = base.model.settings;
				return base.model.enabled && settings.lut != null && settings.contribution > 0f && settings.lut.height == (int)Mathf.Sqrt((float)settings.lut.width) && !this.context.interrupted;
			}
		}

		// Token: 0x06002365 RID: 9061 RVA: 0x001F9618 File Offset: 0x001F7818
		public override void Prepare(Material uberMaterial)
		{
			UserLutModel.Settings settings = base.model.settings;
			uberMaterial.EnableKeyword("USER_LUT");
			uberMaterial.SetTexture(UserLutComponent.Uniforms._UserLut, settings.lut);
			uberMaterial.SetVector(UserLutComponent.Uniforms._UserLut_Params, new Vector4(1f / (float)settings.lut.width, 1f / (float)settings.lut.height, (float)settings.lut.height - 1f, settings.contribution));
		}

		// Token: 0x06002366 RID: 9062 RVA: 0x001F969C File Offset: 0x001F789C
		public void OnGUI()
		{
			UserLutModel.Settings settings = base.model.settings;
			GUI.DrawTexture(new Rect(this.context.viewport.x * (float)Screen.width + 8f, 8f, (float)settings.lut.width, (float)settings.lut.height), settings.lut);
		}

		// Token: 0x020006B1 RID: 1713
		private static class Uniforms
		{
			// Token: 0x04005190 RID: 20880
			internal static readonly int _UserLut = Shader.PropertyToID("_UserLut");

			// Token: 0x04005191 RID: 20881
			internal static readonly int _UserLut_Params = Shader.PropertyToID("_UserLut_Params");
		}
	}
}
