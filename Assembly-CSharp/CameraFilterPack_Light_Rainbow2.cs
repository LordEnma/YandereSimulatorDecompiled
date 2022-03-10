using System;
using UnityEngine;

// Token: 0x020001DA RID: 474
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Rainbow2")]
public class CameraFilterPack_Light_Rainbow2 : MonoBehaviour
{
	// Token: 0x170002DE RID: 734
	// (get) Token: 0x06000FDC RID: 4060 RVA: 0x000806A0 File Offset: 0x0007E8A0
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

	// Token: 0x06000FDD RID: 4061 RVA: 0x000806D4 File Offset: 0x0007E8D4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Rainbow2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FDE RID: 4062 RVA: 0x000806F8 File Offset: 0x0007E8F8
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

	// Token: 0x06000FDF RID: 4063 RVA: 0x000807AE File Offset: 0x0007E9AE
	private void Update()
	{
	}

	// Token: 0x06000FE0 RID: 4064 RVA: 0x000807B0 File Offset: 0x0007E9B0
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001458 RID: 5208
	public Shader SCShader;

	// Token: 0x04001459 RID: 5209
	private float TimeX = 1f;

	// Token: 0x0400145A RID: 5210
	private Material SCMaterial;

	// Token: 0x0400145B RID: 5211
	[Range(0.01f, 5f)]
	public float Value = 1.5f;
}
