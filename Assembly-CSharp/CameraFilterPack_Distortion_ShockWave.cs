using System;
using UnityEngine;

// Token: 0x0200017F RID: 383
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/ShockWave")]
public class CameraFilterPack_Distortion_ShockWave : MonoBehaviour
{
	// Token: 0x17000284 RID: 644
	// (get) Token: 0x06000DBB RID: 3515 RVA: 0x000771CD File Offset: 0x000753CD
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

	// Token: 0x06000DBC RID: 3516 RVA: 0x00077201 File Offset: 0x00075401
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_ShockWave");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DBD RID: 3517 RVA: 0x00077224 File Offset: 0x00075424
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
			this.material.SetFloat("_Value", this.PosX);
			this.material.SetFloat("_Value2", this.PosY);
			this.material.SetFloat("_Value3", this.Speed);
			this.material.SetFloat("_Value4", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DBE RID: 3518 RVA: 0x0007731C File Offset: 0x0007551C
	private void Update()
	{
	}

	// Token: 0x06000DBF RID: 3519 RVA: 0x0007731E File Offset: 0x0007551E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011F7 RID: 4599
	public Shader SCShader;

	// Token: 0x040011F8 RID: 4600
	private float TimeX = 1f;

	// Token: 0x040011F9 RID: 4601
	private Material SCMaterial;

	// Token: 0x040011FA RID: 4602
	[Range(-1.5f, 1.5f)]
	public float PosX = 0.5f;

	// Token: 0x040011FB RID: 4603
	[Range(-1.5f, 1.5f)]
	public float PosY = 0.5f;

	// Token: 0x040011FC RID: 4604
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x040011FD RID: 4605
	[Range(0f, 10f)]
	private float Size = 1f;
}
