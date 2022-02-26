using System;
using UnityEngine;

// Token: 0x0200014F RID: 335
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Noise")]
public class CameraFilterPack_Blur_Noise : MonoBehaviour
{
	// Token: 0x17000253 RID: 595
	// (get) Token: 0x06000C97 RID: 3223 RVA: 0x00072732 File Offset: 0x00070932
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

	// Token: 0x06000C98 RID: 3224 RVA: 0x00072766 File Offset: 0x00070966
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C99 RID: 3225 RVA: 0x00072788 File Offset: 0x00070988
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

	// Token: 0x06000C9A RID: 3226 RVA: 0x0007285A File Offset: 0x00070A5A
	private void Update()
	{
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x0007285C File Offset: 0x00070A5C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010DE RID: 4318
	public Shader SCShader;

	// Token: 0x040010DF RID: 4319
	private float TimeX = 1f;

	// Token: 0x040010E0 RID: 4320
	private Material SCMaterial;

	// Token: 0x040010E1 RID: 4321
	[Range(2f, 16f)]
	public int Level = 4;

	// Token: 0x040010E2 RID: 4322
	public Vector2 Distance = new Vector2(30f, 0f);
}
