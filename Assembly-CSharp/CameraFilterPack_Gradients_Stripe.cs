using System;
using UnityEngine;

// Token: 0x020001D6 RID: 470
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Stripe")]
public class CameraFilterPack_Gradients_Stripe : MonoBehaviour
{
	// Token: 0x170002DA RID: 730
	// (get) Token: 0x06000FC6 RID: 4038 RVA: 0x00080578 File Offset: 0x0007E778
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

	// Token: 0x06000FC7 RID: 4039 RVA: 0x000805AC File Offset: 0x0007E7AC
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FC8 RID: 4040 RVA: 0x000805D0 File Offset: 0x0007E7D0
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

	// Token: 0x06000FC9 RID: 4041 RVA: 0x0008069C File Offset: 0x0007E89C
	private void Update()
	{
	}

	// Token: 0x06000FCA RID: 4042 RVA: 0x0008069E File Offset: 0x0007E89E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001449 RID: 5193
	public Shader SCShader;

	// Token: 0x0400144A RID: 5194
	private string ShaderName = "CameraFilterPack/Gradients_Stripe";

	// Token: 0x0400144B RID: 5195
	private float TimeX = 1f;

	// Token: 0x0400144C RID: 5196
	private Material SCMaterial;

	// Token: 0x0400144D RID: 5197
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400144E RID: 5198
	[Range(0f, 1f)]
	public float Fade = 1f;
}
