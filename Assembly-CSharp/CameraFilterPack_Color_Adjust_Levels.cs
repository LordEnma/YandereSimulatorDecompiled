using System;
using UnityEngine;

// Token: 0x0200015A RID: 346
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Colors/Levels")]
public class CameraFilterPack_Color_Adjust_Levels : MonoBehaviour
{
	// Token: 0x1700025F RID: 607
	// (get) Token: 0x06000CDB RID: 3291 RVA: 0x00073897 File Offset: 0x00071A97
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

	// Token: 0x06000CDC RID: 3292 RVA: 0x000738CB File Offset: 0x00071ACB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Color_Levels");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000CDD RID: 3293 RVA: 0x000738EC File Offset: 0x00071AEC
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

	// Token: 0x06000CDE RID: 3294 RVA: 0x000739E4 File Offset: 0x00071BE4
	private void Update()
	{
	}

	// Token: 0x06000CDF RID: 3295 RVA: 0x000739E6 File Offset: 0x00071BE6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400112A RID: 4394
	public Shader SCShader;

	// Token: 0x0400112B RID: 4395
	private float TimeX = 1f;

	// Token: 0x0400112C RID: 4396
	private Material SCMaterial;

	// Token: 0x0400112D RID: 4397
	[Range(0f, 1f)]
	public float levelMinimum;

	// Token: 0x0400112E RID: 4398
	[Range(0f, 1f)]
	public float levelMiddle = 0.5f;

	// Token: 0x0400112F RID: 4399
	[Range(0f, 1f)]
	public float levelMaximum = 1f;

	// Token: 0x04001130 RID: 4400
	[Range(0f, 1f)]
	public float minOutput;

	// Token: 0x04001131 RID: 4401
	[Range(0f, 1f)]
	public float maxOutput = 1f;
}
