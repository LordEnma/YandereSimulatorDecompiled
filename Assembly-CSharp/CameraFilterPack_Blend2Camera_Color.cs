using System;
using UnityEngine;

// Token: 0x02000128 RID: 296
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Color")]
public class CameraFilterPack_Blend2Camera_Color : MonoBehaviour
{
	// Token: 0x1700022C RID: 556
	// (get) Token: 0x06000B72 RID: 2930 RVA: 0x0006CFC0 File Offset: 0x0006B1C0
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

	// Token: 0x06000B73 RID: 2931 RVA: 0x0006CFF4 File Offset: 0x0006B1F4
	private void Start()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
		this.SCShader = Shader.Find(this.ShaderName);
		if (!SystemInfo.supportsImageEffects)
		{
			base.enabled = false;
			return;
		}
	}

	// Token: 0x06000B74 RID: 2932 RVA: 0x0006D058 File Offset: 0x0006B258
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
			this.material.SetFloat("_TimeX", this.TimeX);
			this.material.SetFloat("_Value", this.BlendFX);
			this.material.SetFloat("_Value2", this.SwitchCameraToCamera2);
			this.material.SetVector("_ScreenResolution", new Vector4((float)sourceTexture.width, (float)sourceTexture.height, 0f, 0f));
			Graphics.Blit(sourceTexture, destTexture, this.material);
			return;
		}
		Graphics.Blit(sourceTexture, destTexture);
	}

	// Token: 0x06000B75 RID: 2933 RVA: 0x0006D148 File Offset: 0x0006B348
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B76 RID: 2934 RVA: 0x0006D180 File Offset: 0x0006B380
	private void Update()
	{
	}

	// Token: 0x06000B77 RID: 2935 RVA: 0x0006D182 File Offset: 0x0006B382
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B78 RID: 2936 RVA: 0x0006D1BA File Offset: 0x0006B3BA
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

	// Token: 0x04000FA3 RID: 4003
	private string ShaderName = "CameraFilterPack/Blend2Camera_Color";

	// Token: 0x04000FA4 RID: 4004
	public Shader SCShader;

	// Token: 0x04000FA5 RID: 4005
	public Camera Camera2;

	// Token: 0x04000FA6 RID: 4006
	private float TimeX = 1f;

	// Token: 0x04000FA7 RID: 4007
	private Material SCMaterial;

	// Token: 0x04000FA8 RID: 4008
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FA9 RID: 4009
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FAA RID: 4010
	private RenderTexture Camera2tex;
}
