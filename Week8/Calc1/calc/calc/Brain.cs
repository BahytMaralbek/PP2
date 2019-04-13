using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    enum CalcState
    {
        Zero,
        AccumulateDigits,
        AccumulateDigitsWithDecimal,
        Compute,
        Result,
        Error,
        Off,
    }

    public delegate void ShowResultDelegate(string msg);
    class Brain
    {
        ShowResultDelegate resultDelegate;
        CalcState currentState = CalcState.Zero;
        string tempNumber;
        string resultNumber;
        string operation;
        public Brain(ShowResultDelegate resultDelegate)
        {
            this.resultDelegate = resultDelegate;
            tempNumber = "";
            operation = "";
            resultDelegate("0");
        }
        public void Process(string msg)
        {
            switch (currentState)
            {
                case CalcState.Zero:
                    Zero(false, msg);
                    break;
                case CalcState.AccumulateDigits:
                    AccumulateDigits(false, msg);
                    break;
                case CalcState.AccumulateDigitsWithDecimal:
                    AccumulateDigitsWithDecimal(false, msg);
                    break;
                case CalcState.Compute:
                    Compute(false, msg);
                    break;
                case CalcState.Result:
                    Result(false, msg);
                    break;
                case CalcState.Error:
                    Error(false, msg);
                    break;
                case CalcState.Off:
                    Off(false, msg);
                    break;
                default:
                    break;
            }
        }

        void Zero(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Zero;
                resultDelegate("0");
                msg = "";
                tempNumber = "";
                resultNumber = "";
                operation = "";
            }
            else
            {
                if (Rules.IsNonZeroDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsSeparator(msg))
                {
                    AccumulateDigitsWithDecimal(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                else if (Rules.IsOperator(msg) || Rules.IsRootSign(msg))
                {
                    tempNumber = "0";
                    Compute(true, msg);
                }
            }
        }
        void AccumulateDigits(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.AccumulateDigits;
                tempNumber += msg;
                resultDelegate(tempNumber);
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsOperator(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg) || Rules.IsXPowerY(msg))
                {
                    Compute(true, msg);
                }
                else if (Rules.IsEqualSign(msg) && operation.Length > 0)
                {
                    Result(true, msg);
                }
                else if (Rules.IsSeparator(msg))
                {
                    AccumulateDigitsWithDecimal(true, msg);
                }
                else if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                
            }
        }
        void AccumulateDigitsWithDecimal(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.AccumulateDigitsWithDecimal;
                tempNumber += msg;
                resultDelegate(tempNumber);
            }
            else
            {
                if (Rules.IsOperator(msg) || Rules.IsXPowerY(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg))
                {
                    Compute(true, msg);
                }
                else if (Rules.IsDigit(msg))
                {
                    AccumulateDigitsWithDecimal(true, msg);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Result(true, msg);
                }
                else if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                
            }
        }
        void Compute(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Compute;
                if (Rules.IsRootSign(msg)  || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg))
                {
                    operation = msg;
                    if (operation.Length > 0)
                    {
                        Calculate();
                        resultDelegate(resultNumber);
                    }
                    tempNumber = resultNumber;
                    operation = "";
                }
                else
                {
                    if (operation.Length > 0)
                    {
                        Calculate();
                        
                        resultDelegate(resultNumber);
                    }
                    else
                    {
                        resultNumber = tempNumber;
                    }
                    operation = msg;
                    tempNumber = "";
                } 
            }
            else
            {
                if (Rules.IsDigit(msg))
                {
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                else if (Rules.IsOperator(msg) || Rules.IsXPowerY(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg))
                {
                    Compute(true, msg);
                }
               
            }
        }
        void Result(bool isInput, string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Result;
                Calculate();
                
                resultDelegate(resultNumber);
            }
            else
            {
                if (Rules.IsZero(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsNonZeroDigit(msg))
                {
                    tempNumber = "";
                    AccumulateDigits(true, msg);
                }
                else if (Rules.IsOperator(msg) || Rules.IsXPowerY(msg) || Rules.IsSquareSign(msg) || Rules.IsOneOverXSign(msg) || Rules.IsPlusMinus(msg) || Rules.IsDEL(msg))
                {
                    operation = "";
                    tempNumber = resultNumber;
                    Compute(true, msg);
                }
                else if (Rules.IsSeparator(msg))
                {
                    operation = "";
                    tempNumber = resultNumber;
                    AccumulateDigitsWithDecimal(true, msg);
                }
                else if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
                else if (Rules.IsOff(msg))
                {
                    Off(true, msg);
                }
                else if (Rules.IsEqualSign(msg))
                {
                    Result(true,msg);
                }
                
            }
        }
        void Off(bool isInput,string msg)
        {
            if (isInput)
            {
                msg = "";
                tempNumber = "";
                resultNumber = "";
                operation = "";
                currentState = CalcState.Off;
                resultDelegate("");
            }
            else
            {
                if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
            }
        }
        void Error(bool isInput,string msg)
        {
            if (isInput)
            {
                currentState = CalcState.Error;
                resultDelegate("ERROR");
                msg = "";
                resultNumber = "";
                tempNumber = "";
            }
            else
            {
                if (Rules.IsClearSign(msg))
                {
                    Zero(true, msg);
                }
            }
        }
        void Calculate()
        {
            if (operation == "+")
            {
                resultNumber = (float.Parse(resultNumber) + double.Parse(tempNumber)).ToString();
            }
            else if (operation == "-")
            {
                resultNumber = (float.Parse(resultNumber) - double.Parse(tempNumber)).ToString();
            }
            else if (operation == "*")
            {
                resultNumber = (float.Parse(resultNumber) * double.Parse(tempNumber)).ToString();
            }
            else if(operation == "x^y")
            {
                double ans = 1;
                double x = double.Parse(resultNumber);
                double y = double.Parse(tempNumber);
                for(int i = 1; i <= y; i++)
                {
                    ans *= x;
                }
                resultNumber = ans.ToString();
            }
            else if (operation == "/")
            {
                if (Rules.IsZero(tempNumber))
                {
                    Error(true, "ERROR");
                }
                else
                {
                    resultNumber = (float.Parse(resultNumber) / double.Parse(tempNumber)).ToString();
                }
            }
            else if (operation == "%")
            {
                resultNumber = ((float.Parse(resultNumber) * double.Parse(tempNumber)) / 100).ToString();
            }
            else if (operation == "V")
            {
                resultNumber = ((Math.Sqrt(float.Parse(tempNumber)))).ToString();
            }
            else if(operation == "x^2")
            {
                resultNumber = (float.Parse(tempNumber) * double.Parse(tempNumber)).ToString();
            }
            else if(operation == "1/x")
            {
                resultNumber = (float.Parse("1") / double.Parse(tempNumber)).ToString();
            }
            else if(operation == "(+-)")
            {
                resultNumber = (-float.Parse(tempNumber)).ToString();
            }
            else if(operation == "DEL")
            {
                if (tempNumber.Length == 1)
                {
                    Zero(true, "");
                }
                else
                {
                    resultNumber = "";
                    for(int i = 0; i < tempNumber.Length - 1; i++)
                    {
                        if(i != tempNumber.Length)
                        {
                            resultNumber += tempNumber[i];
                        }
                    }
                }
            }
        }
    }
}
