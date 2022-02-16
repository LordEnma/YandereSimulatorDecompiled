using System;
using UnityEngine;

// Token: 0x02000217 RID: 535
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/RGB Display")]
public class CameraFilterPack_TV_Rgb : MonoBehaviour
{
	// Token: 0x1700031B RID: 795
	// (get) Token: 0x0600116D RID: 4461 RVA: 0x00087D39 File Offset: 0x00085F39
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

	// Token: 0x0600116E RID: 4462 RVA: 0x00087D6D File Offset: 0x00085F6D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Rgb");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600116F RID: 4463 RVA: 0x00087D90 File Offset: 0x00085F90
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001170 RID: 4464 RVA: 0x00087E46 File Offset: 0x00086046
	private void Update()
	{
	}

	// Token: 0x06001171 RID: 4465 RVA: 0x00087E48 File Offset: 0x00086048
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015FE RID: 5630
	public Shader SCShader;

	// Token: 0x040015FF RID: 5631
	private float TimeX = 1f;

	// Token: 0x04001600 RID: 5632
	[Range(0.01f, 4f)]
	public float Distortion = 1f;

	// Token: 0x04001601 RID: 5633
	private Material SCMaterial;
}
