using System;
using UnityEngine;

// Token: 0x0200022C RID: 556
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Vision/Plasma")]
public class CameraFilterPack_Vision_Plasma : MonoBehaviour
{
	// Token: 0x17000330 RID: 816
	// (get) Token: 0x060011ED RID: 4589 RVA: 0x0008A4E0 File Offset: 0x000886E0
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

	// Token: 0x060011EE RID: 4590 RVA: 0x0008A514 File Offset: 0x00088714
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Vision_Plasma");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x060011EF RID: 4591 RVA: 0x0008A538 File Offset: 0x00088738
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
			this.material.SetFloat("_Value", this.Value);
			this.material.SetFloat("_Value2", this.Value2);
			this.material.SetFloat("_Value3", this.Intensity);
			this.material.SetFloat("_Value4", this.Value4);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x060011F0 RID: 4592 RVA: 0x0008A630 File Offset: 0x00088830
	private void Update()
	{
	}

	// Token: 0x060011F1 RID: 4593 RVA: 0x0008A632 File Offset: 0x00088832
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001694 RID: 5780
	public Shader SCShader;

	// Token: 0x04001695 RID: 5781
	private float TimeX = 1f;

	// Token: 0x04001696 RID: 5782
	private Material SCMaterial;

	// Token: 0x04001697 RID: 5783
	[Range(-2f, 2f)]
	public float Value = 0.6f;

	// Token: 0x04001698 RID: 5784
	[Range(-2f, 2f)]
	public float Value2 = 0.2f;

	// Token: 0x04001699 RID: 5785
	[Range(0f, 60f)]
	public float Intensity = 15f;

	// Token: 0x0400169A RID: 5786
	[Range(0f, 10f)]
	private float Value4 = 1f;
}
