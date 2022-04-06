using System;
using UnityEngine;

// Token: 0x02000182 RID: 386
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Twist")]
public class CameraFilterPack_Distortion_Twist : MonoBehaviour
{
	// Token: 0x17000286 RID: 646
	// (get) Token: 0x06000DCD RID: 3533 RVA: 0x00077F3F File Offset: 0x0007613F
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

	// Token: 0x06000DCE RID: 3534 RVA: 0x00077F73 File Offset: 0x00076173
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Twist");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DCF RID: 3535 RVA: 0x00077F94 File Offset: 0x00076194
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
			this.material.SetFloat("_CenterX", this.CenterX);
			this.material.SetFloat("_CenterY", this.CenterY);
			this.material.SetFloat("_Distortion", this.Distortion);
			this.material.SetFloat("_Size", this.Size);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000DD0 RID: 3536 RVA: 0x00078085 File Offset: 0x00076285
	private void Update()
	{
	}

	// Token: 0x06000DD1 RID: 3537 RVA: 0x00078087 File Offset: 0x00076287
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400121D RID: 4637
	public Shader SCShader;

	// Token: 0x0400121E RID: 4638
	private float TimeX = 1f;

	// Token: 0x0400121F RID: 4639
	private Material SCMaterial;

	// Token: 0x04001220 RID: 4640
	[Range(-2f, 2f)]
	public float CenterX = 0.5f;

	// Token: 0x04001221 RID: 4641
	[Range(-2f, 2f)]
	public float CenterY = 0.5f;

	// Token: 0x04001222 RID: 4642
	[Range(-3.14f, 3.14f)]
	public float Distortion = 1f;

	// Token: 0x04001223 RID: 4643
	[Range(-2f, 2f)]
	public float Size = 1f;
}
