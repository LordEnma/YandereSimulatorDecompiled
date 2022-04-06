using System;
using UnityEngine;

// Token: 0x0200014B RID: 331
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Dithering2x2")]
public class CameraFilterPack_Blur_Dithering2x2 : MonoBehaviour
{
	// Token: 0x1700024F RID: 591
	// (get) Token: 0x06000C81 RID: 3201 RVA: 0x000726ED File Offset: 0x000708ED
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

	// Token: 0x06000C82 RID: 3202 RVA: 0x00072721 File Offset: 0x00070921
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Dithering2x2");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C83 RID: 3203 RVA: 0x00072744 File Offset: 0x00070944
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
			this.material.SetFloat("_Level", (float)this.Level);
			this.material.SetVector("_Distance", this.Distance);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C84 RID: 3204 RVA: 0x00072816 File Offset: 0x00070A16
	private void Update()
	{
	}

	// Token: 0x06000C85 RID: 3205 RVA: 0x00072818 File Offset: 0x00070A18
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010D8 RID: 4312
	public Shader SCShader;

	// Token: 0x040010D9 RID: 4313
	private float TimeX = 1f;

	// Token: 0x040010DA RID: 4314
	private Material SCMaterial;

	// Token: 0x040010DB RID: 4315
	[Range(2f, 16f)]
	public int Level = 4;

	// Token: 0x040010DC RID: 4316
	public Vector2 Distance = new Vector2(30f, 0f);
}
