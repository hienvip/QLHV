using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //int a = 6;

            //if(a is int _tmp)
            //{
            //    Console.WriteLine(_tmp + 1);
            //}
            SQLConnector.SetConnectionInfo(@"(LocalDB)\MSSQLLocalDB", @"D:\Visual studio\C#\SofwareProject\PSL\QLHVdb.mdf");
            if (SQLConnector.TestConnection())
            {
                Console.WriteLine("success");
            }
            else
            {
                Console.WriteLine("fail");
            }
        }
    }
}
