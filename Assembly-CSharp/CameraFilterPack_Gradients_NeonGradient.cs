using System;
using UnityEngine;

// Token: 0x020001D3 RID: 467
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Neon")]
public class CameraFilterPack_Gradients_NeonGradient : MonoBehaviour
{
	// Token: 0x170002D8 RID: 728
	// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x0007F870 File Offset: 0x0007DA70
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

	// Token: 0x06000FB5 RID: 4021 RVA: 0x0007F8A4 File Offset: 0x0007DAA4
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x0007F8C8 File Offset: 0x0007DAC8
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

	// Token: 0x06000FB7 RID: 4023 RVA: 0x0007F994 File Offset: 0x0007DB94
	private void Update()
	{
	}

	// Token: 0x06000FB8 RID: 4024 RVA: 0x0007F996 File Offset: 0x0007DB96
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001425 RID: 5157
	public Shader SCShader;

	// Token: 0x04001426 RID: 5158
	private string ShaderName = "CameraFilterPack/Gradients_NeonGradient";

	// Token: 0x04001427 RID: 5159
	private float TimeX = 1f;

	// Token: 0x04001428 RID: 5160
	private Material SCMaterial;

	// Token: 0x04001429 RID: 5161
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400142A RID: 5162
	[Range(0f, 1f)]
	public float Fade = 1f;
}
