using System;
using UnityEngine;

// Token: 0x0200018D RID: 397
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Laplacian")]
public class CameraFilterPack_Drawing_Laplacian : MonoBehaviour
{
	// Token: 0x17000292 RID: 658
	// (get) Token: 0x06000E0F RID: 3599 RVA: 0x00078789 File Offset: 0x00076989
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

	// Token: 0x06000E10 RID: 3600 RVA: 0x000787BD File Offset: 0x000769BD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Laplacian");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E11 RID: 3601 RVA: 0x000787E0 File Offset: 0x000769E0
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

	// Token: 0x06000E12 RID: 3602 RVA: 0x0007887D File Offset: 0x00076A7D
	private void Update()
	{
		bool isPlaying = Application.isPlaying;
	}

	// Token: 0x06000E13 RID: 3603 RVA: 0x00078885 File Offset: 0x00076A85
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001252 RID: 4690
	public Shader SCShader;

	// Token: 0x04001253 RID: 4691
	private float TimeX = 1f;

	// Token: 0x04001254 RID: 4692
	private Material SCMaterial;
}
