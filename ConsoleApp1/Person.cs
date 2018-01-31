using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ConsoleApp1
{
    [DataContract]
    public class Person
    {
        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "otherProps")]
        public Hashtable OtherProps { get; set; }

        [DataMember(Name = "age")]
        public int? Age { get; set; }

        public Person()
        {
            OtherProps = new Hashtable();
        }
    }
}
