using System;
using UnityEngine;

// Token: 0x020001EB RID: 491
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Night Vision/Night Vision 4")]
public class CameraFilterPack_NightVision_4 : MonoBehaviour
{
	// Token: 0x170002F0 RID: 752
	// (get) Token: 0x06001060 RID: 4192 RVA: 0x00082FAA File Offset: 0x000811AA
	private Material material
	{
		get
		{
			if (this.SCMaterial == null)
			{
				this.SCMaterial = new Material(this.SCShader);
				this.SCMaterial.hideFlags = HideFlags.HideAndDontSave;
			}
			return this.SCMaterial;
		}
	}

	// Token: 0x06001061 RID: 4193 RVA: 0x00082FDE File Offset: 0x000811DE
	private void ChangeFilters()
	{
		this.Matrix9 = new float[]
		{
			200f,
			-200f,
			-200f,
			195f,
			4f,
			-160f,
			200f,
			-200f,
			-200f,
			-200f,
			10f,
			-200f
		};
	}

	// Token: 0x06001062 RID: 4194 RVA: 0x00082FF8 File Offset: 0x000811F8
	private void Start()
	{
		this.ChangeFilters();
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001063 RID: 4195 RVA: 0x00083020 File Offset: 0x00081220
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Red_R", this.Matrix9[0] / 100f);
			this.material.SetFloat("_Red_G", this.Matrix9[1] / 100f);
			this.material.SetFloat("_Red_B", this.Matrix9[2] / 100f);
			this.material.SetFloat("_Green_R", this.Matrix9[3] / 100f);
			this.material.SetFloat("_Green_G", this.Matrix9[4] / 100f);
			this.material.SetFloat("_Green_B", this.Matrix9[5] / 100f);
			this.material.SetFloat("_Blue_R", this.Matrix9[6] / 100f);
			this.material.SetFloat("_Blue_G", this.Matrix9[7] / 100f);
			this.material.SetFloat("_Blue_B", this.Matrix9[8] / 100f);
			this.material.SetFloat("_Red_C", this.Matrix9[9] / 100f);
			this.material.SetFloat("_Green_C", this.Matrix9[10] / 100f);
			this.material.SetFloat("_Blue_C", this.Matrix9[11] / 100f);
			this.material.SetFloat("_FadeFX", this.FadeFX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001064 RID: 4196 RVA: 0x00083241 File Offset: 0x00081441
	private void OnValidate()
	{
		this.ChangeFilters();
	}

	// Token: 0x06001065 RID: 4197 RVA: 0x00083249 File Offset: 0x00081449
	private void Update()
	{
	}

	// Token: 0x06001066 RID: 4198 RVA: 0x0008324B File Offset: 0x0008144B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040014DF RID: 5343
	private string ShaderName = "CameraFilterPack/NightVision_4";

	// Token: 0x040014E0 RID: 5344
	public Shader SCShader;

	// Token: 0x040014E1 RID: 5345
	[Range(0f, 1f)]
	public float FadeFX = 1f;

	// Token: 0x040014E2 RID: 5346
	private float TimeX = 1f;

	// Token: 0x040014E3 RID: 5347
	private Material SCMaterial;

	// Token: 0x040014E4 RID: 5348
	private float[] Matrix9;
}
