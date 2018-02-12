// https://dotblogs.com.tw/larrynung/2011/03/19/21957
// String to Structure

// Define structure, 
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
public struct MyStruct
{
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
    public string fname;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
    public string lname;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
    public string phone;
}

// Convert string to pointer, then convert pointer to structure and release the pointer

private static T ConvertToStruct<T>(string val)
{
    IntPtr valPoint = Marshal.StringToBSTR(val);
    T ret = (T)Marshal.PtrToStructure(valPoint, typeof(T));
    Marshal.FreeBSTR(valPoint);
    return ret;
}

// Full example
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
 
namespace ConsoleApplication20
{
    class Program
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct MyStruct
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string fname;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
            public string lname;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 7)]
            public string phone;
        }
 
        private static T ConvertToStruct<T>(string val)
        {
            IntPtr valPoint = Marshal.StringToBSTR(val);
            T ret = (T)Marshal.PtrToStructure(valPoint, typeof(T));
            Marshal.FreeBSTR(valPoint);
            return ret;
        }
 
        public static void Main()
        {
            MyStruct ms = ConvertToStruct<MyStruct>("abcdefgh2223333");
            Console.WriteLine("fname is: {0}", ms.fname);
            Console.WriteLine("lname is: {0}", ms.lname);
            Console.WriteLine("phone is: {0}", ms.phone);          
        }
    }
}
