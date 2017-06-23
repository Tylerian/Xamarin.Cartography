using System;

using UIKit;

namespace Cartography
{
    public class Edges : ICompound, IRelativeCompoundEquality, IRelativeCompoundInequality
    {
        public Context Context { get; }
        public IProperty[] Properties { get; }

        public Edges(Context context, IProperty[] properties)
        {
            Context = context;
            Properties = properties;
        }

        public EdgesExpression Inset(Edges edges, nfloat all)
        {
            return Inset(edges, all, all, all, all);
        }

        public EdgesExpression Inset(Edges edges, UIKit.UIEdgeInsets insets)
        {
            return Inset(edges, insets.Top, insets.Left, insets.Bottom, insets.Right);
        }

        public EdgesExpression Inset(Edges edges, nfloat horizontal, nfloat vertical)
        {
            return Inset(edges, horizontal, vertical, horizontal, vertical);
        }

        public EdgesExpression Inset(Edges edges, nfloat top, nfloat leading, nfloat bottom, nfloat trailing)
        {
            return new EdgesExpression(edges, new[] {
                new Coefficients(1, top),
                new Coefficients(1, leading),
                new Coefficients(1, -bottom),
                new Coefficients(1, -trailing)
            });
        }

        #region IRelativeCompoundEquality Operators
        public static NSLayoutConstraint[] operator ==(Edges lhs, IRelativeCompoundEquality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs);
        }

        public static NSLayoutConstraint[] operator !=(Edges lhs, IRelativeCompoundEquality rhs)
        {
            throw new NotImplementedException();
        }

        /*
        public static NSLayoutConstraint[] operator ==(IRelativeCompoundEquality lhs, Edges rhs)
        {
            return rhs == lhs;
        }

        public static NSLayoutConstraint[] operator !=(IRelativeCompoundEquality lhs, Edges rhs)
        {
            return rhs != lhs;
        }
        */

        public static NSLayoutConstraint[] operator ==(Edges lhs, RelativeCompoundEqualityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients);
        }

        public static NSLayoutConstraint[] operator !=(Edges lhs, RelativeCompoundEqualityExpression rhs)
        {
            throw new NotImplementedException();
        }

        /*
        public static NSLayoutConstraint[] operator ==(RelativeCompoundEqualityExpression lhs, Point rhs)
        {
            return rhs == lhs;
        }

        public static NSLayoutConstraint[] operator !=(RelativeCompoundEqualityExpression lhs, Point rhs)
        {
            return rhs != lhs;
        }
        */
        #endregion

        #region IRelativeCompoundInequality Operators
        public static NSLayoutConstraint[] operator <=(Edges lhs, IRelativeCompoundInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint[] operator >=(Edges lhs, IRelativeCompoundInequality rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        /*
        public static NSLayoutConstraint[] operator <=(IRelativeCompoundInequality lhs, Edges rhs)
        {
            return rhs <= lhs;
        }

        public static NSLayoutConstraint[] operator >=(IRelativeCompoundInequality lhs, Edges rhs)
        {
            return rhs >= lhs;
        }
        */

        public static NSLayoutConstraint[] operator <=(Edges lhs, RelativeCompoundInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients, relation: NSLayoutRelation.LessThanOrEqual);
        }

        public static NSLayoutConstraint[] operator >=(Edges lhs, RelativeCompoundInequalityExpression rhs)
        {
            return lhs.Context.AddConstraint(lhs, to: rhs.Value, coefficients: rhs.Coefficients, relation: NSLayoutRelation.GreaterThanOrEqual);
        }

        /*
        public static NSLayoutConstraint[] operator <=(RelativeCompoundInequalityExpression lhs, Point rhs)
        {
            return rhs <= lhs;
        }

        public static NSLayoutConstraint[] operator >=(RelativeCompoundInequalityExpression lhs, Point rhs)
        {
            return rhs >= lhs;
        }
        */
        #endregion
    }
}
