using System;
using UnityEngine;

// Token: 0x0200014F RID: 335
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Noise")]
public class CameraFilterPack_Blur_Noise : MonoBehaviour
{
	// Token: 0x17000253 RID: 595
	// (get) Token: 0x06000C99 RID: 3225 RVA: 0x00072CF6 File Offset: 0x00070EF6
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

	// Token: 0x06000C9A RID: 3226 RVA: 0x00072D2A File Offset: 0x00070F2A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C9B RID: 3227 RVA: 0x00072D4C File Offset: 0x00070F4C
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

	// Token: 0x06000C9C RID: 3228 RVA: 0x00072E1E File Offset: 0x0007101E
	private void Update()
	{
	}

	// Token: 0x06000C9D RID: 3229 RVA: 0x00072E20 File Offset: 0x00071020
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010EE RID: 4334
	public Shader SCShader;

	// Token: 0x040010EF RID: 4335
	private float TimeX = 1f;

	// Token: 0x040010F0 RID: 4336
	private Material SCMaterial;

	// Token: 0x040010F1 RID: 4337
	[Range(2f, 16f)]
	public int Level = 4;

	// Token: 0x040010F2 RID: 4338
	public Vector2 Distance = new Vector2(30f, 0f);
}
