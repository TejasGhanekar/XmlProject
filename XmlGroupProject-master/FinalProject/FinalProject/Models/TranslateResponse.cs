using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Model
{
    public class TranslateResponse
    {
        public Head head { get; set; }
        public List<Def> def { get; set; }
    }

    public class Head
    {
    }

    public class Syn
    {
        public string text { get; set; }
        public string pos { get; set; }
    }

    public class Mean
    {
        public string text { get; set; }
    }

    public class Tr
    {
        public string text { get; set; }
        public string pos { get; set; }
        public List<Syn> syn { get; set; }
        public List<Mean> mean { get; set; }
    }

    public class Def
    {
        public string text { get; set; }
        public string pos { get; set; }
        public string ts { get; set; }
        public List<Tr> tr { get; set; }
    }

}