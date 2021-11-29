using System;
using UnityEngine;

// Token: 0x02000114 RID: 276
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/3D/Shield")]
public class CameraFilterPack_3D_Shield : MonoBehaviour
{
	// Token: 0x17000219 RID: 537
	// (get) Token: 0x06000AF8 RID: 2808 RVA: 0x00069E78 File Offset: 0x00068078
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

	// Token: 0x06000AF9 RID: 2809 RVA: 0x00069EAC File Offset: 0x000680AC
	private void Start()
	{
		this.SCShader = Shader.Find("CameraFilterPack/3D_Shield");
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000AFA RID: 2810 RVA: 0x00069ED0 File Offset: 0x000680D0
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
			this.material.SetFloat("_LightIntensity", this.LightIntensity * 64f);
			this.material.SetFloat("_Visualize", (float)(this._Visualize ? 1 : 0));
			this.material.SetFloat("_FadeShield", this._FadeShield);
			this.material.SetFloat("_Value", this.Speed);
			this.material.SetFloat("_Value2", this.Speed_X);
			this.material.SetFloat("_Value3", this.Speed_Y);
			this.material.SetFloat("_Value4", this.Intensity);
			float farClipPlane = base.GetComponent<Camera>().farClipPlane;
			this.material.SetFloat("_FarCamera", 1000f / farClipPlane);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x0006A0F1 File Offset: 0x000682F1
	private void Update()
	{
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x0006A0F3 File Offset: 0x000682F3
	private void OnDisable()
	{
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04000EBF RID: 3775
	public Shader SCShader;

	// Token: 0x04000EC0 RID: 3776
	public bool _Visualize;

	// Token: 0x04000EC1 RID: 3777
	private float TimeX = 1f;

	// Token: 0x04000EC2 RID: 3778
	private Material SCMaterial;

	// Token: 0x04000EC3 RID: 3779
	[Range(0f, 100f)]
	public float _FixDistance = 1.5f;

	// Token: 0x04000EC4 RID: 3780
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.4f;

	// Token: 0x04000EC5 RID: 3781
	[Range(0f, 0.5f)]
	public float _Size = 0.5f;

	// Token: 0x04000EC6 RID: 3782
	[Range(0f, 1f)]
	public float _FadeShield = 0.75f;

	// Token: 0x04000EC7 RID: 3783
	[Range(-0.2f, 0.2f)]
	public float LightIntensity = 0.025f;

	// Token: 0x04000EC8 RID: 3784
	public bool AutoAnimatedNear;

	// Token: 0x04000EC9 RID: 3785
	[Range(-5f, 5f)]
	public float AutoAnimatedNearSpeed = 0.5f;

	// Token: 0x04000ECA RID: 3786
	[Range(0f, 10f)]
	public float Speed = 0.2f;

	// Token: 0x04000ECB RID: 3787
	[Range(0f, 10f)]
	public float Speed_X = 0.2f;

	// Token: 0x04000ECC RID: 3788
	[Range(0f, 1f)]
	public float Speed_Y = 0.3f;

	// Token: 0x04000ECD RID: 3789
	[Range(0f, 10f)]
	public float Intensity = 2.4f;

	// Token: 0x04000ECE RID: 3790
	public static Color ChangeColorRGB;
}
