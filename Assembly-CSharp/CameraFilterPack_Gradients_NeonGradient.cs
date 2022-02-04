using System;
using UnityEngine;

// Token: 0x020001D4 RID: 468
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Neon")]
public class CameraFilterPack_Gradients_NeonGradient : MonoBehaviour
{
	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x06000FB7 RID: 4023 RVA: 0x0007FA68 File Offset: 0x0007DC68
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

	// Token: 0x06000FB8 RID: 4024 RVA: 0x0007FA9C File Offset: 0x0007DC9C
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FB9 RID: 4025 RVA: 0x0007FAC0 File Offset: 0x0007DCC0
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

	// Token: 0x06000FBA RID: 4026 RVA: 0x0007FB8C File Offset: 0x0007DD8C
	private void Update()
	{
	}

	// Token: 0x06000FBB RID: 4027 RVA: 0x0007FB8E File Offset: 0x0007DD8E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400142A RID: 5162
	public Shader SCShader;

	// Token: 0x0400142B RID: 5163
	private string ShaderName = "CameraFilterPack/Gradients_NeonGradient";

	// Token: 0x0400142C RID: 5164
	private float TimeX = 1f;

	// Token: 0x0400142D RID: 5165
	private Material SCMaterial;

	// Token: 0x0400142E RID: 5166
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400142F RID: 5167
	[Range(0f, 1f)]
	public float Fade = 1f;
}
