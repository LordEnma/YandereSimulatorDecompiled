using System;
using UnityEngine;

// Token: 0x0200014A RID: 330
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/DitherOffset")]
public class CameraFilterPack_Blur_DitherOffset : MonoBehaviour
{
	// Token: 0x1700024E RID: 590
	// (get) Token: 0x06000C7B RID: 3195 RVA: 0x00072579 File Offset: 0x00070779
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

	// Token: 0x06000C7C RID: 3196 RVA: 0x000725AD File Offset: 0x000707AD
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_DitherOffset");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C7D RID: 3197 RVA: 0x000725D0 File Offset: 0x000707D0
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

	// Token: 0x06000C7E RID: 3198 RVA: 0x000726A2 File Offset: 0x000708A2
	private void Update()
	{
	}

	// Token: 0x06000C7F RID: 3199 RVA: 0x000726A4 File Offset: 0x000708A4
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010D3 RID: 4307
	public Shader SCShader;

	// Token: 0x040010D4 RID: 4308
	private float TimeX = 1f;

	// Token: 0x040010D5 RID: 4309
	private Material SCMaterial;

	// Token: 0x040010D6 RID: 4310
	[Range(1f, 16f)]
	public int Level = 4;

	// Token: 0x040010D7 RID: 4311
	public Vector2 Distance = new Vector2(30f, 0f);
}
