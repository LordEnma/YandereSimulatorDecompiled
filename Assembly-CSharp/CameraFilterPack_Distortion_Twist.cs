using System;
using UnityEngine;

// Token: 0x02000182 RID: 386
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Twist")]
public class CameraFilterPack_Distortion_Twist : MonoBehaviour
{
	// Token: 0x17000286 RID: 646
	// (get) Token: 0x06000DCA RID: 3530 RVA: 0x00077717 File Offset: 0x00075917
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

	// Token: 0x06000DCB RID: 3531 RVA: 0x0007774B File Offset: 0x0007594B
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Twist");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DCC RID: 3532 RVA: 0x0007776C File Offset: 0x0007596C
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

	// Token: 0x06000DCD RID: 3533 RVA: 0x0007785D File Offset: 0x00075A5D
	private void Update()
	{
	}

	// Token: 0x06000DCE RID: 3534 RVA: 0x0007785F File Offset: 0x00075A5F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x0400120A RID: 4618
	public Shader SCShader;

	// Token: 0x0400120B RID: 4619
	private float TimeX = 1f;

	// Token: 0x0400120C RID: 4620
	private Material SCMaterial;

	// Token: 0x0400120D RID: 4621
	[Range(-2f, 2f)]
	public float CenterX = 0.5f;

	// Token: 0x0400120E RID: 4622
	[Range(-2f, 2f)]
	public float CenterY = 0.5f;

	// Token: 0x0400120F RID: 4623
	[Range(-3.14f, 3.14f)]
	public float Distortion = 1f;

	// Token: 0x04001210 RID: 4624
	[Range(-2f, 2f)]
	public float Size = 1f;
}
