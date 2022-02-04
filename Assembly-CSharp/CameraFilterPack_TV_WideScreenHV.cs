using System;
using UnityEngine;

// Token: 0x02000221 RID: 545
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/TV/WideScreenHV")]
public class CameraFilterPack_TV_WideScreenHV : MonoBehaviour
{
	// Token: 0x17000325 RID: 805
	// (get) Token: 0x060011A8 RID: 4520 RVA: 0x000889CB File Offset: 0x00086BCB
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

	// Token: 0x060011A9 RID: 4521 RVA: 0x000889FF File Offset: 0x00086BFF
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/TV_WideScreenHV");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011AA RID: 4522 RVA: 0x00088A20 File Offset: 0x00086C20
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
			this.material.SetFloat("_Value", this.Size);
			this.material.SetFloat("_Value2", this.Smooth);
			this.material.SetFloat("_Value3", this.StretchX);
			this.material.SetFloat("_Value4", this.StretchY);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011AB RID: 4523 RVA: 0x00088B18 File Offset: 0x00086D18
	private void Update()
	{
	}

	// Token: 0x060011AC RID: 4524 RVA: 0x00088B1A File Offset: 0x00086D1A
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001631 RID: 5681
	public Shader SCShader;

	// Token: 0x04001632 RID: 5682
	private float TimeX = 1f;

	// Token: 0x04001633 RID: 5683
	private Material SCMaterial;

	// Token: 0x04001634 RID: 5684
	[Range(0f, 0.8f)]
	public float Size = 0.55f;

	// Token: 0x04001635 RID: 5685
	[Range(0.001f, 0.4f)]
	public float Smooth = 0.01f;

	// Token: 0x04001636 RID: 5686
	[Range(0f, 10f)]
	private float StretchX = 1f;

	// Token: 0x04001637 RID: 5687
	[Range(0f, 10f)]
	private float StretchY = 1f;
}
