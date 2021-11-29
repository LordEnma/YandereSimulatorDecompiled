using System;
using UnityEngine;

// Token: 0x020001D1 RID: 465
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Fire")]
public class CameraFilterPack_Gradients_FireGradient : MonoBehaviour
{
	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x06000FA8 RID: 4008 RVA: 0x0007F588 File Offset: 0x0007D788
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

	// Token: 0x06000FA9 RID: 4009 RVA: 0x0007F5BC File Offset: 0x0007D7BC
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x0007F5E0 File Offset: 0x0007D7E0
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

	// Token: 0x06000FAB RID: 4011 RVA: 0x0007F6AC File Offset: 0x0007D8AC
	private void Update()
	{
	}

	// Token: 0x06000FAC RID: 4012 RVA: 0x0007F6AE File Offset: 0x0007D8AE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001419 RID: 5145
	public Shader SCShader;

	// Token: 0x0400141A RID: 5146
	private string ShaderName = "CameraFilterPack/Gradients_FireGradient";

	// Token: 0x0400141B RID: 5147
	private float TimeX = 1f;

	// Token: 0x0400141C RID: 5148
	private Material SCMaterial;

	// Token: 0x0400141D RID: 5149
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400141E RID: 5150
	[Range(0f, 1f)]
	public float Fade = 1f;
}
