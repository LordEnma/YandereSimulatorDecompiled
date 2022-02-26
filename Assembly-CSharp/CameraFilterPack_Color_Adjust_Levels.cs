using System;
using UnityEngine;

// Token: 0x0200015B RID: 347
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Levels")]
public class CameraFilterPack_Color_Adjust_Levels : MonoBehaviour
{
	// Token: 0x1700025F RID: 607
	// (get) Token: 0x06000CDF RID: 3295 RVA: 0x00073CF3 File Offset: 0x00071EF3
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

	// Token: 0x06000CE0 RID: 3296 RVA: 0x00073D27 File Offset: 0x00071F27
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Levels");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CE1 RID: 3297 RVA: 0x00073D48 File Offset: 0x00071F48
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

	// Token: 0x06000CE2 RID: 3298 RVA: 0x00073E40 File Offset: 0x00072040
	private void Update()
	{
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x00073E42 File Offset: 0x00072042
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001132 RID: 4402
	public Shader SCShader;

	// Token: 0x04001133 RID: 4403
	private float TimeX = 1f;

	// Token: 0x04001134 RID: 4404
	private Material SCMaterial;

	// Token: 0x04001135 RID: 4405
	[Range(0f, 1f)]
	public float levelMinimum;

	// Token: 0x04001136 RID: 4406
	[Range(0f, 1f)]
	public float levelMiddle = 0.5f;

	// Token: 0x04001137 RID: 4407
	[Range(0f, 1f)]
	public float levelMaximum = 1f;

	// Token: 0x04001138 RID: 4408
	[Range(0f, 1f)]
	public float minOutput;

	// Token: 0x04001139 RID: 4409
	[Range(0f, 1f)]
	public float maxOutput = 1f;
}
