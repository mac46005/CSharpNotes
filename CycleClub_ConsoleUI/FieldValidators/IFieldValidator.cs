using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CycleClub_ConsoleUI.FieldValidators
{
    public delegate bool FieldValidatorDel(int fieldIndex,string fieldValue,string[] fieldArray,out string fieldInvalidMessage);

    public interface IFieldValidator
    {
        void InitializeValidatorDelegates();
        FieldValidatorDel ValidatorDel { get; }
    }
}
