using System;
using UnityEngine;

// Token: 0x02000149 RID: 329
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blur/Blurry")]
public class CameraFilterPack_Blur_Blurry : MonoBehaviour
{
	// Token: 0x1700024D RID: 589
	// (get) Token: 0x06000C73 RID: 3187 RVA: 0x00071E1C File Offset: 0x0007001C
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

	// Token: 0x06000C74 RID: 3188 RVA: 0x00071E50 File Offset: 0x00070050
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Blur_Blurry");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C75 RID: 3189 RVA: 0x00071E74 File Offset: 0x00070074
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (!(this.SCShader != null))
		{
			Graphics.Blit(sourceTexture, destTexture);
			return;
		}
		int fastFilter = this.FastFilter;
		this.TimeX += Time.deltaTime;
		if (this.TimeX > 100f)
		{
			this.TimeX = 0f;
		}
		this.material.SetFloat("_TimeX", this.TimeX);
		this.material.SetFloat("_Amount", this.Amount);
		this.material.SetVector("_ScreenResolution", new Vector2((float)(Screen.width / fastFilter), (float)(Screen.height / fastFilter)));
		int width = sourceTexture.width / fastFilter;
		int height = sourceTexture.height / fastFilter;
		if (this.FastFilter > 1)
		{
			RenderTexture temporary = RenderTexture.GetTemporary(width, height, 0);
			temporary.filterMode = FilterMode.Trilinear;
			Graphics.Blit(sourceTexture, temporary, this.material);
			Graphics.Blit(temporary, destTexture);
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture, this.material);
	}

	// Token: 0x06000C76 RID: 3190 RVA: 0x00071F74 File Offset: 0x00070174
	private void Update()
	{
	}

	// Token: 0x06000C77 RID: 3191 RVA: 0x00071F76 File Offset: 0x00070176
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040010BE RID: 4286
	public Shader SCShader;

	// Token: 0x040010BF RID: 4287
	private float TimeX = 1f;

	// Token: 0x040010C0 RID: 4288
	private Material SCMaterial;

	// Token: 0x040010C1 RID: 4289
	[Range(0f, 20f)]
	public float Amount = 2f;

	// Token: 0x040010C2 RID: 4290
	[Range(1f, 8f)]
	public int FastFilter = 2;
}
