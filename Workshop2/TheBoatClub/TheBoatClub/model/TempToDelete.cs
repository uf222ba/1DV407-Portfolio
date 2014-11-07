List<Car> cars = new List<Car>();

//save the car list to a file
ObjectToSerialize objectToSerialize = new ObjectToSerialize();
objectToSerialize.Cars = cars;

Serializer serializer = new Serializer()
serializer.SerializeObject("outputFile.txt", objectToSerialize);

//the car list has been saved to outputFile.txt
//read the file back from outputFile.txt

objectToSerialize = serializer.DeSerializeObject("outputFile.txt");
cars = objectToSerialize.Cars;


//code.cs

//based on c# tutorial - serialize objects to a file by The Reddest
//goto http://www.switchonthecode.com/tutorials/csharp-tutorial-serialize-objects-to-a-file


//Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using mydata;
using serializers;

//extra bits to make the single file version compile
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace filer3
{
    class Program
    {

        static void setup(List<TCar> list, int n)
        {
            string N = Convert.ToString(n);
            TCar car1 = new TCar();
            TOwner owner1 = new TOwner();
            list.Add(car1);

            car1.owner = owner1;
            car1.make = "Saturn" + N;
            car1.model = "Sky" + N;
            car1.year = 2007 + n;
            owner1.firstName = "The" + N;
            owner1.lastName = "Reddest" + N;

            TCar car2 = new TCar();
            TOwner owner2 = new TOwner();
            list.Add(car2);

            owner2.firstName = "The" + N;
            owner2.lastName = "Tallest" + N;
            car2.owner = owner2;
            car2.make = "Nissan" + N;
            car2.model = "Maxima" + N;
            car2.year = 2006 + n;
        }


        static void Main(string[] args)
        {
            int j = 0;
            List<TCar> cars = new List<TCar>();
            TDocument document = new TDocument();
            TFiler filer = new TFiler();
            TCar xx;
            string fname = "data3.txt";
            document.Cars = cars;

            while (1 == 1)
            {

                Console.Write("enter command >");
                string line = Console.ReadLine();
                if (line == "i")
                {
                    Console.WriteLine("initialised");
                    setup(document.Cars, j++);
                }
                if (line == "l")
                {
                    Console.WriteLine("loading");
                    filer.DeSerializeObject(fname);
                }
                if (line == "s")
                {
                    Console.WriteLine("saving");
                    filer.SerializeObject(fname, document);
                }
                if (line == "q")
                {
                    Console.WriteLine("quit");
                    break;
                }


                Console.WriteLine("Entries =" + Convert.ToString(document.Cars.Count));
                for (int n = 0; n < document.Cars.Count; n++)
                {
                    xx = document.Cars.ElementAt(n);
                    Console.Write(Convert.ToString(n) + "  ");
                    Console.Write(xx.make + ",");
                    Console.Write(xx.model + ",");
                    Console.WriteLine(xx.year);
                }
            }
        }
    }
}
//TCar.cs
//using System;
//using System.IO;
//using System.Runtime.Serialization;

namespace mydata
{
    [Serializable()] 
    public class TCar:ISerializable
    {
        public string make;
        public string model;
        public int year;
        public TOwner owner;

        public TCar()
        {
        }        
        public TCar(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("TCAR deserialising"); 
            this.make = (string)info.GetValue("Make", typeof(string));
            this.model = (string)info.GetValue("Model",typeof(string));
            this.year = (int)info.GetValue("Year", typeof(int));
            this.owner = (TOwner)info.GetValue("Owner", typeof(TOwner));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("TCAR serialising");
            info.AddValue("Make", this.make);
            info.AddValue("Model", this.model);
            info.AddValue("Year", this.year);
            info.AddValue("Owner", this.owner);            
        }       
    }
}
//TDocument.cs
//using System;
//using System.IO;
//using System.Runtime.Serialization;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.Serialization.Formatters.Binary;
//using mydata;


namespace mydata
{

    [Serializable()] 
    // Top level data object all other data types are encapsulated by this class
    public class TDocument : ISerializable
    {
        private List<TCar> cars;

        public  List<TCar> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }

        public TDocument()
        { 
        }

        public TDocument(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("document deserialising");
            this.cars = (List<TCar>)info.GetValue("Cars", typeof(List<TCar>));
        }

        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("document serialising");
            info.AddValue("Cars", this.cars);
        }
    }
}

//TOwner.cs
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;


namespace mydata
{
    [Serializable()]
    public class TOwner : ISerializable
    {
        public string firstName;
        public string lastName;

        public TOwner()
        {
        }
        public TOwner(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("TOWNER deserialising");
            this.firstName = (string)info.GetValue("FirstName", typeof(string));
            this.lastName =  (string)info.GetValue("LastName",  typeof(string));
        }
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {
            Console.WriteLine("TOWNER serialising");
            info.AddValue("FirstName", this.firstName);
            info.AddValue("LastName", this.lastName);
        }
    }
}
//TSerialiser_1.cs
//using System;
//using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
//using mydata;

namespace serializers
{
    public class TFiler
    {
        //Version 1 serialiser, instance specific, so a bit of a pain

        public void SerializeObject(string filename, TDocument document)
        {
            Stream stream = File.Open(filename, FileMode.Create);  
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, document);
            stream.Close();
        }

        public TDocument DeSerializeObject(string filename)        
        {
            TDocument document;
            Stream stream = File.Open(filename, FileMode.Open);
            BinaryFormatter bFormatter = new BinaryFormatter();
            document = (TDocument)bFormatter.Deserialize(stream);
            stream.Close();
            return document;
        }
    }
}