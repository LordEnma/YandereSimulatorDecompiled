using System;
using UnityEngine;

// Token: 0x020001DA RID: 474
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Rainbow2")]
public class CameraFilterPack_Light_Rainbow2 : MonoBehaviour
{
	// Token: 0x170002DE RID: 734
	// (get) Token: 0x06000FDE RID: 4062 RVA: 0x00080B1C File Offset: 0x0007ED1C
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

	// Token: 0x06000FDF RID: 4063 RVA: 0x00080B50 File Offset: 0x0007ED50
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Rainbow2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FE0 RID: 4064 RVA: 0x00080B74 File Offset: 0x0007ED74
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FE1 RID: 4065 RVA: 0x00080C2A File Offset: 0x0007EE2A
	private void Update()
	{
	}

	// Token: 0x06000FE2 RID: 4066 RVA: 0x00080C2C File Offset: 0x0007EE2C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400145F RID: 5215
	public Shader SCShader;

	// Token: 0x04001460 RID: 5216
	private float TimeX = 1f;

	// Token: 0x04001461 RID: 5217
	private Material SCMaterial;

	// Token: 0x04001462 RID: 5218
	[Range(0.01f, 5f)]
	public float Value = 1.5f;
}
