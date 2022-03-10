using System;
using UnityEngine;

// Token: 0x02000138 RID: 312
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LinearDodge")]
public class CameraFilterPack_Blend2Camera_LinearDodge : MonoBehaviour
{
	// Token: 0x1700023C RID: 572
	// (get) Token: 0x06000BF0 RID: 3056 RVA: 0x0006F5C3 File Offset: 0x0006D7C3
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

	// Token: 0x06000BF1 RID: 3057 RVA: 0x0006F5F8 File Offset: 0x0006D7F8
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

	// Token: 0x06000BF2 RID: 3058 RVA: 0x0006F65C File Offset: 0x0006D85C
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

	// Token: 0x06000BF3 RID: 3059 RVA: 0x0006F74C File Offset: 0x0006D94C
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BF4 RID: 3060 RVA: 0x0006F784 File Offset: 0x0006D984
	private void Update()
	{
	}

	// Token: 0x06000BF5 RID: 3061 RVA: 0x0006F786 File Offset: 0x0006D986
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BF6 RID: 3062 RVA: 0x0006F7BE File Offset: 0x0006D9BE
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

	// Token: 0x04001030 RID: 4144
	private string ShaderName = "CameraFilterPack/Blend2Camera_LinearDodge";

	// Token: 0x04001031 RID: 4145
	public Shader SCShader;

	// Token: 0x04001032 RID: 4146
	public Camera Camera2;

	// Token: 0x04001033 RID: 4147
	private float TimeX = 1f;

	// Token: 0x04001034 RID: 4148
	private Material SCMaterial;

	// Token: 0x04001035 RID: 4149
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x04001036 RID: 4150
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x04001037 RID: 4151
	private RenderTexture Camera2tex;
}
