using System;

public class Timer
{
    private readonly string _saveKey;
    private readonly float _eventCooldownInSeconds;
    
    private DateTime _nextEventTime;

    public bool IsEventCanBe => DateTime.Now > _nextEventTime;
    public int SpanHours => (_nextEventTime - DateTime.Now).Hours;
    public int SpanMinutes => (_nextEventTime - DateTime.Now).Minutes;
    public int SpanSeconds => (_nextEventTime - DateTime.Now).Seconds;

    public Timer(string saveKey, float eventCooldown)
    {
        _saveKey = saveKey;
        _eventCooldownInSeconds = eventCooldown;
        _nextEventTime = SaveSystem.Get<DateTime>(_saveKey);
        if (_nextEventTime == default) 
            _nextEventTime = DateTime.Now.AddSeconds(-1);
    }

    public void Reset()
    {
        _nextEventTime = DateTime.Now.AddSeconds(_eventCooldownInSeconds);
        SaveSystem.Set(_saveKey, _nextEventTime);
    }
}