public interface IActionTarget
{
    public void ApplyEffect(EffectBase effect);
    public void ClearEffect(EffectBase effect);
    public void ApplyDamage(float damage);
    public void ApplyHeal(float heal);
    public void ApplyAdditionalHeal(float heal);
    public void ClearAdditionalHeal();
}