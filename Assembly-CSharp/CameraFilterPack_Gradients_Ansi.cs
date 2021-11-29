using System;
using UnityEngine;

// Token: 0x020001CE RID: 462
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Ansi")]
public class CameraFilterPack_Gradients_Ansi : MonoBehaviour
{
	// Token: 0x170002D3 RID: 723
	// (get) Token: 0x06000F96 RID: 3990 RVA: 0x0007F12C File Offset: 0x0007D32C
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

	// Token: 0x06000F97 RID: 3991 RVA: 0x0007F160 File Offset: 0x0007D360
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F98 RID: 3992 RVA: 0x0007F184 File Offset: 0x0007D384
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

	// Token: 0x06000F99 RID: 3993 RVA: 0x0007F250 File Offset: 0x0007D450
	private void Update()
	{
	}

	// Token: 0x06000F9A RID: 3994 RVA: 0x0007F252 File Offset: 0x0007D452
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001407 RID: 5127
	public Shader SCShader;

	// Token: 0x04001408 RID: 5128
	private string ShaderName = "CameraFilterPack/Gradients_Ansi";

	// Token: 0x04001409 RID: 5129
	private float TimeX = 1f;

	// Token: 0x0400140A RID: 5130
	private Material SCMaterial;

	// Token: 0x0400140B RID: 5131
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400140C RID: 5132
	[Range(0f, 1f)]
	public float Fade = 1f;
}
