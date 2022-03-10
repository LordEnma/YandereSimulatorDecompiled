using System;
using UnityEngine;

// Token: 0x020001D9 RID: 473
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Rainbow")]
public class CameraFilterPack_Light_Rainbow : MonoBehaviour
{
	// Token: 0x170002DD RID: 733
	// (get) Token: 0x06000FD6 RID: 4054 RVA: 0x00080558 File Offset: 0x0007E758
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

	// Token: 0x06000FD7 RID: 4055 RVA: 0x0008058C File Offset: 0x0007E78C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Rainbow");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FD8 RID: 4056 RVA: 0x000805B0 File Offset: 0x0007E7B0
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000FD9 RID: 4057 RVA: 0x00080666 File Offset: 0x0007E866
	private void Update()
	{
	}

	// Token: 0x06000FDA RID: 4058 RVA: 0x00080668 File Offset: 0x0007E868
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001454 RID: 5204
	public Shader SCShader;

	// Token: 0x04001455 RID: 5205
	private float TimeX = 1f;

	// Token: 0x04001456 RID: 5206
	private Material SCMaterial;

	// Token: 0x04001457 RID: 5207
	[Range(0.01f, 5f)]
	public float Value = 1.5f;
}
