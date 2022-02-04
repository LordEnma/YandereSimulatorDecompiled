using System;
using UnityEngine;

// Token: 0x02000165 RID: 357
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Switching")]
public class CameraFilterPack_Color_Switching : MonoBehaviour
{
	// Token: 0x17000269 RID: 617
	// (get) Token: 0x06000D1A RID: 3354 RVA: 0x00074840 File Offset: 0x00072A40
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

	// Token: 0x06000D1B RID: 3355 RVA: 0x00074874 File Offset: 0x00072A74
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Switching");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D1C RID: 3356 RVA: 0x00074898 File Offset: 0x00072A98
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
			this.material.SetFloat("_Distortion", (float)this.Color);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D1D RID: 3357 RVA: 0x0007494F File Offset: 0x00072B4F
	private void Update()
	{
	}

	// Token: 0x06000D1E RID: 3358 RVA: 0x00074951 File Offset: 0x00072B51
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400115F RID: 4447
	public Shader SCShader;

	// Token: 0x04001160 RID: 4448
	private float TimeX = 1f;

	// Token: 0x04001161 RID: 4449
	private Material SCMaterial;

	// Token: 0x04001162 RID: 4450
	[Range(0f, 5f)]
	public int Color = 1;
}
