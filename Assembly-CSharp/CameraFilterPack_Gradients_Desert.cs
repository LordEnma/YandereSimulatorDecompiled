using System;
using UnityEngine;

// Token: 0x020001CF RID: 463
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Desert")]
public class CameraFilterPack_Gradients_Desert : MonoBehaviour
{
	// Token: 0x170002D4 RID: 724
	// (get) Token: 0x06000F9C RID: 3996 RVA: 0x0007F2A0 File Offset: 0x0007D4A0
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

	// Token: 0x06000F9D RID: 3997 RVA: 0x0007F2D4 File Offset: 0x0007D4D4
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F9E RID: 3998 RVA: 0x0007F2F8 File Offset: 0x0007D4F8
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

	// Token: 0x06000F9F RID: 3999 RVA: 0x0007F3C4 File Offset: 0x0007D5C4
	private void Update()
	{
	}

	// Token: 0x06000FA0 RID: 4000 RVA: 0x0007F3C6 File Offset: 0x0007D5C6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400140D RID: 5133
	public Shader SCShader;

	// Token: 0x0400140E RID: 5134
	private string ShaderName = "CameraFilterPack/Gradients_Desert";

	// Token: 0x0400140F RID: 5135
	private float TimeX = 1f;

	// Token: 0x04001410 RID: 5136
	private Material SCMaterial;

	// Token: 0x04001411 RID: 5137
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001412 RID: 5138
	[Range(0f, 1f)]
	public float Fade = 1f;
}
