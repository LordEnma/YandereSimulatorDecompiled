using System;
using UnityEngine;

// Token: 0x020001D6 RID: 470
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Stripe")]
public class CameraFilterPack_Gradients_Stripe : MonoBehaviour
{
	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06000FC4 RID: 4036 RVA: 0x000800FC File Offset: 0x0007E2FC
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

	// Token: 0x06000FC5 RID: 4037 RVA: 0x00080130 File Offset: 0x0007E330
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FC6 RID: 4038 RVA: 0x00080154 File Offset: 0x0007E354
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

	// Token: 0x06000FC7 RID: 4039 RVA: 0x00080220 File Offset: 0x0007E420
	private void Update()
	{
	}

	// Token: 0x06000FC8 RID: 4040 RVA: 0x00080222 File Offset: 0x0007E422
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001442 RID: 5186
	public Shader SCShader;

	// Token: 0x04001443 RID: 5187
	private string ShaderName = "CameraFilterPack/Gradients_Stripe";

	// Token: 0x04001444 RID: 5188
	private float TimeX = 1f;

	// Token: 0x04001445 RID: 5189
	private Material SCMaterial;

	// Token: 0x04001446 RID: 5190
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001447 RID: 5191
	[Range(0f, 1f)]
	public float Fade = 1f;
}
