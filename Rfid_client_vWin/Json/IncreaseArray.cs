using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Json
{
    class IncreaseArray
    {
        public static Array Redim(Array origArray, int desiredSize)
        {
            //determine the type of element
            Type t = origArray.GetType().GetElementType();
            //create a number of elements with a new array of expectations
            //new array type must match the type of the original array
            Array newArray = Array.CreateInstance(t, desiredSize);
            //copy the original elements of the array to the new array
            Array.Copy(origArray, 0, newArray, 0, Math.Min(origArray.Length, desiredSize));
            //return new array
            return newArray;
        }
    }
}
