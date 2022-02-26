using System;
using UnityEngine;

// Token: 0x02000120 RID: 288
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Antialiasing/FXAA")]
public class CameraFilterPack_Antialiasing_FXAA : MonoBehaviour
{
	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06000B3E RID: 2878 RVA: 0x0006BC88 File Offset: 0x00069E88
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

	// Token: 0x06000B3F RID: 2879 RVA: 0x0006BCBC File Offset: 0x00069EBC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Antialiasing_FXAA");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B40 RID: 2880 RVA: 0x0006BCE0 File Offset: 0x00069EE0
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

	// Token: 0x06000B41 RID: 2881 RVA: 0x0006BD76 File Offset: 0x00069F76
	private void Update()
	{
	}

	// Token: 0x06000B42 RID: 2882 RVA: 0x0006BD78 File Offset: 0x00069F78
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F46 RID: 3910
	public Shader SCShader;

	// Token: 0x04000F47 RID: 3911
	private float TimeX = 1f;

	// Token: 0x04000F48 RID: 3912
	private Material SCMaterial;
}
