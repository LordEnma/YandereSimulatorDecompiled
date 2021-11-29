using System;
using UnityEngine;

// Token: 0x0200010E RID: 270
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Ghost")]
public class CameraFilterPack_3D_Ghost : MonoBehaviour
{
	// Token: 0x17000213 RID: 531
	// (get) Token: 0x06000AD4 RID: 2772 RVA: 0x00068EBF File Offset: 0x000670BF
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

	// Token: 0x06000AD5 RID: 2773 RVA: 0x00068EF3 File Offset: 0x000670F3
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Ghost");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x00068F14 File Offset: 0x00067114
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
			this.material.SetFloat("_Value2", this.Intensity);
			this.material.SetFloat("GhostPosX", this.GhostPosX);
			this.material.SetFloat("GhostPosY", this.GhostPosY);
			this.material.SetFloat("GhostFade", this.GhostFade);
			this.material.SetFloat("GhostFade2", this.GhostFade2);
			this.material.SetFloat("GhostSize", this.GhostSize);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("Drop_Near", this.Ghost_Near);
			this.material.SetFloat("Drop_Far", this.Ghost_Far);
			this.material.SetFloat("Drop_With_Obj", this.GhostWithoutObject);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x000690B9 File Offset: 0x000672B9
	private void Update()
	{
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x000690BB File Offset: 0x000672BB
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E73 RID: 3699
	public Shader SCShader;

	// Token: 0x04000E74 RID: 3700
	private float TimeX = 1f;

	// Token: 0x04000E75 RID: 3701
	public bool _Visualize;

	// Token: 0x04000E76 RID: 3702
	private Material SCMaterial;

	// Token: 0x04000E77 RID: 3703
	[Range(0f, 100f)]
	public float _FixDistance = 5f;

	// Token: 0x04000E78 RID: 3704
	[Range(-0.5f, 0.99f)]
	public float Ghost_Near = 0.08f;

	// Token: 0x04000E79 RID: 3705
	[Range(0f, 1f)]
	public float Ghost_Far = 0.55f;

	// Token: 0x04000E7A RID: 3706
	[Range(0f, 2f)]
	public float Intensity = 1f;

	// Token: 0x04000E7B RID: 3707
	[Range(0f, 1f)]
	public float GhostWithoutObject = 1f;

	// Token: 0x04000E7C RID: 3708
	[Range(-1f, 1f)]
	public float GhostPosX;

	// Token: 0x04000E7D RID: 3709
	[Range(-1f, 1f)]
	public float GhostPosY;

	// Token: 0x04000E7E RID: 3710
	[Range(0.1f, 8f)]
	public float GhostFade2 = 2f;

	// Token: 0x04000E7F RID: 3711
	[Range(-1f, 1f)]
	public float GhostFade;

	// Token: 0x04000E80 RID: 3712
	[Range(0.5f, 1.5f)]
	public float GhostSize = 0.9f;
}
