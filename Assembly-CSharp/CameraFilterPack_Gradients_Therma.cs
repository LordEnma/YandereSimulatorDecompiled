using System;
using UnityEngine;

// Token: 0x020001D7 RID: 471
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Thermal")]
public class CameraFilterPack_Gradients_Therma : MonoBehaviour
{
	// Token: 0x170002DC RID: 732
	// (get) Token: 0x06000FCC RID: 4044 RVA: 0x0007FE40 File Offset: 0x0007E040
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

	// Token: 0x06000FCD RID: 4045 RVA: 0x0007FE74 File Offset: 0x0007E074
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FCE RID: 4046 RVA: 0x0007FE98 File Offset: 0x0007E098
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

	// Token: 0x06000FCF RID: 4047 RVA: 0x0007FF64 File Offset: 0x0007E164
	private void Update()
	{
	}

	// Token: 0x06000FD0 RID: 4048 RVA: 0x0007FF66 File Offset: 0x0007E166
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
	private string ShaderName = "CameraFilterPack/Gradients_Therma";

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
