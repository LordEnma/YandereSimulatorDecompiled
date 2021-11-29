using System;
using UnityEngine;

// Token: 0x0200018E RID: 398
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Lines")]
public class CameraFilterPack_Drawing_Lines : MonoBehaviour
{
	// Token: 0x17000293 RID: 659
	// (get) Token: 0x06000E15 RID: 3605 RVA: 0x000788B2 File Offset: 0x00076AB2
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

	// Token: 0x06000E16 RID: 3606 RVA: 0x000788E6 File Offset: 0x00076AE6
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Lines");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E17 RID: 3607 RVA: 0x00078908 File Offset: 0x00076B08
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

	// Token: 0x06000E18 RID: 3608 RVA: 0x00078A00 File Offset: 0x00076C00
	private void Update()
	{
	}

	// Token: 0x06000E19 RID: 3609 RVA: 0x00078A02 File Offset: 0x00076C02
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001255 RID: 4693
	public Shader SCShader;

	// Token: 0x04001256 RID: 4694
	private float TimeX = 1f;

	// Token: 0x04001257 RID: 4695
	private Material SCMaterial;

	// Token: 0x04001258 RID: 4696
	[Range(0.1f, 10f)]
	public float Number = 1f;

	// Token: 0x04001259 RID: 4697
	[Range(0f, 1f)]
	public float Random = 0.5f;

	// Token: 0x0400125A RID: 4698
	[Range(0f, 10f)]
	private float PositionY = 1f;

	// Token: 0x0400125B RID: 4699
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
