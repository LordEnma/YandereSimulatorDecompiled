using System;
using UnityEngine;

// Token: 0x020001DA RID: 474
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Rainbow2")]
public class CameraFilterPack_Light_Rainbow2 : MonoBehaviour
{
	// Token: 0x170002DE RID: 734
	// (get) Token: 0x06000FDC RID: 4060 RVA: 0x00080558 File Offset: 0x0007E758
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

	// Token: 0x06000FDD RID: 4061 RVA: 0x0008058C File Offset: 0x0007E78C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Rainbow2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FDE RID: 4062 RVA: 0x000805B0 File Offset: 0x0007E7B0
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

	// Token: 0x06000FDF RID: 4063 RVA: 0x00080666 File Offset: 0x0007E866
	private void Update()
	{
	}

	// Token: 0x06000FE0 RID: 4064 RVA: 0x00080668 File Offset: 0x0007E868
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400144F RID: 5199
	public Shader SCShader;

	// Token: 0x04001450 RID: 5200
	private float TimeX = 1f;

	// Token: 0x04001451 RID: 5201
	private Material SCMaterial;

	// Token: 0x04001452 RID: 5202
	[Range(0.01f, 5f)]
	public float Value = 1.5f;
}
