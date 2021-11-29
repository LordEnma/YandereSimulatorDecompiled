using System;
using UnityEngine;

// Token: 0x0200014C RID: 332
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/GaussianBlur")]
public class CameraFilterPack_Blur_GaussianBlur : MonoBehaviour
{
	// Token: 0x17000251 RID: 593
	// (get) Token: 0x06000C87 RID: 3207 RVA: 0x00071FE1 File Offset: 0x000701E1
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

	// Token: 0x06000C88 RID: 3208 RVA: 0x00072015 File Offset: 0x00070215
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_GaussianBlur");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C89 RID: 3209 RVA: 0x00072038 File Offset: 0x00070238
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
			this.material.SetFloat("_Distortion", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C8A RID: 3210 RVA: 0x000720E7 File Offset: 0x000702E7
	private void Update()
	{
	}

	// Token: 0x06000C8B RID: 3211 RVA: 0x000720E9 File Offset: 0x000702E9
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010CC RID: 4300
	public Shader SCShader;

	// Token: 0x040010CD RID: 4301
	private float TimeX = 1f;

	// Token: 0x040010CE RID: 4302
	[Range(1f, 16f)]
	public float Size = 10f;

	// Token: 0x040010CF RID: 4303
	private Material SCMaterial;
}
