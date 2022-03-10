using System;
using UnityEngine;

// Token: 0x0200015B RID: 347
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Levels")]
public class CameraFilterPack_Color_Adjust_Levels : MonoBehaviour
{
	// Token: 0x1700025F RID: 607
	// (get) Token: 0x06000CDF RID: 3295 RVA: 0x00073E3B File Offset: 0x0007203B
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

	// Token: 0x06000CE0 RID: 3296 RVA: 0x00073E6F File Offset: 0x0007206F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Levels");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CE1 RID: 3297 RVA: 0x00073E90 File Offset: 0x00072090
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("levelMinimum", this.levelMinimum);
			this.material.SetFloat("levelMiddle", this.levelMiddle);
			this.material.SetFloat("levelMaximum", this.levelMaximum);
			this.material.SetFloat("minOutput", this.minOutput);
			this.material.SetFloat("maxOutput", this.maxOutput);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000CE2 RID: 3298 RVA: 0x00073F88 File Offset: 0x00072188
	private void Update()
	{
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x00073F8A File Offset: 0x0007218A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400113B RID: 4411
	public Shader SCShader;

	// Token: 0x0400113C RID: 4412
	private float TimeX = 1f;

	// Token: 0x0400113D RID: 4413
	private Material SCMaterial;

	// Token: 0x0400113E RID: 4414
	[Range(0f, 1f)]
	public float levelMinimum;

	// Token: 0x0400113F RID: 4415
	[Range(0f, 1f)]
	public float levelMiddle = 0.5f;

	// Token: 0x04001140 RID: 4416
	[Range(0f, 1f)]
	public float levelMaximum = 1f;

	// Token: 0x04001141 RID: 4417
	[Range(0f, 1f)]
	public float minOutput;

	// Token: 0x04001142 RID: 4418
	[Range(0f, 1f)]
	public float maxOutput = 1f;
}
