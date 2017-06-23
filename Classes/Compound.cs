using UIKit;

using System;

namespace Cartography
{
    public interface ICompound
    {
        Context Context { get; }
        IProperty[] Properties { get; }
    }

    internal abstract class BaseCompound : ICompound
    {
        public Context Context { get; }
        public IProperty[] Properties { get; }

        internal BaseCompound(Context context, IProperty[] properties)
        {
            Context = context;
            Properties = properties;
        }
    }

    public interface IRelativeCompoundEquality : ICompound { }

    internal abstract class RelativeCompoundEquality : BaseCompound, IRelativeCompoundEquality
    {
        public RelativeCompoundEquality(Context context, IProperty[] properties) : base(context, properties) { }

        public static NSLayoutConstraint[] operator ==(RelativeCompoundEquality lhs, RelativeCompoundEquality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint[] operator !=(RelativeCompoundEquality lhs, RelativeCompoundEquality rhs)
        {
            throw new NotImplementedException();
        }

        public static NSLayoutConstraint[] operator ==(RelativeCompoundEquality lhs, RelativeCompoundEqualityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients);
        }

        public static NSLayoutConstraint[] operator !=(RelativeCompoundEquality lhs, RelativeCompoundEqualityExpression rhs)
        {
            throw new NotImplementedException();
        }
    }

    public interface IRelativeCompoundInequality : ICompound { }

    internal abstract class RelativeCompoundInequality : BaseCompound, IRelativeCompoundInequality
    {
        public RelativeCompoundInequality(Context context, IProperty[] properties) : base(context, properties) { }

        public static NSLayoutConstraint[] operator <=(RelativeCompoundInequality lhs, RelativeCompoundInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint[] operator >=(RelativeCompoundInequality lhs, RelativeCompoundInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        public static NSLayoutConstraint[] operator <=(RelativeCompoundInequality lhs, RelativeCompoundInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint[] operator >=(RelativeCompoundInequality lhs, RelativeCompoundInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients, relation: NSLayoutRelation.GreaterThanOrEqual);
        }
    }
}