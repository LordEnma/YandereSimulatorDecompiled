using System;
using UnityEngine;

// Token: 0x020001AF RID: 431
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Drunk")]
public class CameraFilterPack_FX_Drunk : MonoBehaviour
{
	// Token: 0x170002B3 RID: 691
	// (get) Token: 0x06000ED9 RID: 3801 RVA: 0x0007BB60 File Offset: 0x00079D60
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

	// Token: 0x06000EDA RID: 3802 RVA: 0x0007BB94 File Offset: 0x00079D94
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Drunk");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000EDB RID: 3803 RVA: 0x0007BBB8 File Offset: 0x00079DB8
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

	// Token: 0x06000EDC RID: 3804 RVA: 0x0007BD4A File Offset: 0x00079F4A
	private void Update()
	{
	}

	// Token: 0x06000EDD RID: 3805 RVA: 0x0007BD4C File Offset: 0x00079F4C
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001325 RID: 4901
	public Shader SCShader;

	// Token: 0x04001326 RID: 4902
	private float TimeX = 1f;

	// Token: 0x04001327 RID: 4903
	private Material SCMaterial;

	// Token: 0x04001328 RID: 4904
	[HideInInspector]
	[Range(0f, 20f)]
	public float Value = 6f;

	// Token: 0x04001329 RID: 4905
	[Range(0f, 10f)]
	public float Speed = 1f;

	// Token: 0x0400132A RID: 4906
	[Range(0f, 1f)]
	public float Wavy = 1f;

	// Token: 0x0400132B RID: 4907
	[Range(0f, 1f)]
	public float Distortion;

	// Token: 0x0400132C RID: 4908
	[Range(0f, 1f)]
	public float DistortionWave;

	// Token: 0x0400132D RID: 4909
	[Range(0f, 1f)]
	public float Fade = 1f;

	// Token: 0x0400132E RID: 4910
	[Range(-2f, 2f)]
	public float ColoredSaturate = 1f;

	// Token: 0x0400132F RID: 4911
	[Range(-1f, 2f)]
	public float ColoredChange;

	// Token: 0x04001330 RID: 4912
	[Range(-1f, 1f)]
	public float ChangeRed;

	// Token: 0x04001331 RID: 4913
	[Range(-1f, 1f)]
	public float ChangeGreen;

	// Token: 0x04001332 RID: 4914
	[Range(-1f, 1f)]
	public float ChangeBlue;
}
