namespace RPG.Core
{
    public interface ICharacter
    {
        IWeapon Weapon { get; set; }
        string Name { get; set; }
        int Blood { get; set; }

        void Move(Direction direction);
        void Atack(ICharacter target);
    }
}