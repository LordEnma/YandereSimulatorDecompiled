using System;
using UnityEngine;

// Token: 0x02000181 RID: 385
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/ShockWave Manual")]
public class CameraFilterPack_Distortion_ShockWaveManual : MonoBehaviour
{
	// Token: 0x17000285 RID: 645
	// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x0007791B File Offset: 0x00075B1B
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

	// Token: 0x06000DC6 RID: 3526 RVA: 0x0007794F File Offset: 0x00075B4F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_ShockWaveManual");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DC7 RID: 3527 RVA: 0x00077970 File Offset: 0x00075B70
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
			this.material.SetFloat("_Value3", this.Value);
			this.material.SetFloat("_Value4", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DC8 RID: 3528 RVA: 0x00077A68 File Offset: 0x00075C68
	private void Update()
	{
	}

	// Token: 0x06000DC9 RID: 3529 RVA: 0x00077A6A File Offset: 0x00075C6A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400120F RID: 4623
	public Shader SCShader;

	// Token: 0x04001210 RID: 4624
	private float TimeX = 1f;

	// Token: 0x04001211 RID: 4625
	private Material SCMaterial;

	// Token: 0x04001212 RID: 4626
	[Range(-1.5f, 1.5f)]
	public float PosX = 0.5f;

	// Token: 0x04001213 RID: 4627
	[Range(-1.5f, 1.5f)]
	public float PosY = 0.5f;

	// Token: 0x04001214 RID: 4628
	[Range(-0.1f, 2f)]
	public float Value = 0.5f;

	// Token: 0x04001215 RID: 4629
	[Range(0f, 10f)]
	public float Size = 1f;
}
