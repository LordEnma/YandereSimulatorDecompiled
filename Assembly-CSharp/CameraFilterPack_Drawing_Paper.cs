using System;
using UnityEngine;

// Token: 0x02000199 RID: 409
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/Paper")]
public class CameraFilterPack_Drawing_Paper : MonoBehaviour
{
	// Token: 0x1700029E RID: 670
	// (get) Token: 0x06000E57 RID: 3671 RVA: 0x000797DD File Offset: 0x000779DD
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

	// Token: 0x06000E58 RID: 3672 RVA: 0x00079811 File Offset: 0x00077A11
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_Paper1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_Paper");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E59 RID: 3673 RVA: 0x00079848 File Offset: 0x00077A48
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

	// Token: 0x06000E5A RID: 3674 RVA: 0x00079997 File Offset: 0x00077B97
	private void Update()
	{
	}

	// Token: 0x06000E5B RID: 3675 RVA: 0x00079999 File Offset: 0x00077B99
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001292 RID: 4754
	public Shader SCShader;

	// Token: 0x04001293 RID: 4755
	private float TimeX = 1f;

	// Token: 0x04001294 RID: 4756
	public Color Pencil_Color = new Color(0.156f, 0.3f, 0.738f, 1f);

	// Token: 0x04001295 RID: 4757
	[Range(0.0001f, 0.0022f)]
	public float Pencil_Size = 0.0008f;

	// Token: 0x04001296 RID: 4758
	[Range(0f, 2f)]
	public float Pencil_Correction = 0.76f;

	// Token: 0x04001297 RID: 4759
	[Range(0f, 1f)]
	public float Intensity = 1f;

	// Token: 0x04001298 RID: 4760
	[Range(0f, 2f)]
	public float Speed_Animation = 1f;

	// Token: 0x04001299 RID: 4761
	[Range(0f, 1f)]
	public float Corner_Lose = 0.5f;

	// Token: 0x0400129A RID: 4762
	[Range(0f, 1f)]
	public float Fade_Paper_to_BackColor;

	// Token: 0x0400129B RID: 4763
	[Range(0f, 1f)]
	public float Fade_With_Original = 1f;

	// Token: 0x0400129C RID: 4764
	public Color Back_Color = new Color(1f, 1f, 1f, 1f);

	// Token: 0x0400129D RID: 4765
	private Material SCMaterial;

	// Token: 0x0400129E RID: 4766
	private Texture2D Texture2;
}
