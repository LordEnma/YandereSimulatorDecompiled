using System;
using UnityEngine;

// Token: 0x020001A0 RID: 416
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Edge_filter")]
public class CameraFilterPack_Edge_Edge_filter : MonoBehaviour
{
	// Token: 0x170002A5 RID: 677
	// (get) Token: 0x06000E82 RID: 3714 RVA: 0x0007A535 File Offset: 0x00078735
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

	// Token: 0x06000E83 RID: 3715 RVA: 0x0007A569 File Offset: 0x00078769
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Edge_filter");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E84 RID: 3716 RVA: 0x0007A58C File Offset: 0x0007878C
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
			this.material.SetFloat("_RedAmplifier", this.RedAmplifier);
			this.material.SetFloat("_GreenAmplifier", this.GreenAmplifier);
			this.material.SetFloat("_BlueAmplifier", this.BlueAmplifier);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E85 RID: 3717 RVA: 0x0007A667 File Offset: 0x00078867
	private void Update()
	{
	}

	// Token: 0x06000E86 RID: 3718 RVA: 0x0007A669 File Offset: 0x00078869
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012D2 RID: 4818
	public Shader SCShader;

	// Token: 0x040012D3 RID: 4819
	private float TimeX = 1f;

	// Token: 0x040012D4 RID: 4820
	private Material SCMaterial;

	// Token: 0x040012D5 RID: 4821
	[Range(0f, 10f)]
	public float RedAmplifier;

	// Token: 0x040012D6 RID: 4822
	[Range(0f, 10f)]
	public float GreenAmplifier = 2f;

	// Token: 0x040012D7 RID: 4823
	[Range(0f, 10f)]
	public float BlueAmplifier;
}
