using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Ystari.Serialization;
using Ystari.StateManagement;

namespace Ystari
{
    public interface IEditableObject : IBindableObject, INotifyDataErrorInfo
    { }

    public class EditableObject : BindableObject, IEditableObject
    {
        public bool HasErrors
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        protected IObjectState ObjectState { get; private set; }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            throw new NotImplementedException();
        }
    }
}
