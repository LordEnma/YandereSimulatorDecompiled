using System;
using UnityEngine;

// Token: 0x020001A4 RID: 420
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Sobel")]
public class CameraFilterPack_Edge_Sobel : MonoBehaviour
{
	// Token: 0x170002A9 RID: 681
	// (get) Token: 0x06000E9A RID: 3738 RVA: 0x0007AA3D File Offset: 0x00078C3D
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

	// Token: 0x06000E9B RID: 3739 RVA: 0x0007AA71 File Offset: 0x00078C71
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Sobel");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E9C RID: 3740 RVA: 0x0007AA94 File Offset: 0x00078C94
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

	// Token: 0x06000E9D RID: 3741 RVA: 0x0007AB31 File Offset: 0x00078D31
	private void Update()
	{
	}

	// Token: 0x06000E9E RID: 3742 RVA: 0x0007AB33 File Offset: 0x00078D33
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012E3 RID: 4835
	public Shader SCShader;

	// Token: 0x040012E4 RID: 4836
	private float TimeX = 1f;

	// Token: 0x040012E5 RID: 4837
	private Material SCMaterial;
}
