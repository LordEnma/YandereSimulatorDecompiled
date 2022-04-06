using System;
using UnityEngine;

// Token: 0x0200022D RID: 557
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Psycho")]
public class CameraFilterPack_Vision_Psycho : MonoBehaviour
{
	// Token: 0x17000331 RID: 817
	// (get) Token: 0x060011F3 RID: 4595 RVA: 0x0008A68B File Offset: 0x0008888B
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

	// Token: 0x060011F4 RID: 4596 RVA: 0x0008A6BF File Offset: 0x000888BF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Psycho");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011F5 RID: 4597 RVA: 0x0008A6E0 File Offset: 0x000888E0
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
			this.material.SetFloat("_Value", this.HoleSize);
			this.material.SetFloat("_Value2", this.HoleSmooth);
			this.material.SetFloat("_Value3", this.Color1);
			this.material.SetFloat("_Value4", this.Color2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011F6 RID: 4598 RVA: 0x0008A7D8 File Offset: 0x000889D8
	private void Update()
	{
	}

	// Token: 0x060011F7 RID: 4599 RVA: 0x0008A7DA File Offset: 0x000889DA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400169B RID: 5787
	public Shader SCShader;

	// Token: 0x0400169C RID: 5788
	private float TimeX = 1f;

	// Token: 0x0400169D RID: 5789
	private Material SCMaterial;

	// Token: 0x0400169E RID: 5790
	[Range(0.01f, 1f)]
	public float HoleSize = 0.6f;

	// Token: 0x0400169F RID: 5791
	[Range(-1f, 1f)]
	public float HoleSmooth = 0.3f;

	// Token: 0x040016A0 RID: 5792
	[Range(-2f, 2f)]
	public float Color1 = 0.2f;

	// Token: 0x040016A1 RID: 5793
	[Range(-2f, 2f)]
	public float Color2 = 0.9f;
}
