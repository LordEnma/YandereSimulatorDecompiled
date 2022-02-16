using System;
using UnityEngine;

// Token: 0x020001D0 RID: 464
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Gradients/Desert")]
public class CameraFilterPack_Gradients_Desert : MonoBehaviour
{
	// Token: 0x170002D4 RID: 724
	// (get) Token: 0x06000FA0 RID: 4000 RVA: 0x0007F5E8 File Offset: 0x0007D7E8
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

	// Token: 0x06000FA1 RID: 4001 RVA: 0x0007F61C File Offset: 0x0007D81C
	private void Start()
	{
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FA2 RID: 4002 RVA: 0x0007F640 File Offset: 0x0007D840
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

	// Token: 0x06000FA3 RID: 4003 RVA: 0x0007F70C File Offset: 0x0007D90C
	private void Update()
	{
	}

	// Token: 0x06000FA4 RID: 4004 RVA: 0x0007F70E File Offset: 0x0007D90E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001415 RID: 5141
	public Shader SCShader;

	// Token: 0x04001416 RID: 5142
	private string ShaderName = "CameraFilterPack/Gradients_Desert";

	// Token: 0x04001417 RID: 5143
	private float TimeX = 1f;

	// Token: 0x04001418 RID: 5144
	private Material SCMaterial;

	// Token: 0x04001419 RID: 5145
	[Range(0f, 1f)]
	public float Switch = 1f;

	// Token: 0x0400141A RID: 5146
	[Range(0f, 1f)]
	public float Fade = 1f;
}
