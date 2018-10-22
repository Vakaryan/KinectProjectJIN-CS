using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementalMove
{

    [SerializeField]
    public float linearTolerance;

    public virtual bool verify(Transform lastPose, Transform currentPose) { return true; }

    protected bool reducedX(Transform lastPose, Transform currentPose)
    {
        float difference = lastPose.position.x - currentPose.position.x;
        return Mathf.Abs(difference) < linearTolerance ? false : (difference < 0);
    }

    protected bool reducedY(Transform lastPose, Transform currentPose)
    {
        float difference = lastPose.position.y - currentPose.position.y;
        return Mathf.Abs(difference) < linearTolerance ? false : (difference < 0);
    }

    protected bool reducedZ(Transform lastPose, Transform currentPose)
    {
        float difference = lastPose.position.z - currentPose.position.z;
        return Mathf.Abs(difference) < linearTolerance ? false : (difference < 0);
    }

}

public class MoveLeft : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedX(lastPose, currentPose);
    }
}

public class MoveRight : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedX(lastPose, currentPose);
    }
}

public class MoveUp : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedY(lastPose, currentPose);
    }
}

public class MoveDown : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedY(lastPose, currentPose);
    }
}

public class MoveForward : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedZ(lastPose, currentPose);
    }
}

public class MoveBackward : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedZ(lastPose, currentPose);
    }
}

public class MoveUpLeft : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedY(lastPose, currentPose) && reducedX(lastPose, currentPose);
    }
}

public class MoveUpRight : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedY(lastPose, currentPose) && !reducedX(lastPose, currentPose);
    }
}

public class MoveDownLeft : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedY(lastPose, currentPose) && reducedX(lastPose, currentPose);
    }
}

public class MoveDownRight : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedY(lastPose, currentPose) && !reducedX(lastPose, currentPose);
    }
}

public class MoveForwardLeft : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedZ(lastPose, currentPose) && reducedX(lastPose, currentPose);
    }
}

public class MoveForwardRight : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedZ(lastPose, currentPose) && !reducedX(lastPose, currentPose);
    }
}

public class MoveForwardUp : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedZ(lastPose, currentPose) && !reducedY(lastPose, currentPose);
    }
}

public class MoveForwardDown : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedZ(lastPose, currentPose) && reducedY(lastPose, currentPose);
    }
}

public class MoveForwardUpLeft : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedZ(lastPose, currentPose) && !reducedY(lastPose, currentPose) && reducedX(lastPose, currentPose);
    }
}

public class MoveForwardUpRight : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedZ(lastPose, currentPose) && !reducedY(lastPose, currentPose) && !reducedX(lastPose, currentPose);
    }
}

public class MoveForwardDownLeft : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedZ(lastPose, currentPose) && reducedY(lastPose, currentPose) && reducedX(lastPose, currentPose);
    }
}

public class MoveForwardDownRight : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedZ(lastPose, currentPose) && reducedY(lastPose, currentPose) && !reducedX(lastPose, currentPose);
    }
}

public class MoveBackwardLeft : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedZ(lastPose, currentPose) && reducedX(lastPose, currentPose);
    }
}

public class MoveBackwardRight : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedZ(lastPose, currentPose) && !reducedX(lastPose, currentPose);
    }
}

public class MoveBackwardUp : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedZ(lastPose, currentPose) && !reducedY(lastPose, currentPose);
    }
}

public class MoveBackwardDown : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedZ(lastPose, currentPose) && reducedY(lastPose, currentPose);
    }
}

public class MoveBackwardUpLeft : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return !reducedZ(lastPose, currentPose) && !reducedY(lastPose, currentPose) && reducedX(lastPose, currentPose);
    }
}

public class MoveBackwardUpRight : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedZ(lastPose, currentPose) && !reducedY(lastPose, currentPose) && !reducedX(lastPose, currentPose);
    }
}

public class MoveBackwardDownLeft : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedZ(lastPose, currentPose) && !reducedY(lastPose, currentPose) && reducedX(lastPose, currentPose);
    }
}

public class MoveBackwardDownRight : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return reducedZ(lastPose, currentPose) && reducedY(lastPose, currentPose) && !reducedX(lastPose, currentPose);
    }
}

public class StayStill : ElementalMove
{
    public override bool verify(Transform lastPose, Transform currentPose)
    {
        return false; // TODO
    }
}