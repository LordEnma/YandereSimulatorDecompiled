using System;
using UnityEngine;

// Token: 0x02000185 RID: 389
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Wave_Horizontal")]
public class CameraFilterPack_Distortion_Wave_Horizontal : MonoBehaviour
{
	// Token: 0x17000289 RID: 649
	// (get) Token: 0x06000DDC RID: 3548 RVA: 0x00077BE6 File Offset: 0x00075DE6
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

	// Token: 0x06000DDD RID: 3549 RVA: 0x00077C1A File Offset: 0x00075E1A
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Wave_Horizontal");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DDE RID: 3550 RVA: 0x00077C3C File Offset: 0x00075E3C
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

	// Token: 0x06000DDF RID: 3551 RVA: 0x00077CEB File Offset: 0x00075EEB
	private void Update()
	{
	}

	// Token: 0x06000DE0 RID: 3552 RVA: 0x00077CED File Offset: 0x00075EED
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400121F RID: 4639
	public Shader SCShader;

	// Token: 0x04001220 RID: 4640
	private float TimeX = 1f;

	// Token: 0x04001221 RID: 4641
	private Material SCMaterial;

	// Token: 0x04001222 RID: 4642
	[Range(1f, 100f)]
	public float WaveIntensity = 32f;
}
