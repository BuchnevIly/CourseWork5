namespace Model
{
    internal interface IEntity
    {
        void Save();

        void Load();

        void Update();

        void Delete();
    }
}
