namespace ConTrail.Game.Interfaces
{
    public interface ITarget
    {
        ITarget Owner { get; set; }
        string Name { get; set; }

        void MoveTo();
        bool Use(ITarget source);
        ITarget GetCopy();
    }
}
