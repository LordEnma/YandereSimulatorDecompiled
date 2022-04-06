using System;
using UnityEngine;

// Token: 0x02000180 RID: 384
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/ShockWave")]
public class CameraFilterPack_Distortion_ShockWave : MonoBehaviour
{
	// Token: 0x17000284 RID: 644
	// (get) Token: 0x06000DC1 RID: 3521 RVA: 0x00077BED File Offset: 0x00075DED
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

	// Token: 0x06000DC2 RID: 3522 RVA: 0x00077C21 File Offset: 0x00075E21
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_ShockWave");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DC3 RID: 3523 RVA: 0x00077C44 File Offset: 0x00075E44
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

	// Token: 0x06000DC4 RID: 3524 RVA: 0x00077D3C File Offset: 0x00075F3C
	private void Update()
	{
	}

	// Token: 0x06000DC5 RID: 3525 RVA: 0x00077D3E File Offset: 0x00075F3E
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
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001215 RID: 4629
	[Range(0f, 10f)]
	private float Size = 1f;
}
