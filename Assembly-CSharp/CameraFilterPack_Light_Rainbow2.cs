using System;
using UnityEngine;

// Token: 0x020001DA RID: 474
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Light/Rainbow2")]
public class CameraFilterPack_Light_Rainbow2 : MonoBehaviour
{
	// Token: 0x170002DE RID: 734
	// (get) Token: 0x06000FDB RID: 4059 RVA: 0x000802F4 File Offset: 0x0007E4F4
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

	// Token: 0x06000FDC RID: 4060 RVA: 0x00080328 File Offset: 0x0007E528
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Light_Rainbow2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000FDD RID: 4061 RVA: 0x0008034C File Offset: 0x0007E54C
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

	// Token: 0x06000FDE RID: 4062 RVA: 0x00080402 File Offset: 0x0007E602
	private void Update()
	{
	}

	// Token: 0x06000FDF RID: 4063 RVA: 0x00080404 File Offset: 0x0007E604
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400144C RID: 5196
	public Shader SCShader;

	// Token: 0x0400144D RID: 5197
	private float TimeX = 1f;

	// Token: 0x0400144E RID: 5198
	private Material SCMaterial;

	// Token: 0x0400144F RID: 5199
	[Range(0.01f, 5f)]
	public float Value = 1.5f;
}
