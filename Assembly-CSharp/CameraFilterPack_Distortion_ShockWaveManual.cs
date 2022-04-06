using System;
using UnityEngine;

// Token: 0x02000181 RID: 385
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/ShockWave Manual")]
public class CameraFilterPack_Distortion_ShockWaveManual : MonoBehaviour
{
	// Token: 0x17000285 RID: 645
	// (get) Token: 0x06000DC7 RID: 3527 RVA: 0x00077D97 File Offset: 0x00075F97
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

	// Token: 0x06000DC8 RID: 3528 RVA: 0x00077DCB File Offset: 0x00075FCB
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_ShockWaveManual");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DC9 RID: 3529 RVA: 0x00077DEC File Offset: 0x00075FEC
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

	// Token: 0x06000DCA RID: 3530 RVA: 0x00077EE4 File Offset: 0x000760E4
	private void Update()
	{
	}

	// Token: 0x06000DCB RID: 3531 RVA: 0x00077EE6 File Offset: 0x000760E6
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001216 RID: 4630
	public Shader SCShader;

	// Token: 0x04001217 RID: 4631
	private float TimeX = 1f;

	// Token: 0x04001218 RID: 4632
	private Material SCMaterial;

	// Token: 0x04001219 RID: 4633
	[Range(-1.5f, 1.5f)]
	public float PosX = 0.5f;

	// Token: 0x0400121A RID: 4634
	[Range(-1.5f, 1.5f)]
	public float PosY = 0.5f;

	// Token: 0x0400121B RID: 4635
	[Range(-0.1f, 2f)]
	public float Value = 0.5f;

	// Token: 0x0400121C RID: 4636
	[Range(0f, 10f)]
	public float Size = 1f;
}
