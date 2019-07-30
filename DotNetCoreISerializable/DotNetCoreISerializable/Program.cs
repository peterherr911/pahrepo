using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace DotNetISeralizable
{
    public class Person : ISerializable
    {
        public string fname { get; set; }
        public string lname { get; set; }

        public Person() { }

        public Person(string name, string surname)

        {
            this.fname = name;
            this.lname = surname;
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("fname", this.fname);
            info.AddValue("lname", this.lname);

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Person[] Personlist = new Person[]
            {
                new Person("Peter", "Herrera"),
                new Person("Peter1", "Herrera1"),
                new Person("Peter2", "Herrera2")
            };



            //Person p = new Person("Peter", "Herrera");

            //p.fname = "antonio";
            //p.lname = "herrera";


            XmlSerializer oSerialiser = new XmlSerializer(typeof(Person[]));

            using (
            Stream oStream = new FileStream(@"C:\Peter\VSLIB\DotNetCoreISerializable\mydata.xml", FileMode.Create))
            {
                oSerialiser.Serialize(oStream, Personlist);
                oStream.Close();
            }

            Console.ReadLine();

        }

    }


}

