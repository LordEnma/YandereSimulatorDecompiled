using System;
using UnityEngine;

// Token: 0x02000217 RID: 535
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/RGB Display")]
public class CameraFilterPack_TV_Rgb : MonoBehaviour
{
	// Token: 0x1700031B RID: 795
	// (get) Token: 0x0600116D RID: 4461 RVA: 0x00087F95 File Offset: 0x00086195
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

	// Token: 0x0600116E RID: 4462 RVA: 0x00087FC9 File Offset: 0x000861C9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_Rgb");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x0600116F RID: 4463 RVA: 0x00087FEC File Offset: 0x000861EC
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06001170 RID: 4464 RVA: 0x000880A2 File Offset: 0x000862A2
	private void Update()
	{
	}

	// Token: 0x06001171 RID: 4465 RVA: 0x000880A4 File Offset: 0x000862A4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001607 RID: 5639
	public Shader SCShader;

	// Token: 0x04001608 RID: 5640
	private float TimeX = 1f;

	// Token: 0x04001609 RID: 5641
	[Range(0.01f, 4f)]
	public float Distortion = 1f;

	// Token: 0x0400160A RID: 5642
	private Material SCMaterial;
}
