using System;

// Token: 0x02000490 RID: 1168
public static class CardinalDirection
{
	// Token: 0x06001F12 RID: 7954 RVA: 0x001B6898 File Offset: 0x001B4A98
	public static Direction Reversed(Direction direction)
	{
		if (direction == Direction.North)
		{
			return Direction.South;
		}
		if (direction == Direction.East)
		{
			return Direction.West;
		}
		if (direction == Direction.South)
		{
			return Direction.North;
		}
		return Direction.East;
	}

	// Token: 0x06001F13 RID: 7955 RVA: 0x001B68AC File Offset: 0x001B4AAC
	public static Direction LeftPerp(Direction direction)
	{
		if (direction == Direction.North)
		{
			return Direction.West;
		}
		if (direction == Direction.East)
		{
			return Direction.North;
		}
		if (direction == Direction.South)
		{
			return Direction.East;
		}
		return Direction.South;
	}

	// Token: 0x06001F14 RID: 7956 RVA: 0x001B68C0 File Offset: 0x001B4AC0
	public static Direction RightPerp(Direction direction)
	{
		if (direction == Direction.North)
		{
			return Direction.East;
		}
		if (direction == Direction.East)
		{
			return Direction.South;
		}
		if (direction == Direction.South)
		{
			return Direction.West;
		}
		return Direction.North;
	}
}
