// Decompiled with JetBrains decompiler
// Type: IScheduledEventTime
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 8D5F971C-3CB1-4F04-A688-57005AB18418
// Assembly location: C:\YandereSimulator\YandereSimulator\YandereSimulator_Data\Managed\Assembly-CSharp.dll

public interface IScheduledEventTime
{
  ScheduledEventTimeType ScheduleType { get; }

  bool OccurringNow(DateAndTime currentTime);

  bool OccursInTheFuture(DateAndTime currentTime);

  bool OccurredInThePast(DateAndTime currentTime);
}
