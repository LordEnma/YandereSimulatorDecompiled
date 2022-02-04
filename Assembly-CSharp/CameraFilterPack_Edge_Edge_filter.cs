using System;
using UnityEngine;

// Token: 0x020001A1 RID: 417
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Edge/Edge_filter")]
public class CameraFilterPack_Edge_Edge_filter : MonoBehaviour
{
	// Token: 0x170002A5 RID: 677
	// (get) Token: 0x06000E85 RID: 3717 RVA: 0x0007A72D File Offset: 0x0007892D
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

	// Token: 0x06000E86 RID: 3718 RVA: 0x0007A761 File Offset: 0x00078961
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/Edge_Edge_filter");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000E87 RID: 3719 RVA: 0x0007A784 File Offset: 0x00078984
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

	// Token: 0x06000E88 RID: 3720 RVA: 0x0007A85F File Offset: 0x00078A5F
	private void Update()
	{
	}

	// Token: 0x06000E89 RID: 3721 RVA: 0x0007A861 File Offset: 0x00078A61
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x040012D7 RID: 4823
	public Shader SCShader;

	// Token: 0x040012D8 RID: 4824
	private float TimeX = 1f;

	// Token: 0x040012D9 RID: 4825
	private Material SCMaterial;

	// Token: 0x040012DA RID: 4826
	[Range(0f, 10f)]
	public float RedAmplifier;

	// Token: 0x040012DB RID: 4827
	[Range(0f, 10f)]
	public float GreenAmplifier = 2f;

	// Token: 0x040012DC RID: 4828
	[Range(0f, 10f)]
	public float BlueAmplifier;
}
