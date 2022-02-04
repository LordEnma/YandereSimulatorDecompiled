using System;
using UnityEngine;

// Token: 0x0200014D RID: 333
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/GaussianBlur")]
public class CameraFilterPack_Blur_GaussianBlur : MonoBehaviour
{
	// Token: 0x17000251 RID: 593
	// (get) Token: 0x06000C8A RID: 3210 RVA: 0x000721D9 File Offset: 0x000703D9
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

	// Token: 0x06000C8B RID: 3211 RVA: 0x0007220D File Offset: 0x0007040D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_GaussianBlur");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C8C RID: 3212 RVA: 0x00072230 File Offset: 0x00070430
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

	// Token: 0x06000C8D RID: 3213 RVA: 0x000722DF File Offset: 0x000704DF
	private void Update()
	{
	}

	// Token: 0x06000C8E RID: 3214 RVA: 0x000722E1 File Offset: 0x000704E1
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010D1 RID: 4305
	public Shader SCShader;

	// Token: 0x040010D2 RID: 4306
	private float TimeX = 1f;

	// Token: 0x040010D3 RID: 4307
	[Range(1f, 16f)]
	public float Size = 10f;

	// Token: 0x040010D4 RID: 4308
	private Material SCMaterial;
}
