namespace RPG.Core
{
    public interface IMap
    {
        bool Completed { get; set; }
        int Dificulty { get; set; }

        void Load();
        void Execute(ICharacter player);
    }
}