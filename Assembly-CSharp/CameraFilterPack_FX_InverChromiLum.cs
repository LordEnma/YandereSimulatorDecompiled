using System;
using UnityEngine;

// Token: 0x020001B9 RID: 441
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/InverChromiLum")]
public class CameraFilterPack_FX_InverChromiLum : MonoBehaviour
{
	// Token: 0x170002BE RID: 702
	// (get) Token: 0x06000F18 RID: 3864 RVA: 0x0007C954 File Offset: 0x0007AB54
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

	// Token: 0x06000F19 RID: 3865 RVA: 0x0007C988 File Offset: 0x0007AB88
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_InverChromiLum");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F1A RID: 3866 RVA: 0x0007C9AC File Offset: 0x0007ABAC
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

	// Token: 0x06000F1B RID: 3867 RVA: 0x0007CA49 File Offset: 0x0007AC49
	private void Update()
	{
	}

	// Token: 0x06000F1C RID: 3868 RVA: 0x0007CA4B File Offset: 0x0007AC4B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400135F RID: 4959
	public Shader SCShader;

	// Token: 0x04001360 RID: 4960
	private float TimeX = 1f;

	// Token: 0x04001361 RID: 4961
	private Material SCMaterial;
}
