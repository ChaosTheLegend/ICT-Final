using System;

namespace Calculator
{
    public enum Operation
    {
        Add,
        Subtract,
        Multiply,
        Divide,
        Remainder,
        Factorial
    }

    public enum CalculatorState
    {
        Zero,
        AccumulateDigits,
        Pending,
        Compute,
        Error
    }
    
    public class CalculatorController
    {
        private CalculatorState _state;
        private string _display;
        private Operation _savedOperation;
        private long _firstNumber; 
        private long _secondNumber;
        private const long MaxFactorial = 40;


        public CalculatorController()
        {
            _state = CalculatorState.Zero;
            Clear();
        }

        private void ShowError()
        {
            _state = CalculatorState.Error;
            _display = "Error";
        }
        
        private long Factorial(long number)
        {

            var fact = 1l;
            for (int i = 1; i < number; i++)
            {
                fact *= i;
            }
            
            return fact;
        }

        public void Clear()
        {
            _display = "0";
        }

        public void FullClear()
        {
            _display = "";
        }

        public void AddDigit(string digit)
        {
            _display += digit;
        }

        public void Calculate()
        {
            var result = 0l;
            _state = CalculatorState.Compute;
            switch (_savedOperation)
            {
                case Operation.Add:
                    result = _firstNumber + _secondNumber;
                    break;
                case Operation.Subtract:
                    result = _firstNumber - _secondNumber;
                    break;
                case Operation.Multiply:
                    result = _firstNumber * _secondNumber;
                    break;
                case Operation.Divide:
                    result = _firstNumber / _secondNumber;
                    if (_secondNumber == 0l)
                    {
                        ShowError();
                    }
                    break;
                case Operation.Remainder:
                    result = _firstNumber % _secondNumber;
                    break;
                case Operation.Factorial:
                    if (_firstNumber > MaxFactorial)
                    {
                        ShowError();
                        break;
                    }
                    result = Factorial(_firstNumber);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            
            if (_state != CalculatorState.Error)
            {
                FullClear();
                AddDigit(""+result);
                _firstNumber = result;
            }
        }
        
        public void PressZero()
        {
            switch (_state)
            {
                case CalculatorState.Zero:
                    break;
                case CalculatorState.AccumulateDigits:
                    AddDigit("0");
                    break;
                case CalculatorState.Pending:
                    if(_display != "0") AddDigit("0");
                    break;
                case CalculatorState.Compute:
                    _state = CalculatorState.Zero;
                    Clear();
                    break;
                case CalculatorState.Error:
                    _state = CalculatorState.Zero;
                    Clear();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void PressDigit(string digit)
        {
            switch (_state)
            {
                case CalculatorState.Zero:
                    _state = CalculatorState.AccumulateDigits;
                    FullClear();
                    AddDigit(digit);
                    break;
                case CalculatorState.AccumulateDigits:
                    AddDigit(digit);
                    break;
                case CalculatorState.Pending:
                    if (_display == "0")
                    {
                        FullClear();
                        AddDigit(digit);
                    }
                    break;
                case CalculatorState.Compute:
                    _state = CalculatorState.AccumulateDigits;
                    FullClear();
                    AddDigit(digit);
                    break;
                case CalculatorState.Error:
                    _state = CalculatorState.AccumulateDigits;
                    FullClear();
                    AddDigit(digit);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void PressOperation(Operation operation)
        {
            switch (_state)
            {
                case CalculatorState.Zero:
                    break;
                case CalculatorState.AccumulateDigits:
                    _savedOperation = operation;
                    _state = CalculatorState.Pending;
                    _firstNumber = int.Parse(_display);
                    Clear();
                    if (operation == Operation.Factorial) Calculate();
                    break;
                case CalculatorState.Pending:
                    _savedOperation = operation;
                    _state = CalculatorState.Pending;
                    _firstNumber = int.Parse(_display);
                    Clear();
                    break;
                case CalculatorState.Compute:
                    break;
                case CalculatorState.Error:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void PressCompute()
        {
            switch (_state)
            {
                case CalculatorState.Zero:
                    break;
                case CalculatorState.AccumulateDigits:
                    break;
                case CalculatorState.Pending:
                    _state = CalculatorState.Compute;
                    _secondNumber = int.Parse(_display);
                    Calculate();
                    break;
                case CalculatorState.Compute:
                    break;
                case CalculatorState.Error:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void PressClear()
        {
            _state = CalculatorState.Zero;
            Clear();
        }

        public string GetDisplay()
        {
            return _display;
        }
        
    }
}