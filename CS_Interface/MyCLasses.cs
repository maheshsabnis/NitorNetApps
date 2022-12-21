using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Interface
{
    public interface IMath
    {
        int Add(int x, int y);
        int Sub(int x, int y);
    }

    public interface IMathNew
    {
        int Add(int x, int y);
        int Sub(int x, int y);
    }

    /// <summary>
    /// Class implement interface implicitly
    /// The Methods are declared in interface and defined by class
    /// and the class owns these mehods
    /// </summary>
    public class MathOp : IMath
    { 
        public int Add(int x, int y) 
        {
            return x + y;
        }
        public int Sub(int x, int y) 
        {
            return x - y;
        }
    }
    /// <summary>
    /// Explicit IMplementation
    /// Methods will be belong to interface
    /// </summary>
    public class MathOp2 : IMath , IMathNew
    {
        int IMath.Add(int x,int y)
        {
            return x + y;  
        }

        int IMathNew.Add(int x, int y)
        {
            return (x * x) + (y * y);
        }

        int IMath.Sub(int x, int y)
        {
            return x - y;
        }

        int IMathNew.Sub(int x, int y)
        {
            return (x * x) - (y * y);
        }
    }
}
