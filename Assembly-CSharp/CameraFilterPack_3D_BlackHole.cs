using System;
using UnityEngine;

// Token: 0x0200010B RID: 267
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/BlackHole")]
public class CameraFilterPack_3D_BlackHole : MonoBehaviour
{
	// Token: 0x1700020F RID: 527
	// (get) Token: 0x06000AC0 RID: 2752 RVA: 0x0006898D File Offset: 0x00066B8D
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

	// Token: 0x06000AC1 RID: 2753 RVA: 0x000689C1 File Offset: 0x00066BC1
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_BlackHole");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AC2 RID: 2754 RVA: 0x000689E4 File Offset: 0x00066BE4
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
			if (this.AutoAnimatedNear)
			{
				this._Distance += Time.deltaTime * this.AutoAnimatedNearSpeed;
				if (this._Distance > 1f)
				{
					this._Distance = -1f;
				}
				if (this._Distance < -1f)
				{
					this._Distance = 1f;
				}
				this.material.SetFloat("_Near", this._Distance);
			}
			else
			{
				this.material.SetFloat("_Near", this._Distance);
			}
			this.material.SetFloat("_Far", this._Size);
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_DistortionLevel", this.DistortionLevel);
			this.material.SetFloat("_DistortionSize", this.DistortionSize);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000AC3 RID: 2755 RVA: 0x00068BA7 File Offset: 0x00066DA7
	private void Update()
	{
	}

	// Token: 0x06000AC4 RID: 2756 RVA: 0x00068BA9 File Offset: 0x00066DA9
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000E51 RID: 3665
	public Shader SCShader;

	// Token: 0x04000E52 RID: 3666
	private float TimeX = 1f;

	// Token: 0x04000E53 RID: 3667
	public bool _Visualize;

	// Token: 0x04000E54 RID: 3668
	private Material SCMaterial;

	// Token: 0x04000E55 RID: 3669
	[Range(0f, 100f)]
	public float _FixDistance = 5f;

	// Token: 0x04000E56 RID: 3670
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.05f;

	// Token: 0x04000E57 RID: 3671
	[Range(0f, 1f)]
	public float _Size = 0.25f;

	// Token: 0x04000E58 RID: 3672
	[Range(-2f, 2f)]
	public float DistortionLevel = 1.2f;

	// Token: 0x04000E59 RID: 3673
	[Range(0f, 1f)]
	public float DistortionSize;

	// Token: 0x04000E5A RID: 3674
	public bool AutoAnimatedNear;

	// Token: 0x04000E5B RID: 3675
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04000E5C RID: 3676
	public static Color ChangeColorRGB;
}
