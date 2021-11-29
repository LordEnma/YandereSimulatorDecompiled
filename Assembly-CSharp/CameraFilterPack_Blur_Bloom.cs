using System;
using UnityEngine;

// Token: 0x02000146 RID: 326
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Bloom")]
public class CameraFilterPack_Blur_Bloom : MonoBehaviour
{
	// Token: 0x1700024B RID: 587
	// (get) Token: 0x06000C63 RID: 3171 RVA: 0x0007165B File Offset: 0x0006F85B
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

	// Token: 0x06000C64 RID: 3172 RVA: 0x0007168F File Offset: 0x0006F88F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Bloom");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C65 RID: 3173 RVA: 0x000716B0 File Offset: 0x0006F8B0
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

	// Token: 0x06000C66 RID: 3174 RVA: 0x00071775 File Offset: 0x0006F975
	private void Update()
	{
	}

	// Token: 0x06000C67 RID: 3175 RVA: 0x00071777 File Offset: 0x0006F977
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010A7 RID: 4263
	public Shader SCShader;

	// Token: 0x040010A8 RID: 4264
	private float TimeX = 1f;

	// Token: 0x040010A9 RID: 4265
	private Material SCMaterial;

	// Token: 0x040010AA RID: 4266
	[Range(0f, 10f)]
	public float Amount = 4.5f;

	// Token: 0x040010AB RID: 4267
	[Range(0f, 1f)]
	public float Glow = 0.5f;
}
