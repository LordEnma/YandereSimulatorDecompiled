using System;
using UnityEngine;

// Token: 0x02000113 RID: 275
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Myst")]
public class CameraFilterPack_3D_Myst : MonoBehaviour
{
	// Token: 0x17000217 RID: 535
	// (get) Token: 0x06000AF0 RID: 2800 RVA: 0x00069C20 File Offset: 0x00067E20
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

	// Token: 0x06000AF1 RID: 2801 RVA: 0x00069C54 File Offset: 0x00067E54
	private void Start()
	{
		this.Texture2 = (Resources.Load("CameraFilterPack_3D_Myst1") as Texture2D);
		this.SCShader = Shader.Find("CameraFilterPack/3D_Myst");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AF2 RID: 2802 RVA: 0x00069C8C File Offset: 0x00067E8C
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
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_DistortionLevel", this.DistortionLevel * 28f);
			this.material.SetFloat("_DistortionSize", this.DistortionSize * 16f);
			this.material.SetFloat("_LightIntensity", this.LightIntensity * 64f);
			this.material.SetTexture("_MainTex2", this.Texture2);
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000AF3 RID: 2803 RVA: 0x00069E8D File Offset: 0x0006808D
	private void Update()
	{
	}

	// Token: 0x06000AF4 RID: 2804 RVA: 0x00069E8F File Offset: 0x0006808F
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EAC RID: 3756
	public Shader SCShader;

	// Token: 0x04000EAD RID: 3757
	public bool _Visualize;

	// Token: 0x04000EAE RID: 3758
	private float TimeX = 1f;

	// Token: 0x04000EAF RID: 3759
	private Material SCMaterial;

	// Token: 0x04000EB0 RID: 3760
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x04000EB1 RID: 3761
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.5f;

	// Token: 0x04000EB2 RID: 3762
	[Range(0f, 0.5f)]
	public float _Size = 0.1f;

	// Token: 0x04000EB3 RID: 3763
	[Range(0f, 10f)]
	public float DistortionLevel = 1.2f;

	// Token: 0x04000EB4 RID: 3764
	[Range(0.1f, 10f)]
	public float DistortionSize = 1.4f;

	// Token: 0x04000EB5 RID: 3765
	[Range(-2f, 4f)]
	public float LightIntensity = 0.08f;

	// Token: 0x04000EB6 RID: 3766
	public bool AutoAnimatedNear;

	// Token: 0x04000EB7 RID: 3767
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04000EB8 RID: 3768
	private Texture2D Texture2;

	// Token: 0x04000EB9 RID: 3769
	public static Color ChangeColorRGB;
}
