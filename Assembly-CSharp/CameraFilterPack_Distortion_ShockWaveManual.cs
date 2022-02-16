using System;
using UnityEngine;

// Token: 0x02000181 RID: 385
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/ShockWave Manual")]
public class CameraFilterPack_Distortion_ShockWaveManual : MonoBehaviour
{
	// Token: 0x17000285 RID: 645
	// (get) Token: 0x06000DC5 RID: 3525 RVA: 0x000776BF File Offset: 0x000758BF
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

	// Token: 0x06000DC6 RID: 3526 RVA: 0x000776F3 File Offset: 0x000758F3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_ShockWaveManual");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DC7 RID: 3527 RVA: 0x00077714 File Offset: 0x00075914
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

	// Token: 0x06000DC8 RID: 3528 RVA: 0x0007780C File Offset: 0x00075A0C
	private void Update()
	{
	}

	// Token: 0x06000DC9 RID: 3529 RVA: 0x0007780E File Offset: 0x00075A0E
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001206 RID: 4614
	public Shader SCShader;

	// Token: 0x04001207 RID: 4615
	private float TimeX = 1f;

	// Token: 0x04001208 RID: 4616
	private Material SCMaterial;

	// Token: 0x04001209 RID: 4617
	[Range(-1.5f, 1.5f)]
	public float PosX = 0.5f;

	// Token: 0x0400120A RID: 4618
	[Range(-1.5f, 1.5f)]
	public float PosY = 0.5f;

	// Token: 0x0400120B RID: 4619
	[Range(-0.1f, 2f)]
	public float Value = 0.5f;

	// Token: 0x0400120C RID: 4620
	[Range(0f, 10f)]
	public float Size = 1f;
}
