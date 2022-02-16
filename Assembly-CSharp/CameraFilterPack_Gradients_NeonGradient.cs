using System;
using UnityEngine;

// Token: 0x020001D4 RID: 468
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Neon")]
public class CameraFilterPack_Gradients_NeonGradient : MonoBehaviour
{
	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x06000FB8 RID: 4024 RVA: 0x0007FBB8 File Offset: 0x0007DDB8
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

	// Token: 0x06000FB9 RID: 4025 RVA: 0x0007FBEC File Offset: 0x0007DDEC
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FBA RID: 4026 RVA: 0x0007FC10 File Offset: 0x0007DE10
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

	// Token: 0x06000FBB RID: 4027 RVA: 0x0007FCDC File Offset: 0x0007DEDC
	private void Update()
	{
	}

	// Token: 0x06000FBC RID: 4028 RVA: 0x0007FCDE File Offset: 0x0007DEDE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400142D RID: 5165
	public Shader SCShader;

	// Token: 0x0400142E RID: 5166
	private string ShaderName = "CameraFilterPack/Gradients_NeonGradient";

	// Token: 0x0400142F RID: 5167
	private float TimeX = 1f;

	// Token: 0x04001430 RID: 5168
	private Material SCMaterial;

	// Token: 0x04001431 RID: 5169
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001432 RID: 5170
	[Range(0f, 1f)]
	public float Fade = 1f;
}
