using System;
using UnityEngine;

// Token: 0x020001D4 RID: 468
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Neon")]
public class CameraFilterPack_Gradients_NeonGradient : MonoBehaviour
{
	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x0007FE14 File Offset: 0x0007E014
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

	// Token: 0x06000FB9 RID: 4025 RVA: 0x0007FE48 File Offset: 0x0007E048
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FBA RID: 4026 RVA: 0x0007FE6C File Offset: 0x0007E06C
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

	// Token: 0x06000FBB RID: 4027 RVA: 0x0007FF38 File Offset: 0x0007E138
	private void Update()
	{
	}

	// Token: 0x06000FBC RID: 4028 RVA: 0x0007FF3A File Offset: 0x0007E13A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001436 RID: 5174
	public Shader SCShader;

	// Token: 0x04001437 RID: 5175
	private string ShaderName = "CameraFilterPack/Gradients_NeonGradient";

	// Token: 0x04001438 RID: 5176
	private float TimeX = 1f;

	// Token: 0x04001439 RID: 5177
	private Material SCMaterial;

	// Token: 0x0400143A RID: 5178
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400143B RID: 5179
	[Range(0f, 1f)]
	public float Fade = 1f;
}
