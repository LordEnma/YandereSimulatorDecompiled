using System;
using UnityEngine;

// Token: 0x020001D5 RID: 469
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Rainbow")]
public class CameraFilterPack_Gradients_Rainbow : MonoBehaviour
{
	// Token: 0x170002D9 RID: 729
	// (get) Token: 0x06000FBE RID: 4030 RVA: 0x0007FF88 File Offset: 0x0007E188
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

	// Token: 0x06000FBF RID: 4031 RVA: 0x0007FFBC File Offset: 0x0007E1BC
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FC0 RID: 4032 RVA: 0x0007FFE0 File Offset: 0x0007E1E0
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

	// Token: 0x06000FC1 RID: 4033 RVA: 0x000800AC File Offset: 0x0007E2AC
	private void Update()
	{
	}

	// Token: 0x06000FC2 RID: 4034 RVA: 0x000800AE File Offset: 0x0007E2AE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400143C RID: 5180
	public Shader SCShader;

	// Token: 0x0400143D RID: 5181
	private string ShaderName = "CameraFilterPack/Gradients_Rainbow";

	// Token: 0x0400143E RID: 5182
	private float TimeX = 1f;

	// Token: 0x0400143F RID: 5183
	private Material SCMaterial;

	// Token: 0x04001440 RID: 5184
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001441 RID: 5185
	[Range(0f, 1f)]
	public float Fade = 1f;
}
