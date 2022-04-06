using System;
using UnityEngine;

// Token: 0x020001AE RID: 430
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/FX/Dot_Circle")]
public class CameraFilterPack_FX_Dot_Circle : MonoBehaviour
{
	// Token: 0x170002B2 RID: 690
	// (get) Token: 0x06000ED6 RID: 3798 RVA: 0x0007C242 File Offset: 0x0007A442
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

	// Token: 0x06000ED7 RID: 3799 RVA: 0x0007C276 File Offset: 0x0007A476
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/FX_Dot_Circle");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ED8 RID: 3800 RVA: 0x0007C298 File Offset: 0x0007A498
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

	// Token: 0x06000ED9 RID: 3801 RVA: 0x0007C34E File Offset: 0x0007A54E
	private void Update()
	{
	}

	// Token: 0x06000EDA RID: 3802 RVA: 0x0007C350 File Offset: 0x0007A550
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001334 RID: 4916
	public Shader SCShader;

	// Token: 0x04001335 RID: 4917
	private float TimeX = 1f;

	// Token: 0x04001336 RID: 4918
	private Material SCMaterial;

	// Token: 0x04001337 RID: 4919
	[Range(4f, 32f)]
	public float Value = 7f;
}
