using System;
using System.Collections.Generic;
using System.Linq;
using InsurgencyServerManager.Core;

namespace InsurgencyServerManager.ViewModels;

public static class ComboBoxSelectionViewModel
{
    public static List<ComboBoxSelectionViewModel<TEnum>> FromEnum<TEnum>()
        where TEnum : Enum
    {
        var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>().ToArray();

        var list = values.Select(v => new ComboBoxSelectionViewModel<TEnum>
        {
            Value = v,
            DisplayName = v.ToString()
        });

        return new List<ComboBoxSelectionViewModel<TEnum>>(list);
    }
}

public class ComboBoxSelectionViewModel<T> : ViewModelBase
{
    private T? _value;

    private string? _displayName;

    public T? Value
    {
        get => this._value;
        set
        {
            this._value = value;
            this.RaisePropertyChanged();
        }
    }

    public string? DisplayName
    {
        get => this._displayName;
        set
        {
            this._displayName = value;
            this.RaisePropertyChanged();
        }
    }
}
