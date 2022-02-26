using System;
using UnityEngine;

// Token: 0x02000143 RID: 323
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Split Screen/Split 3D")]
public class CameraFilterPack_Blend2Camera_SplitScreen3D : MonoBehaviour
{
	// Token: 0x17000247 RID: 583
	// (get) Token: 0x06000C49 RID: 3145 RVA: 0x00071148 File Offset: 0x0006F348
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

	// Token: 0x06000C4A RID: 3146 RVA: 0x0007117C File Offset: 0x0006F37C
	private void OnValidate()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000C4B RID: 3147 RVA: 0x000711A0 File Offset: 0x0006F3A0
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture((int)this.ScreenSize.x, (int)this.ScreenSize.y, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000C4C RID: 3148 RVA: 0x00071214 File Offset: 0x0006F414
	private void OnRenderImage(RenderTexture sourceTexture, RenderTexture destTexture)
	{
		if (this.SCShader != null)
		{
			this.TimeX += Time.deltaTime;
			if (this.TimeX > 100f)
			{
				this.TimeX = 0f;
			}
			if (this.Camera2 != null)
			{
				this.material.SetTexture("_MainTex2", this.Camera2tex);
			}
			this.material.SetFloat("_Near", this._Distance);
			this.material.SetFloat("_Far", this._Size);
			this.material.SetFloat("_FixDistance", this._FixDistance);
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetFloat("_Value3", this.SplitX);
			this.material.SetFloat("_Value6", this.SplitY);
			this.material.SetFloat("_Value4", this.Smooth);
			this.material.SetFloat("_Value5", this.Rotation);
			this.material.SetInt("_ForceYSwap", this.ForceYSwap ? 0 : 1);
			base.GetComponent<Camera>().depthTextureMode = DepthTextureMode.Depth;
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000C4D RID: 3149 RVA: 0x00071399 File Offset: 0x0006F599
	private void Update()
	{
		this.ScreenSize.x = (float)Screen.width;
		this.ScreenSize.y = (float)Screen.height;
	}

	// Token: 0x06000C4E RID: 3150 RVA: 0x000713BD File Offset: 0x0006F5BD
	private void OnEnable()
	{
		this.Start();
	}

	// Token: 0x06000C4F RID: 3151 RVA: 0x000713C5 File Offset: 0x0006F5C5
	private void OnDisable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2.targetTexture = null;
		}
		if (this.SCMaterial)
		{
			UnityEngine.Object.DestroyImmediate(this.SCMaterial);
		}
	}

	// Token: 0x04001087 RID: 4231
	private string ShaderName = "CameraFilterPack/Blend2Camera_SplitScreen3D";

	// Token: 0x04001088 RID: 4232
	public Shader SCShader;

	// Token: 0x04001089 RID: 4233
	public Camera Camera2;

	// Token: 0x0400108A RID: 4234
	private float TimeX = 1f;

	// Token: 0x0400108B RID: 4235
	private Material SCMaterial;

	// Token: 0x0400108C RID: 4236
	[Range(0f, 100f)]
	public float _FixDistance = 1f;

	// Token: 0x0400108D RID: 4237
	[Range(-0.99f, 0.99f)]
	public float _Distance = 0.5f;

	// Token: 0x0400108E RID: 4238
	[Range(0f, 0.5f)]
	public float _Size = 0.1f;

	// Token: 0x0400108F RID: 4239
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001090 RID: 4240
	[Range(0f, 1f)]
	public float BlendFX = 1f;

	// Token: 0x04001091 RID: 4241
	[Range(-3f, 3f)]
	public float SplitX = 0.5f;

	// Token: 0x04001092 RID: 4242
	[Range(-3f, 3f)]
	public float SplitY = 0.5f;

	// Token: 0x04001093 RID: 4243
	[Range(0f, 2f)]
	public float Smooth = 0.1f;

	// Token: 0x04001094 RID: 4244
	[Range(-3.14f, 3.14f)]
	public float Rotation = 3.14f;

	// Token: 0x04001095 RID: 4245
	private bool ForceYSwap;

	// Token: 0x04001096 RID: 4246
	private RenderTexture Camera2tex;

	// Token: 0x04001097 RID: 4247
	private Vector2 ScreenSize;
}
