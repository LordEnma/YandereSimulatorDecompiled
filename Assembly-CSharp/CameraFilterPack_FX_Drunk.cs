using System;
using UnityEngine;

// Token: 0x020001AF RID: 431
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Drunk")]
public class CameraFilterPack_FX_Drunk : MonoBehaviour
{
	// Token: 0x170002B3 RID: 691
	// (get) Token: 0x06000EDA RID: 3802 RVA: 0x0007BF0C File Offset: 0x0007A10C
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

	// Token: 0x06000EDB RID: 3803 RVA: 0x0007BF40 File Offset: 0x0007A140
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Drunk");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EDC RID: 3804 RVA: 0x0007BF64 File Offset: 0x0007A164
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetFloat("_Speed", this.Speed);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_DistortionWave", this.DistortionWave);
			this.material.SetFloat("_Wavy", this.Wavy);
			this.material.SetFloat("_Fade", this.Fade);
			this.material.SetFloat("_ColoredChange", this.ColoredChange);
			this.material.SetFloat("_ChangeRed", this.ChangeRed);
			this.material.SetFloat("_ChangeGreen", this.ChangeGreen);
			this.material.SetFloat("_ChangeBlue", this.ChangeBlue);
			this.material.SetFloat("_Colored", this.ColoredSaturate);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000EDD RID: 3805 RVA: 0x0007C0F6 File Offset: 0x0007A2F6
	private void Update()
	{
	}

	// Token: 0x06000EDE RID: 3806 RVA: 0x0007C0F8 File Offset: 0x0007A2F8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001331 RID: 4913
	public Shader SCShader;

	// Token: 0x04001332 RID: 4914
	private float TimeX = 1f;

	// Token: 0x04001333 RID: 4915
	private Material SCMaterial;

	// Token: 0x04001334 RID: 4916
	[HideInInspector]
	[Range(0f, 20f)]
	public float Value = 6f;

	// Token: 0x04001335 RID: 4917
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x04001336 RID: 4918
	[Range(0f, 1f)]
	public float Wavy = 1f;

	// Token: 0x04001337 RID: 4919
	[Range(0f, 1f)]
	public float Distortion;

	// Token: 0x04001338 RID: 4920
	[Range(0f, 1f)]
	public float DistortionWave;

	// Token: 0x04001339 RID: 4921
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x0400133A RID: 4922
	[Range(-2f, 2f)]
	public float ColoredSaturate = 1f;

	// Token: 0x0400133B RID: 4923
	[Range(-1f, 2f)]
	public float ColoredChange;

	// Token: 0x0400133C RID: 4924
	[Range(-1f, 1f)]
	public float ChangeRed;

	// Token: 0x0400133D RID: 4925
	[Range(-1f, 1f)]
	public float ChangeGreen;

	// Token: 0x0400133E RID: 4926
	[Range(-1f, 1f)]
	public float ChangeBlue;
}
