using System;
using UnityEngine;

// Token: 0x020001D8 RID: 472
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Thermal")]
public class CameraFilterPack_Gradients_Therma : MonoBehaviour
{
	// Token: 0x170002DC RID: 732
	// (get) Token: 0x06000FD2 RID: 4050 RVA: 0x00080860 File Offset: 0x0007EA60
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

	// Token: 0x06000FD3 RID: 4051 RVA: 0x00080894 File Offset: 0x0007EA94
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FD4 RID: 4052 RVA: 0x000808B8 File Offset: 0x0007EAB8
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

	// Token: 0x06000FD5 RID: 4053 RVA: 0x00080984 File Offset: 0x0007EB84
	private void Update()
	{
	}

	// Token: 0x06000FD6 RID: 4054 RVA: 0x00080986 File Offset: 0x0007EB86
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001455 RID: 5205
	public Shader SCShader;

	// Token: 0x04001456 RID: 5206
	private string ShaderName = "CameraFilterPack/Gradients_Therma";

	// Token: 0x04001457 RID: 5207
	private float TimeX = 1f;

	// Token: 0x04001458 RID: 5208
	private Material SCMaterial;

	// Token: 0x04001459 RID: 5209
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400145A RID: 5210
	[Range(0f, 1f)]
	public float Fade = 1f;
}
