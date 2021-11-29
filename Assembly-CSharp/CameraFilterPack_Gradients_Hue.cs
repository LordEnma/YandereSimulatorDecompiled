using System;
using UnityEngine;

// Token: 0x020001D2 RID: 466
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Hue")]
public class CameraFilterPack_Gradients_Hue : MonoBehaviour
{
	// Token: 0x170002D7 RID: 727
	// (get) Token: 0x06000FAE RID: 4014 RVA: 0x0007F6FC File Offset: 0x0007D8FC
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

	// Token: 0x06000FAF RID: 4015 RVA: 0x0007F730 File Offset: 0x0007D930
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FB0 RID: 4016 RVA: 0x0007F754 File Offset: 0x0007D954
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

	// Token: 0x06000FB1 RID: 4017 RVA: 0x0007F820 File Offset: 0x0007DA20
	private void Update()
	{
	}

	// Token: 0x06000FB2 RID: 4018 RVA: 0x0007F822 File Offset: 0x0007DA22
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
	private string ShaderName = "CameraFilterPack/Gradients_Hue";

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
