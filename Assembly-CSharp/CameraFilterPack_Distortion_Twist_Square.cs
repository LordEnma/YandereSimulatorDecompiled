using System;
using UnityEngine;

// Token: 0x02000183 RID: 387
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Twist_Square")]
public class CameraFilterPack_Distortion_Twist_Square : MonoBehaviour
{
	// Token: 0x17000287 RID: 647
	// (get) Token: 0x06000DD1 RID: 3537 RVA: 0x00077C64 File Offset: 0x00075E64
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

	// Token: 0x06000DD2 RID: 3538 RVA: 0x00077C98 File Offset: 0x00075E98
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Twist_Square");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DD3 RID: 3539 RVA: 0x00077CBC File Offset: 0x00075EBC
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

	// Token: 0x06000DD4 RID: 3540 RVA: 0x00077DAD File Offset: 0x00075FAD
	private void Update()
	{
	}

	// Token: 0x06000DD5 RID: 3541 RVA: 0x00077DAF File Offset: 0x00075FAF
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
	public float Distortion = 0.5f;

	// Token: 0x04001223 RID: 4643
	[Range(-2f, 2f)]
	public float Size = 0.25f;
}
