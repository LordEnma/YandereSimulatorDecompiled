using System;
using UnityEngine;

// Token: 0x02000197 RID: 407
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Manga_FlashWhite")]
public class CameraFilterPack_Drawing_Manga_FlashWhite : MonoBehaviour
{
	// Token: 0x1700029B RID: 667
	// (get) Token: 0x06000E49 RID: 3657 RVA: 0x00079719 File Offset: 0x00077919
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

	// Token: 0x06000E4A RID: 3658 RVA: 0x0007974D File Offset: 0x0007794D
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Manga_FlashWhite");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E4B RID: 3659 RVA: 0x00079770 File Offset: 0x00077970
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

	// Token: 0x06000E4C RID: 3660 RVA: 0x0007987F File Offset: 0x00077A7F
	private void Update()
	{
	}

	// Token: 0x06000E4D RID: 3661 RVA: 0x00079881 File Offset: 0x00077A81
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001285 RID: 4741
	public Shader SCShader;

	// Token: 0x04001286 RID: 4742
	private float TimeX = 1f;

	// Token: 0x04001287 RID: 4743
	private Material SCMaterial;

	// Token: 0x04001288 RID: 4744
	[Range(1f, 10f)]
	public float Size = 1f;

	// Token: 0x04001289 RID: 4745
	[Range(0f, 30f)]
	public int Speed = 5;

	// Token: 0x0400128A RID: 4746
	[Range(-1f, 1f)]
	public float PosX = 0.5f;

	// Token: 0x0400128B RID: 4747
	[Range(-1f, 1f)]
	public float PosY = 0.5f;

	// Token: 0x0400128C RID: 4748
	[Range(0f, 1f)]
	public float Intensity = 1f;
}
