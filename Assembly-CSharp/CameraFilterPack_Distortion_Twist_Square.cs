using System;
using UnityEngine;

// Token: 0x02000183 RID: 387
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Distortion/Twist_Square")]
public class CameraFilterPack_Distortion_Twist_Square : MonoBehaviour
{
	// Token: 0x17000287 RID: 647
	// (get) Token: 0x06000DD0 RID: 3536 RVA: 0x000778B8 File Offset: 0x00075AB8
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

	// Token: 0x06000DD1 RID: 3537 RVA: 0x000778EC File Offset: 0x00075AEC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Distortion_Twist_Square");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000DD2 RID: 3538 RVA: 0x00077910 File Offset: 0x00075B10
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

	// Token: 0x06000DD3 RID: 3539 RVA: 0x00077A01 File Offset: 0x00075C01
	private void Update()
	{
	}

	// Token: 0x06000DD4 RID: 3540 RVA: 0x00077A03 File Offset: 0x00075C03
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001211 RID: 4625
	public Shader SCShader;

	// Token: 0x04001212 RID: 4626
	private float TimeX = 1f;

	// Token: 0x04001213 RID: 4627
	private Material SCMaterial;

	// Token: 0x04001214 RID: 4628
	[Range(-2f, 2f)]
	public float CenterX = 0.5f;

	// Token: 0x04001215 RID: 4629
	[Range(-2f, 2f)]
	public float CenterY = 0.5f;

	// Token: 0x04001216 RID: 4630
	[Range(-3.14f, 3.14f)]
	public float Distortion = 0.5f;

	// Token: 0x04001217 RID: 4631
	[Range(-2f, 2f)]
	public float Size = 0.25f;
}
