using System;
using UnityEngine;

// Token: 0x02000167 RID: 359
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/ColorRGB")]
public class CameraFilterPack_Colors_Adjust_ColorRGB : MonoBehaviour
{
	// Token: 0x1700026B RID: 619
	// (get) Token: 0x06000D29 RID: 3369 RVA: 0x00075315 File Offset: 0x00073515
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

	// Token: 0x06000D2A RID: 3370 RVA: 0x00075349 File Offset: 0x00073549
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Adjust_ColorRGB");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x0007536C File Offset: 0x0007356C
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

	// Token: 0x06000D2C RID: 3372 RVA: 0x00075464 File Offset: 0x00073664
	private void Update()
	{
	}

	// Token: 0x06000D2D RID: 3373 RVA: 0x00075466 File Offset: 0x00073666
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
	[Range(-2f, 2f)]
	public float Red;

	// Token: 0x04001180 RID: 4480
	[Range(-2f, 2f)]
	public float Green;

	// Token: 0x04001181 RID: 4481
	[Range(-2f, 2f)]
	public float Blue;

	// Token: 0x04001182 RID: 4482
	[Range(-1f, 1f)]
	public float Brightness;
}
