using System;
using UnityEngine;

// Token: 0x0200014D RID: 333
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/GaussianBlur")]
public class CameraFilterPack_Blur_GaussianBlur : MonoBehaviour
{
	// Token: 0x17000251 RID: 593
	// (get) Token: 0x06000C8B RID: 3211 RVA: 0x00072329 File Offset: 0x00070529
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

	// Token: 0x06000C8C RID: 3212 RVA: 0x0007235D File Offset: 0x0007055D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_GaussianBlur");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C8D RID: 3213 RVA: 0x00072380 File Offset: 0x00070580
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
			this.material.SetFloat("_Distortion", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C8E RID: 3214 RVA: 0x0007242F File Offset: 0x0007062F
	private void Update()
	{
	}

	// Token: 0x06000C8F RID: 3215 RVA: 0x00072431 File Offset: 0x00070631
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010D4 RID: 4308
	public Shader SCShader;

	// Token: 0x040010D5 RID: 4309
	private float TimeX = 1f;

	// Token: 0x040010D6 RID: 4310
	[Range(1f, 16f)]
	public float Size = 10f;

	// Token: 0x040010D7 RID: 4311
	private Material SCMaterial;
}
