using System;
using UnityEngine;

// Token: 0x0200010F RID: 271
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Ghost")]
public class CameraFilterPack_3D_Ghost : MonoBehaviour
{
	// Token: 0x17000213 RID: 531
	// (get) Token: 0x06000AD8 RID: 2776 RVA: 0x00069463 File Offset: 0x00067663
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

	// Token: 0x06000AD9 RID: 2777 RVA: 0x00069497 File Offset: 0x00067697
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Ghost");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x000694B8 File Offset: 0x000676B8
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

	// Token: 0x06000ADB RID: 2779 RVA: 0x0006965D File Offset: 0x0006785D
	private void Update()
	{
	}

	// Token: 0x06000ADC RID: 2780 RVA: 0x0006965F File Offset: 0x0006785F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E84 RID: 3716
	public Shader SCShader;

	// Token: 0x04000E85 RID: 3717
	private float TimeX = 1f;

	// Token: 0x04000E86 RID: 3718
	public bool _Visualize;

	// Token: 0x04000E87 RID: 3719
	private Material SCMaterial;

	// Token: 0x04000E88 RID: 3720
	[Range(0f, 100f)]
	public float _FixDistance = 5f;

	// Token: 0x04000E89 RID: 3721
	[Range(-0.5f, 0.99f)]
	public float Ghost_Near = 0.08f;

	// Token: 0x04000E8A RID: 3722
	[Range(0f, 1f)]
	public float Ghost_Far = 0.55f;

	// Token: 0x04000E8B RID: 3723
	[Range(0f, 2f)]
	public float Intensity = 1f;

	// Token: 0x04000E8C RID: 3724
	[Range(0f, 1f)]
	public float GhostWithoutObject = 1f;

	// Token: 0x04000E8D RID: 3725
	[Range(-1f, 1f)]
	public float GhostPosX;

	// Token: 0x04000E8E RID: 3726
	[Range(-1f, 1f)]
	public float GhostPosY;

	// Token: 0x04000E8F RID: 3727
	[Range(0.1f, 8f)]
	public float GhostFade2 = 2f;

	// Token: 0x04000E90 RID: 3728
	[Range(-1f, 1f)]
	public float GhostFade;

	// Token: 0x04000E91 RID: 3729
	[Range(0.5f, 1.5f)]
	public float GhostSize = 0.9f;
}
