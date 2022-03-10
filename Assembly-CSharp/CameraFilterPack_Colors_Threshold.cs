using System;
using UnityEngine;

// Token: 0x02000171 RID: 369
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Threshold")]
public class CameraFilterPack_Colors_Threshold : MonoBehaviour
{
	// Token: 0x17000275 RID: 629
	// (get) Token: 0x06000D65 RID: 3429 RVA: 0x00076353 File Offset: 0x00074553
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

	// Token: 0x06000D66 RID: 3430 RVA: 0x00076387 File Offset: 0x00074587
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Threshold");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D67 RID: 3431 RVA: 0x000763A8 File Offset: 0x000745A8
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
			this.material.SetFloat("_Distortion", this.Threshold);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D68 RID: 3432 RVA: 0x0007642E File Offset: 0x0007462E
	private void Update()
	{
	}

	// Token: 0x06000D69 RID: 3433 RVA: 0x00076430 File Offset: 0x00074630
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011BB RID: 4539
	public Shader SCShader;

	// Token: 0x040011BC RID: 4540
	private float TimeX = 1f;

	// Token: 0x040011BD RID: 4541
	[Range(0f, 1f)]
	public float Threshold = 0.3f;

	// Token: 0x040011BE RID: 4542
	private Material SCMaterial;
}
