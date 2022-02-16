using System;
using UnityEngine;

// Token: 0x02000199 RID: 409
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Drawing/NewCellShading")]
public class CameraFilterPack_Drawing_NewCellShading : MonoBehaviour
{
	// Token: 0x1700029D RID: 669
	// (get) Token: 0x06000E55 RID: 3669 RVA: 0x000799E4 File Offset: 0x00077BE4
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

	// Token: 0x06000E56 RID: 3670 RVA: 0x00079A18 File Offset: 0x00077C18
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Drawing_NewCellShading");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E57 RID: 3671 RVA: 0x00079A3C File Offset: 0x00077C3C
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
			this.material.SetFloat("_Threshold", this.Threshold);
			this.material.SetVector("_ScreenResolution", new Vector2((float)Screen.width, (float)Screen.height));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000E58 RID: 3672 RVA: 0x00079AEB File Offset: 0x00077CEB
	private void Update()
	{
	}

	// Token: 0x06000E59 RID: 3673 RVA: 0x00079AED File Offset: 0x00077CED
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001296 RID: 4758
	public Shader SCShader;

	// Token: 0x04001297 RID: 4759
	private float TimeX = 1f;

	// Token: 0x04001298 RID: 4760
	private Material SCMaterial;

	// Token: 0x04001299 RID: 4761
	[Range(0f, 1f)]
	public float Threshold = 0.2f;
}
