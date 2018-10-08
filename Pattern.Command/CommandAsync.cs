namespace Pattern.Command
{
    using System.Threading.Tasks;

    public abstract class CommandAsync<TIn, TOut>
    {
        public Task ExecuteAsync(TIn input, Next<TOut> next)
        {
            if (this.OnCanExecute(input))
            {
                return this.OnExecuteAsync(input, next);
            }

            return Task.CompletedTask;
        }

        protected virtual bool OnCanExecute(TIn input)
        {
            if (input == null && typeof(TIn).IsValueType)
            {
                return false;
            }

            return true;
        }

        protected abstract Task OnExecuteAsync(TIn input, Next<TOut> next);
    }
}