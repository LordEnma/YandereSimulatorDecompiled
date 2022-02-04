using System;
using UnityEngine;

// Token: 0x0200020C RID: 524
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Compression FX")]
public class CameraFilterPack_TV_CompressionFX : MonoBehaviour
{
	// Token: 0x17000310 RID: 784
	// (get) Token: 0x0600112A RID: 4394 RVA: 0x00086D3F File Offset: 0x00084F3F
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

	// Token: 0x0600112B RID: 4395 RVA: 0x00086D73 File Offset: 0x00084F73
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_CompressionFX");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600112C RID: 4396 RVA: 0x00086D94 File Offset: 0x00084F94
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

	// Token: 0x0600112D RID: 4397 RVA: 0x00086E4A File Offset: 0x0008504A
	private void Update()
	{
	}

	// Token: 0x0600112E RID: 4398 RVA: 0x00086E4C File Offset: 0x0008504C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015C4 RID: 5572
	public Shader SCShader;

	// Token: 0x040015C5 RID: 5573
	private float TimeX = 1f;

	// Token: 0x040015C6 RID: 5574
	[Range(-10f, 10f)]
	public float Parasite = 1f;

	// Token: 0x040015C7 RID: 5575
	private Material SCMaterial;
}
