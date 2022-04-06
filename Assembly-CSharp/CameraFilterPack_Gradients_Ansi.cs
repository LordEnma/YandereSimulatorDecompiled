using System;
using UnityEngine;

// Token: 0x020001CF RID: 463
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Ansi")]
public class CameraFilterPack_Gradients_Ansi : MonoBehaviour
{
	// Token: 0x170002D3 RID: 723
	// (get) Token: 0x06000F9C RID: 3996 RVA: 0x0007FB4C File Offset: 0x0007DD4C
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

	// Token: 0x06000F9D RID: 3997 RVA: 0x0007FB80 File Offset: 0x0007DD80
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F9E RID: 3998 RVA: 0x0007FBA4 File Offset: 0x0007DDA4
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

	// Token: 0x06000F9F RID: 3999 RVA: 0x0007FC70 File Offset: 0x0007DE70
	private void Update()
	{
	}

	// Token: 0x06000FA0 RID: 4000 RVA: 0x0007FC72 File Offset: 0x0007DE72
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400141F RID: 5151
	public Shader SCShader;

	// Token: 0x04001420 RID: 5152
	private string ShaderName = "CameraFilterPack/Gradients_Ansi";

	// Token: 0x04001421 RID: 5153
	private float TimeX = 1f;

	// Token: 0x04001422 RID: 5154
	private Material SCMaterial;

	// Token: 0x04001423 RID: 5155
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001424 RID: 5156
	[Range(0f, 1f)]
	public float Fade = 1f;
}
