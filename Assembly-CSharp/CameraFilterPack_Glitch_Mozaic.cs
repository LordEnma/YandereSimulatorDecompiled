using System;
using UnityEngine;

// Token: 0x020001CC RID: 460
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Glitch/Mozaic")]
public class CameraFilterPack_Glitch_Mozaic : MonoBehaviour
{
	// Token: 0x170002D0 RID: 720
	// (get) Token: 0x06000F8A RID: 3978 RVA: 0x0007F455 File Offset: 0x0007D655
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

	// Token: 0x06000F8B RID: 3979 RVA: 0x0007F489 File Offset: 0x0007D689
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Glitch_Mozaic");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000F8C RID: 3980 RVA: 0x0007F4AC File Offset: 0x0007D6AC
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
			this.material.SetFloat("_Value", this.Intensity);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Value3);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000F8D RID: 3981 RVA: 0x0007F5A4 File Offset: 0x0007D7A4
	private void Update()
	{
	}

	// Token: 0x06000F8E RID: 3982 RVA: 0x0007F5A6 File Offset: 0x0007D7A6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001407 RID: 5127
	public Shader SCShader;

	// Token: 0x04001408 RID: 5128
	private float TimeX = 1f;

	// Token: 0x04001409 RID: 5129
	private Material SCMaterial;

	// Token: 0x0400140A RID: 5130
	[Range(0.001f, 10f)]
	public float Intensity = 1f;

	// Token: 0x0400140B RID: 5131
	[Range(0f, 10f)]
	private float Value2 = 1f;

	// Token: 0x0400140C RID: 5132
	[Range(0f, 10f)]
	private float Value3 = 1f;

	// Token: 0x0400140D RID: 5133
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
