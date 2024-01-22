using UnityEngine;

public class ScrollingTexture : MonoBehaviour
{
	public Transform Player;

	public Renderer MyRenderer;

	public int MaterialID;

	public float Offset;

	public float Speed;

	private void Start()
	{
		MyRenderer = GetComponent<Renderer>();
		Player = GameObject.Find("YandereChan").transform;
	}

	private void Update()
	{
		float num = 0f;
		if (Player != null)
		{
			num = (base.transform.position - Player.position).sqrMagnitude;
		}
		if (num < 11f)
		{
			Offset += Time.deltaTime * Speed;
			MyRenderer.materials[MaterialID].SetTextureOffset("_MainTex", new Vector2(Offset, Offset));
		}
	}
}
