using System;
using UnityEngine;

// Token: 0x020001D4 RID: 468
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Neon")]
public class CameraFilterPack_Gradients_NeonGradient : MonoBehaviour
{
	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x06000FBA RID: 4026 RVA: 0x00080290 File Offset: 0x0007E490
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

	// Token: 0x06000FBB RID: 4027 RVA: 0x000802C4 File Offset: 0x0007E4C4
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FBC RID: 4028 RVA: 0x000802E8 File Offset: 0x0007E4E8
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

	// Token: 0x06000FBD RID: 4029 RVA: 0x000803B4 File Offset: 0x0007E5B4
	private void Update()
	{
	}

	// Token: 0x06000FBE RID: 4030 RVA: 0x000803B6 File Offset: 0x0007E5B6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400143D RID: 5181
	public Shader SCShader;

	// Token: 0x0400143E RID: 5182
	private string ShaderName = "CameraFilterPack/Gradients_NeonGradient";

	// Token: 0x0400143F RID: 5183
	private float TimeX = 1f;

	// Token: 0x04001440 RID: 5184
	private Material SCMaterial;

	// Token: 0x04001441 RID: 5185
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001442 RID: 5186
	[Range(0f, 1f)]
	public float Fade = 1f;
}
