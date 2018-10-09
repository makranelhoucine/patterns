namespace Pattern.Specification
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    internal sealed class ConditionSpecification<TEntity> : Specification<TEntity>
    {
        private readonly Func<Expression, Expression, Expression> conditionalFunc;

        private readonly Specification<TEntity> left;

        private readonly Specification<TEntity> right;

        public ConditionSpecification(
            Specification<TEntity> left,
            Specification<TEntity> right,
            Func<Expression, Expression, Expression> conditionalFunc)
        {
            this.left = left;
            this.right = right;
            this.conditionalFunc = conditionalFunc;
        }

        public override Expression<Func<TEntity, bool>> ToExpression()
        {
            var leftExpression = this.left.ToExpression();
            var rightExpression = this.right.ToExpression();

            var expression = new SwapVisitor(leftExpression.Parameters[0], rightExpression.Parameters[0]).Visit(leftExpression.Body);
            var conditionExpression = this.conditionalFunc(expression, rightExpression.Body);
            return Expression.Lambda<Func<TEntity, bool>>(conditionExpression, rightExpression.Parameters);
        }

        private class SwapVisitor : ExpressionVisitor
        {
            private readonly Expression from;

            private readonly Expression to;

            public SwapVisitor(Expression from, Expression to)
            {
                this.from = from;
                this.to = to;
            }

            public override Expression Visit(Expression node)
            {
                return node == from ? to : base.Visit(node);
            }
        }
    }
}