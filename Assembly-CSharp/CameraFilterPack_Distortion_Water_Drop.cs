using System;
using UnityEngine;

// Token: 0x02000184 RID: 388
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Water_Drop")]
public class CameraFilterPack_Distortion_Water_Drop : MonoBehaviour
{
	// Token: 0x17000288 RID: 648
	// (get) Token: 0x06000DD6 RID: 3542 RVA: 0x00077A5C File Offset: 0x00075C5C
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

	// Token: 0x06000DD7 RID: 3543 RVA: 0x00077A90 File Offset: 0x00075C90
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Water_Drop");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DD8 RID: 3544 RVA: 0x00077AB4 File Offset: 0x00075CB4
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

	// Token: 0x06000DD9 RID: 3545 RVA: 0x00077BA5 File Offset: 0x00075DA5
	private void Update()
	{
	}

	// Token: 0x06000DDA RID: 3546 RVA: 0x00077BA7 File Offset: 0x00075DA7
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001218 RID: 4632
	public Shader SCShader;

	// Token: 0x04001219 RID: 4633
	private float TimeX = 1f;

	// Token: 0x0400121A RID: 4634
	private Material SCMaterial;

	// Token: 0x0400121B RID: 4635
	[Range(-1f, 1f)]
	public float CenterX;

	// Token: 0x0400121C RID: 4636
	[Range(-1f, 1f)]
	public float CenterY;

	// Token: 0x0400121D RID: 4637
	[Range(0f, 10f)]
	public float WaveIntensity = 1f;

	// Token: 0x0400121E RID: 4638
	[Range(0f, 20f)]
	public int NumberOfWaves = 5;
}
