using System;
using UnityEngine;

// Token: 0x02000147 RID: 327
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Bloom")]
public class CameraFilterPack_Blur_Bloom : MonoBehaviour
{
	// Token: 0x1700024B RID: 587
	// (get) Token: 0x06000C67 RID: 3175 RVA: 0x00071BFF File Offset: 0x0006FDFF
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

	// Token: 0x06000C68 RID: 3176 RVA: 0x00071C33 File Offset: 0x0006FE33
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Bloom");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C69 RID: 3177 RVA: 0x00071C54 File Offset: 0x0006FE54
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
			this.material.SetFloat("_Amount", this.Amount);
			this.material.SetFloat("_Glow", this.Glow);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C6A RID: 3178 RVA: 0x00071D19 File Offset: 0x0006FF19
	private void Update()
	{
	}

	// Token: 0x06000C6B RID: 3179 RVA: 0x00071D1B File Offset: 0x0006FF1B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010B8 RID: 4280
	public Shader SCShader;

	// Token: 0x040010B9 RID: 4281
	private float TimeX = 1f;

	// Token: 0x040010BA RID: 4282
	private Material SCMaterial;

	// Token: 0x040010BB RID: 4283
	[Range(0f, 10f)]
	public float Amount = 4.5f;

	// Token: 0x040010BC RID: 4284
	[Range(0f, 1f)]
	public float Glow = 0.5f;
}
