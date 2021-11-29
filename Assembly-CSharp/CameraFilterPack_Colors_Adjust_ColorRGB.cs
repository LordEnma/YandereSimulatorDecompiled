using System;
using UnityEngine;

// Token: 0x02000166 RID: 358
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/ColorsAdjust/ColorRGB")]
public class CameraFilterPack_Colors_Adjust_ColorRGB : MonoBehaviour
{
	// Token: 0x1700026B RID: 619
	// (get) Token: 0x06000D23 RID: 3363 RVA: 0x000748F5 File Offset: 0x00072AF5
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

	// Token: 0x06000D24 RID: 3364 RVA: 0x00074929 File Offset: 0x00072B29
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Adjust_ColorRGB");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D25 RID: 3365 RVA: 0x0007494C File Offset: 0x00072B4C
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

	// Token: 0x06000D26 RID: 3366 RVA: 0x00074A44 File Offset: 0x00072C44
	private void Update()
	{
	}

	// Token: 0x06000D27 RID: 3367 RVA: 0x00074A46 File Offset: 0x00072C46
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001164 RID: 4452
	public Shader SCShader;

	// Token: 0x04001165 RID: 4453
	private float TimeX = 1f;

	// Token: 0x04001166 RID: 4454
	private Material SCMaterial;

	// Token: 0x04001167 RID: 4455
	[Range(-2f, 2f)]
	public float Red;

	// Token: 0x04001168 RID: 4456
	[Range(-2f, 2f)]
	public float Green;

	// Token: 0x04001169 RID: 4457
	[Range(-2f, 2f)]
	public float Blue;

	// Token: 0x0400116A RID: 4458
	[Range(-1f, 1f)]
	public float Brightness;
}
