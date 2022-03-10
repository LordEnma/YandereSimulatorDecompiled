using System;
using UnityEngine;

// Token: 0x0200020C RID: 524
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Compression FX")]
public class CameraFilterPack_TV_CompressionFX : MonoBehaviour
{
	// Token: 0x17000310 RID: 784
	// (get) Token: 0x0600112B RID: 4395 RVA: 0x000870EB File Offset: 0x000852EB
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

	// Token: 0x0600112C RID: 4396 RVA: 0x0008711F File Offset: 0x0008531F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_CompressionFX");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600112D RID: 4397 RVA: 0x00087140 File Offset: 0x00085340
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
			this.material.SetFloat("_Parasite", this.Parasite);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x0600112E RID: 4398 RVA: 0x000871F6 File Offset: 0x000853F6
	private void Update()
	{
	}

	// Token: 0x0600112F RID: 4399 RVA: 0x000871F8 File Offset: 0x000853F8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D0 RID: 5584
	public Shader SCShader;

	// Token: 0x040015D1 RID: 5585
	private float TimeX = 1f;

	// Token: 0x040015D2 RID: 5586
	[Range(-10f, 10f)]
	public float Parasite = 1f;

	// Token: 0x040015D3 RID: 5587
	private Material SCMaterial;
}
