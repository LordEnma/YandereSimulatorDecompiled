using System;
using UnityEngine;

// Token: 0x02000149 RID: 329
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/DitherOffset")]
public class CameraFilterPack_Blur_DitherOffset : MonoBehaviour
{
	// Token: 0x1700024E RID: 590
	// (get) Token: 0x06000C75 RID: 3189 RVA: 0x00071B59 File Offset: 0x0006FD59
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

	// Token: 0x06000C76 RID: 3190 RVA: 0x00071B8D File Offset: 0x0006FD8D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_DitherOffset");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x00071BB0 File Offset: 0x0006FDB0
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

	// Token: 0x06000C78 RID: 3192 RVA: 0x00071C82 File Offset: 0x0006FE82
	private void Update()
	{
	}

	// Token: 0x06000C79 RID: 3193 RVA: 0x00071C84 File Offset: 0x0006FE84
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010BB RID: 4283
	public Shader SCShader;

	// Token: 0x040010BC RID: 4284
	private float TimeX = 1f;

	// Token: 0x040010BD RID: 4285
	private Material SCMaterial;

	// Token: 0x040010BE RID: 4286
	[Range(1f, 16f)]
	public int Level = 4;

	// Token: 0x040010BF RID: 4287
	public Vector2 Distance = new Vector2(30f, 0f);
}
