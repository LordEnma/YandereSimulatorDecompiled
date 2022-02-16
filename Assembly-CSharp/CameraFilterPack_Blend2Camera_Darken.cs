using System;
using UnityEngine;

// Token: 0x0200012C RID: 300
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/Darken")]
public class CameraFilterPack_Blend2Camera_Darken : MonoBehaviour
{
	// Token: 0x17000230 RID: 560
	// (get) Token: 0x06000B91 RID: 2961 RVA: 0x0006D70F File Offset: 0x0006B90F
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

	// Token: 0x06000B92 RID: 2962 RVA: 0x0006D744 File Offset: 0x0006B944
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

	// Token: 0x06000B93 RID: 2963 RVA: 0x0006D7A8 File Offset: 0x0006B9A8
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

	// Token: 0x06000B94 RID: 2964 RVA: 0x0006D898 File Offset: 0x0006BA98
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B95 RID: 2965 RVA: 0x0006D8D0 File Offset: 0x0006BAD0
	private void Update()
	{
	}

	// Token: 0x06000B96 RID: 2966 RVA: 0x0006D8D2 File Offset: 0x0006BAD2
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000B97 RID: 2967 RVA: 0x0006D90A File Offset: 0x0006BB0A
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

	// Token: 0x04000FC1 RID: 4033
	private string ShaderName = "CameraFilterPack/Blend2Camera_Darken";

	// Token: 0x04000FC2 RID: 4034
	public Shader SCShader;

	// Token: 0x04000FC3 RID: 4035
	public Camera Camera2;

	// Token: 0x04000FC4 RID: 4036
	private float TimeX = 1f;

	// Token: 0x04000FC5 RID: 4037
	private Material SCMaterial;

	// Token: 0x04000FC6 RID: 4038
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04000FC7 RID: 4039
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04000FC8 RID: 4040
	private RenderTexture Camera2tex;
}
