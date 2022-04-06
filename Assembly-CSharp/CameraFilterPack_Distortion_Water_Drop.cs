using System;
using UnityEngine;

// Token: 0x02000184 RID: 388
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Water_Drop")]
public class CameraFilterPack_Distortion_Water_Drop : MonoBehaviour
{
	// Token: 0x17000288 RID: 648
	// (get) Token: 0x06000DD9 RID: 3545 RVA: 0x00078284 File Offset: 0x00076484
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

	// Token: 0x06000DDA RID: 3546 RVA: 0x000782B8 File Offset: 0x000764B8
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Water_Drop");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DDB RID: 3547 RVA: 0x000782DC File Offset: 0x000764DC
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

	// Token: 0x06000DDC RID: 3548 RVA: 0x000783CD File Offset: 0x000765CD
	private void Update()
	{
	}

	// Token: 0x06000DDD RID: 3549 RVA: 0x000783CF File Offset: 0x000765CF
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400122B RID: 4651
	public Shader SCShader;

	// Token: 0x0400122C RID: 4652
	private float TimeX = 1f;

	// Token: 0x0400122D RID: 4653
	private Material SCMaterial;

	// Token: 0x0400122E RID: 4654
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x0400122F RID: 4655
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x04001230 RID: 4656
	[Range(0f, 10f)]
	public float WaveIntensity = 1f;

	// Token: 0x04001231 RID: 4657
	[Range(0f, 20f)]
	public int NumberOfWaves = 5;
}
