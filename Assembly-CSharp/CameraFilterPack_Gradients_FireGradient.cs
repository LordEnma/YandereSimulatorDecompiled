using System;
using UnityEngine;

// Token: 0x020001D2 RID: 466
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Fire")]
public class CameraFilterPack_Gradients_FireGradient : MonoBehaviour
{
	// Token: 0x170002D6 RID: 726
	// (get) Token: 0x06000FAE RID: 4014 RVA: 0x0007FFA8 File Offset: 0x0007E1A8
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

	// Token: 0x06000FAF RID: 4015 RVA: 0x0007FFDC File Offset: 0x0007E1DC
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FB0 RID: 4016 RVA: 0x00080000 File Offset: 0x0007E200
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

	// Token: 0x06000FB1 RID: 4017 RVA: 0x000800CC File Offset: 0x0007E2CC
	private void Update()
	{
	}

	// Token: 0x06000FB2 RID: 4018 RVA: 0x000800CE File Offset: 0x0007E2CE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001431 RID: 5169
	public Shader SCShader;

	// Token: 0x04001432 RID: 5170
	private string ShaderName = "CameraFilterPack/Gradients_FireGradient";

	// Token: 0x04001433 RID: 5171
	private float TimeX = 1f;

	// Token: 0x04001434 RID: 5172
	private Material SCMaterial;

	// Token: 0x04001435 RID: 5173
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001436 RID: 5174
	[Range(0f, 1f)]
	public float Fade = 1f;
}
