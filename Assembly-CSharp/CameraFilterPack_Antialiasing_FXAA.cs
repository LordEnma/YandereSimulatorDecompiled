using System;
using UnityEngine;

// Token: 0x02000120 RID: 288
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Antialiasing/FXAA")]
public class CameraFilterPack_Antialiasing_FXAA : MonoBehaviour
{
	// Token: 0x17000224 RID: 548
	// (get) Token: 0x06000B40 RID: 2880 RVA: 0x0006C24C File Offset: 0x0006A44C
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

	// Token: 0x06000B41 RID: 2881 RVA: 0x0006C280 File Offset: 0x0006A480
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Antialiasing_FXAA");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B42 RID: 2882 RVA: 0x0006C2A4 File Offset: 0x0006A4A4
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

	// Token: 0x06000B43 RID: 2883 RVA: 0x0006C33A File Offset: 0x0006A53A
	private void Update()
	{
	}

	// Token: 0x06000B44 RID: 2884 RVA: 0x0006C33C File Offset: 0x0006A53C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000F56 RID: 3926
	public Shader SCShader;

	// Token: 0x04000F57 RID: 3927
	private float TimeX = 1f;

	// Token: 0x04000F58 RID: 3928
	private Material SCMaterial;
}
