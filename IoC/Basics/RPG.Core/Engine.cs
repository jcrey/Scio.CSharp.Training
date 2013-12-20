namespace RPG.Core
{
    public class Engine
    {
        public int Points = 0;

        private readonly ICharacter _player;
         
        public Engine(ICharacter player)
        {
            _player = player;
        }

        public void Run(IMap map)
        {
            map.Load();

            do
            {
                map.Execute(_player);
            } while (!map.Completed && _player.Blood > 0);

            Points += _player.Blood * map.Dificulty;
        }
    }
}
