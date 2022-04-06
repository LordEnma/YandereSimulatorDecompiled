using System;
using UnityEngine;

// Token: 0x0200014D RID: 333
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/GaussianBlur")]
public class CameraFilterPack_Blur_GaussianBlur : MonoBehaviour
{
	// Token: 0x17000251 RID: 593
	// (get) Token: 0x06000C8D RID: 3213 RVA: 0x00072A01 File Offset: 0x00070C01
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

	// Token: 0x06000C8E RID: 3214 RVA: 0x00072A35 File Offset: 0x00070C35
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_GaussianBlur");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x00072A58 File Offset: 0x00070C58
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

	// Token: 0x06000C90 RID: 3216 RVA: 0x00072B07 File Offset: 0x00070D07
	private void Update()
	{
	}

	// Token: 0x06000C91 RID: 3217 RVA: 0x00072B09 File Offset: 0x00070D09
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010E4 RID: 4324
	public Shader SCShader;

	// Token: 0x040010E5 RID: 4325
	private float TimeX = 1f;

	// Token: 0x040010E6 RID: 4326
	[Range(1f, 16f)]
	public float Size = 10f;

	// Token: 0x040010E7 RID: 4327
	private Material SCMaterial;
}
