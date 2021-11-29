using System;
using UnityEngine;

// Token: 0x0200011F RID: 287
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Antialiasing/FXAA")]
public class CameraFilterPack_Antialiasing_FXAA : MonoBehaviour
{
	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06000B3A RID: 2874 RVA: 0x0006B82C File Offset: 0x00069A2C
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

	// Token: 0x06000B3B RID: 2875 RVA: 0x0006B860 File Offset: 0x00069A60
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Antialiasing_FXAA");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B3C RID: 2876 RVA: 0x0006B884 File Offset: 0x00069A84
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
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B3D RID: 2877 RVA: 0x0006B91A File Offset: 0x00069B1A
	private void Update()
	{
	}

	// Token: 0x06000B3E RID: 2878 RVA: 0x0006B91C File Offset: 0x00069B1C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F3E RID: 3902
	public Shader SCShader;

	// Token: 0x04000F3F RID: 3903
	private float TimeX = 1f;

	// Token: 0x04000F40 RID: 3904
	private Material SCMaterial;
}
