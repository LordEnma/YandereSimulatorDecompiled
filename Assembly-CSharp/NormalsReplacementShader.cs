using System;
using UnityEngine;

// Token: 0x020004F6 RID: 1270
public class NormalsReplacementShader : MonoBehaviour
{
	// Token: 0x0600210C RID: 8460 RVA: 0x001E8AA0 File Offset: 0x001E6CA0
	private void Start()
	{
		Camera component = base.GetComponent<Camera>();
		this.renderTexture = new RenderTexture(component.pixelWidth, component.pixelHeight, 24);
		Shader.SetGlobalTexture("_CameraNormalsTexture", this.renderTexture);
		GameObject gameObject = new GameObject("Normals camera");
		this.camera = gameObject.AddComponent<Camera>();
		this.camera.CopyFrom(component);
		this.camera.transform.SetParent(base.transform);
		this.camera.targetTexture = this.renderTexture;
		this.camera.SetReplacementShader(this.normalsShader, "RenderType");
		this.camera.depth = component.depth - 1f;
	}

	// Token: 0x0400491A RID: 18714
	[SerializeField]
	private Shader normalsShader;

	// Token: 0x0400491B RID: 18715
	private RenderTexture renderTexture;

	// Token: 0x0400491C RID: 18716
	private Camera camera;
}
