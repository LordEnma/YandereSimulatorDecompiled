using System;
using UnityEngine;

// Token: 0x020001BB RID: 443
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Mirror")]
public class CameraFilterPack_FX_Mirror : MonoBehaviour
{
	// Token: 0x170002BF RID: 703
	// (get) Token: 0x06000F21 RID: 3873 RVA: 0x0007CC70 File Offset: 0x0007AE70
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

	// Token: 0x06000F22 RID: 3874 RVA: 0x0007CCA4 File Offset: 0x0007AEA4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Mirror");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F23 RID: 3875 RVA: 0x0007CCC8 File Offset: 0x0007AEC8
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

	// Token: 0x06000F24 RID: 3876 RVA: 0x0007CD65 File Offset: 0x0007AF65
	private void Update()
	{
	}

	// Token: 0x06000F25 RID: 3877 RVA: 0x0007CD67 File Offset: 0x0007AF67
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
