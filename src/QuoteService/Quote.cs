using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace QuoteService
{
    public class Quote
    {
        public Quote(){
            // var envVersion = new Version(Environment.GetEnvironmentVariable("VERSION"));
            // if (envVersion != null){
            //     Version=new Version(envVersion.ToString());
            // } else{
            //     Version=new Version("0.0.0");
            // }
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public string Attribution { get; set; }
        //[NotMapped]
        //public Version Version { get; private set;}
    }
}
