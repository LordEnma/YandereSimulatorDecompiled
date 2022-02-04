using System;
using UnityEngine;

// Token: 0x020001D9 RID: 473
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Rainbow")]
public class CameraFilterPack_Light_Rainbow : MonoBehaviour
{
	// Token: 0x170002DD RID: 733
	// (get) Token: 0x06000FD5 RID: 4053 RVA: 0x000801AC File Offset: 0x0007E3AC
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

	// Token: 0x06000FD6 RID: 4054 RVA: 0x000801E0 File Offset: 0x0007E3E0
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Rainbow");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FD7 RID: 4055 RVA: 0x00080204 File Offset: 0x0007E404
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

	// Token: 0x06000FD8 RID: 4056 RVA: 0x000802BA File Offset: 0x0007E4BA
	private void Update()
	{
	}

	// Token: 0x06000FD9 RID: 4057 RVA: 0x000802BC File Offset: 0x0007E4BC
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001448 RID: 5192
	public Shader SCShader;

	// Token: 0x04001449 RID: 5193
	private float TimeX = 1f;

	// Token: 0x0400144A RID: 5194
	private Material SCMaterial;

	// Token: 0x0400144B RID: 5195
	[Range(0.01f, 5f)]
	public float Value = 1.5f;
}
