using System;
using UnityEngine;

// Token: 0x02000168 RID: 360
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/FullColors")]
public class CameraFilterPack_Colors_Adjust_FullColors : MonoBehaviour
{
	// Token: 0x1700026C RID: 620
	// (get) Token: 0x06000D2D RID: 3373 RVA: 0x00075017 File Offset: 0x00073217
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

	// Token: 0x06000D2E RID: 3374 RVA: 0x0007504B File Offset: 0x0007324B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Adjust_FullColors");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D2F RID: 3375 RVA: 0x0007506C File Offset: 0x0007326C
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

	// Token: 0x06000D30 RID: 3376 RVA: 0x0007525C File Offset: 0x0007345C
	private void Update()
	{
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000D31 RID: 3377 RVA: 0x00075264 File Offset: 0x00073464
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400117C RID: 4476
	public Shader SCShader;

	// Token: 0x0400117D RID: 4477
	private float TimeX = 1f;

	// Token: 0x0400117E RID: 4478
	private Material SCMaterial;

	// Token: 0x0400117F RID: 4479
	[Range(-200f, 200f)]
	public float Red_R = 100f;

	// Token: 0x04001180 RID: 4480
	[Range(-200f, 200f)]
	public float Red_G;

	// Token: 0x04001181 RID: 4481
	[Range(-200f, 200f)]
	public float Red_B;

	// Token: 0x04001182 RID: 4482
	[Range(-200f, 200f)]
	public float Red_Constant;

	// Token: 0x04001183 RID: 4483
	[Range(-200f, 200f)]
	public float Green_R;

	// Token: 0x04001184 RID: 4484
	[Range(-200f, 200f)]
	public float Green_G = 100f;

	// Token: 0x04001185 RID: 4485
	[Range(-200f, 200f)]
	public float Green_B;

	// Token: 0x04001186 RID: 4486
	[Range(-200f, 200f)]
	public float Green_Constant;

	// Token: 0x04001187 RID: 4487
	[Range(-200f, 200f)]
	public float Blue_R;

	// Token: 0x04001188 RID: 4488
	[Range(-200f, 200f)]
	public float Blue_G;

	// Token: 0x04001189 RID: 4489
	[Range(-200f, 200f)]
	public float Blue_B = 100f;

	// Token: 0x0400118A RID: 4490
	[Range(-200f, 200f)]
	public float Blue_Constant;
}
