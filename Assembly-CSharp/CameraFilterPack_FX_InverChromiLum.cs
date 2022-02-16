using System;
using UnityEngine;

// Token: 0x020001BA RID: 442
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/InverChromiLum")]
public class CameraFilterPack_FX_InverChromiLum : MonoBehaviour
{
	// Token: 0x170002BE RID: 702
	// (get) Token: 0x06000F1C RID: 3868 RVA: 0x0007CC9C File Offset: 0x0007AE9C
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

	// Token: 0x06000F1D RID: 3869 RVA: 0x0007CCD0 File Offset: 0x0007AED0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_InverChromiLum");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F1E RID: 3870 RVA: 0x0007CCF4 File Offset: 0x0007AEF4
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

	// Token: 0x06000F1F RID: 3871 RVA: 0x0007CD91 File Offset: 0x0007AF91
	private void Update()
	{
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x0007CD93 File Offset: 0x0007AF93
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001367 RID: 4967
	public Shader SCShader;

	// Token: 0x04001368 RID: 4968
	private float TimeX = 1f;

	// Token: 0x04001369 RID: 4969
	private Material SCMaterial;
}
