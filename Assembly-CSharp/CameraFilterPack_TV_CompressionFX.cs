using System;
using UnityEngine;

// Token: 0x0200020B RID: 523
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Compression FX")]
public class CameraFilterPack_TV_CompressionFX : MonoBehaviour
{
	// Token: 0x17000310 RID: 784
	// (get) Token: 0x06001127 RID: 4391 RVA: 0x00086B47 File Offset: 0x00084D47
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

	// Token: 0x06001128 RID: 4392 RVA: 0x00086B7B File Offset: 0x00084D7B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_CompressionFX");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06001129 RID: 4393 RVA: 0x00086B9C File Offset: 0x00084D9C
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

	// Token: 0x0600112A RID: 4394 RVA: 0x00086C52 File Offset: 0x00084E52
	private void Update()
	{
	}

	// Token: 0x0600112B RID: 4395 RVA: 0x00086C54 File Offset: 0x00084E54
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040015BF RID: 5567
	public Shader SCShader;

	// Token: 0x040015C0 RID: 5568
	private float TimeX = 1f;

	// Token: 0x040015C1 RID: 5569
	[Range(-10f, 10f)]
	public float Parasite = 1f;

	// Token: 0x040015C2 RID: 5570
	private Material SCMaterial;
}
