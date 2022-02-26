using System;
using UnityEngine;

// Token: 0x0200020C RID: 524
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Compression FX")]
public class CameraFilterPack_TV_CompressionFX : MonoBehaviour
{
	// Token: 0x17000310 RID: 784
	// (get) Token: 0x0600112B RID: 4395 RVA: 0x00086FA3 File Offset: 0x000851A3
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

	// Token: 0x0600112C RID: 4396 RVA: 0x00086FD7 File Offset: 0x000851D7
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_CompressionFX");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600112D RID: 4397 RVA: 0x00086FF8 File Offset: 0x000851F8
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

	// Token: 0x0600112E RID: 4398 RVA: 0x000870AE File Offset: 0x000852AE
	private void Update()
	{
	}

	// Token: 0x0600112F RID: 4399 RVA: 0x000870B0 File Offset: 0x000852B0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015C7 RID: 5575
	public Shader SCShader;

	// Token: 0x040015C8 RID: 5576
	private float TimeX = 1f;

	// Token: 0x040015C9 RID: 5577
	[Range(-10f, 10f)]
	public float Parasite = 1f;

	// Token: 0x040015CA RID: 5578
	private Material SCMaterial;
}
