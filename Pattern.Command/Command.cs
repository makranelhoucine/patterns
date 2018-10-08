namespace Pattern.Command
{
    public delegate void Next<in TOut>(TOut output);

    public abstract class Command<TIn, TOut>
    {
        public void Execute(TIn input, Next<TOut> next)
        {
            if (this.OnCanExecute(input))
            {
                this.OnExecute(input, next);
            }
        }

        protected virtual bool OnCanExecute(TIn input)
        {
            if (input == null && typeof(TIn).IsValueType)
            {
                return false;
            }

            return true;
        }

        protected abstract void OnExecute(TIn input, Next<TOut> next);
    }

    public abstract class Command<TOut>
    {
        public void Execute(Next<TOut> next)
        {
            this.OnExecute(next);
        }

        protected abstract void OnExecute(Next<TOut> next);
    }
}