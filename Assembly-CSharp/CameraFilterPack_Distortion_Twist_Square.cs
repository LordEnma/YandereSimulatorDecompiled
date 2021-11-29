using System;
using UnityEngine;

// Token: 0x02000182 RID: 386
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Twist_Square")]
public class CameraFilterPack_Distortion_Twist_Square : MonoBehaviour
{
	// Token: 0x17000287 RID: 647
	// (get) Token: 0x06000DCD RID: 3533 RVA: 0x000776C0 File Offset: 0x000758C0
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

	// Token: 0x06000DCE RID: 3534 RVA: 0x000776F4 File Offset: 0x000758F4
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Twist_Square");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DCF RID: 3535 RVA: 0x00077718 File Offset: 0x00075918
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

	// Token: 0x06000DD0 RID: 3536 RVA: 0x00077809 File Offset: 0x00075A09
	private void Update()
	{
	}

	// Token: 0x06000DD1 RID: 3537 RVA: 0x0007780B File Offset: 0x00075A0B
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400120C RID: 4620
	public Shader SCShader;

	// Token: 0x0400120D RID: 4621
	private float TimeX = 1f;

	// Token: 0x0400120E RID: 4622
	private Material SCMaterial;

	// Token: 0x0400120F RID: 4623
	[Range(-2f, 2f)]
	public float CenterX = 0.5f;

	// Token: 0x04001210 RID: 4624
	[Range(-2f, 2f)]
	public float CenterY = 0.5f;

	// Token: 0x04001211 RID: 4625
	[Range(-3.14f, 3.14f)]
	public float Distortion = 0.5f;

	// Token: 0x04001212 RID: 4626
	[Range(-2f, 2f)]
	public float Size = 0.25f;
}
