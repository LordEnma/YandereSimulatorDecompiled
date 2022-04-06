using System;
using UnityEngine;

// Token: 0x02000224 RID: 548
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/VHS/Tracking")]
public class CameraFilterPack_VHS_Tracking : MonoBehaviour
{
	// Token: 0x17000328 RID: 808
	// (get) Token: 0x060011BD RID: 4541 RVA: 0x000896EB File Offset: 0x000878EB
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

	// Token: 0x060011BE RID: 4542 RVA: 0x0008971F File Offset: 0x0008791F
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/VHS_Tracking");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011BF RID: 4543 RVA: 0x00089740 File Offset: 0x00087940
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
			this.material.SetFloat("_Value", this.Tracking);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011C0 RID: 4544 RVA: 0x000897F6 File Offset: 0x000879F6
	private void Update()
	{
	}

	// Token: 0x060011C1 RID: 4545 RVA: 0x000897F8 File Offset: 0x000879F8
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001659 RID: 5721
	public Shader SCShader;

	// Token: 0x0400165A RID: 5722
	private float TimeX = 1f;

	// Token: 0x0400165B RID: 5723
	private Material SCMaterial;

	// Token: 0x0400165C RID: 5724
	[Range(0f, 2f)]
	public float Tracking = 1f;
}
