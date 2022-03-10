using System;
using UnityEngine;

// Token: 0x020001AB RID: 427
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/DarkMatter")]
public class CameraFilterPack_FX_DarkMatter : MonoBehaviour
{
	// Token: 0x170002AF RID: 687
	// (get) Token: 0x06000EC2 RID: 3778 RVA: 0x0007B86D File Offset: 0x00079A6D
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

	// Token: 0x06000EC3 RID: 3779 RVA: 0x0007B8A1 File Offset: 0x00079AA1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_DarkMatter");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EC4 RID: 3780 RVA: 0x0007B8C4 File Offset: 0x00079AC4
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
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("_Value3", this.PosX);
			this.material.SetFloat("_Value4", this.PosY);
			this.material.SetFloat("_Value5", this.Zoom);
			this.material.SetFloat("_Value6", this.DarkIntensity);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EC5 RID: 3781 RVA: 0x0007B9E8 File Offset: 0x00079BE8
	private void Update()
	{
	}

	// Token: 0x06000EC6 RID: 3782 RVA: 0x0007B9EA File Offset: 0x00079BEA
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001316 RID: 4886
	public Shader SCShader;

	// Token: 0x04001317 RID: 4887
	private float TimeX = 1f;

	// Token: 0x04001318 RID: 4888
	private Material SCMaterial;

	// Token: 0x04001319 RID: 4889
	[Range(-10f, 10f)]
	public float Speed = 0.8f;

	// Token: 0x0400131A RID: 4890
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x0400131B RID: 4891
	[Range(-1f, 2f)]
	public float PosX = 0.5f;

	// Token: 0x0400131C RID: 4892
	[Range(-1f, 2f)]
	public float PosY = 0.5f;

	// Token: 0x0400131D RID: 4893
	[Range(-2f, 2f)]
	public float Zoom = 0.33f;

	// Token: 0x0400131E RID: 4894
	[Range(0f, 5f)]
	public float DarkIntensity = 2f;
}
