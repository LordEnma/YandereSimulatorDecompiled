using UnityEngine;

namespace RetroAesthetics
{
	public class UVScroller : MonoBehaviour
	{
		public Vector2 scrollSpeed = new Vector2(-1f, 0f);

		public string textureName = "_GridTex";

		private Material target;

		private Vector2 offset = Vector2.zero;

		private void Start()
		{
			Renderer component = GetComponent<Renderer>();
			if (component == null || component.material == null)
			{
				base.enabled = false;
				return;
			}
			target = component.material;
			if (!target.HasProperty(textureName))
			{
				Debug.LogWarning("Texture name '" + textureName + "' not found in material.");
				base.enabled = false;
			}
		}

		private void Update()
		{
			offset += scrollSpeed * Time.deltaTime * Application.targetFrameRate;
			target.SetTextureOffset(textureName, offset);
		}
	}
}
