using System;
using UnityEngine;

// Token: 0x02000167 RID: 359
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/ColorRGB")]
public class CameraFilterPack_Colors_Adjust_ColorRGB : MonoBehaviour
{
	// Token: 0x1700026B RID: 619
	// (get) Token: 0x06000D27 RID: 3367 RVA: 0x00074E99 File Offset: 0x00073099
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

	// Token: 0x06000D28 RID: 3368 RVA: 0x00074ECD File Offset: 0x000730CD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Adjust_ColorRGB");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D29 RID: 3369 RVA: 0x00074EF0 File Offset: 0x000730F0
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
			this.material.SetFloat("_Value", this.Red);
			this.material.SetFloat("_Value2", this.Green);
			this.material.SetFloat("_Value3", this.Blue);
			this.material.SetFloat("_Value4", this.Brightness);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D2A RID: 3370 RVA: 0x00074FE8 File Offset: 0x000731E8
	private void Update()
	{
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x00074FEA File Offset: 0x000731EA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001175 RID: 4469
	public Shader SCShader;

	// Token: 0x04001176 RID: 4470
	private float TimeX = 1f;

	// Token: 0x04001177 RID: 4471
	private Material SCMaterial;

	// Token: 0x04001178 RID: 4472
	[Range(-2f, 2f)]
	public float Red;

	// Token: 0x04001179 RID: 4473
	[Range(-2f, 2f)]
	public float Green;

	// Token: 0x0400117A RID: 4474
	[Range(-2f, 2f)]
	public float Blue;

	// Token: 0x0400117B RID: 4475
	[Range(-1f, 1f)]
	public float Brightness;
}
