namespace Pattern.NullObject.Models
{
    public abstract partial class Animal
    {
        public virtual int Id { get; set; }

        public virtual string Food { get; set; }

        public virtual int Legs { get; set; }

        public virtual string Name { get; set; }

        public string Describe()
        {
            return string.Format("{0} has {1} legs and eats {2}", this.Name, this.Legs, this.Food);
        }
    }
}