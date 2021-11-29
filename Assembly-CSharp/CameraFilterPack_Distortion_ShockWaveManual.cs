using System;
using UnityEngine;

// Token: 0x02000180 RID: 384
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/ShockWave Manual")]
public class CameraFilterPack_Distortion_ShockWaveManual : MonoBehaviour
{
	// Token: 0x17000285 RID: 645
	// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x00077377 File Offset: 0x00075577
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

	// Token: 0x06000DC2 RID: 3522 RVA: 0x000773AB File Offset: 0x000755AB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_ShockWaveManual");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DC3 RID: 3523 RVA: 0x000773CC File Offset: 0x000755CC
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

	// Token: 0x06000DC4 RID: 3524 RVA: 0x000774C4 File Offset: 0x000756C4
	private void Update()
	{
	}

	// Token: 0x06000DC5 RID: 3525 RVA: 0x000774C6 File Offset: 0x000756C6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040011FE RID: 4606
	public Shader SCShader;

	// Token: 0x040011FF RID: 4607
	private float TimeX = 1f;

	// Token: 0x04001200 RID: 4608
	private Material SCMaterial;

	// Token: 0x04001201 RID: 4609
	[Range(-1.5f, 1.5f)]
	public float PosX = 0.5f;

	// Token: 0x04001202 RID: 4610
	[Range(-1.5f, 1.5f)]
	public float PosY = 0.5f;

	// Token: 0x04001203 RID: 4611
	[Range(-0.1f, 2f)]
	public float Value = 0.5f;

	// Token: 0x04001204 RID: 4612
	[Range(0f, 10f)]
	public float Size = 1f;
}
