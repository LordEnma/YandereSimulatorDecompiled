using System;
using UnityEngine;

// Token: 0x02000167 RID: 359
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/FullColors")]
public class CameraFilterPack_Colors_Adjust_FullColors : MonoBehaviour
{
	// Token: 0x1700026C RID: 620
	// (get) Token: 0x06000D29 RID: 3369 RVA: 0x00074A73 File Offset: 0x00072C73
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

	// Token: 0x06000D2A RID: 3370 RVA: 0x00074AA7 File Offset: 0x00072CA7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Adjust_FullColors");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x00074AC8 File Offset: 0x00072CC8
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
			this.material.SetFloat("_Red_R", this.Red_R / 100f);
			this.material.SetFloat("_Red_G", this.Red_G / 100f);
			this.material.SetFloat("_Red_B", this.Red_B / 100f);
			this.material.SetFloat("_Green_R", this.Green_R / 100f);
			this.material.SetFloat("_Green_G", this.Green_G / 100f);
			this.material.SetFloat("_Green_B", this.Green_B / 100f);
			this.material.SetFloat("_Blue_R", this.Blue_R / 100f);
			this.material.SetFloat("_Blue_G", this.Blue_G / 100f);
			this.material.SetFloat("_Blue_B", this.Blue_B / 100f);
			this.material.SetFloat("_Red_C", this.Red_Constant / 100f);
			this.material.SetFloat("_Green_C", this.Green_Constant / 100f);
			this.material.SetFloat("_Blue_C", this.Blue_Constant / 100f);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D2C RID: 3372 RVA: 0x00074CB8 File Offset: 0x00072EB8
	private void Update()
	{
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x00074CC0 File Offset: 0x00072EC0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400116B RID: 4459
	public Shader SCShader;

	// Token: 0x0400116C RID: 4460
	private float TimeX = 1f;

	// Token: 0x0400116D RID: 4461
	private Material SCMaterial;

	// Token: 0x0400116E RID: 4462
	[Range(-200f, 200f)]
	public float Red_R = 100f;

	// Token: 0x0400116F RID: 4463
	[Range(-200f, 200f)]
	public float Red_G;

	// Token: 0x04001170 RID: 4464
	[Range(-200f, 200f)]
	public float Red_B;

	// Token: 0x04001171 RID: 4465
	[Range(-200f, 200f)]
	public float Red_Constant;

	// Token: 0x04001172 RID: 4466
	[Range(-200f, 200f)]
	public float Green_R;

	// Token: 0x04001173 RID: 4467
	[Range(-200f, 200f)]
	public float Green_G = 100f;

	// Token: 0x04001174 RID: 4468
	[Range(-200f, 200f)]
	public float Green_B;

	// Token: 0x04001175 RID: 4469
	[Range(-200f, 200f)]
	public float Green_Constant;

	// Token: 0x04001176 RID: 4470
	[Range(-200f, 200f)]
	public float Blue_R;

	// Token: 0x04001177 RID: 4471
	[Range(-200f, 200f)]
	public float Blue_G;

	// Token: 0x04001178 RID: 4472
	[Range(-200f, 200f)]
	public float Blue_B = 100f;

	// Token: 0x04001179 RID: 4473
	[Range(-200f, 200f)]
	public float Blue_Constant;
}
