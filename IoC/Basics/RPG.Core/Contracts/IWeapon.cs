namespace RPG.Core
{
    public interface IWeapon
    {
        int Damage { get; }
        string Name { get; set; }

        void Use();
    }
}