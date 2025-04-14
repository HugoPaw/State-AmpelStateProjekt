using System;

// 1. State-Interface
public interface IAmpelState
{
    void Handle(AmpelContext context);
}

// 2. Konkrete States
public class GruenState : IAmpelState
{
    public void Handle(AmpelContext context)
    {
        Console.WriteLine("Grün: Autos fahren.");
        context.SetState(new GelbState());
    }
}

public class GelbState : IAmpelState
{
    public void Handle(AmpelContext context)
    {
        Console.WriteLine("Gelb: Vorbereitung auf Stopp.");
        context.SetState(new RotState());
    }
}

public class RotState : IAmpelState
{
    public void Handle(AmpelContext context)
    {
        Console.WriteLine("Rot: Autos halten.");
        context.SetState(new GruenState());
    }
}

// 3. Kontext-Klasse
public class AmpelContext
{
    private IAmpelState _state;

    public AmpelContext(IAmpelState initialState)
    {
        _state = initialState;
    }

    public void SetState(IAmpelState state)
    {
        _state = state;
    }

    public void Request()
    {
        _state.Handle(this);
    }
}
