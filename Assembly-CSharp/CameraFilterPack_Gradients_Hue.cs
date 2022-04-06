using System;
using UnityEngine;

// Token: 0x020001D3 RID: 467
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Hue")]
public class CameraFilterPack_Gradients_Hue : MonoBehaviour
{
	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06000FB4 RID: 4020 RVA: 0x0008011C File Offset: 0x0007E31C
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

	// Token: 0x06000FB5 RID: 4021 RVA: 0x00080150 File Offset: 0x0007E350
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FB6 RID: 4022 RVA: 0x00080174 File Offset: 0x0007E374
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

	// Token: 0x06000FB7 RID: 4023 RVA: 0x00080240 File Offset: 0x0007E440
	private void Update()
	{
	}

	// Token: 0x06000FB8 RID: 4024 RVA: 0x00080242 File Offset: 0x0007E442
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
	private string ShaderName = "CameraFilterPack/Gradients_Hue";

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
