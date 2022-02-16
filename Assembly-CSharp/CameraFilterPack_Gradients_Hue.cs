using System;
using UnityEngine;

// Token: 0x020001D3 RID: 467
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Hue")]
public class CameraFilterPack_Gradients_Hue : MonoBehaviour
{
	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06000FB2 RID: 4018 RVA: 0x0007FA44 File Offset: 0x0007DC44
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

	// Token: 0x06000FB3 RID: 4019 RVA: 0x0007FA78 File Offset: 0x0007DC78
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FB4 RID: 4020 RVA: 0x0007FA9C File Offset: 0x0007DC9C
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

	// Token: 0x06000FB5 RID: 4021 RVA: 0x0007FB68 File Offset: 0x0007DD68
	private void Update()
	{
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x0007FB6A File Offset: 0x0007DD6A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001427 RID: 5159
	public Shader SCShader;

	// Token: 0x04001428 RID: 5160
	private string ShaderName = "CameraFilterPack/Gradients_Hue";

	// Token: 0x04001429 RID: 5161
	private float TimeX = 1f;

	// Token: 0x0400142A RID: 5162
	private Material SCMaterial;

	// Token: 0x0400142B RID: 5163
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400142C RID: 5164
	[Range(0f, 1f)]
	public float Fade = 1f;
}
