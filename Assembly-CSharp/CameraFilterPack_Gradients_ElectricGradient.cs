using System;
using UnityEngine;

// Token: 0x020001D1 RID: 465
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Electric")]
public class CameraFilterPack_Gradients_ElectricGradient : MonoBehaviour
{
	// Token: 0x170002D5 RID: 725
	// (get) Token: 0x06000FA6 RID: 4006 RVA: 0x0007F75C File Offset: 0x0007D95C
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

	// Token: 0x06000FA7 RID: 4007 RVA: 0x0007F790 File Offset: 0x0007D990
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FA8 RID: 4008 RVA: 0x0007F7B4 File Offset: 0x0007D9B4
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

	// Token: 0x06000FA9 RID: 4009 RVA: 0x0007F880 File Offset: 0x0007DA80
	private void Update()
	{
	}

	// Token: 0x06000FAA RID: 4010 RVA: 0x0007F882 File Offset: 0x0007DA82
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400141B RID: 5147
	public Shader SCShader;

	// Token: 0x0400141C RID: 5148
	private string ShaderName = "CameraFilterPack/Gradients_ElectricGradient";

	// Token: 0x0400141D RID: 5149
	private float TimeX = 1f;

	// Token: 0x0400141E RID: 5150
	private Material SCMaterial;

	// Token: 0x0400141F RID: 5151
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x04001420 RID: 5152
	[Range(0f, 1f)]
	public float Fade = 1f;
}
