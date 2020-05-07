using System;

namespace Dom
{
    public class MenuItem
    {
        public string Name { get; set;  }
        public Action<object> Function { get; set; }
        public bool IsSelected { get; set; }
        public object Parameter { get; set; }
        public int Distance { get; set; }

        public void Invoke(object parameter = null)
        {
            if (!(Parameter is null))
            {
                parameter = Parameter;
            }
            Function.Invoke(parameter);
        }

    }
}