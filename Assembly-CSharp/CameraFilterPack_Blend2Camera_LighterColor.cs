using System;
using UnityEngine;

// Token: 0x02000136 RID: 310
[ExecuteInEditMode]
[AddComponentMenu("Camera Filter Pack/Blend 2 Camera/LighterColor")]
public class CameraFilterPack_Blend2Camera_LighterColor : MonoBehaviour
{
	// Token: 0x1700023A RID: 570
	// (get) Token: 0x06000BE2 RID: 3042 RVA: 0x0006F58F File Offset: 0x0006D78F
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

	// Token: 0x06000BE3 RID: 3043 RVA: 0x0006F5C4 File Offset: 0x0006D7C4
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

	// Token: 0x06000BE4 RID: 3044 RVA: 0x0006F628 File Offset: 0x0006D828
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

	// Token: 0x06000BE5 RID: 3045 RVA: 0x0006F718 File Offset: 0x0006D918
	private void OnValidate()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BE6 RID: 3046 RVA: 0x0006F750 File Offset: 0x0006D950
	private void Update()
	{
	}

	// Token: 0x06000BE7 RID: 3047 RVA: 0x0006F752 File Offset: 0x0006D952
	private void OnEnable()
	{
		if (this.Camera2 != null)
		{
			this.Camera2tex = new RenderTexture(Screen.width, Screen.height, 24);
			this.Camera2.targetTexture = this.Camera2tex;
		}
	}

	// Token: 0x06000BE8 RID: 3048 RVA: 0x0006F78A File Offset: 0x0006D98A
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

	// Token: 0x04001027 RID: 4135
	private string ShaderName = "CameraFilterPack/Blend2Camera_LighterColor";

	// Token: 0x04001028 RID: 4136
	public Shader SCShader;

	// Token: 0x04001029 RID: 4137
	public Camera Camera2;

	// Token: 0x0400102A RID: 4138
	private float TimeX = 1f;

	// Token: 0x0400102B RID: 4139
	private Material SCMaterial;

	// Token: 0x0400102C RID: 4140
	[Range(0f, 1f)]
	public float SwitchCameraToCamera2;

	// Token: 0x0400102D RID: 4141
	[Range(0f, 1f)]
	public float BlendFX = 0.5f;

	// Token: 0x0400102E RID: 4142
	private RenderTexture Camera2tex;
}
