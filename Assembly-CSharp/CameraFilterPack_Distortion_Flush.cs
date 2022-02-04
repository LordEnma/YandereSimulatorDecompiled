using System;
using UnityEngine;

// Token: 0x0200017B RID: 379
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Flush")]
public class CameraFilterPack_Distortion_Flush : MonoBehaviour
{
	// Token: 0x1700027F RID: 639
	// (get) Token: 0x06000DA0 RID: 3488 RVA: 0x00076CFD File Offset: 0x00074EFD
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

	// Token: 0x06000DA1 RID: 3489 RVA: 0x00076D31 File Offset: 0x00074F31
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Flush");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DA2 RID: 3490 RVA: 0x00076D54 File Offset: 0x00074F54
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
			this.material.SetFloat("Value", this.Value);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DA3 RID: 3491 RVA: 0x00076E0A File Offset: 0x0007500A
	private void Update()
	{
	}

	// Token: 0x06000DA4 RID: 3492 RVA: 0x00076E0C File Offset: 0x0007500C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011E3 RID: 4579
	public Shader SCShader;

	// Token: 0x040011E4 RID: 4580
	private float TimeX = 1f;

	// Token: 0x040011E5 RID: 4581
	private Material SCMaterial;

	// Token: 0x040011E6 RID: 4582
	[Range(-10f, 50f)]
	public float Value = 5f;
}
