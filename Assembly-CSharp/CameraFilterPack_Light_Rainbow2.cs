using System;
using UnityEngine;

// Token: 0x020001D9 RID: 473
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Rainbow2")]
public class CameraFilterPack_Light_Rainbow2 : MonoBehaviour
{
	// Token: 0x170002DE RID: 734
	// (get) Token: 0x06000FD8 RID: 4056 RVA: 0x000800FC File Offset: 0x0007E2FC
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

	// Token: 0x06000FD9 RID: 4057 RVA: 0x00080130 File Offset: 0x0007E330
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Rainbow2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FDA RID: 4058 RVA: 0x00080154 File Offset: 0x0007E354
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

	// Token: 0x06000FDB RID: 4059 RVA: 0x0008020A File Offset: 0x0007E40A
	private void Update()
	{
	}

	// Token: 0x06000FDC RID: 4060 RVA: 0x0008020C File Offset: 0x0007E40C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001447 RID: 5191
	public Shader SCShader;

	// Token: 0x04001448 RID: 5192
	private float TimeX = 1f;

	// Token: 0x04001449 RID: 5193
	private Material SCMaterial;

	// Token: 0x0400144A RID: 5194
	[Range(0.01f, 5f)]
	public float Value = 1.5f;
}
