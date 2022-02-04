using System;
using UnityEngine;

// Token: 0x020001D2 RID: 466
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Fire")]
public class CameraFilterPack_Gradients_FireGradient : MonoBehaviour
{
	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x06000FAB RID: 4011 RVA: 0x0007F780 File Offset: 0x0007D980
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

	// Token: 0x06000FAC RID: 4012 RVA: 0x0007F7B4 File Offset: 0x0007D9B4
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FAD RID: 4013 RVA: 0x0007F7D8 File Offset: 0x0007D9D8
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

	// Token: 0x06000FAE RID: 4014 RVA: 0x0007F8A4 File Offset: 0x0007DAA4
	private void Update()
	{
	}

	// Token: 0x06000FAF RID: 4015 RVA: 0x0007F8A6 File Offset: 0x0007DAA6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400141E RID: 5150
	public Shader SCShader;

	// Token: 0x0400141F RID: 5151
	private string ShaderName = "CameraFilterPack/Gradients_FireGradient";

	// Token: 0x04001420 RID: 5152
	private float TimeX = 1f;

	// Token: 0x04001421 RID: 5153
	private Material SCMaterial;

	// Token: 0x04001422 RID: 5154
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001423 RID: 5155
	[Range(0f, 1f)]
	public float Fade = 1f;
}
