using System;

[Serializable]
public class BucketGas : BucketContents
{
	public override BucketContentsType Type
	{
		get
		{
			return BucketContentsType.Gas;
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
			return true;
		}
	}

	public override bool CanBeLifted(int strength)
	{
		return true;
	}
}
