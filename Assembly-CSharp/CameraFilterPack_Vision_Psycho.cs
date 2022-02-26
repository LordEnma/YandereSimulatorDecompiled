using System;
using UnityEngine;

// Token: 0x0200022D RID: 557
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Psycho")]
public class CameraFilterPack_Vision_Psycho : MonoBehaviour
{
	// Token: 0x17000331 RID: 817
	// (get) Token: 0x060011F1 RID: 4593 RVA: 0x0008A0C7 File Offset: 0x000882C7
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

	// Token: 0x060011F2 RID: 4594 RVA: 0x0008A0FB File Offset: 0x000882FB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Psycho");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011F3 RID: 4595 RVA: 0x0008A11C File Offset: 0x0008831C
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

	// Token: 0x060011F4 RID: 4596 RVA: 0x0008A214 File Offset: 0x00088414
	private void Update()
	{
	}

	// Token: 0x060011F5 RID: 4597 RVA: 0x0008A216 File Offset: 0x00088416
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400168B RID: 5771
	public Shader SCShader;

	// Token: 0x0400168C RID: 5772
	private float TimeX = 1f;

	// Token: 0x0400168D RID: 5773
	private Material SCMaterial;

	// Token: 0x0400168E RID: 5774
	[Range(0.01f, 1f)]
	public float HoleSize = 0.6f;

	// Token: 0x0400168F RID: 5775
	[Range(-1f, 1f)]
	public float HoleSmooth = 0.3f;

	// Token: 0x04001690 RID: 5776
	[Range(-2f, 2f)]
	public float Color1 = 0.2f;

	// Token: 0x04001691 RID: 5777
	[Range(-2f, 2f)]
	public float Color2 = 0.9f;
}
