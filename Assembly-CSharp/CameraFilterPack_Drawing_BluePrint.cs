using System;
using UnityEngine;

// Token: 0x02000186 RID: 390
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/BluePrint")]
public class CameraFilterPack_Drawing_BluePrint : MonoBehaviour
{
	// Token: 0x1700028A RID: 650
	// (get) Token: 0x06000DE2 RID: 3554 RVA: 0x00077D25 File Offset: 0x00075F25
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

	// Token: 0x06000DE3 RID: 3555 RVA: 0x00077D59 File Offset: 0x00075F59
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Paper2") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_BluePrint");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DE4 RID: 3556 RVA: 0x00077D90 File Offset: 0x00075F90
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
			this.material.SetColor("_PColor", this.Pencil_Color);
			this.material.SetFloat("_Value1", this.Pencil_Size);
			this.material.SetFloat("_Value2", this.Pencil_Correction);
			this.material.SetFloat("_Value3", this.Intensity);
			this.material.SetFloat("_Value4", this.Speed_Animation);
			this.material.SetFloat("_Value5", this.Corner_Lose);
			this.material.SetFloat("_Value6", this.Fade_Paper_to_BackColor);
			this.material.SetFloat("_Value7", this.Fade_With_Original);
			this.material.SetColor("_PColor2", this.Back_Color);
			this.material.SetTexture("_MainTex2", this.Texture2);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DE5 RID: 3557 RVA: 0x00077EDF File Offset: 0x000760DF
	private void Update()
	{
	}

	// Token: 0x06000DE6 RID: 3558 RVA: 0x00077EE1 File Offset: 0x000760E1
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001223 RID: 4643
	public Shader SCShader;

	// Token: 0x04001224 RID: 4644
	private float TimeX = 1f;

	// Token: 0x04001225 RID: 4645
	public Color Pencil_Color = new Color(1f, 1f, 1f, 1f);

	// Token: 0x04001226 RID: 4646
	[Range(0.0001f, 0.0022f)]
	public float Pencil_Size = 0.0008f;

	// Token: 0x04001227 RID: 4647
	[Range(0f, 2f)]
	public float Pencil_Correction = 0.76f;

	// Token: 0x04001228 RID: 4648
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x04001229 RID: 4649
	[Range(0f, 2f)]
	public float Speed_Animation = 1f;

	// Token: 0x0400122A RID: 4650
	[Range(0f, 1f)]
	public float Corner_Lose = 0.5f;

	// Token: 0x0400122B RID: 4651
	[Range(0f, 1f)]
	public float Fade_Paper_to_BackColor = 0.2f;

	// Token: 0x0400122C RID: 4652
	[Range(0f, 1f)]
	public float Fade_With_Original = 1f;

	// Token: 0x0400122D RID: 4653
	public Color Back_Color = new Color(0.175f, 0.402f, 0.687f, 1f);

	// Token: 0x0400122E RID: 4654
	private Material SCMaterial;

	// Token: 0x0400122F RID: 4655
	private Texture2D Texture2;
}
