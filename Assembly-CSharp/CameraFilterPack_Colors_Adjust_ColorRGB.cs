using System;
using UnityEngine;

// Token: 0x02000167 RID: 359
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/ColorRGB")]
public class CameraFilterPack_Colors_Adjust_ColorRGB : MonoBehaviour
{
	// Token: 0x1700026B RID: 619
	// (get) Token: 0x06000D27 RID: 3367 RVA: 0x00074C3D File Offset: 0x00072E3D
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

	// Token: 0x06000D28 RID: 3368 RVA: 0x00074C71 File Offset: 0x00072E71
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Adjust_ColorRGB");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D29 RID: 3369 RVA: 0x00074C94 File Offset: 0x00072E94
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

	// Token: 0x06000D2A RID: 3370 RVA: 0x00074D8C File Offset: 0x00072F8C
	private void Update()
	{
	}

	// Token: 0x06000D2B RID: 3371 RVA: 0x00074D8E File Offset: 0x00072F8E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400116C RID: 4460
	public Shader SCShader;

	// Token: 0x0400116D RID: 4461
	private float TimeX = 1f;

	// Token: 0x0400116E RID: 4462
	private Material SCMaterial;

	// Token: 0x0400116F RID: 4463
	[Range(-2f, 2f)]
	public float Red;

	// Token: 0x04001170 RID: 4464
	[Range(-2f, 2f)]
	public float Green;

	// Token: 0x04001171 RID: 4465
	[Range(-2f, 2f)]
	public float Blue;

	// Token: 0x04001172 RID: 4466
	[Range(-1f, 1f)]
	public float Brightness;
}
