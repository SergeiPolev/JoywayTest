using DG.Tweening;

public static class TweenMethods
{
    public static void KillTo0(this Tween tween)
    {
        if (tween != null)
        {
            tween.Goto(0, true);
            tween.Kill();
        }
    }
}