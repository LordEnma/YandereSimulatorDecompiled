using System;
using UnityEngine;

// Token: 0x02000186 RID: 390
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/BluePrint")]
public class CameraFilterPack_Drawing_BluePrint : MonoBehaviour
{
	// Token: 0x1700028A RID: 650
	// (get) Token: 0x06000DE3 RID: 3555 RVA: 0x000780D1 File Offset: 0x000762D1
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

	// Token: 0x06000DE4 RID: 3556 RVA: 0x00078105 File Offset: 0x00076305
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

	// Token: 0x06000DE5 RID: 3557 RVA: 0x0007813C File Offset: 0x0007633C
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

	// Token: 0x06000DE6 RID: 3558 RVA: 0x0007828B File Offset: 0x0007648B
	private void Update()
	{
	}

	// Token: 0x06000DE7 RID: 3559 RVA: 0x0007828D File Offset: 0x0007648D
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400122F RID: 4655
	public Shader SCShader;

	// Token: 0x04001230 RID: 4656
	private float TimeX = 1f;

	// Token: 0x04001231 RID: 4657
	public Color Pencil_Color = new Color(1f, 1f, 1f, 1f);

	// Token: 0x04001232 RID: 4658
	[Range(0.0001f, 0.0022f)]
	public float Pencil_Size = 0.0008f;

	// Token: 0x04001233 RID: 4659
	[Range(0f, 2f)]
	public float Pencil_Correction = 0.76f;

	// Token: 0x04001234 RID: 4660
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x04001235 RID: 4661
	[Range(0f, 2f)]
	public float Speed_Animation = 1f;

	// Token: 0x04001236 RID: 4662
	[Range(0f, 1f)]
	public float Corner_Lose = 0.5f;

	// Token: 0x04001237 RID: 4663
	[Range(0f, 1f)]
	public float Fade_Paper_to_BackColor = 0.2f;

	// Token: 0x04001238 RID: 4664
	[Range(0f, 1f)]
	public float Fade_With_Original = 1f;

	// Token: 0x04001239 RID: 4665
	public Color Back_Color = new Color(0.175f, 0.402f, 0.687f, 1f);

	// Token: 0x0400123A RID: 4666
	private Material SCMaterial;

	// Token: 0x0400123B RID: 4667
	private Texture2D Texture2;
}
