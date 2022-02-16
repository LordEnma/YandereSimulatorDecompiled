using System;
using UnityEngine;

// Token: 0x0200017A RID: 378
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Flag")]
public class CameraFilterPack_Distortion_Flag : MonoBehaviour
{
	// Token: 0x1700027E RID: 638
	// (get) Token: 0x06000D9B RID: 3483 RVA: 0x00076D0C File Offset: 0x00074F0C
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

	// Token: 0x06000D9C RID: 3484 RVA: 0x00076D40 File Offset: 0x00074F40
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Flag");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000D9D RID: 3485 RVA: 0x00076D64 File Offset: 0x00074F64
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
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000D9E RID: 3486 RVA: 0x00076E13 File Offset: 0x00075013
	private void Update()
	{
	}

	// Token: 0x06000D9F RID: 3487 RVA: 0x00076E15 File Offset: 0x00075015
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011E1 RID: 4577
	public Shader SCShader;

	// Token: 0x040011E2 RID: 4578
	private float TimeX = 1f;

	// Token: 0x040011E3 RID: 4579
	[Range(0f, 2f)]
	public float Distortion = 1f;

	// Token: 0x040011E4 RID: 4580
	private Material SCMaterial;

	// Token: 0x040011E5 RID: 4581
	public static float ChangeDistortion;
}
