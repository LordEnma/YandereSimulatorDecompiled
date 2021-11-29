using System;
using UnityEngine;

// Token: 0x0200015C RID: 348
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Chromatic_Aberration")]
public class CameraFilterPack_Color_Chromatic_Aberration : MonoBehaviour
{
	// Token: 0x17000261 RID: 609
	// (get) Token: 0x06000CE7 RID: 3303 RVA: 0x00073BBE File Offset: 0x00071DBE
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

	// Token: 0x06000CE8 RID: 3304 RVA: 0x00073BF2 File Offset: 0x00071DF2
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Chromatic_Aberration");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CE9 RID: 3305 RVA: 0x00073C14 File Offset: 0x00071E14
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
			this.material.SetFloat("_Distortion", this.Offset);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CEA RID: 3306 RVA: 0x00073CCA File Offset: 0x00071ECA
	private void Update()
	{
	}

	// Token: 0x06000CEB RID: 3307 RVA: 0x00073CCC File Offset: 0x00071ECC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001138 RID: 4408
	public Shader SCShader;

	// Token: 0x04001139 RID: 4409
	private float TimeX = 1f;

	// Token: 0x0400113A RID: 4410
	private Material SCMaterial;

	// Token: 0x0400113B RID: 4411
	[Range(-0.02f, 0.02f)]
	public float Offset = 0.02f;
}
