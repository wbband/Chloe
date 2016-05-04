﻿using Chloe.Utility;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Chloe.DbExpressions
{
    public abstract class DbExpression
    {
        DbExpressionType _nodeType;
        Type _type;

        protected DbExpression(DbExpressionType nodeType)
            : this(nodeType, UtilConstants.TypeOfVoid)
        {
        }
        protected DbExpression(DbExpressionType nodeType, Type type)
        {
            this._nodeType = nodeType;
            this._type = type;
        }

        public virtual DbExpressionType NodeType
        {
            get { return this._nodeType; }
        }
        public virtual Type Type
        {
            get { return this._type; }
        }

        public abstract T Accept<T>(DbExpressionVisitor<T> visitor);


        public static DbAddExpression Add(Type returnType, DbExpression left, DbExpression right, MethodInfo method)
        {
            return new DbAddExpression(returnType, left, right, method);
        }
        public static DbAndExpression And(DbExpression left, DbExpression right)
        {
            return new DbAndExpression(left, right);
        }
        public static DbOrExpression Or(DbExpression left, DbExpression right)
        {
            return new DbOrExpression(left, right);
        }
        public static DbNotEqualExpression NotEqual(DbExpression left, DbExpression right)
        {
            return new DbNotEqualExpression(left, right);
        }
        public static DbNotExpression Not(DbExpression exp)
        {
            return new DbNotExpression(exp);
        }
        public static DbConvertExpression Convert(Type type, DbExpression operand)
        {
            return new DbConvertExpression(type, operand);
        }

        public static DbCaseWhenExpression CaseWhen(IReadOnlyList<DbCaseWhenExpression.WhenThenExpressionPair> whenThenExps, DbExpression elseExp, Type type)
        {
            return new DbCaseWhenExpression(type, whenThenExps, elseExp);
        }

        public static DbConstantExpression Constant(object value)
        {
            return new DbConstantExpression(value);
        }

        public static DbConstantExpression Constant(object value, Type type)
        {
            return new DbConstantExpression(value, type);
        }

        public static DbDivideExpression Divide(Type returnType, DbExpression left, DbExpression right)
        {
            return new DbDivideExpression(returnType, left, right);
        }

        public static DbEqualExpression Equal(DbExpression left, DbExpression right)
        {
            return new DbEqualExpression(left, right);
        }

        public static DbGreaterThanExpression GreaterThan(DbExpression left, DbExpression right)
        {
            return new DbGreaterThanExpression(left, right);
        }
        public static DbGreaterThanOrEqualExpression GreaterThanOrEqual(DbExpression left, DbExpression right)
        {
            return new DbGreaterThanOrEqualExpression(left, right);
        }

        public static DbLessThanExpression LessThan(DbExpression left, DbExpression right)
        {
            return new DbLessThanExpression(left, right);
        }
        public static DbLessThanOrEqualExpression LessThanOrEqual(DbExpression left, DbExpression right)
        {
            return new DbLessThanOrEqualExpression(left, right);
        }

        public static DbMemberExpression MemberAccess(MemberInfo member, DbExpression exp)
        {
            return new DbMemberExpression(member, exp);
        }

        public static DbMethodCallExpression MethodCall(DbExpression @object, MethodInfo method, IReadOnlyList<DbExpression> arguments)
        {
            return new DbMethodCallExpression(@object, method, arguments);
        }

        public static DbMultiplyExpression Multiply(DbExpression left, DbExpression right, Type returnType)
        {
            return new DbMultiplyExpression(returnType, left, right);
        }

        public static DbParameterExpression Parameter(object value)
        {
            return new DbParameterExpression(value);
        }

        public static DbParameterExpression Parameter(object value, Type type)
        {
            return new DbParameterExpression(value, type);
        }

        public static DbSubtractExpression Subtract(DbExpression left, DbExpression right, Type returnType)
        {
            return new DbSubtractExpression(returnType, left, right);
        }

    }
}
