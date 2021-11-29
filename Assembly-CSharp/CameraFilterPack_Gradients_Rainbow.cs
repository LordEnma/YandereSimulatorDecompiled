using System;
using UnityEngine;

// Token: 0x020001D4 RID: 468
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Rainbow")]
public class CameraFilterPack_Gradients_Rainbow : MonoBehaviour
{
	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x06000FBA RID: 4026 RVA: 0x0007F9E4 File Offset: 0x0007DBE4
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

	// Token: 0x06000FBB RID: 4027 RVA: 0x0007FA18 File Offset: 0x0007DC18
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FBC RID: 4028 RVA: 0x0007FA3C File Offset: 0x0007DC3C
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

	// Token: 0x06000FBD RID: 4029 RVA: 0x0007FB08 File Offset: 0x0007DD08
	private void Update()
	{
	}

	// Token: 0x06000FBE RID: 4030 RVA: 0x0007FB0A File Offset: 0x0007DD0A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400142B RID: 5163
	public Shader SCShader;

	// Token: 0x0400142C RID: 5164
	private string ShaderName = "CameraFilterPack/Gradients_Rainbow";

	// Token: 0x0400142D RID: 5165
	private float TimeX = 1f;

	// Token: 0x0400142E RID: 5166
	private Material SCMaterial;

	// Token: 0x0400142F RID: 5167
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001430 RID: 5168
	[Range(0f, 1f)]
	public float Fade = 1f;
}
