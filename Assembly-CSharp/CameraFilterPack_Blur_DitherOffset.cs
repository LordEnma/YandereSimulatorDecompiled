using System;
using UnityEngine;

// Token: 0x0200014A RID: 330
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/DitherOffset")]
public class CameraFilterPack_Blur_DitherOffset : MonoBehaviour
{
	// Token: 0x1700024E RID: 590
	// (get) Token: 0x06000C78 RID: 3192 RVA: 0x00071D51 File Offset: 0x0006FF51
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

	// Token: 0x06000C79 RID: 3193 RVA: 0x00071D85 File Offset: 0x0006FF85
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_DitherOffset");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C7A RID: 3194 RVA: 0x00071DA8 File Offset: 0x0006FFA8
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

	// Token: 0x06000C7B RID: 3195 RVA: 0x00071E7A File Offset: 0x0007007A
	private void Update()
	{
	}

	// Token: 0x06000C7C RID: 3196 RVA: 0x00071E7C File Offset: 0x0007007C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010C0 RID: 4288
	public Shader SCShader;

	// Token: 0x040010C1 RID: 4289
	private float TimeX = 1f;

	// Token: 0x040010C2 RID: 4290
	private Material SCMaterial;

	// Token: 0x040010C3 RID: 4291
	[Range(1f, 16f)]
	public int Level = 4;

	// Token: 0x040010C4 RID: 4292
	public Vector2 Distance = new Vector2(30f, 0f);
}
