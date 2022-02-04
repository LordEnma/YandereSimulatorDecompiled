using System;
using UnityEngine;

// Token: 0x02000197 RID: 407
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_FlashWhite")]
public class CameraFilterPack_Drawing_Manga_FlashWhite : MonoBehaviour
{
	// Token: 0x1700029B RID: 667
	// (get) Token: 0x06000E48 RID: 3656 RVA: 0x000794B5 File Offset: 0x000776B5
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

	// Token: 0x06000E49 RID: 3657 RVA: 0x000794E9 File Offset: 0x000776E9
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_FlashWhite");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E4A RID: 3658 RVA: 0x0007950C File Offset: 0x0007770C
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", (float)this.Speed);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetFloat("_Intensity", this.Intensity);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E4B RID: 3659 RVA: 0x0007961B File Offset: 0x0007781B
	private void Update()
	{
	}

	// Token: 0x06000E4C RID: 3660 RVA: 0x0007961D File Offset: 0x0007781D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001282 RID: 4738
	public Shader SCShader;

	// Token: 0x04001283 RID: 4739
	private float TimeX = 1f;

	// Token: 0x04001284 RID: 4740
	private Material SCMaterial;

	// Token: 0x04001285 RID: 4741
	[Range(1f, 10f)]
	public float Size = 1f;

	// Token: 0x04001286 RID: 4742
	[Range(0f, 30f)]
	public int Speed = 5;

	// Token: 0x04001287 RID: 4743
	[Range(-1f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x04001288 RID: 4744
	[Range(-1f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x04001289 RID: 4745
	[Range(0f, 1f)]
	public float Intensity = 1f;
}
