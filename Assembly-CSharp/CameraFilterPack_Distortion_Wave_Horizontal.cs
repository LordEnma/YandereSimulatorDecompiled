using System;
using UnityEngine;

// Token: 0x02000185 RID: 389
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Wave_Horizontal")]
public class CameraFilterPack_Distortion_Wave_Horizontal : MonoBehaviour
{
	// Token: 0x17000289 RID: 649
	// (get) Token: 0x06000DDD RID: 3549 RVA: 0x00077F92 File Offset: 0x00076192
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

	// Token: 0x06000DDE RID: 3550 RVA: 0x00077FC6 File Offset: 0x000761C6
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Wave_Horizontal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DDF RID: 3551 RVA: 0x00077FE8 File Offset: 0x000761E8
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			this.material.SetFloat("_WaveIntensity", this.WaveIntensity);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DE0 RID: 3552 RVA: 0x00078097 File Offset: 0x00076297
	private void Update()
	{
	}

	// Token: 0x06000DE1 RID: 3553 RVA: 0x00078099 File Offset: 0x00076299
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
	[Range(1f, 100f)]
	public float WaveIntensity = 32f;
}
