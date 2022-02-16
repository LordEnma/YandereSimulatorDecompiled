using System;
using UnityEngine;

// Token: 0x020001CF RID: 463
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Ansi")]
public class CameraFilterPack_Gradients_Ansi : MonoBehaviour
{
	// Token: 0x170002D3 RID: 723
	// (get) Token: 0x06000F9A RID: 3994 RVA: 0x0007F474 File Offset: 0x0007D674
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

	// Token: 0x06000F9B RID: 3995 RVA: 0x0007F4A8 File Offset: 0x0007D6A8
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F9C RID: 3996 RVA: 0x0007F4CC File Offset: 0x0007D6CC
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
			this.material.SetFloat("_Value", this.Switch);
			this.material.SetFloat("_Value2", this.Fade);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F9D RID: 3997 RVA: 0x0007F598 File Offset: 0x0007D798
	private void Update()
	{
	}

	// Token: 0x06000F9E RID: 3998 RVA: 0x0007F59A File Offset: 0x0007D79A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400140F RID: 5135
	public Shader SCShader;

	// Token: 0x04001410 RID: 5136
	private string ShaderName = "CameraFilterPack/Gradients_Ansi";

	// Token: 0x04001411 RID: 5137
	private float TimeX = 1f;

	// Token: 0x04001412 RID: 5138
	private Material SCMaterial;

	// Token: 0x04001413 RID: 5139
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001414 RID: 5140
	[Range(0f, 1f)]
	public float Fade = 1f;
}
