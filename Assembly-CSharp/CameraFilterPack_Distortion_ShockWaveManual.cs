using System;
using UnityEngine;

// Token: 0x02000181 RID: 385
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/ShockWave Manual")]
public class CameraFilterPack_Distortion_ShockWaveManual : MonoBehaviour
{
	// Token: 0x17000285 RID: 645
	// (get) Token: 0x06000DC4 RID: 3524 RVA: 0x0007756F File Offset: 0x0007576F
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

	// Token: 0x06000DC5 RID: 3525 RVA: 0x000775A3 File Offset: 0x000757A3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_ShockWaveManual");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DC6 RID: 3526 RVA: 0x000775C4 File Offset: 0x000757C4
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

	// Token: 0x06000DC7 RID: 3527 RVA: 0x000776BC File Offset: 0x000758BC
	private void Update()
	{
	}

	// Token: 0x06000DC8 RID: 3528 RVA: 0x000776BE File Offset: 0x000758BE
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001203 RID: 4611
	public Shader SCShader;

	// Token: 0x04001204 RID: 4612
	private float TimeX = 1f;

	// Token: 0x04001205 RID: 4613
	private Material SCMaterial;

	// Token: 0x04001206 RID: 4614
	[Range(-1.5f, 1.5f)]
	public float PosX = 0.5f;

	// Token: 0x04001207 RID: 4615
	[Range(-1.5f, 1.5f)]
	public float PosY = 0.5f;

	// Token: 0x04001208 RID: 4616
	[Range(-0.1f, 2f)]
	public float Value = 0.5f;

	// Token: 0x04001209 RID: 4617
	[Range(0f, 10f)]
	public float Size = 1f;
}
