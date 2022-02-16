using System;
using UnityEngine;

// Token: 0x020001AE RID: 430
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Dot_Circle")]
public class CameraFilterPack_FX_Dot_Circle : MonoBehaviour
{
	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x06000ED4 RID: 3796 RVA: 0x0007BB6A File Offset: 0x00079D6A
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

	// Token: 0x06000ED5 RID: 3797 RVA: 0x0007BB9E File Offset: 0x00079D9E
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Dot_Circle");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ED6 RID: 3798 RVA: 0x0007BBC0 File Offset: 0x00079DC0
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
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			this.material.SetFloat("_Value", this.Value);
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000ED7 RID: 3799 RVA: 0x0007BC76 File Offset: 0x00079E76
	private void Update()
	{
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x0007BC78 File Offset: 0x00079E78
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001324 RID: 4900
	public Shader SCShader;

	// Token: 0x04001325 RID: 4901
	private float TimeX = 1f;

	// Token: 0x04001326 RID: 4902
	private Material SCMaterial;

	// Token: 0x04001327 RID: 4903
	[Range(4f, 32f)]
	public float Value = 7f;
}
