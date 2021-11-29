using System;
using UnityEngine;

// Token: 0x0200015E RID: 350
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Contrast")]
public class CameraFilterPack_Color_Contrast : MonoBehaviour
{
	// Token: 0x17000263 RID: 611
	// (get) Token: 0x06000CF3 RID: 3315 RVA: 0x00073E8E File Offset: 0x0007208E
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

	// Token: 0x06000CF4 RID: 3316 RVA: 0x00073EC2 File Offset: 0x000720C2
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Contrast");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CF5 RID: 3317 RVA: 0x00073EE4 File Offset: 0x000720E4
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_Contrast", this.Contrast);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CF6 RID: 3318 RVA: 0x00073F9A File Offset: 0x0007219A
	private void Update()
	{
	}

	// Token: 0x06000CF7 RID: 3319 RVA: 0x00073F9C File Offset: 0x0007219C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001142 RID: 4418
	public Shader SCShader;

	// Token: 0x04001143 RID: 4419
	private float TimeX = 1f;

	// Token: 0x04001144 RID: 4420
	private Material SCMaterial;

	// Token: 0x04001145 RID: 4421
	[Range(0f, 10f)]
	public float Contrast = 4.5f;
}
