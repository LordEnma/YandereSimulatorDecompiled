using System;
using UnityEngine;

// Token: 0x020001AF RID: 431
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Drunk")]
public class CameraFilterPack_FX_Drunk : MonoBehaviour
{
	// Token: 0x170002B3 RID: 691
	// (get) Token: 0x06000EDC RID: 3804 RVA: 0x0007C388 File Offset: 0x0007A588
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

	// Token: 0x06000EDD RID: 3805 RVA: 0x0007C3BC File Offset: 0x0007A5BC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Drunk");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EDE RID: 3806 RVA: 0x0007C3E0 File Offset: 0x0007A5E0
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

	// Token: 0x06000EDF RID: 3807 RVA: 0x0007C572 File Offset: 0x0007A772
	private void Update()
	{
	}

	// Token: 0x06000EE0 RID: 3808 RVA: 0x0007C574 File Offset: 0x0007A774
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001338 RID: 4920
	public Shader SCShader;

	// Token: 0x04001339 RID: 4921
	private float TimeX = 1f;

	// Token: 0x0400133A RID: 4922
	private Material SCMaterial;

	// Token: 0x0400133B RID: 4923
	[HideInInspector]
	[Range(0f, 20f)]
	public float Value = 6f;

	// Token: 0x0400133C RID: 4924
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x0400133D RID: 4925
	[Range(0f, 1f)]
	public float Wavy = 1f;

	// Token: 0x0400133E RID: 4926
	[Range(0f, 1f)]
	public float Distortion;

	// Token: 0x0400133F RID: 4927
	[Range(0f, 1f)]
	public float DistortionWave;

	// Token: 0x04001340 RID: 4928
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x04001341 RID: 4929
	[Range(-2f, 2f)]
	public float ColoredSaturate = 1f;

	// Token: 0x04001342 RID: 4930
	[Range(-1f, 2f)]
	public float ColoredChange;

	// Token: 0x04001343 RID: 4931
	[Range(-1f, 1f)]
	public float ChangeRed;

	// Token: 0x04001344 RID: 4932
	[Range(-1f, 1f)]
	public float ChangeGreen;

	// Token: 0x04001345 RID: 4933
	[Range(-1f, 1f)]
	public float ChangeBlue;
}
