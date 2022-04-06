using System;
using UnityEngine;

// Token: 0x0200020C RID: 524
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Compression FX")]
public class CameraFilterPack_TV_CompressionFX : MonoBehaviour
{
	// Token: 0x17000310 RID: 784
	// (get) Token: 0x0600112D RID: 4397 RVA: 0x00087567 File Offset: 0x00085767
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

	// Token: 0x0600112E RID: 4398 RVA: 0x0008759B File Offset: 0x0008579B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_CompressionFX");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600112F RID: 4399 RVA: 0x000875BC File Offset: 0x000857BC
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

	// Token: 0x06001130 RID: 4400 RVA: 0x00087672 File Offset: 0x00085872
	private void Update()
	{
	}

	// Token: 0x06001131 RID: 4401 RVA: 0x00087674 File Offset: 0x00085874
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015D7 RID: 5591
	public Shader SCShader;

	// Token: 0x040015D8 RID: 5592
	private float TimeX = 1f;

	// Token: 0x040015D9 RID: 5593
	[Range(-10f, 10f)]
	public float Parasite = 1f;

	// Token: 0x040015DA RID: 5594
	private Material SCMaterial;
}
