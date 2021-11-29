using System;
using UnityEngine;

// Token: 0x020001D6 RID: 470
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Tech")]
public class CameraFilterPack_Gradients_Tech : MonoBehaviour
{
	// Token: 0x170002DB RID: 731
	// (get) Token: 0x06000FC6 RID: 4038 RVA: 0x0007FCCC File Offset: 0x0007DECC
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

	// Token: 0x06000FC7 RID: 4039 RVA: 0x0007FD00 File Offset: 0x0007DF00
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FC8 RID: 4040 RVA: 0x0007FD24 File Offset: 0x0007DF24
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

	// Token: 0x06000FC9 RID: 4041 RVA: 0x0007FDF0 File Offset: 0x0007DFF0
	private void Update()
	{
	}

	// Token: 0x06000FCA RID: 4042 RVA: 0x0007FDF2 File Offset: 0x0007DFF2
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001437 RID: 5175
	public Shader SCShader;

	// Token: 0x04001438 RID: 5176
	private string ShaderName = "CameraFilterPack/Gradients_Tech";

	// Token: 0x04001439 RID: 5177
	private float TimeX = 1f;

	// Token: 0x0400143A RID: 5178
	private Material SCMaterial;

	// Token: 0x0400143B RID: 5179
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400143C RID: 5180
	[Range(0f, 1f)]
	public float Fade = 1f;
}
