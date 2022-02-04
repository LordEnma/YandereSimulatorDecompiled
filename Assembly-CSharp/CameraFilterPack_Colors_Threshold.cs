using System;
using UnityEngine;

// Token: 0x02000171 RID: 369
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Threshold")]
public class CameraFilterPack_Colors_Threshold : MonoBehaviour
{
	// Token: 0x17000275 RID: 629
	// (get) Token: 0x06000D64 RID: 3428 RVA: 0x00075FA7 File Offset: 0x000741A7
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

	// Token: 0x06000D65 RID: 3429 RVA: 0x00075FDB File Offset: 0x000741DB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Colors_Threshold");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D66 RID: 3430 RVA: 0x00075FFC File Offset: 0x000741FC
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

	// Token: 0x06000D67 RID: 3431 RVA: 0x00076082 File Offset: 0x00074282
	private void Update()
	{
	}

	// Token: 0x06000D68 RID: 3432 RVA: 0x00076084 File Offset: 0x00074284
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011AF RID: 4527
	public Shader SCShader;

	// Token: 0x040011B0 RID: 4528
	private float TimeX = 1f;

	// Token: 0x040011B1 RID: 4529
	[Range(0f, 1f)]
	public float Threshold = 0.3f;

	// Token: 0x040011B2 RID: 4530
	private Material SCMaterial;
}
