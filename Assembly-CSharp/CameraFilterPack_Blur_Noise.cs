using System;
using UnityEngine;

// Token: 0x0200014F RID: 335
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Noise")]
public class CameraFilterPack_Blur_Noise : MonoBehaviour
{
	// Token: 0x17000253 RID: 595
	// (get) Token: 0x06000C96 RID: 3222 RVA: 0x000724CE File Offset: 0x000706CE
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

	// Token: 0x06000C97 RID: 3223 RVA: 0x00072502 File Offset: 0x00070702
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Noise");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C98 RID: 3224 RVA: 0x00072524 File Offset: 0x00070724
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

	// Token: 0x06000C99 RID: 3225 RVA: 0x000725F6 File Offset: 0x000707F6
	private void Update()
	{
	}

	// Token: 0x06000C9A RID: 3226 RVA: 0x000725F8 File Offset: 0x000707F8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010DB RID: 4315
	public Shader SCShader;

	// Token: 0x040010DC RID: 4316
	private float TimeX = 1f;

	// Token: 0x040010DD RID: 4317
	private Material SCMaterial;

	// Token: 0x040010DE RID: 4318
	[Range(2f, 16f)]
	public int Level = 4;

	// Token: 0x040010DF RID: 4319
	public Vector2 Distance = new Vector2(30f, 0f);
}
