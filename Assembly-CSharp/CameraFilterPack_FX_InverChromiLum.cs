using System;
using UnityEngine;

// Token: 0x020001BA RID: 442
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/InverChromiLum")]
public class CameraFilterPack_FX_InverChromiLum : MonoBehaviour
{
	// Token: 0x170002BE RID: 702
	// (get) Token: 0x06000F1C RID: 3868 RVA: 0x0007CDB0 File Offset: 0x0007AFB0
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

	// Token: 0x06000F1D RID: 3869 RVA: 0x0007CDE4 File Offset: 0x0007AFE4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_InverChromiLum");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F1E RID: 3870 RVA: 0x0007CE08 File Offset: 0x0007B008
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

	// Token: 0x06000F1F RID: 3871 RVA: 0x0007CEA5 File Offset: 0x0007B0A5
	private void Update()
	{
	}

	// Token: 0x06000F20 RID: 3872 RVA: 0x0007CEA7 File Offset: 0x0007B0A7
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
