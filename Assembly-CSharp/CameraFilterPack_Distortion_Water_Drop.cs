using System;
using UnityEngine;

// Token: 0x02000184 RID: 388
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Water_Drop")]
public class CameraFilterPack_Distortion_Water_Drop : MonoBehaviour
{
	// Token: 0x17000288 RID: 648
	// (get) Token: 0x06000DD7 RID: 3543 RVA: 0x00077E08 File Offset: 0x00076008
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

	// Token: 0x06000DD8 RID: 3544 RVA: 0x00077E3C File Offset: 0x0007603C
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Water_Drop");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DD9 RID: 3545 RVA: 0x00077E60 File Offset: 0x00076060
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
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			this.material.SetFloat("_CenterX", this.CenterX);
			this.material.SetFloat("_CenterY", this.CenterY);
			this.material.SetFloat("_WaveIntensity", this.WaveIntensity);
			this.material.SetInt("_NumberOfWaves", this.NumberOfWaves);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DDA RID: 3546 RVA: 0x00077F51 File Offset: 0x00076151
	private void Update()
	{
	}

	// Token: 0x06000DDB RID: 3547 RVA: 0x00077F53 File Offset: 0x00076153
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001224 RID: 4644
	public Shader SCShader;

	// Token: 0x04001225 RID: 4645
	private float TimeX = 1f;

	// Token: 0x04001226 RID: 4646
	private Material SCMaterial;

	// Token: 0x04001227 RID: 4647
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x04001228 RID: 4648
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x04001229 RID: 4649
	[Range(0f, 10f)]
	public float WaveIntensity = 1f;

	// Token: 0x0400122A RID: 4650
	[Range(0f, 20f)]
	public int NumberOfWaves = 5;
}
