using System;
using UnityEngine;

// Token: 0x0200015B RID: 347
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Levels")]
public class CameraFilterPack_Color_Adjust_Levels : MonoBehaviour
{
	// Token: 0x1700025F RID: 607
	// (get) Token: 0x06000CE1 RID: 3297 RVA: 0x000742B7 File Offset: 0x000724B7
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

	// Token: 0x06000CE2 RID: 3298 RVA: 0x000742EB File Offset: 0x000724EB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Levels");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CE3 RID: 3299 RVA: 0x0007430C File Offset: 0x0007250C
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

	// Token: 0x06000CE4 RID: 3300 RVA: 0x00074404 File Offset: 0x00072604
	private void Update()
	{
	}

	// Token: 0x06000CE5 RID: 3301 RVA: 0x00074406 File Offset: 0x00072606
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001142 RID: 4418
	public Shader SCShader;

	// Token: 0x04001143 RID: 4419
	private float TimeX = 1f;

	// Token: 0x04001144 RID: 4420
	private Material SCMaterial;

	// Token: 0x04001145 RID: 4421
	[Range(0f, 1f)]
	public float levelMinimum;

	// Token: 0x04001146 RID: 4422
	[Range(0f, 1f)]
	public float levelMiddle = 0.5f;

	// Token: 0x04001147 RID: 4423
	[Range(0f, 1f)]
	public float levelMaximum = 1f;

	// Token: 0x04001148 RID: 4424
	[Range(0f, 1f)]
	public float minOutput;

	// Token: 0x04001149 RID: 4425
	[Range(0f, 1f)]
	public float maxOutput = 1f;
}
