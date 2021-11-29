using System;
using UnityEngine;

// Token: 0x020001D8 RID: 472
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Rainbow")]
public class CameraFilterPack_Light_Rainbow : MonoBehaviour
{
	// Token: 0x170002DD RID: 733
	// (get) Token: 0x06000FD2 RID: 4050 RVA: 0x0007FFB4 File Offset: 0x0007E1B4
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

	// Token: 0x06000FD3 RID: 4051 RVA: 0x0007FFE8 File Offset: 0x0007E1E8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Rainbow");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FD4 RID: 4052 RVA: 0x0008000C File Offset: 0x0007E20C
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

	// Token: 0x06000FD5 RID: 4053 RVA: 0x000800C2 File Offset: 0x0007E2C2
	private void Update()
	{
	}

	// Token: 0x06000FD6 RID: 4054 RVA: 0x000800C4 File Offset: 0x0007E2C4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001443 RID: 5187
	public Shader SCShader;

	// Token: 0x04001444 RID: 5188
	private float TimeX = 1f;

	// Token: 0x04001445 RID: 5189
	private Material SCMaterial;

	// Token: 0x04001446 RID: 5190
	[Range(0.01f, 5f)]
	public float Value = 1.5f;
}
