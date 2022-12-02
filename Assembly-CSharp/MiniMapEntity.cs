using System.Collections.Generic;
using UnityEngine;

public class MiniMapEntity
{
	public bool showDetails;

	public Sprite icon;

	public bool rotateWithObject = true;

	public Vector3 upAxis;

	public float rotation;

	public Vector2 size;

	public bool clampInBorder;

	public float clampDist;

	public List<GameObject> mapObjects;
}
