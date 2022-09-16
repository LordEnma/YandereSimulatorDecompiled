// Decompiled with JetBrains decompiler
// Type: IScheduledEventTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DEBC9029-E754-4F76-ACC2-E5BB554B97F0
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public interface IScheduledEventTime
{
  ScheduledEventTimeType ScheduleType { get; }

  bool OccurringNow(DateAndTime currentTime);

  bool OccursInTheFuture(DateAndTime currentTime);

  bool OccurredInThePast(DateAndTime currentTime);
}
