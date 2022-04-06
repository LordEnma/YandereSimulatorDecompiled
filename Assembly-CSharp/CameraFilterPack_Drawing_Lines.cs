using System;
using UnityEngine;

// Token: 0x0200018F RID: 399
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Lines")]
public class CameraFilterPack_Drawing_Lines : MonoBehaviour
{
	// Token: 0x17000293 RID: 659
	// (get) Token: 0x06000E1B RID: 3611 RVA: 0x000792D2 File Offset: 0x000774D2
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

	// Token: 0x06000E1C RID: 3612 RVA: 0x00079306 File Offset: 0x00077506
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Lines");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E1D RID: 3613 RVA: 0x00079328 File Offset: 0x00077528
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
			this.material.SetFloat("_Value", this.Number);
			this.material.SetFloat("_Value2", this.Random);
			this.material.SetFloat("_Value3", this.PositionY);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E1E RID: 3614 RVA: 0x00079420 File Offset: 0x00077620
	private void Update()
	{
	}

	// Token: 0x06000E1F RID: 3615 RVA: 0x00079422 File Offset: 0x00077622
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400126D RID: 4717
	public Shader SCShader;

	// Token: 0x0400126E RID: 4718
	private float TimeX = 1f;

	// Token: 0x0400126F RID: 4719
	private Material SCMaterial;

	// Token: 0x04001270 RID: 4720
	[Range(0.1f, 10f)]
	public float Number = 1f;

	// Token: 0x04001271 RID: 4721
	[Range(0f, 1f)]
	public float Random = 0.5f;

	// Token: 0x04001272 RID: 4722
	[Range(0f, 10f)]
	private float PositionY = 1f;

	// Token: 0x04001273 RID: 4723
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
