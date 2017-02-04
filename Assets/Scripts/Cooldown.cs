class Cooldown
{
    private float _max;
    private float _seconds;

    public Cooldown(float seconds, bool initialDelay = false)
    {
        _max = seconds;
        _seconds = initialDelay ? seconds : 0;
    }

    public bool Check() {
        return _seconds < 0;
    }

    public void Trigger()
    {
        _seconds = _max;
    }

    public void Update(float deltaTime)
    {
        _seconds -= deltaTime;
    }

    public bool UpdateAndCheck(float deltaTime)
    {
        _seconds -= deltaTime;

        if (_seconds > 0) return false;

        _seconds = _max;
        return true;
    }
}
