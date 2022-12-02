using System;
using UnityEngine;

[Serializable]
public class BucketWater : BucketContents
{
	[SerializeField]
	private float bloodiness;

	[SerializeField]
	private bool hasBleach;

	public float Bloodiness
	{
		get
		{
			return bloodiness;
		}
		set
		{
			bloodiness = Mathf.Clamp01(value);
		}
	}

	public bool HasBleach
	{
		get
		{
			return hasBleach;
		}
		set
		{
			hasBleach = value;
		}
	}

	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Water;
		}
	}

	public override bool IsCleaningAgent
	{
		get
		{
			return hasBleach;
		}
	}

	public override bool IsFlammable
	{
		get
		{
			return false;
		}
	}

	public override bool CanBeLifted(int strength)
	{
		return true;
	}
}
