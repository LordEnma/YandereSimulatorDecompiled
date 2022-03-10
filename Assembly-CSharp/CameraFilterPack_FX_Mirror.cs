using System;
using UnityEngine;

// Token: 0x020001BB RID: 443
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Mirror")]
public class CameraFilterPack_FX_Mirror : MonoBehaviour
{
	// Token: 0x170002BF RID: 703
	// (get) Token: 0x06000F22 RID: 3874 RVA: 0x0007D01C File Offset: 0x0007B21C
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

	// Token: 0x06000F23 RID: 3875 RVA: 0x0007D050 File Offset: 0x0007B250
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Mirror");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F24 RID: 3876 RVA: 0x0007D074 File Offset: 0x0007B274
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x0007D111 File Offset: 0x0007B311
	private void Update()
	{
	}

	// Token: 0x06000F26 RID: 3878 RVA: 0x0007D113 File Offset: 0x0007B313
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001373 RID: 4979
	public Shader SCShader;

	// Token: 0x04001374 RID: 4980
	private float TimeX = 1f;

	// Token: 0x04001375 RID: 4981
	private Material SCMaterial;
}
