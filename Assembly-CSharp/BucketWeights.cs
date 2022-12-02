using System;
using UnityEngine;

[Serializable]
public class BucketWeights : BucketContents
{
	[SerializeField]
	private int count;

	public int Count
	{
		get
		{
			return count;
		}
		set
		{
			count = ((value >= 0) ? value : 0);
		}
	}

	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Weights;
		}
	}

	public override bool IsCleaningAgent
	{
		get
		{
			return false;
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
		return strength > 0;
	}
}
