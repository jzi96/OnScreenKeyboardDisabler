using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace zieschang.net.Projects.OnScreenKeyboardDisabler.Native.ViewModel
{
    public static class Helper
    {
        public static void Raise(this PropertyChangedEventHandler handler, object sender, Expression<Func<object>> expression)
        {
            if (handler != null)
            {
                if (expression.NodeType != ExpressionType.Lambda)
                    throw new ArgumentException("Value must be a lamda expression", "expression");

                MemberExpression body = expression.Body as MemberExpression;

                if (body == null)
                {
                    body = (MemberExpression)((UnaryExpression)expression.Body).Operand;
                }
                System.Diagnostics.Debug.Assert(body != null, "Could not resolve expression type!");
                string propertyName = body.Member.Name;
                handler(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public abstract class PropertyChangedViewModelBase<TModel> : INotifyPropertyChanged
    {

        public TModel Model { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(Expression<Func<object>> projection)
        {
            this.PropertyChanged.Raise(this, projection);
        }


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        protected PropertyChangedViewModelBase(TModel model)
        {
            this.Model = model;
        }
    }
}
